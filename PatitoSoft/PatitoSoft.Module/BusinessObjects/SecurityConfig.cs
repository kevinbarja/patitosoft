using System;
using System.Linq;
using System.Text;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Data.Filtering;
using DevExpress.Persistent.Base;
using System.Collections.Generic;
using DevExpress.ExpressApp.Model;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

//TOUCH
namespace PatitoSoft.Module.BusinessObjects
{
    [DefaultClassOptions]
    //[ImageName("BO_Contact")]
    //[DefaultProperty("DisplayMemberNameForLookupEditorsOfThisType")]
    //[DefaultListViewOptions(MasterDetailMode.ListViewOnly, false, NewItemRowPosition.None)]
    //[Persistent("DatabaseTableName")]
    public class SecurityConfig : BaseObject
    { 
        public SecurityConfig(Session session)
            : base(session)
        {
        }
        public override void AfterConstruction()
        {
            base.AfterConstruction();
            MaxLogonAttemptCount = 5;
            Id = 1;
        }


        private int maxLogonAttemptCount;

        [XafDisplayName("Cantidad de intentos fallidos")]
        public int MaxLogonAttemptCount
        {
            get { return maxLogonAttemptCount; }
            set { maxLogonAttemptCount = value; }
        }

        private int id;
        [Browsable(false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }


    }
}