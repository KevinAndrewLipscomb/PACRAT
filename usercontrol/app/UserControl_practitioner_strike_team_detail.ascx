<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_practitioner_strike_team_detail.ascx.cs" Inherits="UserControl_practitioner_strike_team_detail.TWebUserControl_practitioner_strike_team_detail"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~kicrudhelped~item.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr id="TableRow_practitioner_id" runat="server" visible="false">
    <td bgcolor="gainsboro" valign="top"><font class="">practitioner_id:</font></td>
    <td></td>
    <td>&nbsp;</td>
    <td valign="top"><font class="">
      <table cellspacing="0" cellpadding="0" border="0">
         <tr>
           <td valign="middle">
             <table cellspacing="0" cellpadding="0" border="0">
               <tr>
                 <td>
      <ASP:TextBox id="TextBox_practitioner_id" runat="server"  cssclass=""></ASP:TextBox><ASP:Button id="Button_lookup" runat="server" causesvalidation="False" text="LOOKUP" onclick="Button_lookup_Click"></ASP:Button>
                </td>
                <td nowrap="nowrap"><small><small><asp:Label id="Label_lookup_arrow" runat="server">&lt;--</asp:Label></small></small></td>
                <td><small><small><em><asp:Label id="Label_lookup_hint" runat="server">Lookup by partial or full field value</asp:Label></em></small></small></td>
              </tr>
            </table>
          </td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td valign="middle">
            <small>
              <ASP:LinkButton id="LinkButton_reset" runat="server" causesvalidation="False" enabled="False" onclick="LinkButton_reset_Click">New lookup</ASP:LinkButton>
            </small>
          </td>
          <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
          <td valign="middle">
            <small>
              <ASP:LinkButton id="LinkButton_new_record" runat="server" causesvalidation="False" visible="False" onclick="LinkButton_new_record_Click">Enter&nbsp;brand&nbsp;new&nbsp;record</ASP:LinkButton>
            </small>
          </td>
        </tr>
      </table>
      <table>
        <tr>
          <td><asp:Panel ID="Panel_match_numbers" runat="server" Visible="False"><small>(<asp:Literal ID="Literal_match_index" runat="server"></asp:Literal>/<asp:Literal ID="Literal_num_matches" runat="server"></asp:Literal>)</small></asp:Panel></td>
          <td>
            <asp:LinkButton id="LinkButton_go_to_match_first" runat="server" text="<IMG src=&quot;~/protected/image/first_track_blue16_h.png&quot; alt=&quot;First match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_first_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_prior" runat="server" text="<IMG src=&quot;~/protected/image/play_blue16_h-flipped.png&quot; alt=&quot;Prior match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_prior_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_next" runat="server" text="<IMG src=&quot;~/protected/image/play_blue16_h.png&quot; alt=&quot;Next match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_next_Click"></asp:LinkButton><asp:LinkButton id="LinkButton_go_to_match_last" runat="server" text="<IMG src=&quot;~/protected/image/last_track_blue16_h.png&quot; alt=&quot;Last match&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; />" causesvalidation="False" visible="False" onclick="LinkButton_go_to_match_last_Click"></asp:LinkButton>
          </td>
          <td>
            <div style="width:0px;white-space:nowrap;"><ASP:DropDownList id="DropDownList_practitioner_id" runat="server" visible="False" autopostback="True" onselectedindexchanged="DropDownList_practitioner_id_SelectedIndexChanged"></ASP:DropDownList></div>
          </td>
        </tr>
      </table>
    </font>
    </td>
    <td nowrap="nowrap" valign="top">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_practitioner_id" runat="server" errormessage="Please enter practitioner_id." font-bold="True" controltovalidate="TextBox_practitioner_id" Display="Dynamic">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-right: thin solid Gainsboro; border-left: thin solid Gainsboro" bgcolor="WhiteSmoke"><p><strong>Contact information</strong></p></td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">Phone&nbsp;number:</font></td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_phone_number" runat="server" columns="10" maxlength="10" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">
      <ASP:CustomValidator id="CustomValidator_phone_num" runat="server" errormessage="Please enter a valid Phone number.  Premium and reserved numbers are not allowed." controltovalidate="TextBox_phone_number" font-bold="True" onservervalidate="CustomValidator_phone_number_ServerValidate" Display="Dynamic">!ERR!</ASP:CustomValidator>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro" valign="top"><font class="">Cellular&nbsp;service:</font></td>
    <td valign="top"><font color="#33CC33">&clubs;</font></td>
    <td valign="top"><font color="#3366FF">&diams;</font></td>
    <td valign="top">
      <asp:DropDownList ID="DropDownList_phone_service" runat="server"></asp:DropDownList>
      <small>
        <table bgcolor="khaki" cellpadding="5" cellspacing="0">
          <tr>
            <td>
              <p>If the practitioner&#39;s cellular service does not appear in the list of choices, please do as follows:</p>
              <ol>
                <li>
                  <p>
                    Have the practitioner use his or her cellphone to <strong>TEXT</strong> a test message to <b>your email address</b> --
                    <asp:Label ID="Label_user_email_address" runat="server" Font-Italic="True"></asp:Label>
                    &nbsp;-- <b>not</b> to your phone.&nbsp; The practitioner may not realize this is possible, but most cell phones can indeed do this.
                  </p>
                </li>
                <li>
                  <p>
                    Check your email.&nbsp; When you receive the practitioner&#39;s test message, check its <i>From:</i> address.&nbsp; The <i>From:</i> address should reveal which primary cellular service the practitioner's
                    phone is actually currently assigned to.
                  </p>
                </li>
                <li>
                  <p>
                    If the cellular service revealed by the previous step appears in the list of choices to the left, select it.&nbsp; (The practitioner likely subscribes to an
                    <a href="https://en.wikipedia.org/wiki/Mobile_virtual_network_operator" target="_blank">MVNO</a> instead of to a true primary cellular service.)
                  </p>
                </li>
                <li>
                  <p>
                    Otherwise, forward the practitioner's test message to <asp:HyperLink ID="HyperLink_app_email_address" runat="server" Font-Italic="True">[HyperLink_app_email_address]</asp:HyperLink> and ask the application administrator to add the indicated cellular service to the list of
                    choices.
                  </p>
                </li>
              </ol>
            </td>
          </tr>
        </table>
      </small>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">Emergency&nbsp;contact&nbsp;1&nbsp;name:</font></td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_emergency_contact_1_name" runat="server" columns="72" maxlength="127" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">Emergency&nbsp;contact&nbsp;1&nbsp;phone&nbsp;number:</font></td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_emergency_contact_1_phone_number" runat="server" columns="10" maxlength="10" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">
      <ASP:CustomValidator id="CustomValidator_emergency_contact_1_phone_number" runat="server" errormessage="Please enter a valid Emergency contact 1 phone number.  Premium and reserved numbers are not allowed." controltovalidate="TextBox_emergency_contact_1_phone_number" font-bold="True" onservervalidate="CustomValidator_emergency_contact_1_phone_number_ServerValidate" Display="Dynamic">!ERR!</ASP:CustomValidator>
    </td>
  </tr>
  <tr style="border-right: thin solid Gainsboro; border-left: thin solid Gainsboro">
    <td style="border-left: thin solid Gainsboro"><font class="">Emergency&nbsp;contact&nbsp;2&nbsp;name:</font></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_emergency_contact_2_name" runat="server" columns="72" maxlength="127" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">Emergency&nbsp;contact&nbsp;2&nbsp;phone&nbsp;number:</font></td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <ASP:TextBox id="TextBox_emergency_contact_2_phone_number" runat="server" columns="10" maxlength="10" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">
      <ASP:CustomValidator id="CustomValidator_emergency_contact_2_phone_number" runat="server" errormessage="Please enter a valid Emergency contact 2 phone number.  Premium and reserved numbers are not allowed." controltovalidate="TextBox_emergency_contact_2_phone_number" font-bold="True" onservervalidate="CustomValidator_emergency_contact_2_phone_number_ServerValidate" Display="Dynamic">!ERR!</ASP:CustomValidator>
    </td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-right: thin solid Gainsboro; border-left: thin solid Gainsboro" bgcolor="WhiteSmoke"><p><strong>Health information</strong></p></td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">Hepatitis&nbsp;B immunization:</font></td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <ASP:CheckBox id="CheckBox_be_immune_hepatitis_b" runat="server"  cssclass="" enabled="False"></ASP:CheckBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr style="border-right: thin solid Gainsboro; border-left: thin solid Gainsboro">
    <td style="border-left: thin solid Gainsboro"><font class="">Diptheria/tetanus immunization:</font></td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <ASP:CheckBox id="CheckBox_be_immune_diptheria_tetanus" runat="server"  cssclass="" enabled="False"></ASP:CheckBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr style="border-right: thin solid Gainsboro; border-left: thin solid Gainsboro">
    <td style="border-left: thin solid Gainsboro"><font class="">Meds/doses:</font></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_meds_doses" runat="server" columns="72" textmode="MultiLine" rows="2" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">
      <ASP:RegularExpressionValidator id="RegularExpressionValidator_meds_doses" runat="server" errormessage="Please restrict the Meds&nbsp;doses entry to 65535 characters." font-bold="True" controltovalidate="TextBox_meds_doses" validationexpression="^[\s\S]{0,65535}$" Display="Dynamic">!ERR!</ASP:RegularExpressionValidator>
    </td>
  </tr>
  <tr style="border-right: thin solid Gainsboro; border-left: thin solid Gainsboro">
    <td style="border-left: thin solid Gainsboro"><font class="">Allergies:</font></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_allergies" runat="server" columns="72" textmode="MultiLine" rows="2" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">
      <ASP:RegularExpressionValidator id="RegularExpressionValidator_allergies" runat="server" errormessage="Please restrict the Allergies entry to 65535 characters." font-bold="True" controltovalidate="TextBox_allergies" validationexpression="^[\s\S]{0,65535}$" Display="Dynamic">!ERR!</ASP:RegularExpressionValidator>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">PCP&nbsp;name:</font></td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <ASP:TextBox id="TextBox_pcp_name" runat="server" columns="72" maxlength="127" cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-right: thin solid Gainsboro; border-left: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>Driving</strong></p>
      <small>This field should hold the date shown on the practitioner's drivers license.&nbsp; The authority entering this data should keep a copy of the source document in case of audit.</small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">Drivers&nbsp;license&nbsp;expiration date:</font></td>
    <td style="border-bottom: thin solid Gainsboro"><font color="#33CC33">&clubs;</font></td>
    <td style="border-bottom: thin solid Gainsboro"><font color="#3366FF">&diams;</font></td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <table cellpadding="0" cellspacing="0">
          <tr>
            <td><uc1:UserControl_drop_down_date id="UserControl_drop_down_date_drivers_license_expiration" runat="server"  cssclass=""></uc1:UserControl_drop_down_date></td>
            <td>&nbsp;&nbsp;&nbsp;</td>
            <td nowrap="nowrap"><asp:Label ID="Label_expired_drivers_license" runat="server" Font-Bold="True" ForeColor="White" Text="&nbsp;!EXPIRED!&nbsp;" BackColor="#FF9900" ToolTip="This expiration date has passed." Visible="False"></asp:Label></td>
          </tr>
        </table>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>Clearance & background checks</strong></p>
      <small>
        These fields should hold the dates shown on the <asp:HyperLink ID="HyperLink_clearance_forms_web_address" runat="server" Target="_blank" Font-Bold="True">corresponding state documents</asp:HyperLink> indicating
        compliance.&nbsp; The authority entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">PA Child Abuse History Clearance date:</font></td>
    <td valign="top"><font color="#33CC33">&clubs;</font></td>
    <td valign="top"><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <table cellpadding="0" cellspacing="0">
          <tr>
            <td><uc1:UserControl_drop_down_date id="UserControl_drop_down_date_act_1985_33_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date></td>
            <td>&nbsp;&nbsp;&nbsp;</td>
            <td nowrap="nowrap"><asp:Label ID="Label_stale_act_1985_33_date" runat="server" Font-Bold="True" ForeColor="White" Text="&nbsp;!STALE!&nbsp;" BackColor="#FF9900" ToolTip="This date is older than credentialing rules allow." Visible="False"></asp:Label></td>
          </tr>
        </table>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr style="border-left: thin solid Gainsboro; border-right: thin solid Gainsboro">
    <td style="border-left: thin solid Gainsboro" valign="top"><font class="">PA Criminal Record Check date:</font></td>
    <td valign="top"><font color="#33CC33">&clubs;</font></td>
    <td valign="top"><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <table cellpadding="0" cellspacing="0">
          <tr>
            <td><uc1:UserControl_drop_down_date id="UserControl_drop_down_date_act_1985_34_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date></td>
            <td>&nbsp;&nbsp;&nbsp;</td>
            <td nowrap="nowrap"><asp:Label ID="Label_stale_act_1985_34_date" runat="server" Font-Bold="True" ForeColor="White" Text="&nbsp;!STALE!&nbsp;" BackColor="#FF9900" ToolTip="This date is older than credentialing rules allow." Visible="False"></asp:Label></td>
          </tr>
        </table>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro" valign="top"><font class="">FBI Criminal Background Check date:</font></td>
    <td  style="border-bottom: thin solid Gainsboro"valign="top"><font color="#33CC33">&clubs;</font></td>
    <td  style="border-bottom: thin solid Gainsboro"valign="top"><font color="#3366FF">&diams;</font></td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <table cellpadding="0" cellspacing="0">
          <tr>
            <td><uc1:UserControl_drop_down_date id="UserControl_drop_down_date_act_1994_151_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date></td>
            <td>&nbsp;&nbsp;&nbsp;</td>
            <td nowrap="nowrap"><asp:Label ID="Label_stale_act_1994_151_date" runat="server" Font-Bold="True" ForeColor="White" Text="&nbsp;!STALE!&nbsp;" BackColor="#FF9900" ToolTip="This date is older than credentialing rules allow." Visible="False"></asp:Label></td>
          </tr>
        </table>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>National Incident Management System independent study</strong></p>
      <small>
        These fields should hold the dates shown on the corresponding class completion certificates from the
        <strong><a href="http://training.fema.gov/IS/NIMS.aspx" target="_blank">FEMA EMI ISP</a></strong>
        or from
        <strong><a href="https://pa.train.org" target="_blank">TRAIN PA</a></strong>.&nbsp; The authority
        entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        NIMS IS-100 date:
        <br />
        <small>TRAIN PA # 1024632</small>
      </font>
    </td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_is_100_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        NIMS IS-200 date:
        <br />
        <small>TRAIN PA # 1084004</small>
      </font>
    </td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_is_200_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        NIMS IS-700 date:
        <br />
        <small>TRAIN PA # 1078831</small>
      </font>
    </td>
    <td><font color="#33CC33">&clubs;</font></td>
    <td><font color="#3366FF">&diams;</font></td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_is_700_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro">
      <font class="">
        NIMS IS-800 date:
        <br />
        <small>TRAIN PA # 1077604</small>
      </font>
    </td>
    <td style="border-bottom: thin solid Gainsboro"><font color="#33CC33">&clubs;</font></td>
    <td style="border-bottom: thin solid Gainsboro"><font color="#3366FF">&diams;</font></td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_is_800_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>National Incident Management System classroom training</strong></p>
      <small>
        These fields should hold the dates shown on the corresponding class completion certificates.&nbsp; The authority entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro"><font class="">NIMS ICS-300 date:</font></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_ics_300_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro;"><font class="">NIMS ICS-400 date:</font></td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_nims_ics_400_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">Strike Team Leader (E/L 984) date:</font></td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_pa_ems_strike_team_leader_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>Texas A&M Engineering Extension Service (TEEX) training</strong></p>
      <small>
        These fields should hold the dates shown on the corresponding class completion certificates from <strong><a href="https://teex.org" target="_blank">TEEX</a></strong>.&nbsp; The authority entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro">
      <font class="">
        Swiftwater Awareness date:
        <br />
        <small>TEEX# TNG80A</small>
      </font>
    </td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_pa_water_rescue_awareness_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-bottom: thin solid Gainsboro; border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>TRAIN PA training</strong></p>
      <small>
        These fields should hold the dates shown on the corresponding class completion certificates from <strong><a href="https://pa.train.org" target="_blank">TRAIN PA</a></strong>.&nbsp; The authority
        entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        EMS Ops for MCIs date:
        <br />
        <small>TRAIN PA # 1009610</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_ems_mci_ops_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        WMD Awareness date:
        <br />
        <small>TRAIN PA # 1051625</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_wmd_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro">
      <font class="">
        HazMat Awareness date:
        <br />
        <small>TRAIN PA # 1076417</small>
      </font>
    </td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_pa_hazmat_awareness_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-bottom: thin solid Gainsboro; border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        Stress Response During Disasters date:
        <br />
        <small>LMS# 002869</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_disaster_stress_response_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        Smallpox date:
        <br />
        <small>LMS# 003078 or 003077</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_smallpox_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        Basic Medical Response to Terrorism date:
        <br />
        <small>LMS# 002161</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_basic_med_terrorism_response_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro">
      <font class="">
        Electrical Hazards date:
        <br />
        <small>LMS# 003599</small>
      </font>
    </td>
    <td>&nbsp;</td>
    <td>&nbsp;</td>
    <td>
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_electrical_hazards_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro">
      <font class="">
        Biological Terrorism for EMS date:
        <br />
        <small>LMS# 002176</small>
      </font>
    </td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_lms_ems_bioterror_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr><td colspan="5">&nbsp;</td></tr>
  <tr>
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>Pennsylvania continuing education classes</strong></p>
      <small>
        These fields should hold the dates shown on the corresponding class completion certificates.&nbsp; The authority entering this data should keep a copy of the source documents in case of audit.
      </small>
    </td>
  </tr>
  <tr>
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">Psychological First Aid date:</font></td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_pa_psychological_first_aid_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black"><td colspan="5">&nbsp;</td></tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td colspan="5" style="border-top: thin solid Gainsboro; border-left: thin solid Gainsboro; border-right: thin solid Gainsboro" bgcolor="WhiteSmoke">
      <p><strong>Experience</strong></p>
      <small>
        These fields should hold the dates when the corresponding qualification was achieved.
      </small>
    </td>
  </tr>
  <tr runat="server" visible="false" bgcolor="black">
    <td style="border-left: thin solid Gainsboro; border-bottom: thin solid Gainsboro"><font class="">Two years in supervisory role date:</font></td>
    <td style="border-bottom: thin solid Gainsboro">&nbsp;</td>
    <td style="border-bottom: thin solid Gainsboro"><font color="#3366FF">&diams;</font></td>
    <td style="border-bottom: thin solid Gainsboro">
      <font class="">
        <uc1:UserControl_drop_down_date id="UserControl_drop_down_date_two_years_supervisory_experience_date" runat="server"  cssclass=""></uc1:UserControl_drop_down_date>
      </font>
    </td>
    <td nowrap="nowrap" style="border-right: thin solid Gainsboro; border-bottom: thin solid Gainsboro">&nbsp;</td>
  </tr>
      </table>
    </td>
  </tr>
</table>
<ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click" Visible="false"></ASP:Button>&nbsp;&nbsp;<ASP:Button id="Button_delete" text="Delete" runat="server" enabled="False" onclick="Button_delete_Click" Visible="false"></ASP:Button>
