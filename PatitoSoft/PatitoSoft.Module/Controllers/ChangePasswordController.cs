using System;
using System.Linq;
using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Validation;
using PatitoSoft.Module.BusinessObjects;

//TOUCH
namespace PatitoSoft.Module.Controllers
{
    public partial class ChangePasswordController : ViewController
    {

        public ChangePasswordController()
        {
            InitializeComponent();
            TargetViewId = "ChangePasswordParameters_DetailView;ChangePasswordOnLogonParameters_DetailView;ResetPasswordParameters_DetailView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            //TODO: FRANZ
            //Build regular expresion using security config.
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(SecurityConfig));
            var config = objectSpace.FindObject<SecurityConfig>(new BinaryOperator("Id", 1));


            String pattern = "^(?=.*[a-zA-Z])(?=.*\\d).{3,}$";
            String message = "La nueva contraseña debe tener al menos 3 caracteres alfanuméricos";

            
            RuleRegularExpression ruleExpresionChangePasswordOnLogon = (RuleRegularExpression)Validator.RuleSet.First(x => x.Id == "ChangePasswordOnLogon");
            IRuleRegularExpressionProperties ruleChangePasswordOnLogon = ruleExpresionChangePasswordOnLogon.Properties;

            ruleChangePasswordOnLogon.Pattern = pattern;
            ruleChangePasswordOnLogon.MessageTemplateMustMatchPattern = "ruleChangePasswordOnLogon: " + message;
            

            RuleRegularExpression ruleExpresionResetPassword = (RuleRegularExpression)Validator.RuleSet.First(x => x.Id == "ResetPassword");
            IRuleRegularExpressionProperties ruleResetPassword = ruleExpresionResetPassword.Properties;

            ruleResetPassword.Pattern = pattern;
            ruleResetPassword.MessageTemplateMustMatchPattern = "ruleResetPassword: " + message;
        }
    }
}
