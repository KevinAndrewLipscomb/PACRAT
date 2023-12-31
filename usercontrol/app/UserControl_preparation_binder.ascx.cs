// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~binder.cs~template

using Class_biz_privileges;
using Class_biz_members;
using Class_biz_user;
using kix;
using UserControl_region_affiliation;
using UserControl_service_affiliation;
using UserControl_state_affiliation;

namespace UserControl_preparation_binder
  {

  public class UserControl_preparation_binder_Static
    {
    public const int TSSI_SERVICE = 0;
    public const int TSSI_REGION = 1;
    public const int TSSI_STATE = 2;
    }

  public partial class TWebUserControl_preparation_binder: ki_web_ui.usercontrol_class
    {

    //--
    //
    // PRIVATE
    //
    //--

    private struct p_type
      {
      internal bool be_loaded;
      internal TClass_biz_privileges biz_privileges;
      internal TClass_biz_members biz_members;
      internal TClass_biz_user biz_user;
      internal string content_id;
      internal string user_member_id;
      internal uint tab_index;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters

    private void FillPlaceHolder
      (
      #pragma warning disable CA1801 // Remove unused parameter
      bool be_fresh_control_required,
      string target
      #pragma warning restore CA1801 // Remove unused parameter
      )
      {
      if (p.tab_index == UserControl_preparation_binder_Static.TSSI_SERVICE)
        {
        var c = ((TWebUserControl_service_affiliation)(LoadControl("~/usercontrol/app/UserControl_service_affiliation.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_service_affiliation",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_preparation_binder_Static.TSSI_REGION)
        {
        var c = ((TWebUserControl_region_affiliation)(LoadControl("~/usercontrol/app/UserControl_region_affiliation.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_region_affiliation",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      else if (p.tab_index == UserControl_preparation_binder_Static.TSSI_STATE)
        {
        var c = ((TWebUserControl_state_affiliation)(LoadControl("~/usercontrol/app/UserControl_state_affiliation.ascx")));
        p.content_id = AddIdentifiedControlToPlaceHolder(c,"UserControl_state_affiliation",PlaceHolder_content,(be_fresh_control_required ? InstanceId() : k.EMPTY));
        //c.SetTarget(target);
        }
      }
    private void FillPlaceHolder(bool be_fresh_control_required)
      {
      FillPlaceHolder(be_fresh_control_required,k.EMPTY);
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      TabContainer_control.ActiveTabChanged += TabContainer_control_ActiveTabChanged;
      PreRender += TWebUserControl_preparation_binder_PreRender;
      }

    private void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        TabContainer_control.ActiveTabIndex = (int)(p.tab_index);
        p.be_loaded = true;
        }
      }

    private void TabContainer_control_ActiveTabChanged(object sender, System.EventArgs e)
      {
      p.tab_index = (uint)(TabContainer_control.ActiveTabIndex);
      PlaceHolder_content.Controls.Clear();
      FillPlaceHolder(true);
      }

    private void TWebUserControl_preparation_binder_PreRender(object sender, System.EventArgs e)
      {
      //
      // Indicate to children which content control was active on this pass, so that on subsequent passes a child can detect whether or
      // not it is already loaded in the user's browser.
      //
      SessionSet(PlaceHolder_content.ClientID, p.content_id);
      SessionSet(InstanceId() + ".p", p);
      }

    //--
    //
    // PROTECTED
    //
    //--

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack && ((Session["UserControl_member_binder_PlaceHolder_content"] as string) == "UserControl_preparation_binder");
        //
        // Dynamic controls must be re-added on each postback.
        //
        FillPlaceHolder(false);
        }
      else
        {
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_members = new TClass_biz_members();
        p.biz_user = new TClass_biz_user();
        //
        p.be_loaded = false;
        p.user_member_id = p.biz_members.IdOfUserId(p.biz_user.IdNum());
        //
        if (p.biz_privileges.HasForAnyScope(member_id:p.user_member_id,privilege_name:"config-strike-team-service"))
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_SERVICE;
          }
        if (p.biz_privileges.HasForAnyScope(member_id:p.user_member_id,privilege_name:"config-strike-team-region"))
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_REGION;
          }
        if(
            p.biz_privileges.HasForAnyScope(member_id:p.user_member_id,privilege_name:"see-all-strike-team-data")
          ||
            p.biz_privileges.HasForAnyScope(member_id:p.user_member_id,privilege_name:"config-strike-team-state")
          ||
            p.biz_privileges.HasForAnyScope(member_id:p.user_member_id,privilege_name:"config-strike-team-state-unlimited")
          )
        //then
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_STATE;
          }
        FillPlaceHolder(true);
        }
      }

    //--
    //
    // PUBLIC
    //
    //--

    public TWebUserControl_preparation_binder Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    public void SetTarget(string target)
      {
      if (target.Length > 0)
        {
        if (target.ToLower().Contains("/service/"))
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_SERVICE;
          }
        else if (target.ToLower().Contains("/region/"))
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_REGION;
          }
        else if (target.ToLower().Contains("/state/"))
          {
          p.tab_index = UserControl_preparation_binder_Static.TSSI_STATE;
          }
        //
        TabContainer_control.ActiveTabIndex = (int)p.tab_index;
        PlaceHolder_content.Controls.Clear();
        FillPlaceHolder(false,target);
        //
        }
      }

    } // end TWebUserControl_preparation_binder

  }

