// Derived from KiAspdotnetFramework/UserControl/app/UserControl~template~datagrid~sortable.ascx.cs

using Class_biz_members;
using Class_biz_practitioner_strike_team_details;
using Class_biz_privileges;
using Class_biz_quick_messages;
using Class_biz_regions;
using Class_biz_services;
using Class_biz_user;
using Class_msg_protected;
using kix;
using System;
using System.Collections;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UserControl_region_detail
  {
  public partial class TWebUserControl_region_detail: ki_web_ui.usercontrol_class
    {
    private class Static
      {
      public const int TCI_SELECT = 0;
      public const int TCI_ID = 1;
      public const int TCI_AFFILIATE_NUM = 2;
      public const int TCI_SHORT_NAME = 3;
      public const int TCI_LONG_NAME = 4;
      public const int TCI_PARTICIPATION = 5;
      public const int TCI_NUM_MEMBERS = 6;
      public const int TCI_NUM_VEHICLES = 7;
      public const int TCI_EMAIL_TARGET = 8;
      public const int TCI_SMS_TARGET = 9;
      public const int TCI_SELECT_FOR_QUICKMESSAGE = 10;
      }

    private struct p_type
      {
      public bool be_ad_hoc_participants;
      public bool be_datagrid_empty;
      public bool be_interactive;
      public bool be_loaded;
      public bool be_more_than_examiner;
      public bool be_sort_order_ascending;
      public TClass_biz_members biz_members;
      public TClass_biz_practitioner_strike_team_details biz_practitioner_strike_team_details;
      public TClass_biz_privileges biz_privileges;
      public TClass_biz_quick_messages biz_quick_messages;
      public TClass_biz_regions biz_regions;
      public TClass_biz_services biz_services;
      public TClass_biz_user biz_user;
      public bool do_include_all_services;
      public string member_id;
      public TClass_msg_protected.service_management msg_protected_service_management;
      public uint num_services;
      public string region_code;
      public string sort_order;
      public object summary;
      public string user_target_email;
      public string user_target_sms;
      }

    private struct v_type
      {
      public StringBuilder distribution_list_email;
      public StringBuilder distribution_list_sms;
      }

    private p_type p; // Private Parcel of Page-Pertinent Process-Persistent Parameters
    private v_type v; // Volatile instance Variable container

    private void InjectPersistentClientSideScript()
      {
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.EL);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.KGS_TO_LBS);
      // EstablishClientSideFunction(k.client_side_function_enumeral_type.LBS_TO_KGS);
      // EstablishClientSideFunction
      // (
      // 'RecalculateDependentValues()',
      // k.EMPTY
      // + 'El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value - El("' + TextBox_gross_invoiced_weight_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_lbs.clientid + '").value - El("' + TextBox_franchise_in_lbs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_gain_or_loss_in_kgs.clientid + '").value - El("' + TextBox_franchise_in_kgs.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_lbs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_actual_gain_or_loss_per_bale_in_kgs.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_kgs.clientid + '").value/El("' + TextBox_bales.clientid + '").value;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_percent_gain_or_loss.clientid + '").value ='
      // +  ' Math.round(El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value/El("' + TextBox_net_invoiced_in_lbs.clientid + '").value*100*100)/100;'
      // + k.NEW_LINE
      // + 'El("' + TextBox_monetary_gain_or_loss.clientid + '").value ='
      // +  ' El("' + TextBox_actual_gain_or_loss_in_lbs.clientid + '").value*El("' + TextBox_unit_price_in_cents_per_pound.clientid + '").value;'
      // );
      // //
      // TextBox_bales.attributes.Add('onkeyup','RecalculateDependentValues();');
      // TextBox_gross_landed_weight_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_gross_landed_weight_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_gross_landed_weight_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_gross_landed_weight_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_landed_or_ciq_tare.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_landed_or_ciq_tare_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_landed_or_ciq_tare.clientid + '").value = KgsToLbs(El("' + TextBox_landed_or_ciq_tare_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_pounds.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_kgs.clientid + '").value = LbsToKgs(El("' + TextBox_net_landed_in_pounds.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      // TextBox_net_landed_in_kgs.attributes.Add
      // (
      // 'onkeyup',
      // 'El("' + TextBox_net_landed_in_pounds.clientid + '").value = KgsToLbs(El("' + TextBox_net_landed_in_kgs.clientid + '").value);'
      // + ' RecalculateDependentValues();'
      // );
      }

    protected void Page_Load(object sender, System.EventArgs e)
      {
      if (!p.be_loaded)
        {
        Literal_region_name.Text = p.biz_regions.NameOf(p.summary);
        CheckBox_do_include_all_services.Checked = p.do_include_all_services;
        RequireConfirmation
          (
          c:Button_deactivate_ad_hoc_participants,
          prompt:"Deactivating ad-hoc participants is a safe operation that should be performed after an unconventional deployment has concluded.  Deactivation only sets the participation level to 'None'.  No other data"
          + " will be altered or removed." + k.NEW_LINE
          + k.NEW_LINE
          + "Are you sure you want to de-activate all the ad hoc participants in this region?"
          );
        if (p.be_interactive)
          {
          Literal_author_target.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? p.user_target_email : p.user_target_sms);
          }
        else
          {
          DataGrid_control.AllowSorting = false;
          }
        DataGrid_control.Columns[Static.TCI_SELECT_FOR_QUICKMESSAGE].Visible = p.be_more_than_examiner;
        Table_quick_message.Visible = p.be_more_than_examiner;
        Bind();
        p.be_loaded = true;
        }
      InjectPersistentClientSideScript();
      }

    protected override void OnInit(System.EventArgs e)
      {
      // Required for Designer support
      InitializeComponent();
      base.OnInit(e);
      if (Session[InstanceId() + ".p"] != null)
        {
        p = (p_type)(Session[InstanceId() + ".p"]);
        p.be_loaded = IsPostBack;
        }
      else
        {
        p.biz_members = new TClass_biz_members();
        p.biz_practitioner_strike_team_details = new TClass_biz_practitioner_strike_team_details();
        p.biz_privileges = new TClass_biz_privileges();
        p.biz_quick_messages = new TClass_biz_quick_messages();
        p.biz_regions = new TClass_biz_regions();
        p.biz_services = new TClass_biz_services();
        p.biz_user = new TClass_biz_user();
        p.msg_protected_service_management = new TClass_msg_protected.service_management();
        //
        p.be_ad_hoc_participants = false;
        p.be_interactive = (Session["mode:report"] == null);
        p.be_more_than_examiner = false;
        p.be_loaded = false;
        p.be_sort_order_ascending = true;
        p.do_include_all_services = false;
        p.region_code = k.EMPTY;
        p.sort_order = "strike_team_participation_level.pecking_order desc, short_name";
        p.summary = null;
        //
        p.member_id = p.biz_members.IdOfUserId(user_id:p.biz_user.IdNum());
        //
        p.user_target_email = p.biz_members.EmailAddressOf(member_id:p.member_id);
        p.user_target_sms = p.biz_practitioner_strike_team_details.SmsTargetOf(practitioner_id:p.member_id);
        }
      v.distribution_list_email = new StringBuilder();
      v.distribution_list_sms = new StringBuilder();
      }

    // / <summary>
    // / Required method for Designer support -- do not modify
    // / the contents of this method with the code editor.
    // / </summary>
    private void InitializeComponent()
      {
      DataGrid_control.ItemDataBound += new System.Web.UI.WebControls.DataGridItemEventHandler(DataGrid_control_ItemDataBound);
      DataGrid_control.SortCommand += new System.Web.UI.WebControls.DataGridSortCommandEventHandler(DataGrid_control_SortCommand);
      DataGrid_control.ItemCommand += new System.Web.UI.WebControls.DataGridCommandEventHandler(DataGrid_control_ItemCommand);
      PreRender += TWebUserControl_region_detail_PreRender;
      }

    private void TWebUserControl_region_detail_PreRender(object sender, System.EventArgs e)
      {
      SessionSet(InstanceId() + ".p", p);
      }

    public TWebUserControl_region_detail Fresh()
      {
      Session.Remove(InstanceId() + ".p");
      return this;
      }

    private void DataGrid_control_ItemCommand(object source, System.Web.UI.WebControls.DataGridCommandEventArgs e)
      {
      if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
        {
        p.msg_protected_service_management.region_code = p.region_code;
        p.msg_protected_service_management.summary = p.biz_services.Summary(k.Safe(e.Item.Cells[Static.TCI_ID].Text,k.safe_hint_type.NUM));
        p.msg_protected_service_management.be_more_than_examiner = p.be_more_than_examiner;
        MessageDropCrumbAndTransferTo(p.msg_protected_service_management,"protected","service_management");
        }
      }

    private void DataGrid_control_ItemDataBound(object sender, System.Web.UI.WebControls.DataGridItemEventArgs e)
      {
      LinkButton link_button;
      if (p.be_interactive)
        {
        if (new ArrayList {ListItemType.AlternatingItem, ListItemType.Item, ListItemType.EditItem, ListItemType.SelectedItem}.Contains(e.Item.ItemType))
          {
          link_button = ((e.Item.Cells[Static.TCI_SELECT].Controls[0]) as LinkButton);
          link_button.Text = k.ExpandTildePath(link_button.Text);
          //
          var participation = e.Item.Cells[Static.TCI_PARTICIPATION].Text;
          if (participation == "Standing")
            {
            e.Item.Style.Add(HtmlTextWriterStyle.FontWeight,"bold");
            }
          else if (participation == "Ad-hoc")
            {
            e.Item.Style.Add(HtmlTextWriterStyle.FontStyle,"italic");
            p.be_ad_hoc_participants = true;
            }
          //
          p.num_services++;
          }
        }
      else
        {
        e.Item.Cells[Static.TCI_SELECT].Visible = false;
        }
      }

    private void DataGrid_control_SortCommand(object source, System.Web.UI.WebControls.DataGridSortCommandEventArgs e)
      {
      if (e.SortExpression == p.sort_order)
        {
        p.be_sort_order_ascending = !p.be_sort_order_ascending;
        }
      else
        {
        p.sort_order = k.Safe(e.SortExpression, k.safe_hint_type.KI_SORT_EXPRESSION);
        p.be_sort_order_ascending = true;
        }
      DataGrid_control.EditItemIndex =  -1;
      Bind();
      }

    private void Bind()
      {
      p.biz_services.BindPacratManagementBaseDataList
        (
        sort_order:p.sort_order,
        be_sort_order_ascending:p.be_sort_order_ascending,
        target:DataGrid_control,
        region_code:p.region_code,
        do_include_all_services:p.do_include_all_services
        );
      p.be_datagrid_empty = (p.num_services == 0);
      Button_deactivate_ad_hoc_participants.Visible = p.be_ad_hoc_participants;
      TableRow_none.Visible = p.be_datagrid_empty;
      DataGrid_control.Visible = !p.be_datagrid_empty;
      Literal_num_services.Text = p.num_services.ToString();
      p.num_services = 0;
      p.be_ad_hoc_participants = false;
      BuildDistributionListAndRegisterPostBackControls();
      }

    internal void SetP(object summary)
      {
      p.summary = summary;
      p.region_code = p.biz_regions.CodeOf(p.summary);
      p.be_more_than_examiner =
        k.Has(Session["privilege_array"] as string[],"config-strike-team-state") || p.biz_privileges.HasForRegion(member_id:p.member_id,privilege_name:"config-strike-team-region",region_code:p.region_code);
      }

    protected void CheckBox_force_all_CheckedChanged(object sender, EventArgs e)
      {
      for (var i = new k.subtype<int>(0,DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        (DataGrid_control.Items[i.val].Cells[Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked = (sender as CheckBox).Checked;
        }
      BuildDistributionListAndRegisterPostBackControls();
      }

    protected void CheckBox_selected_CheckedChanged(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      }

    private void BuildDistributionListAndRegisterPostBackControls()
      {
      v.distribution_list_email.Clear();
      v.distribution_list_sms.Clear();
      TableCellCollection tcc;
      for (var i = new k.subtype<int>(0, DataGrid_control.Items.Count); i.val < i.LAST; i.val++)
        {
        tcc = DataGrid_control.Items[i.val].Cells;
        if ((tcc[Static.TCI_SELECT_FOR_QUICKMESSAGE].FindControl("CheckBox_selected") as CheckBox).Checked)
          {
          v.distribution_list_email.Append((tcc[Static.TCI_EMAIL_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY));
          v.distribution_list_sms.Append((tcc[Static.TCI_SMS_TARGET].Text + k.COMMA_SPACE).Replace("&nbsp;,",k.EMPTY));
          }
        ScriptManager.GetCurrent(Page).RegisterPostBackControl((tcc[Static.TCI_SELECT].Controls[0]) as LinkButton);
        }
      Label_distribution_list.Text = (RadioButtonList_quick_message_mode.SelectedValue == "email" ? v.distribution_list_email : v.distribution_list_sms).ToString().TrimEnd(new char[] {Convert.ToChar(k.COMMA),Convert.ToChar(k.SPACE)});
      }

    protected void Button_send_Click(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      if (Label_distribution_list.Text.Length > 0)
        {
        p.biz_quick_messages.Send
          (
          be_email_mode:(RadioButtonList_quick_message_mode.SelectedValue == "email"),
          author_title_clause:p.biz_user.Roles()[0],
          author_first_name:p.biz_members.FirstNameOfMemberId(Session["member_id"].ToString()),
          author_last_name:p.biz_members.LastNameOfMemberId(Session["member_id"].ToString()),
          author_target_email:p.user_target_email,
          author_target_sms:p.user_target_sms,
          distribution_list:Label_distribution_list.Text,
          subject:TextBox_quick_message_subject.Text,
          body:TextBox_quick_message_body.Text,
          reply_mode:(RadioButtonList_reply_to.SelectedValue == "bouncer" ? reply_mode_enum.BOUNCER : (RadioButtonList_reply_to.SelectedValue == "phone" ? reply_mode_enum.PHONE : reply_mode_enum.EMAIL))
          );
        TextBox_quick_message_subject.Text = k.EMPTY;
        TextBox_quick_message_body.Text = k.EMPTY;
        Alert
          (
          cause:k.alert_cause_type.LOGIC,
          state:k.alert_state_type.NORMAL,
          key:"messagsnt",
          value:"Message sent",
          be_using_scriptmanager:true
          );
        }
      else
        {
        Alert
          (
          cause:k.alert_cause_type.USER,
          state:k.alert_state_type.FAILURE,
          key:"noqmrecips",
          value:"Message *NOT* sent.  No recipients are selected.",
          be_using_scriptmanager:true
          );
        }
      }

    protected void RadioButtonList_quick_message_mode_SelectedIndexChanged(object sender, EventArgs e)
      {
      BuildDistributionListAndRegisterPostBackControls();
      if (RadioButtonList_quick_message_mode.SelectedValue == "email")
        {
        Literal_quick_message_kind_email.Visible = true;
        Literal_quick_message_kind_sms.Visible = false;
        Literal_author_target.Text = p.user_target_email;
        RadioButtonList_reply_to.SelectedValue = "email";
        TableRow_subject.Visible = true;
        TextBox_quick_message_body.Columns = 72;
        TextBox_quick_message_body.Rows = 18;
        }
      else
        {
        Literal_quick_message_kind_email.Visible = false;
        Literal_quick_message_kind_sms.Visible = true;
        Literal_author_target.Text = p.user_target_sms;
        RadioButtonList_reply_to.SelectedValue = "phone";
        TableRow_subject.Visible = false;
        TextBox_quick_message_body.Columns = 40;
        TextBox_quick_message_body.Rows = 4;
        }
      }

    protected void CheckBox_do_include_all_services_CheckedChanged(object sender, EventArgs e)
      {
      p.do_include_all_services = CheckBox_do_include_all_services.Checked;
      Bind();
      }

    protected void Button_deactivate_ad_hoc_participants_Click(object sender, EventArgs e)
      {
      p.biz_services.DeactivateAdHocParticipants(p.region_code);
      Alert
        (
        cause:k.alert_cause_type.USER,
        state:k.alert_state_type.NORMAL,
        key:"regadhocdeacd",
        value:"All ad hoc participants in this region have been deactivated.",
        be_using_scriptmanager:true
        );
      Bind();
      }
    } // end TWebUserControl_region_detail

  }