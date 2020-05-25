// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployments;
using Class_biz_user;
using kix;
using System;
using System.Collections;
using System.Configuration;
using System.Web.UI.WebControls;

namespace UserControl_per_deployment_iap_log
  {
  public partial class TWebUserControl_per_deployment_iap_log: ki_web_ui.usercontrol_class
    {
    public static class UserControl_per_deployment_iap_log_Static
      {
      }

    private struct p_type
      {
      public bool be_datagrid_empty;
      public TClass_biz_members biz_members;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_biz_user biz_user;
      public string deployment_id;
      public string deployment_name;
      public uint num_logs;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, System.EventArgs e)
      {
      var mark = DateTime.Now;
      Literal_application_name.Text = ConfigurationManager.AppSettings["application_name"];
      Literal_ref_num.Text = mark.ToString("yyyy-MM-dd-HH-mm-ss-ff");
      var practitioner_summary = p.biz_members.Summary(p.biz_members.IdOfUserId(p.biz_user.IdNum()));
      Literal_prepared_name.Text = k.EMPTY
      + p.biz_members.LevelOf(practitioner_summary)
      + k.SPACE
      + p.biz_members.FirstNameOf(practitioner_summary)
      + k.SPACE
      + p.biz_members.LastNameOf(practitioner_summary)
      + k.SPACE
      + "(" + p.biz_members.CertificationNumberOf(practitioner_summary) + ")";
      Literal_prepared_timestamp.Text = mark.ToString("yyyy-MM-dd HH:mm:ss.ff");
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      //
      p.biz_members = new TClass_biz_members();
      p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
      p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
      p.biz_user = new TClass_biz_user();
      //
      p.deployment_id = k.EMPTY;
      p.deployment_name = k.EMPTY;
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      PreRender += TWebUserControl_per_deployment_iap_log_PreRender;
      }

    private void TWebUserControl_per_deployment_iap_log_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_per_deployment_iap_log Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.num_logs++;
        }
      }

    private void Bind()
      {
      p.biz_strike_team_deployment_logs.BindBaseDataList
        (
        sort_order:"timestamp",
        be_sort_order_ascending:true,
        target:DataGrid_control,
        deployment_id:p.deployment_id
        );
      p.be_datagrid_empty = (p.num_logs == 0);
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      p.num_logs = 0;
      }

    internal void Set(string deployment_id)
      {
      p.deployment_id = deployment_id;
      p.deployment_name = p.biz_strike_team_deployments.NameOfId(p.deployment_id);
      Literal_deployment_name.Text = p.biz_strike_team_deployments.NameOfId(deployment_id);
      Bind();
      }

    } // end TWebUserControl_per_deployment_iap_log

  }