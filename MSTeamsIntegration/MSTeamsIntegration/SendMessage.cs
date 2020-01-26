using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using PX.Data;
using PX.Objects;

namespace MSTeamsIntegration
{
    public class SendMessage
    {
        public virtual void SendTeamsMessage()
        {
            //string IncomingWebhookUrl = "https://outlook.office.com/webhook/d67b5182-87ca-44cc-9130-0233ba390908@e0dbb9de-82aa-43fc-8298-acf8a9a42983/IncomingWebhook/47bfa130a74f4405a7cd227eacdd75df/f7e7389a-8900-4ab0-98f4-af94dbcab14d";

            // TODO : Get Teams Info name from Business Event
            // TODO : Get Teams Contents from Business Event

            string[] incomingInfo = GetTeamsIncomingConfig("Hackathon 2020");

            string IncomingWebhookUrl = incomingInfo[1];

            string content = "Hello World, From Acumatica!";

            HttpClient httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders
              .Accept
              .Add(new MediaTypeWithQualityHeaderValue("Application/Json"));    //ACCEPT header

            HttpResponseMessage response;

            var stringContent = new StringContent("{\"text\":\"" + content + "\"}", Encoding.UTF8, "Application/Json");

            response = httpClient.PostAsync(IncomingWebhookUrl, stringContent).Result;

            //var responseContent = httpResponseMessage.Content.ReadAsStringAsync();
            //if (responseContent.Contains("Microsoft Teams endpoint returned HTTP error 429"))
            //{
            //    // initiate retry logic
            //}

        }

        private string[] GetTeamsIncomingConfig(string teamName)
        {
            //teamName = "Hackathon2020";
            string[] returnInfo = null;

            TeamsPlugin pluginInfo = PXSelect<TeamsPlugin,
                Where<TeamsPlugin.name, Equal<Required<TeamsPlugin.name>>>>.Select(new PXGraph(), teamName);

            if (pluginInfo != null)
            {
                returnInfo = new string[2];

                returnInfo[0] = pluginInfo.IncomingWebhookName;
                returnInfo[1] = pluginInfo.IncomingWebhookURL;
            }

            return returnInfo;
        }

        private string[] GetTeamsOutgoingConfig(string teamName)
        {
            //teamName = "Hackathon2020";
            string[] returnInfo = null;

            TeamsPlugin pluginInfo = PXSelect<TeamsPlugin,
                Where<TeamsPlugin.name, Equal<Required<TeamsPlugin.name>>>>.Select(new PXGraph(), teamName);

            if (pluginInfo != null)
            {
                returnInfo = new string[2];

                returnInfo[0] = pluginInfo.OutgoingWebhookName;
                returnInfo[1] = pluginInfo.OutlookWebhookToken;
                returnInfo[2] = pluginInfo.AcumaticaEndpointURL;
            }

            return returnInfo;
        }
    }
}
