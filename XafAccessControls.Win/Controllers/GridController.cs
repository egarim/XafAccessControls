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
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using XafAccessControls.Module.BusinessObjects;

namespace XafAccessControls.Win.Controllers
{

    //HACK documentation https://docs.devexpress.com/eXpressAppFramework/120092/ui-construction/ways-to-access-ui-elements-and-their-controls/ways-to-access-ui-elements-and-their-controls
    //https://docs.devexpress.com/eXpressAppFramework/DevExpress.ExpressApp.DetailViewExtensions.CustomizeViewItemControl(DetailView--Controller--Action-ViewItem---String--)


    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class GridController : ViewController
    {
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public GridController()
        {
            InitializeComponent();
            this.TargetObjectType = typeof(Invoice);
            this.TargetViewType = ViewType.ListView;

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
            var ListView = this.View as ListView;
            var ControlType = ListView.Control.GetType();
            Debug.WriteLine(ControlType.ToString());
            var Grid = ListView.Control as DevExpress.XtraGrid.GridControl;
            GridView gridView = Grid.MainView as GridView;

            if (gridView != null)
            {
                foreach (GridColumn column in gridView.Columns)
                {
                  
                    Debug.WriteLine(column.FieldName);
                    Debug.WriteLine(column.Caption);// Or any other property of the column you're interested in
                    column.Caption = column.Caption + "_Modified";
                }
            }
            // Access and customize the target View control.
        }
        protected override void OnDeactivated()
        {
            // Unsubscribe from previously subscribed events and release other references and resources.
            base.OnDeactivated();
        }
    }
}
