using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace PatitoSoft.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Contactos telefónicos")]
    public class PhoneBook : BaseObject
    { 
        public PhoneBook(Session session)
            : base(session)
        {
        }

        private String employee;

        [XafDisplayName("Empleado")]
        public String Employee
        {
            get { return employee; }
            set { employee = value; }
        }

        private String phone;

        [XafDisplayName("Teléfono")]
        public String Phone
        {
            get { return phone; }
            set { phone = value; }
        }

    }
}