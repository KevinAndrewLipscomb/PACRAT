using Class_biz_members;
using Class_biz_subjoined_attributes;
using Class_biz_user;
using Class_biz_users;
using kix;
using System;
using System.Configuration;
using UserControl_capture_subjoined_attributes;
using UserControl_establish_membership;
using UserControl_member_binder;

namespace overview
  {
  public partial class TWebForm_overview: ki_web_ui.page_class
    {
    private struct p_type
      {
      public TClass_biz_members biz_members;
      public TClass_biz_subjoined_attributes biz_subjoined_attributes;
      public TClass_biz_user biz_user;
      public TClass_biz_users biz_users;
      } // end p_type

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            PreRender += TWebForm_overview_PreRender;
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            Title = Server.HtmlEncode(ConfigurationManager.AppSettings["application_name"]) + " - overview";
            if (!IsPostBack)
            {
            }
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            switch(NatureOfLanding(InstanceId() + ".p"))
            {
                case nature_of_visit_type.VISIT_INITIAL:
                    p.biz_members = new TClass_biz_members();
                    p.biz_subjoined_attributes = new TClass_biz_subjoined_attributes();
                    p.biz_user = new TClass_biz_user();
                    p.biz_users = new TClass_biz_users();
                    BeginBreadCrumbTrail();
                    if (p.biz_users.BeStalePassword(p.biz_user.IdNum()))
                    {
                        DropCrumbAndTransferTo("change_password.aspx");
                    }
                    SessionSet("privilege_array", p.biz_user.Privileges());
                    if ((Session["privilege_array"] != null))
                    {
                        SessionSet("member_id", p.biz_members.IdOfUserId(Session["user_id"].ToString()));
                    }
                    break;
                case nature_of_visit_type.VISIT_POSTBACK_STANDARD:
                    p = (p_type)(Session[InstanceId() + ".p"]);
                    break;
            }
            if (p.biz_members.IdOfUserId(p.biz_user.IdNum()).Length == 0)
              {
              // Display controls appropriate ONLY to nonmembers.
              AddIdentifiedControlToPlaceHolder(((TWebUserControl_establish_membership)(LoadControl("~/usercontrol/app/UserControl_establish_membership.ascx"))), "UserControl_establish_membership", PlaceHolder_control);
              }
            else if(p.biz_subjoined_attributes.BeAnyImplementedSince(p.biz_user.LastLoginTime()))
              {
              AddIdentifiedControlToPlaceHolder(((TWebUserControl_capture_subjoined_attributes)(LoadControl("~/usercontrol/app/UserControl_capture_subjoined_attributes.ascx"))), "UserControl_capture_subjoined_attributes", PlaceHolder_control);
              }
            else
              {
              AddIdentifiedControlToPlaceHolder(((TWebUserControl_member_binder)(LoadControl("~/usercontrol/app/UserControl_member_binder.ascx"))), "UserControl_member_binder", PlaceHolder_control);
              }
//
// ScriptManager.GetCurrent(Page).EnablePartialRendering = false;
//
        }

        private void TWebForm_overview_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

    } // end TWebForm_overview

}
