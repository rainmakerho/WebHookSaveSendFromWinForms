using Microsoft.AspNet.WebHooks;
 
using Microsoft.AspNet.WebHooks.Diagnostics;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebHookRegister
{
    public partial class Form1 : Form
    {

        public IWebHookManager Manager { get; set; }
        public IWebHookStore Store { get; set; }
        public ILogger Logger { get; set; }


        internal const string SignatureHeaderKey = "sha256";
        internal const string SignatureHeaderValueTemplate = SignatureHeaderKey + "={0}";
        internal const string SignatureHeaderName = "ms-signature";

        private const string BodyIdKey = "Id";
        private const string BodyAttemptKey = "Attempt";
        private const string BodyPropertiesKey = "Properties";
        private const string BodyNotificationsKey = "Notifications";

        public Form1()
        {
            InitializeComponent();
        }

        private async void btnRegisterHook_Click(object sender, EventArgs e)
        {
            // Set up default WebHook logger
            
            var webhook = new WebHook
            {
                Secret=txtSecret.Text,
                WebHookUri=new Uri(txtWebHookUrl.Text),
                
            };
            // 這個值在 Send 通知時，會用 ActionId 去 Filter, 
            // * 或是 ActionId == txtActionFilter.Text
            webhook.Filters.Add(txtActionFilter.Text);

            var result = await Store.InsertWebHookAsync(txtUserId.Text, webhook);
            MessageBox.Show(result.ToString());
        }

 

        private void Form1_Load(object sender, EventArgs e)
        {
            //設定 Logger
            Logger = new TraceLogger();
            //設定 SQL 來存 WebHook 的資料
            Store = SqlWebHookStore.CreateStore(Logger);
            //Sender 使用 DataflowWebHookSender 
            var webhookSender = new DataflowWebHookSender(Logger);

            Manager = new WebHookManager(Store, webhookSender, Logger);
        }

        private async void btnSendNotifyAll_Click(object sender, EventArgs e)
        {
            var notifyBody = JObject.Parse(txtNotifyBody.Text);
            //透過 WebHookManager 來傳送通知
            var result = await Manager.NotifyAllAsync(txtActionId.Text, notifyBody);
            
            // Manager.NotifyAllAsync 就相當於下面的 method 
            //var notifications = new NotificationDictionary[] { new NotificationDictionary(txtActionId.Text, notifyBody) };
            //string[] actions = notifications.Select(n => n.Action).ToArray();
            //Func<WebHook, string, bool> predicate = null;
            //var webHooks = await Store.QueryWebHooksAcrossAllUsersAsync(actions, predicate);
            //var wkItems = GetWorkItems(webHooks, notifications);
            //var webhookSender = new DataflowWebHookSender(Logger);


            //await webhookSender.SendWebHookWorkItemsAsync(wkItems);
            // webhookSender.SendWebHookWorkItemsAsync 就相當於 foreach ... LaunchWebHook
            //foreach (var item in wkItems)
            //{
            //    await LaunchWebHook(item);
            //}
        }


        private async Task LaunchWebHook(WebHookWorkItem workItem)
        {
            try
            {
                HttpClient _httpClient = new HttpClient();
                // Setting up and send WebHook request 
                HttpRequestMessage request = CreateWebHookRequest(workItem);
                HttpResponseMessage response = await _httpClient.SendAsync(request);
  
            }
            catch (Exception ex)
            {
                
                Logger.Error(ex.ToString());
            }

             
        }

        protected virtual HttpRequestMessage CreateWebHookRequest(WebHookWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            WebHook hook = workItem.WebHook;

            // Create WebHook request
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, hook.WebHookUri);

            // Fill in request body based on WebHook and work item data
            JObject body = CreateWebHookRequestBody(workItem);
            SignWebHookRequest(workItem, request, body);

            // Add extra request or entity headers
            foreach (var kvp in hook.Headers)
            {
                if (!request.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value))
                {
                    if (!request.Content.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value))
                    {
                        //string msg = string.Format(CultureInfo.CurrentCulture, CustomResources.Manager_InvalidHeader, kvp.Key, hook.Id);
                        //_logger.Error(msg);
                    }
                }
            }

            return request;
        }

        protected JObject CreateWebHookRequestBody(WebHookWorkItem workItem)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }

            Dictionary<string, object> body = new Dictionary<string, object>();

            // Set properties from work item
            body[BodyIdKey] = workItem.Id;
            body[BodyAttemptKey] = workItem.Offset + 1;

            // Set properties from WebHook
            IDictionary<string, object> properties = workItem.WebHook.Properties;
            if (properties != null)
            {
                body[BodyPropertiesKey] = new Dictionary<string, object>(properties);
            }

            // Set notifications
            body[BodyNotificationsKey] = workItem.Notifications;

            return JObject.FromObject(body);
        }

        protected virtual void SignWebHookRequest(WebHookWorkItem workItem, HttpRequestMessage request, JObject body)
        {
            if (workItem == null)
            {
                throw new ArgumentNullException(nameof(workItem));
            }
            if (workItem.WebHook == null)
            {
                string msg =  "WebHook";
                throw new ArgumentException(msg, "workItem");
            }
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            if (body == null)
            {
                throw new ArgumentNullException(nameof(body));
            }

            byte[] secret = Encoding.UTF8.GetBytes(workItem.WebHook.Secret);
            using (var hasher = new HMACSHA256(secret))
            {
                string serializedBody = body.ToString();
                request.Content = new StringContent(serializedBody, Encoding.UTF8, "application/json");

                byte[] data = Encoding.UTF8.GetBytes(serializedBody);
                byte[] sha256 = hasher.ComputeHash(data);
                string headerValue = string.Format(CultureInfo.InvariantCulture, SignatureHeaderValueTemplate, EncodingUtilities.ToHex(sha256));
                request.Headers.Add(SignatureHeaderName, headerValue);
            }
        }

        internal static IEnumerable<WebHookWorkItem> GetWorkItems(ICollection<WebHook> webHooks, ICollection<NotificationDictionary> notifications)
        {
            List<WebHookWorkItem> workItems = new List<WebHookWorkItem>();
            foreach (WebHook webHook in webHooks)
            {
                ICollection<NotificationDictionary> webHookNotifications;

                // Pick the notifications that apply for this particular WebHook. If we only got one notification
                // then we know that it applies to all WebHooks. Otherwise each notification may apply only to a subset.
                if (notifications.Count == 1)
                {
                    webHookNotifications = notifications;
                }
                else
                {
                    webHookNotifications = notifications.Where(n => webHook.MatchesAction(n.Action)).ToArray();
                    if (webHookNotifications.Count == 0)
                    {
                        continue;
                    }
                }

                WebHookWorkItem workItem = new WebHookWorkItem(webHook, webHookNotifications);
                workItems.Add(workItem);
            }
            return workItems;
        }
    }
}
