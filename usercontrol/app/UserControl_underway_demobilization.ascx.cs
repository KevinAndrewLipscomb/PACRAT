using Class_biz_practitioner_strike_team_details;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_members;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_strike_team_deployments;
using kix;

namespace UserControl_underway_demobilization
  {

  public partial class TWebUserControl_underway_demobilization: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public string asset_designator;
      public bool be_loaded;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public string deployment_id;
      public string deployment_name;
      public string mobilization_id;
      public Class_msg_protected.underway_demobilization_mode_enum mode;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_deployment_name.Text = p.deployment_name;
        Literal_asset_mode.Text = p.mode.ToString();
        Literal_asset_designator.Text = p.asset_designator;
        //
        p.be_loaded = true;
        }
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var instance_id = InstanceId();
      if (Session[instance_id + ".p"] != null)
        {
        p = (p_type)(Session[instance_id + ".p"]);
        p.be_loaded = IsPostBack;  // This test is sufficient if this control is being used statically on its page.
        //
        // If this control is being used dynamically under one or more parent binder(s), it must ascertain which instance it is, and whether or not that instance's parent binder
        // had it loaded already.
        //
//#warning Revise the binder-related instance_id to this control appropriately.
//        if (instance_id == "ASP.protected_overview_aspx.UserControl_member_binder_underway_demobilization")
//          {
//#warning Revise the ClientID path to this control appropriately.
//          p.be_loaded &= ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_underway_demobilization");
//          }
////      else if (instance_id == "ASP.~_aspx.UserControl_~_binder_underway_demobilization")
////        {
////        p.be_loaded &= ((Session["UserControl_~_binder_PlaceHolder_content"] as string) == "UserControl_underway_demobilization");
////        }
        }
      else
        {
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
        p.biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
        p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        //
        p.be_loaded = false;
        }
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_underway_demobilization_PreRender;
      }

    private void TWebUserControl_underway_demobilization_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_underway_demobilization Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    internal void Set
      (
      string deployment_id,
      Class_msg_protected.underway_demobilization_mode_enum mode,
      string mobilization_id,
      string asset_designator
      )
      {
      p.deployment_id = deployment_id;
      p.mode = mode;
      p.mobilization_id = mobilization_id;
      p.asset_designator = asset_designator;
      //
      p.deployment_name = p.biz_strike_team_deployments.NameOfId(p.deployment_id);
      }

    protected void Button_submit_Click(object sender, System.EventArgs e)
      {
      var reason = k.Safe(TextBox_reason.Text, k.safe_hint_type.PUNCTUATED);
      if (p.mode == Class_msg_protected.underway_demobilization_mode_enum.MEMBER)
        {
        p.biz_strike_team_deployments.DemobilizeMemberUnderway
          (
          deployment_id:p.deployment_id,
          deployment_name:p.deployment_name,
          mobilization_id:p.mobilization_id,
          asset_designator:p.asset_designator,
          reason:reason,
          sms_target:p.biz_practitioner_strike_team_details.SmsTargetOf(p.biz_strike_team_deployment_members.PractitionerIdOfMobilizationId(p.mobilization_id))
          );
        }
      else if (p.mode == Class_msg_protected.underway_demobilization_mode_enum.VEHICLE)
        {
        p.biz_strike_team_deployments.DemobilizeVehicleUnderway
          (
          deployment_id:p.deployment_id,
          mobilization_id:p.mobilization_id,
          asset_designator:p.asset_designator,
          reason:reason
          );
        }
      //
      BackTrack();
      }

    protected void Button_cancel_Click(object sender, System.EventArgs e)
      {
      BackTrack();
      }

    }

  }
