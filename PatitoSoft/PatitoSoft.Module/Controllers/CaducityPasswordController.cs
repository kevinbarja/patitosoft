using System;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.SystemModule;
using PatitoSoft.Module.BusinessObjects;

namespace PatitoSoft.Module.Controllers
{
    public partial class CaducityPasswordController : ViewController
    {
        private DialogController dialogController;

        public CaducityPasswordController()
        {
            InitializeComponent();
            TargetViewId = "ChangePasswordParameters_DetailView;ChangePasswordOnLogonParameters_DetailView;ResetPasswordParameters_DetailView";
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            dialogController = Frame.GetController<DialogController>();
            if (dialogController != null)
            {
                var current = View.CurrentObject;
                var controllers = dialogController.Controllers;
                dialogController.Accepting += new EventHandler<DialogControllerAcceptingEventArgs>(SavePasswordHistory);
            }
        }


        private void SavePasswordHistory(object sender, DialogControllerAcceptingEventArgs e)
        {
            IObjectSpace objectSpace = Application.CreateObjectSpace(typeof(PasswordHistory));

            PasswordHistory passwordHistory = objectSpace.CreateObject<PasswordHistory>();
            passwordHistory.ModificationDate = DateTime.Now;
            passwordHistory.UserId = SecuritySystem.CurrentUserId.ToString();
            objectSpace.CommitChanges();

            //TODO: Yeli
            //Create a store procedure that check password caducity
        }

        protected override void OnDeactivated()
        {
            if (dialogController != null)
            {
                dialogController.Accepting -= new EventHandler<DialogControllerAcceptingEventArgs>(SavePasswordHistory);
            }
            base.OnDeactivated();
        }
    }
}
