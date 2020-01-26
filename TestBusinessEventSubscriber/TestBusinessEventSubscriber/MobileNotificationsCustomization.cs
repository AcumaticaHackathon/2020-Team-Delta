using MSTeamsIntegration;
using PX.BusinessProcess.DAC;
using PX.BusinessProcess.UI;
using PX.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBusinessEventSubscriber
{
	public class MobileNotificationExt : PXCacheExtension<MobileNotification>
	{
		#region NTo

		/// <exclude/>
		public abstract class usrTo : PX.Data.BQL.BqlString.Field<usrTo> { }

		[PXSelector(typeof(Search<TeamsPlugin.name>))]
		[PXUIField(DisplayName = "To")]
		[PXDBString(40)]
		public virtual string UsrTo { get; set; }

		#endregion
	}
	public class MobileNotificationsCustomization : PXGraphExtension<MobileNotificationMaint>
	{
		[PXMergeAttributes(Method = MergeMethod.Merge)]

		[PXIntList(new int[] { 1, 2, 3 }, new string[] { "Push", "SMS", "Teams" })]
		public void MobileNotification_DeliveryType_CacheAttached(PXCache sender)
		{
		}
		protected virtual void MobileNotification_RowSelected(PXCache cache, PXRowSelectedEventArgs e, PXRowSelected baseMethod)
		{
			if (baseMethod != null)
				baseMethod.Invoke(cache, e);
			var row = e.Row as MobileNotification;
			if (row == null)
				return;
			bool isTeamsNotification = row.DeliveryType == (byte)3;
			PXUIFieldAttribute.SetVisible<MobileNotification.destinationEntityID>(cache, row, !isTeamsNotification);
			PXUIFieldAttribute.SetVisible<MobileNotification.destinationScreenID>(cache, row, !isTeamsNotification);
			PXUIFieldAttribute.SetVisible<MobileNotification.subject>(cache, row, !isTeamsNotification);
			PXUIFieldAttribute.SetVisible<MobileNotification.nfrom>(cache, row, !isTeamsNotification);
			PXUIFieldAttribute.SetVisible<MobileNotification.nto>(cache, row, !isTeamsNotification);
			PXUIFieldAttribute.SetVisible<MobileNotificationExt.usrTo>(cache, row, isTeamsNotification);

			PXDefaultAttribute.SetPersistingCheck<MobileNotification.nto>(cache, row, isTeamsNotification ? PXPersistingCheck.Nothing : PXPersistingCheck.NullOrBlank);

		}
		protected virtual void MobileNotification_RowPersisting(PXCache cache, PXRowPersistingEventArgs e, PXRowPersisting baseMethod)
		{
			var row = e.Row as MobileNotification;
			if (row == null)
				return;
			bool isTeamsNotification = row.DeliveryType == (byte)3;
			if (isTeamsNotification)
			{
				PXDefaultAttribute.SetPersistingCheck<MobileNotification.nto>(cache, row,  PXPersistingCheck.Nothing );
				row.NTo = (string)cache.GetValue(row, "UsrTo");

			}
			else baseMethod?.Invoke(cache, e);
		}
	}
}
