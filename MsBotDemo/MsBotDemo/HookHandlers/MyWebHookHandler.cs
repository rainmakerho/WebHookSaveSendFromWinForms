using Microsoft.AspNet.WebHooks;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MsBotDemo.HookHandlers
{
    public class MyWebHookHandler : WebHookHandler
    {

        /// <summary>
        /// 接收 webhook 進來的資料，
        /// 當同一個 webapi 註冊接收一堆的 webhook，
        /// 可以透過 context?.Id ，或是 context.Actions.FirstOrDefault() 
        /// 例如 context?.Id 是否為 lol, 或是 context.Actions.FirstOrDefault() 開頭是否為 lol_
        /// </summary>
        public override Task ExecuteAsync(string receiver, WebHookHandlerContext context)
        {
            //if (context?.Id != "lol")
            //    return Task.FromResult(1);
            var id = context?.Id;
            Debug.WriteLine($"id:{id}");
            string action = context.Actions.FirstOrDefault();
            CustomNotifications data = context.GetDataOrDefault<CustomNotifications>();

            foreach (IDictionary<string, object> notification in data.Notifications)
            {
                var dataAction = notification["Action"];
                JObject message = (JObject)notification["message"];
                Debug.WriteLine(message);
            }
            return Task.FromResult(1);
        }
    }
}