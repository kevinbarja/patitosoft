using System;
using System.Linq;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.Persistent.Validation;

namespace PatitoSoft.Module.Controllers
{
    public partial class ChangePasswordController : ViewController
    {

        private DialogController controladorDialogo;

        public ChangePasswordController()
        {
            InitializeComponent();
            TargetViewId = "ChangePasswordParameters_DetailView;ChangePasswordOnLogonParameters_DetailView;ResetPasswordParameters_DetailView";
            //TargetObjectType = typeof(DevExpress.ExpressApp.Security.ChangePasswordParameters);
        }
        protected override void OnActivated()
        {
            String id = View.Id;
            base.OnActivated();
            RuleRegularExpression ruleExpresionChangePassword = (RuleRegularExpression) Validator.RuleSet.First(x => x.Id == "ChangePassword");
            IRuleRegularExpressionProperties ruleChangePassword = ruleExpresionChangePassword.Properties;
            //TODO: Build regular expresion by security config.
            String pattern = "^(?=.*[a-zA-Z])(?=.*\\d).{6,}$";
            String message = "New password must consist of at least 6 alphanumeric characters.";

            ruleChangePassword.Pattern = pattern;
            ruleChangePassword.MessageTemplateMustMatchPattern = "ruleChangePassword: " + message;

            
            RuleRegularExpression ruleExpresionChangePasswordOnLogon = (RuleRegularExpression)Validator.RuleSet.First(x => x.Id == "ChangePasswordOnLogon");
            IRuleRegularExpressionProperties ruleChangePasswordOnLogon = ruleExpresionChangePasswordOnLogon.Properties;

            ruleChangePasswordOnLogon.Pattern = pattern;
            ruleChangePasswordOnLogon.MessageTemplateMustMatchPattern = "ruleChangePasswordOnLogon: " + message;
            

            RuleRegularExpression ruleExpresionResetPassword = (RuleRegularExpression)Validator.RuleSet.First(x => x.Id == "ResetPassword");
            IRuleRegularExpressionProperties ruleResetPassword = ruleExpresionResetPassword.Properties;

            ruleResetPassword.Pattern = pattern;
            ruleResetPassword.MessageTemplateMustMatchPattern = "ruleResetPassword: " + message;


            controladorDialogo = Frame.GetController<DialogController>();
            if (controladorDialogo != null)
            {
                var current = View.CurrentObject;
                var controllers = controladorDialogo.Controllers;
                controladorDialogo.Accepting += new EventHandler<DialogControllerAcceptingEventArgs>(SaveDateChangePassword);
            }
        }

        private void SaveDateChangePassword(object sender, DialogControllerAcceptingEventArgs e)
        {
            ;
            //Get current user
            //Store in a new table today and username
            //Create a store procedure that check password date.
        }


        protected override void OnDeactivated()
        {
            if (controladorDialogo != null)
            {
                controladorDialogo.Accepting -= new EventHandler<DialogControllerAcceptingEventArgs>(SaveDateChangePassword);
            }
            base.OnDeactivated();
        }
    }
}
