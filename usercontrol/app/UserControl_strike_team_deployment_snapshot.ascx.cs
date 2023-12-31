using Class_biz_patient_care_levels;
using Class_biz_regions;
using Class_biz_strike_team_deployment_assignments;
using Class_biz_strike_team_deployment_logs;
using Class_biz_strike_team_deployment_member_policies;
using Class_biz_strike_team_deployment_members;
using Class_biz_strike_team_deployment_operational_periods;
using Class_biz_strike_team_deployment_vehicles;
using Class_biz_strike_team_deployments;
using kix;
using System;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_strike_team_deployment_snapshot
  {

  public partial class TWebUserControl_strike_team_deployment_snapshot: ki_web_ui.usercontrol_class
    {

    private static class Static
      {
      public const int ASSIGNMENTS_CI_PRELIM_SHIFT_NAME = 0;
      public const int ASSIGNMENTS_CI_START = 1;
      public const int ASSIGNMENTS_CI_END = 2;
      public const int ASSIGNMENTS_CI_BE_CONVOY = 3;
      public const int ASSIGNMENTS_CI_VEHICLE = 4;
      public const int ASSIGNMENTS_CI_MEMBER_DESIGNATOR = 5;
      public const int DIGEST_CI_PRELIM_SHIFT_NAME = 0;
      public const int DIGEST_CI_START = 01;
      public const int DIGEST_CI_END = 2;
      public const int DIGEST_CI_BE_CONVOY = 3;
      public const int DIGEST_CI_VEHICLE = 4;
      public const int DIGEST_CI_VEHICLE_PATIENT_CARE_LEVEL_ID = 5;
      public const int DIGEST_CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER = 6;
      public const int DIGEST_CI_EFFECTIVE_PATIENT_CARE_LEVEL = 7;
      public const int DIGEST_CI_KIND = 8;
      public const int DIGEST_CI_PAR = 9;
      public const int LOG_CI_TIMESTAMP = 0;
      public const int LOG_CI_ACTOR = 1;
      public const int LOG_CI_ACTION = 2;
      public const int OPERATIONAL_PERIODS_CI_PRELIM_SHIFT_NAME = 0;
      public const int OPERATIONAL_PERIODS_CI_START = 1;
      public const int OPERATIONAL_PERIODS_CI_END = 2;
      public const int OPERATIONAL_PERIODS_CI_BE_CONVOY = 3;
      public const int PERSONNEL_CI_TAG_NUM = 0;
      public const int PERSONNEL_CI_LAST_NAME = 1;
      public const int PERSONNEL_CI_FIRST_NAME = 2;
      public const int PERSONNEL_CI_LEVEL = 3;
      public const int PERSONNEL_CI_AFFILIATION = 4;
      public const int VEHICLES_CI_TACTICAL_NAME = 0;
      public const int VEHICLES_CI_TRANSPONDER_NAME = 1;
      public const int VEHICLES_CI_SERVICE = 2;
      public const int VEHICLES_CI_NAME = 3;
      public const int VEHICLES_CI_LEVEL = 4;
      public const int VEHICLES_CI_KIND = 5;
      public const int VEHICLES_CI_DECAL_NUM = 6;
      public const int VEHICLES_CI_TOW_CAPACITY = 7;
      public const int VEHICLES_CI_FUEL = 8;
      public const int VEHICLES_CI_BE_AWD = 9;
      }

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_patient_care_levels biz_patient_care_levels;
      public TClass_biz_regions biz_regions;
      public TClass_biz_strike_team_deployment_assignments biz_strike_team_deployment_assignments;
      public TClass_biz_strike_team_deployment_logs biz_strike_team_deployment_logs;
      public TClass_biz_strike_team_deployment_member_policies biz_strike_team_deployment_member_policies;
      public TClass_biz_strike_team_deployment_members biz_strike_team_deployment_members;
      public TClass_biz_strike_team_deployment_operational_periods biz_strike_team_deployment_operational_periods;
      public TClass_biz_strike_team_deployment_vehicles biz_strike_team_deployment_vehicles;
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public string deployment_id;
      public string service_strike_team_management_footprint;
      }

    private struct v_type
      {
      public StringBuilder assignments_content_xml;
      public StringBuilder digest_content_xml;
      public StringBuilder log_content_xml;
      public StringBuilder operational_periods_content_xml;
      public StringBuilder personnel_content_xml;
      public StringBuilder vehicles_content_xml;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters
    private v_type v; // Volatile instance Variable container

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        p.be_loaded = true;
        RequireConfirmation
          (
          c:Button_export,
          prompt:"We will send you XMLSS-formatted data masquerading as an XLS file so that it will open up in your spreadsheet program.  The discrepancy is intentional.  The file is not corrupt or untrustworthy." + k.NEW_LINE
          + k.NEW_LINE
          + "If your spreadsheet program mentions these things and asks if you want to open the file, click 'Yes'."
          );
        }
      ScriptManager.GetCurrent(Page).RegisterPostBackControl(Button_export);
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
        if (instance_id == "ASP.protected_strike_team_deployment_detail_aspx.UserControl_strike_team_deployment_control_strike_team_deployment_binder_control_strike_team_deployment_snapshot")
          {
          p.be_loaded &= ((Session["UserControl_strike_team_deployment_control_UserControl_strike_team_deployment_binder_control_PlaceHolder_content"] as string) == "UserControl_strike_team_deployment_snapshot");
          }
        }
      else
        {
        p.be_loaded = false;
        //
        p.biz_patient_care_levels = new TClass_biz_patient_care_levels();
        p.biz_regions = new TClass_biz_regions();
        p.biz_strike_team_deployment_assignments = new TClass_biz_strike_team_deployment_assignments();
        p.biz_strike_team_deployment_logs = new TClass_biz_strike_team_deployment_logs();
        p.biz_strike_team_deployment_member_policies = new TClass_biz_strike_team_deployment_member_policies();
        p.biz_strike_team_deployment_members = new TClass_biz_strike_team_deployment_members();
        p.biz_strike_team_deployment_operational_periods = new TClass_biz_strike_team_deployment_operational_periods();
        p.biz_strike_team_deployment_vehicles = new TClass_biz_strike_team_deployment_vehicles();
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        }
      v.assignments_content_xml = new StringBuilder();
      v.digest_content_xml = new StringBuilder();
      v.log_content_xml = new StringBuilder();
      v.operational_periods_content_xml = new StringBuilder();
      v.personnel_content_xml = new StringBuilder();
      v.vehicles_content_xml = new StringBuilder();
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebUserControl_strike_team_deployment_snapshot_PreRender;
      }

    private void TWebUserControl_strike_team_deployment_snapshot_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_strike_team_deployment_snapshot Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void Bind()
      {
      v.personnel_content_xml.Clear();
      p.biz_strike_team_deployment_members.BindBaseDataList
        (
        sort_order:"last_name,first_name",
        be_sort_order_ascending:true,
        target:DataGrid_personnel,
        deployment_id:p.deployment_id,
        do_include_all_eligible_practitioners:false,
        service_strike_team_management_footprint:p.service_strike_team_management_footprint
        );
      v.vehicles_content_xml.Clear();
      p.biz_strike_team_deployment_vehicles.BindBaseDataList
        (
        sort_order:"service,name",
        be_sort_order_ascending:true,
        target:DataGrid_vehicles,
        deployment_id:p.deployment_id,
        do_include_all_eligible_vehicles:false,
        service_strike_team_management_footprint:p.service_strike_team_management_footprint
        );
      v.operational_periods_content_xml.Clear();
      p.biz_strike_team_deployment_operational_periods.BindBaseDataList
        (
        sort_order:"start,end",
        be_sort_order_ascending:true,
        target:DataGrid_operational_periods,
        deployment_id:p.deployment_id,
        be_unlimited:true
        );
      v.digest_content_xml.Clear();
      p.biz_strike_team_deployment_assignments.BindDigestByDeployment
        (
        sort_order:"start,end,vehicle_designator",
        be_sort_order_ascending:true,
        target:DataGrid_digest,
        deployment_id:p.deployment_id
        );
      v.assignments_content_xml.Clear();
      p.biz_strike_team_deployment_assignments.BindActualsByDeployment
        (
        sort_order:"start,end,vehicle_designator,member_designator",
        be_sort_order_ascending:true,
        target:DataGrid_assignments,
        deployment_id:p.deployment_id
        );
      v.log_content_xml.Clear();
      p.biz_strike_team_deployment_logs.BindBaseDataList
        (
        sort_order:"timestamp",
        be_sort_order_ascending:true,
        target:DataGrid_log,
        deployment_id:p.deployment_id
        );
      }

    internal void Set
      (
      string deployment_id,
      string service_strike_team_management_footprint
      )
      {
      p.deployment_id = deployment_id;
      p.service_strike_team_management_footprint = service_strike_team_management_footprint;
      Bind();
      }

    protected void DataGrid_assignments_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      v.assignments_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_PRELIM_SHIFT_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_START].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_END].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_BE_CONVOY].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_VEHICLE].Text.Replace("&","&amp;") + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.ASSIGNMENTS_CI_MEMBER_DESIGNATOR].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void DataGrid_digest_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        e.Item.Cells[Static.DIGEST_CI_EFFECTIVE_PATIENT_CARE_LEVEL].Text = p.biz_patient_care_levels.EffectiveOf
          (
          vehicle_patient_care_level_description:k.Safe(e.Item.Cells[Static.DIGEST_CI_VEHICLE_PATIENT_CARE_LEVEL_ID].Text,k.safe_hint_type.HYPHENATED_ALPHA),
          practitioner_level_short_description:k.Safe(e.Item.Cells[Static.DIGEST_CI_MAX_PRACTITIONER_LEVEL_PECKING_ORDER].Text,k.safe_hint_type.HYPHENATED_ALPHA)
          );
        }
      //
      v.digest_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_PRELIM_SHIFT_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_START].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_END].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_BE_CONVOY].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_VEHICLE].Text.Replace("&","&amp;") + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_VEHICLE_PATIENT_CARE_LEVEL_ID].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_KIND].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.DIGEST_CI_PAR].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void DataGrid_log_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      v.log_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.LOG_CI_TIMESTAMP].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.LOG_CI_ACTOR].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.LOG_CI_ACTION].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void DataGrid_operational_periods_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      v.operational_periods_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.OPERATIONAL_PERIODS_CI_PRELIM_SHIFT_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.OPERATIONAL_PERIODS_CI_START].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.OPERATIONAL_PERIODS_CI_END].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.OPERATIONAL_PERIODS_CI_BE_CONVOY].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void DataGrid_personnel_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      v.personnel_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.PERSONNEL_CI_TAG_NUM].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.PERSONNEL_CI_LAST_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.PERSONNEL_CI_FIRST_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.PERSONNEL_CI_LEVEL].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.PERSONNEL_CI_AFFILIATION].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void DataGrid_vehicles_ItemDataBound(object sender, DataGridItemEventArgs e)
      {
      v.vehicles_content_xml.Append
        (
        "<ss:Row>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_TACTICAL_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_TRANSPONDER_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_SERVICE].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_NAME].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_LEVEL].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_KIND].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_DECAL_NUM].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_TOW_CAPACITY].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_FUEL].Text + "</ss:Data></ss:Cell>"
        +   "<ss:Cell><ss:Data ss:Type=\"String\">" + e.Item.Cells[Static.VEHICLES_CI_BE_AWD].Text + "</ss:Data></ss:Cell>"
        + "</ss:Row>"
        + k.NEW_LINE
        );
      }

    protected void Button_export_Click(object sender, System.EventArgs e)
      {
      var mark = DateTime.Now;
      var creation_date = DateTime.MinValue;
      var name = k.EMPTY;
      var member_policy_id = k.EMPTY;
      p.biz_strike_team_deployments.Get
        (
        id:p.deployment_id,
        creation_date:out creation_date,
        name:out name,
        member_policy_id:out member_policy_id
        );
      var raw_xml = k.EMPTY
        + "<?xml version=\"1.0\"?>" + k.NEW_LINE
        + "<ss:Workbook xmlns:ss=\"urn:schemas-microsoft-com:office:spreadsheet\">" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Intro\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">This is a snapshot of data associated with the '" + name + "' deployment.</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">This deployment's personnel participation policy is set to '" + p.biz_strike_team_deployment_member_policies.DescriptionOf(member_policy_id).ToUpper() + "'.</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">The authority and scope of this data is the Pennsylvania EMS Strike Team Coordination Center.</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">The authority initiated tracking of this deployment on " + creation_date.ToString("dddd d MMMM yyyy") + ".</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">This snapshot was taken at " + mark.ToString("HH:mm:ss.f dddd d MMMM yyyy") + ".</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +       "<ss:Row><ss:Cell><ss:Data ss:Type=\"String\">Use the worksheet tabs in this workbook to browse this data.</ss:Data></ss:Cell></ss:Row>" + k.NEW_LINE
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Personnel\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.personnel_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Vehicles\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.vehicles_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"OperationalPeriods\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.operational_periods_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Digest\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.digest_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Assignments\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.assignments_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        +   "<ss:Worksheet ss:Name=\"Log\">" + k.NEW_LINE
        +     "<ss:Table>" + k.NEW_LINE
        +       v.log_content_xml.ToString()
        +     "</ss:Table>" + k.NEW_LINE
        +   "</ss:Worksheet>" + k.NEW_LINE
        + "</ss:Workbook>" + k.NEW_LINE;
      ExportToExcel
        (
        filename_sans_extension:"PACRAT-" + p.deployment_id.ToString() + "-" + k.Safe(name,k.safe_hint_type.ALPHANUM) + "-" + mark.ToString("yyyyMMddHHmmssf"),
        excel_string:raw_xml.Replace("&nbsp;",k.EMPTY)
        );
      }

    }

  }
