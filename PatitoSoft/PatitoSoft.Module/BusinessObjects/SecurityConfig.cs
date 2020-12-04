using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;

namespace PatitoSoft.Module.BusinessObjects
{
    [DefaultClassOptions]
    [XafDisplayName("Configuración de seguridad")]
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
            PasswordCaducity = 7;
            Id = 1;
        }


        private int maxLogonAttemptCount;

        [XafDisplayName("Cantidad de intentos fallidos")]
        public int MaxLogonAttemptCount
        {
            get { return maxLogonAttemptCount; }
            set { maxLogonAttemptCount = value; }
        }

        private int passwordCaducity;

        [XafDisplayName("Caducidad de contraseña (días)")]
        public int PasswordCaducity
        {
            get { return passwordCaducity; }
            set { passwordCaducity = value; }
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