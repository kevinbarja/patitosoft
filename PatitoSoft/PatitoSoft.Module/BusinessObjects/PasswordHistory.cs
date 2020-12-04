using System;
using DevExpress.Xpo;
using DevExpress.Persistent.BaseImpl;
using System.ComponentModel;

namespace PatitoSoft.Module.BusinessObjects
{
    [Browsable(false)]
    public class PasswordHistory : BaseObject
    { 
        public PasswordHistory(Session session)
            : base(session)
        {
        }

        private DateTime modificationDate;

        public DateTime ModificationDate
        {
            get { return modificationDate; }
            set { modificationDate = value; }
        }

        private String userId;

        public String UserId
        {
            get { return userId; }
            set { userId = value; }
        }
    }
}