using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using PX.Api.Mobile.PushNotifications;
using PX.BusinessProcess.DAC;
using PX.BusinessProcess.Event;
using PX.BusinessProcess.Subscribers;
using PX.BusinessProcess.Subscribers.ActionHandlers;
using PX.BusinessProcess.Subscribers.Factories;
using PX.BusinessProcess.UI;
using PX.Data;
using PX.Data.PushNotifications;


namespace MSTeamsIntegration
{
    public class TeamsSendMessageAction : IEventAction
    {
        public TeamsSendMessageAction(Guid id)
        {
            Id = id;
        }

        public TeamsSendMessageAction()
        {
        }

        public string Name { get; protected set; }

        public void Process(MatchedRow[] eventRows, CancellationToken cancellation)
        {
            //SendMessage sm = new SendMessage();
            //sm.SendTeamsMessage();

            // Implement send message here 
            throw new NotImplementedException("Put code to send teams message here");
        }

        public Guid Id { get; set; }
    }
}
