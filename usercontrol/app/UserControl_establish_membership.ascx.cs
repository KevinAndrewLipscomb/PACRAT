using AjaxControlToolkit;
using Class_biz_members;
using Class_biz_notifications;
using Class_biz_practitioner_levels;
using Class_biz_regions;
using Class_biz_user;
using Class_biz_users;
using kix;
using System;
using System.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_establish_membership
{
  public partial class TWebUserControl_establish_membership: ki_web_ui.usercontrol_class
    {

    private struct p_type
      {
      public bool be_loaded;
      public TClass_biz_members biz_members;
      public TClass_biz_notifications biz_notifications;
      public TClass_biz_practitioner_levels biz_practitioner_levels;
      public TClass_biz_regions biz_regions;
      public TClass_biz_user biz_user;
      public TClass_biz_users biz_users;
        }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

        protected void Page_Load(object sender, System.EventArgs e)
        {
            if (!p.be_loaded)
            {
                Label_application_name_1.Text = ConfigurationManager.AppSettings["application_name"];
                Label_sponsor_4.Text = ConfigurationManager.AppSettings["sponsor"];
                Label_shared_secret_description_1.Text = ConfigurationManager.AppSettings["shared_secret_description"];
                p.biz_regions.BindDirectToListControl(target:DropDownList_regional_council,application_filter:"pacrat");
                UserControl_drop_down_date_birth.minyear = DateTime.Today.AddYears(-130).Year.ToString();
                UserControl_drop_down_date_birth.maxyear = DateTime.Today.AddYears(-16).Year.ToString();
                p.biz_practitioner_levels.BindDirectToListControl(DropDownList_level);
                TextBox_certification_number.Focus();
                p.be_loaded = true;
            }
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_trouble_handler);
            ScriptManager.GetCurrent(Page).RegisterPostBackControl(LinkButton_proceed);
        }

        protected override void OnInit(System.EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
            if (IsPostBack && (Session[InstanceId() + ".p"] != null))
            {
                p = (p_type)(Session[InstanceId() + ".p"]);
            }
            else
            {
                p.be_loaded = false;
                p.biz_members = new TClass_biz_members();
                p.biz_notifications = new TClass_biz_notifications();
                p.biz_practitioner_levels = new TClass_biz_practitioner_levels();
                p.biz_regions = new TClass_biz_regions();
                p.biz_user = new TClass_biz_user();
                p.biz_users = new TClass_biz_users();
            }

        }

        protected void LinkButton_proceed_Click(object sender, System.EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }

        protected void LinkButton_trouble_handler_Click(object sender, System.EventArgs e)
        {
            DropCrumbAndTransferTo("establish_membership_trouble.aspx");
        }

        protected void Button_submit_Click(object sender, System.EventArgs e)
        {
          if (Page.IsValid)
            {
            if(
              p.biz_users.AcceptAsMember
                (
                certification_number:k.Safe(TextBox_certification_number.Text,k.safe_hint_type.NUM),
                level_id:k.Safe(DropDownList_level.SelectedValue,k.safe_hint_type.NUM),
                regional_council_code:k.Safe(DropDownList_regional_council.SelectedValue,k.safe_hint_type.NUM),
                birth_date:UserControl_drop_down_date_birth.selectedvalue,
                id:p.biz_user.IdNum()
                )
              )
            //
              {
              SessionSet("privilege_array", p.biz_user.Privileges());
              // User was an unprivileged user until now, so reset privs.
              Alert(k.alert_cause_type.USER, k.alert_state_type.SUCCESS, "memaccept", "Link to membership record established.  Membership privileges granted.", true);
              Table_proceed.Visible = true;
              }
            else
              {
              Alert(k.alert_cause_type.USER, k.alert_state_type.FAILURE, "nosuchmem", "No such membership record could be located.  Please check your submission for accuracy.", true);
              }
            }
        }

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            PreRender += TWebUserControl_establish_membership_PreRender;
        }

        private void TWebUserControl_establish_membership_PreRender(object sender, System.EventArgs e)
        {
            SessionSet(InstanceId() + ".p", p);
        }

        public TWebUserControl_establish_membership Fresh()
        {
            TWebUserControl_establish_membership result;
            Session.Remove(InstanceId() + ".p");
            result = this;
            return result;
        }

        protected void CustomValidator_shared_secret_ServerValidate(object source, ServerValidateEventArgs args)
          {
          var claimed_role_name = k.EMPTY;
          var claimed_member_name = k.EMPTY;
          var claimed_member_id = k.EMPTY;
          var claimed_member_email_address = k.EMPTY;
          if(p.biz_members.BeRoleHolderBySharedSecret
              (
              k.Safe(TextBox_certification_number.Text,k.safe_hint_type.NUM),
              k.Safe(DropDownList_level.SelectedValue,k.safe_hint_type.NUM),
              k.Safe(DropDownList_regional_council.SelectedValue,k.safe_hint_type.NUM),
              UserControl_drop_down_date_birth.selectedvalue,
              out claimed_role_name,
              out claimed_member_name,
              out claimed_member_id,
              out claimed_member_email_address
              )
            )
            {
            args.IsValid = false;
            p.biz_notifications.IssueForMembershipEstablishmentBlocked(Session["username"].ToString(),Session["user_id"].ToString(),claimed_role_name,claimed_member_name,claimed_member_id,claimed_member_email_address);
            }
          else
            {
            args.IsValid = true;
            }
          }

    } // end TWebUserControl_establish_membership

}
