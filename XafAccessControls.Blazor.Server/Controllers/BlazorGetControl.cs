using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using XafAccessControls.Module.BusinessObjects;

namespace XafAccessControls.Blazor.Server.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class BlazorGetControl : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public BlazorGetControl()
        {
            InitializeComponent();
            this.TargetObjectType = typeof(Invoice);
            this.TargetViewType = ViewType.DetailView;

            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        protected override void OnActivated()
        {
            base.OnActivated();
            // Perform various tasks depending on the target View.
        }
        protected override void OnViewControlsCreated()
        {
            base.OnViewControlsCreated();
            var Dv = this.View as DetailView;
            var NameViewItem = Dv.Items.FirstOrDefault(i => i.Id.StartsWith("Name"));
            var ControlType = NameViewItem.Control.GetType();
            var DxTextBox=NameViewItem.Control as DevExpress.ExpressApp.Blazor.Editors.Adapters.DxTextBoxAdapter;
            DxTextBox.ValueChanged += DxTextBox_ValueChanged;
            // Access and customize the target View control.
        }

        private void DxTextBox_ValueChanged(object sender, EventArgs e)
        {
            var DxTexbox= sender as DevExpress.ExpressApp.Blazor.Editors.Adapters.DxTextBoxAdapter;
            Debug.WriteLine(DxTexbox.GetValue());
        }

        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
