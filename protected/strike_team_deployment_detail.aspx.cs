// Derived from template~protected~nonlanding.aspx.cs~template

using Class_biz_strike_team_deployments;
using Class_msg_protected;
using kix;
using System;
using System.Configuration;

namespace strike_team_deployment_detail
  {
  public partial class TWebForm_strike_team_deployment_detail: ki_web_ui.page_class
    {

    private struct p_type
      {
      public TClass_biz_strike_team_deployments biz_strike_team_deployments;
      public TClass_msg_protected.strike_team_deployment_detail incoming;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_strike_team_deployment_detail_PreRender;
      }

    private void InjectPersistentClientSideScript()
      {
      Body_control.Attributes.Add
        (
        "onkeypress",
        k.EMPTY
        + " return (document.activeElement.name == 'UserControl_strike_team_deployment_control$TextBox_name' || event.keyCode != 13)"  // Prevent default behavior of performing a postback when enter key is pressed since we want to evaluate the situation first in the TextBox_practitioner onkeyup event.
        );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - strike_team_deployment_detail";
      if (!IsPostBack)
        {
        }
      InjectPersistentClientSideScript();
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisit(InstanceId() + ".p");
      if (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        {
        //
        // Initialize p.~ objects here.
        //
        p.biz_strike_team_deployments = new TClass_biz_strike_team_deployments();
        //
        p.incoming = Message<TClass_msg_protected.strike_team_deployment_detail>
          (
          folder_name:"protected",
          aspx_name:"strike_team_deployment_detail"
          );
        //
        UserControl_strike_team_deployment_control.Set
          (
          id:p.incoming.id,
          be_more_than_examiner:p.incoming.be_more_than_examiner,
          be_ok_to_see_all_strike_team_data:p.incoming.be_ok_to_see_all_strike_team_data
          );
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
//
// ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
      }

    private void TWebForm_strike_team_deployment_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_strike_team_deployment_detail

  }
