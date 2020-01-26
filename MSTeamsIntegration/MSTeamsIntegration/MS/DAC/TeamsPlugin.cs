﻿namespace MSTeamsIntegration
{
	using System;
	using PX.Data;
	
	[System.SerializableAttribute()]
	public class TeamsPlugin : PX.Data.IBqlTable
	{
		#region Name
		public abstract class name : PX.Data.IBqlField
		{
		}
		protected string _Name;
		[PXDBString(250, IsUnicode = true, IsKey = true)]
		[PXDefault()]
		[PXUIField(DisplayName = "Name")]
		public virtual string Name
		{
			get
			{
				return this._Name;
			}
			set
			{
				this._Name = value;
			}
		}
		#endregion
		#region IncomingWebhookName
		public abstract class incomingWebhookName : PX.Data.IBqlField
		{
		}
		protected string _IncomingWebhookName;
		[PXDBString(100, IsUnicode = true)]
		[PXDefault("")]
		[PXUIField(DisplayName = "Incoming Webhook Name")]
		public virtual string IncomingWebhookName
		{
			get
			{
				return this._IncomingWebhookName;
			}
			set
			{
				this._IncomingWebhookName = value;
			}
		}
		#endregion
		#region IncomingWebhookURL
		public abstract class incomingWebhookURL : PX.Data.IBqlField
		{
		}
		protected string _IncomingWebhookURL;
		[PXDBString(500, IsUnicode = true)]
		[PXDefault("")]
		[PXUIField(DisplayName = "Incoming Webhook URL")]
		public virtual string IncomingWebhookURL
		{
			get
			{
				return this._IncomingWebhookURL;
			}
			set
			{
				this._IncomingWebhookURL = value;
			}
		}
		#endregion
		#region OutgoingWebhookName
		public abstract class outgoingWebhookName : PX.Data.IBqlField
		{
		}
		protected string _OutgoingWebhookName;
		[PXDBString(100, IsUnicode = true)]
		[PXDefault("")]
		[PXUIField(DisplayName = "Outgoing Webhook Name")]
		public virtual string OutgoingWebhookName
		{
			get
			{
				return this._OutgoingWebhookName;
			}
			set
			{
				this._OutgoingWebhookName = value;
			}
		}
		#endregion
		#region OutlookWebhookToken
		public abstract class outlookWebhookToken : PX.Data.IBqlField
		{
		}
		protected string _OutlookWebhookToken;
		[PXDBString(250, IsUnicode = true)]
		[PXDefault("")]
		[PXUIField(DisplayName = "Outlook Webhook Token")]
		public virtual string OutlookWebhookToken
		{
			get
			{
				return this._OutlookWebhookToken;
			}
			set
			{
				this._OutlookWebhookToken = value;
			}
		}
		#endregion
		#region AcumaticaEndpointURL
		public abstract class acumaticaEndpointURL : PX.Data.IBqlField
		{
		}
		protected string _AcumaticaEndpointURL;
		[PXDBString(500, IsUnicode = true)]
		[PXDefault("")]
		[PXUIField(DisplayName = "Acumatica Endpoint URL")]
		public virtual string AcumaticaEndpointURL
		{
			get
			{
				return this._AcumaticaEndpointURL;
			}
			set
			{
				this._AcumaticaEndpointURL = value;
			}
		}
		#endregion
		#region tstamp
		public abstract class Tstamp : PX.Data.IBqlField
		{
		}
		protected byte[] _tstamp;
		[PXDBTimestamp()]
		public virtual byte[] tstamp
		{
			get
			{
				return this._tstamp;
			}
			set
			{
				this._tstamp = value;
			}
		}
		#endregion
		#region CreatedByID
		public abstract class createdByID : PX.Data.IBqlField
		{
		}
		protected Guid? _CreatedByID;
        //[PXDBField()]
        //[PXDefault()]
        [PXDBCreatedByID()]
        [PXUIField(DisplayName = "CreatedByID")]
		public virtual Guid? CreatedByID
		{
			get
			{
				return this._CreatedByID;
			}
			set
			{
				this._CreatedByID = value;
			}
		}
		#endregion
		#region CreatedByScreenID
		public abstract class createdByScreenID : PX.Data.IBqlField
		{
		}
		protected string _CreatedByScreenID;
        //[PXDBString(8, IsFixed = true)]
        //[PXDefault("")]
        [PXDBCreatedByScreenID()]
        [PXUIField(DisplayName = "CreatedByScreenID")]
		public virtual string CreatedByScreenID
		{
			get
			{
				return this._CreatedByScreenID;
			}
			set
			{
				this._CreatedByScreenID = value;
			}
		}
		#endregion
		#region CreatedDateTime
		public abstract class createdDateTime : PX.Data.IBqlField
		{
		}
		protected DateTime? _CreatedDateTime;
        //[PXDBDate()]
        //[PXDefault(TypeCode.DateTime, "01/01/1900")]
        [PXDBCreatedDateTime()]
        [PXUIField(DisplayName = "CreatedDateTime")]
		public virtual DateTime? CreatedDateTime
		{
			get
			{
				return this._CreatedDateTime;
			}
			set
			{
				this._CreatedDateTime = value;
			}
		}
		#endregion
		#region LastModifiedByID
		public abstract class lastModifiedByID : PX.Data.IBqlField
		{
		}
		protected Guid? _LastModifiedByID;
        //[PXDBField()]
        //[PXDefault()]
        [PXDBLastModifiedByID()]
        [PXUIField(DisplayName = "LastModifiedByID")]
		public virtual Guid? LastModifiedByID
		{
			get
			{
				return this._LastModifiedByID;
			}
			set
			{
				this._LastModifiedByID = value;
			}
		}
		#endregion
		#region LastModifiedByScreenID
		public abstract class lastModifiedByScreenID : PX.Data.IBqlField
		{
		}
		protected string _LastModifiedByScreenID;
        //[PXDBString(8, IsFixed = true)]
        //[PXDefault("")]
        [PXDBLastModifiedByScreenID()]
        [PXUIField(DisplayName = "LastModifiedByScreenID")]
		public virtual string LastModifiedByScreenID
		{
			get
			{
				return this._LastModifiedByScreenID;
			}
			set
			{
				this._LastModifiedByScreenID = value;
			}
		}
		#endregion
		#region LastModifiedDateTime
		public abstract class lastModifiedDateTime : PX.Data.IBqlField
		{
		}
		protected DateTime? _LastModifiedDateTime;
        //[PXDBDate()]
        //[PXDefault(TypeCode.DateTime, "01/01/1900")]
        [PXDBLastModifiedDateTime()]
        [PXUIField(DisplayName = "LastModifiedDateTime")]
		public virtual DateTime? LastModifiedDateTime
		{
			get
			{
				return this._LastModifiedDateTime;
			}
			set
			{
				this._LastModifiedDateTime = value;
			}
		}
		#endregion
		#region NoteID
		public abstract class noteID : PX.Data.IBqlField
		{
		}
		protected Guid? _NoteID;
        [PXNote]
        [PXDefault]
		[PXUIField(DisplayName = "NoteID")]
		public virtual Guid? NoteID
		{
			get
			{
				return this._NoteID;
			}
			set
			{
				this._NoteID = value;
			}
		}
		#endregion
	}
}
