// Derived from template~protected~nonlanding.aspx.cs~template

using System;
using System.Configuration;

namespace per_deployment_iap_vehicles
  {

  public partial class TWebForm_per_deployment_iap_vehicles: ki_web_ui.page_class
    {

    private struct p_type
      {
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      PreRender += TWebForm_per_deployment_iap_vehicles_PreRender;
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - per_deployment_iap_vehicles";
      if (!IsPostBack)
        {
        }
      }

    protected override void OnInit(EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      var nature_of_visit = NatureOfVisitUnlimited(InstanceId() + ".p");
      if(
          (nature_of_visit == nature_of_visit_type.VISIT_INITIAL)
        ||
          (nature_of_visit == nature_of_visit_type.VISIT_COLD_CALL)
        )
        {
        //
        // Initialize p.~ objects here.
        //
        UserControl_per_deployment_iap_vehicles_control.Set(deployment_id:HashtableOfShieldedRequest()["vehicles_deployment_id"].ToString());
        }
      else if (nature_of_visit == nature_of_visit_type.VISIT_POSTBACK_STANDARD)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        }
      //
      // ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
      //
      }

    private void TWebForm_per_deployment_iap_vehicles_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    } // end TWebForm_per_deployment_iap_vehicles

  }
