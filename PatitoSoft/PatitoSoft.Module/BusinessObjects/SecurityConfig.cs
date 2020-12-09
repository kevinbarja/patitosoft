using DevExpress.Xpo;
using System.ComponentModel;
using DevExpress.ExpressApp.DC;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.ExpressApp.Model;

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
            PasswordLength = 6;
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

        private int passwordLength;

        [XafDisplayName("Longitud de contraseña")]
        public int PasswordLength
        {
            get { return passwordLength; }
            set { passwordLength = value; }
        }

        private PswComplexity passwordComplexity;

        [XafDisplayName("Complejidad de la contraseña")]
        public PswComplexity PasswordComplexity
        {
            get { return passwordComplexity; }
            set { passwordComplexity = value; }
        }

        private int id;
        [Browsable(false)]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

    }

    [DefaultValue(Baja)]
    public enum PswComplexity{
        Baja = 0,
        Media = 1,
        Alta = 2
    }
}