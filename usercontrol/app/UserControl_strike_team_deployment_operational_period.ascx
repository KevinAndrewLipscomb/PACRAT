<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_operational_period.ascx.cs" Inherits="UserControl_strike_team_deployment_operational_period.TWebUserControl_strike_team_deployment_operational_period"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~kicrudhelped~item.ascx-template -->
<%@ Register TagPrefix="uc1" TagName="UserControl_drop_down_date" Src="~/usercontrol/ki/UserControl_drop_down_date.ascx" %>
<%@ Register src="../ki/UserControl_drop_down_datetime.ascx" tagname="UserControl_drop_down_datetime" tagprefix="uc2" %>
<%@ Register src="UserControl_operational_period_detail.ascx" tagname="UserControl_operational_period_detail" tagprefix="uc3" %>
<asp:UpdatePanel ID="UpdatePanel_control" runat="server">
  <ContentTemplate>
<table cellspacing="0" cellpadding="5" width="100%" border="0">
  <tr>
    <td valign="top">
      <table cellspacing="0" cellpadding="5" border="0">
  <tr id="TableRow_navigation" runat="server" visible="false">
    <td bgcolor="gainsboro" valign="top"><font class="">id:</font></td>
    <td valign="top"><font class="">
      <table cellspacing="0" cellpadding="0" border="0">
         <tr>
           <td valign="middle">
             <table cellspacing="0" cellpadding="0" border="0">
               <tr>
                 <td>
      <ASP:TextBox id="TextBox_id" runat="server"  cssclass=""></ASP:TextBox><ASP:Button id="Button_lookup" runat="server" causesvalidation="False" text="LOOKUP" onclick="Button_lookup_Click"></ASP:Button>
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
            <div style="width:0px;white-space:nowrap;"><ASP:DropDownList id="DropDownList_id" runat="server" visible="False" autopostback="True" onselectedindexchanged="DropDownList_id_SelectedIndexChanged"></ASP:DropDownList></div>
          </td>
        </tr>
      </table>
    </font>
    </td>
    <td nowrap="nowrap" valign="top">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_id" runat="server" errormessage="Please enter id." font-bold="True" controltovalidate="TextBox_id" Display="Dynamic">!ERR!</ASP:RequiredFieldValidator>
    </td>
  </tr>
  <tr id="TableRow_id" runat="server" visible="false">
    <td><font class="">Deployment&nbsp;id:</font></td>
    <td>
      <font class="">
        <ASP:TextBox id="TextBox_deployment_id" runat="server"  cssclass="" enabled="False"></ASP:TextBox>
      </font>
    </td>
    <td nowrap="nowrap">
      <ASP:RequiredFieldValidator id="RequiredFieldValidator_deployment_id" runat="server" errormessage="Please enter Deployment&nbsp;id." font-bold="True" controltovalidate="TextBox_deployment_id" Display="Dynamic">!ERR!</ASP:RequiredFieldValidator>
      <ASP:RegularExpressionValidator id="RegularExpressionValidator_deployment_id" runat="server" errormessage="Please enter a valid Deployment&nbsp;id." font-bold="True" controltovalidate="TextBox_deployment_id" validationexpression="-?\d+" Display="Dynamic">!ERR!</ASP:RegularExpressionValidator>
    </td>
  </tr>
  <tr id="TableRow_initial_actions" runat="server" visible="false">
    <td bgcolor="Khaki" colspan="2">
      Instructions:
      <ul>
        <li>In <asp:Literal ID="Literal_application_name" runat="server"></asp:Literal>, there are three kinds of operational periods -- PRELIM, CONVOY, and STANDARD.</li>
        <li>
          <p>
            Create a <i>PRELIM</i> op period template for <u>EACH repeating shift</u> you plan to run during this deployment.&nbsp; For 12-hour shifts, you might create two PRELIM op periods and name them AM
            and PM.&nbsp; For 8-hour shifts, you might create three PRELIM op periods and name them DAY, SWING, and GRAVEYARD.&nbsp; If this deployment is a short drill, you might create just one PRELIM op period and name
            it DURATION.&nbsp; PRELIM op period templates allow Service Strike Team Managers to propose which personnel will work which shifts.
          </p>
        </li>
        <li>
          <p>
            If you are deploying to a distant site, you should also create a <i>CONVOY</i> op period.&nbsp; This allows Service Strike Team Managers to propose which personnel will occupy which vehicles while enroute to or
            from the distant site.
          </p>
        </li>
      </ul>
    </td>
  </tr>
  <tr>
    <td><font class="">Kind:</font></td>
    <td>
      <asp:DropDownList ID="DropDownList_kind" runat="server" AutoPostBack="True" onselectedindexchanged="DropDownList_kind_SelectedIndexChanged">
        <asp:ListItem Value="" Selected="True">-- Select --</asp:ListItem>
        <asp:ListItem Value="PRELIM">PRELIM -- to let Service Strike Team Managers make default shift assignments</asp:ListItem>
        <asp:ListItem Value="CONVOY">CONVOY -- to account for resources on the way to/from deployment base</asp:ListItem>
        <asp:ListItem Value="STANDARD">STANDARD -- to account for resources on duty</asp:ListItem>
      </asp:DropDownList>
      <asp:CheckBox ID="CheckBox_force_overlap" runat="server" Text="Force overlap" Visible="False" Font-Bold="True" />
    </td>
    <td>
      <asp:RequiredFieldValidator ID="RequiredFieldValidator_kind" runat="server" ControlToValidate="DropDownList_kind" ErrorMessage="Please select the Kind of operational period." Font-Bold="True" Display="Dynamic">!ERR!</asp:RequiredFieldValidator>
      <asp:CustomValidator ID="CustomValidator_force_overlap" runat="server" Display="Dynamic" ErrorMessage="The specified start and end times overlap an existing operational period.  You should not normally do this.  Check the 'Force overlap' checkbox to override this error." Font-Bold="True" onservervalidate="CustomValidator_force_overlap_ServerValidate">!ERR!</asp:CustomValidator>
    </td>
  </tr>
  <tr id="TableRow_start" runat="server">
    <td valign="top"><font class="">Start:</font></td>
    <td>
      <uc2:UserControl_drop_down_datetime ID="UserControl_drop_down_datetime_start" runat="server" />
      <table cellspacing="0" cellpadding="10" border="0">
        <tr id="TableRow_start_guidance" runat="server" visible="false" width="100%">
          <td bgcolor="Khaki">
            <strong>NOTE:</strong>&nbsp; If this is the first CONVOY or STANDARD op period of this deployment, the time you specify here is the time that <asp:Literal ID="Literal_application_name_2" runat="server"></asp:Literal> will...
            <ul>
              <li>prohibit you from creating any more PRELIM op periods;</li>
              <li>make this entire deployment READ-ONLY for Service Strike Team Managers.</li>
            </ul>
          </td>
        </tr>
      </table>
    </td>
    <td nowrap="nowrap">
      &nbsp;</td>
  </tr>
  <tr id="TableRow_end" runat="server">
    <td><font class="">End:</font></td>
    <td>
      <uc2:UserControl_drop_down_datetime ID="UserControl_drop_down_datetime_end" runat="server" />
    </td>
    <td nowrap="nowrap">
      &nbsp;</td>
  </tr>
  <tr id="TableRow_prelim_shift_name" runat="server">
    <td valign="top"><font class="">Prelim shift name:</font></td>
    <td>
      <asp:TextBox ID="TextBox_prelim_shift_name" runat="server" Columns="31" MaxLength="31"></asp:TextBox>
      <table cellspacing="0" cellpadding="10" border="0">
        <tr id="TableRow_name_guidance" runat="server" visible="false" width="100%">
          <td bgcolor="Khaki">
            You can only create <i>one</i> operational period at a time using this form.
          </td>
        </tr>
      </table>
    </td>
    <td nowrap="nowrap">
      <asp:RequiredFieldValidator ID="RequiredFieldValidator_prelim_shift_name" runat="server" ControlToValidate="TextBox_prelim_shift_name" Enabled="False" ErrorMessage="Please specify a Preliminary shift name." Font-Bold="True" Display="Dynamic">!ERR!</asp:RequiredFieldValidator>
    </td>
  </tr>
      </table>
    </td>
  </tr>
</table>
<ASP:Button id="Button_submit" text="Submit" runat="server" enabled="False" onclick="Button_submit_Click"></ASP:Button>&nbsp;&nbsp;<ASP:Button id="Button_delete" text="Delete" runat="server" enabled="False" onclick="Button_delete_Click"></ASP:Button>&nbsp;&nbsp;<asp:CustomValidator ID="CustomValidator_chronological_order" runat="server" ErrorMessage="You specified an operational period with a zero or negative duration.  Did you mean to advance the End day by one?" Display="Dynamic" Font-Bold="True" onservervalidate="CustomValidator_chronological_order_ServerValidate">!ERR!</asp:CustomValidator><asp:CustomValidator ID="CustomValidator_uniqueness" runat="server" Display="Dynamic" ErrorMessage="The specified operational period duplicates an existing one in the same deployment." Font-Bold="True" onservervalidate="CustomValidator_uniqueness_ServerValidate">!ERR!</asp:CustomValidator>
<asp:Panel ID="Panel_active_operational_period_detail" runat="server" Visible="false">
  <br />
  <uc3:UserControl_operational_period_detail ID="UserControl_operational_period_detail_control" runat="server" />  
</asp:Panel>
  </ContentTemplate>
</asp:UpdatePanel>
