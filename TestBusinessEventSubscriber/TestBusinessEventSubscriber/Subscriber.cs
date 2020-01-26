using MSTeamsIntegration;
using PX.Api.Mobile.PushNotifications;
using PX.Api.SMS;
using PX.BusinessProcess.DAC;
using PX.BusinessProcess.Event;
using PX.BusinessProcess.Subscribers;
using PX.BusinessProcess.Subscribers.ActionHandlers;
using PX.BusinessProcess.Subscribers.Factories;
using PX.BusinessProcess.UI;
using PX.Data;
using PX.Data.PushNotifications;
using PX.SmsProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TestBusinessEventSubscriber
{
	public class TestSubscriber : IBPSubscriberActionHandlerFactory
	{
		private readonly ISmsSender _sender;
		private readonly IPushNotificationDefinitionProvider _pushDefinitionsProvider;
		private IReadOnlyDictionary<string, ISmsProviderFactory> _providerFactories;
		public string Type { get { return "TBED"; } }
		public string TypeName { get { return "Team Delta Teams Message"; } }
		public string CreateActionName
		{
			get { return "TeamsNotification"; }
		}
		public string CreateActionLabel
		{
			get { return "Team Delta Teams Message"; }
		}
		public TestSubscriber(ISmsSender sender, IPushNotificationDefinitionProvider pushDefinitionsProvider, IReadOnlyDictionary<string, ISmsProviderFactory> providerFactories)
		{
			_sender = sender;
			_pushDefinitionsProvider = pushDefinitionsProvider;
			_providerFactories = providerFactories;
		}
		public IEventAction CreateActionHandler(Guid handlerId, bool stopOnError, EventDefinitionsBySource eventDefinitionsProvider)
		{
			var graph = PXGraph.CreateInstance<PXGraph>();
			var template =
				PXSelect<MobileNotification,
						Where<MobileNotification.noteID, Equal<Required<MobileNotification.noteID>>>>
					.Select(graph, handlerId).SingleOrDefault();
			return template != null ? new TeamsSendMessageAction(handlerId) : (IEventAction)new DummyAction(Type, handlerId);
		}

		/// <summary>
		/// Returns BPHandler referencing particular message template. 
		/// Is used for Subscriber ID selector
		/// </summary>
		/// <param name="graph"></param>
		/// <returns></returns>
		public IEnumerable<BPHandler> GetHandlers(PXGraph graph)
		{
			graph.Clear(PXClearOption.ClearQueriesOnly);
			var result = PXSelect<MobileNotification,
				   Where<MobileNotification.deliveryType, Equal<Required<MobileNotification.deliveryType>>
				  >>.Select(graph, 3).FirstTableItems;

			var resultReadOnly = PXSelectReadonly<MobileNotification,
			   Where<MobileNotification.deliveryType, Equal<Required<MobileNotification.deliveryType>>
			  >>.Select(graph, 3).FirstTableItems;

			var result2 =PXSelect<MobileNotification,
				   Where<MobileNotification.deliveryType, Equal<Required<MobileNotification.deliveryType>>,
				   And<Where<MobileNotification.screenID, Equal<Current<BPEvent.screenID>>,
						  Or<Current<BPEvent.screenID>, IsNull>>>>>
					  .Select(graph, 3).FirstTableItems.Where(c => c != null).Select(c =>
						  new BPHandler() { Id = c.NoteID, Name = c.Name, Type = TypeName });
			return result2;
		}
		/// <summary>
		/// Redirects to Graph with notification configuration
		/// </summary>
		/// <param name="handlerId"></param>
		public void RedirectToHandler(Guid? handlerId)
		{
			var mobileNotificationMaint = PXGraph.CreateInstance<MobileNotificationMaint>();
			mobileNotificationMaint.Notifications.Current = mobileNotificationMaint.Notifications.Search<MobileNotification.noteID>(handlerId);
			PXRedirectHelper.TryRedirect(mobileNotificationMaint, PXRedirectHelper.WindowMode.New);
		}
	}
}
