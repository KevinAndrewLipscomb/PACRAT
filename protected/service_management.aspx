<!DOCTYPE html>
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" codebehind="service_management.aspx.cs" AutoEventWireup="True" Inherits="service_management.TWebForm_service_management" %>
<%@ Register TagPrefix="asp" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit"%>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc3" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<%@ Register Src="~/usercontrol/ki/UserControl_attachment_explorer.ascx" TagPrefix="uc1" TagName="UserControl_attachment_explorer" %>

<html>
  <head runat="server">
    <title></title>
    <!-- $Id: service_management.aspx 7204 2020-05-31 19:25:18Z kevinanlipscomb $ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body id="Body_control" runat="server" bgcolor="white">
    <form runat="server" defaultfocus="TextBox_practitioner">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <asp:UpdatePanel ID="UpdatePanel_overall" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
          <asp:ValidationSummary ID="ValidationSummary_quick_message" runat="server" ValidationGroup="QuickMessage"/>
          <table cellpadding="0" cellspacing="0">
            <tr>
              <td valign="top">
                <asp:Panel ID="Panel_one_at_a_time" runat="server">
                  <table cellpadding="3" cellspacing="0" style="font-size:85%">
                    <tr>
                      <td nowrap="nowrap" bgcolor="Gainsboro">
                        <asp:UpdatePanel ID="UpdatePanel_search_upper" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                            <asp:HiddenField ID="HiddenField_practitioner_saved" runat="server" />
                            <b>Search></b>&nbsp;<asp:TextBox ID="TextBox_practitioner" runat="server" OnTextChanged="TextBox_practitioner_TextChanged" autocomplete="off"></asp:TextBox>
                            <asp:Button ID="Button_add" runat="server" Text="" style="display:none; visibility:hidden" CausesValidation="false" OnClick="Button_add_Click"/>
                            <br />
                            <small><i><asp:Literal ID="Literal_click_to_add" runat="server"></asp:Literal></i></small>
                          </ContentTemplate>
                          <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="ListBox_practitioner" EventName="SelectedIndexChanged" />
                          </Triggers>
                        </asp:UpdatePanel>
                      </td>
                    </tr>
                    <tr>
                      <td align="center" valign="top" bgcolor="Gainsboro">
                        <asp:UpdatePanel ID="UpdatePanel_search_lower" runat="server" UpdateMode="Conditional">
                          <ContentTemplate>
                            <asp:ListBox ID="ListBox_practitioner" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ListBox_practitioner_SelectedIndexChanged" Rows="13" Width="100%"></asp:ListBox>
                          </ContentTemplate>
                          <Triggers>
                            <asp:AsyncPostBackTrigger ControlID="TextBox_practitioner" EventName="TextChanged" />
                            <asp:AsyncPostBackTrigger ControlID="Button_add" EventName="Click" />
                          </Triggers>
                        </asp:UpdatePanel>
                        <small><asp:LinkButton ID="LinkButton_add_associate" runat="server" Visible="false" OnClick="LinkButton_add_associate_Click">Load unlisted practitioner(s) into the system</asp:LinkButton></small>
                      </td>
                    </tr>
                  </table>
                </asp:Panel>
                <br />
                <table align="center">
                  <tr><td colspan="3" align="center" valign="middle">Drill down to</td></tr>
                  <tr>
                    <td align="center" valign="middle"><asp:LinkButton ID="LinkButton_drill_down_to_members" runat="server" onclick="LinkButton_drill_down_to_members_Click" text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Profile&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;&lt;br/&gt;&lt;small&gt;MEMBERS&lt;/small&gt;"></asp:LinkButton></td>
                    <td align="center" valign="middle">or</td>
                    <td align="center" valign="middle"><asp:LinkButton ID="LinkButton_drill_down_to_vehicles" runat="server" onclick="LinkButton_drill_down_to_vehicles_Click" text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Vehicles&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;&lt;br/&gt;&lt;small&gt;VEHICLES&lt;/small&gt;"></asp:LinkButton></td>
                  </tr>
                  <tr><td colspan="3" align="center" valign="middle">in this service's strike team</td></tr>
                </table>
              </td>
              <td>&nbsp;&nbsp;&nbsp;&nbsp;</td>
              <td valign="top">
                <table cellpadding="0" cellspacing="0">
                  <tr>
                    <td>
                      <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro" width="100%">
                        <tr>
                          <td>
                            <table cellpadding="5" cellspacing="0" width="100%">
                              <tr><td colspan="2"><b><asp:Literal ID="Literal_service_name" runat="server"></asp:Literal></b></td></tr>
                              <tr>
                                <td nowrap="nowrap" align="right">Affiliate #:</td>
                                <td>
                                  <table cellpadding="0" cellspacing="0" width="100%">
                                    <tr>
                                      <td><asp:Literal ID="Literal_affiliate_num" runat="server"></asp:Literal></td>
                                      <td align="right">
                                        <asp:HyperLink ID="HyperLink_print_roster" runat="server" Target="_blank" text="&lt;IMG src=&quot;image/print16_h.png&quot; alt=&quot;Print roster&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;"></asp:HyperLink>
                                      </td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                              <tr>
                                <td align="right" nowrap="nowrap" valign="top">Strike Team participation:</td>
                                <td valign="top">
                                  <table>
                                    <tr>
                                      <td valign="top">
                                        <asp:DropDownList ID="DropDownList_strike_team_participation" runat="server" AutoPostBack="True" oncheckedchanged="DropDownList_strike_team_participation_CheckedChanged" Enabled="False" OnSelectedIndexChanged="DropDownList_strike_team_participation_SelectedIndexChanged" />
                                      </td>
                                      <td><small><asp:Literal ID="Literal_strike_team_participation_elaboration" runat="server"></asp:Literal></small></td>
                                    </tr>
                                  </table>
                                </td>
                              </tr>
                              <tr>
                                <td align="right" nowrap="nowrap"><font class="">Service short name:</font></td>
                                <td>
                                  <asp:TextBox runat="server" columns="31" maxlength="31" id="TextBox_short_name" enabled="False"></asp:TextBox>
                                  <asp:Button ID="Button_save_short_name" runat="server" OnClick="Button_save_short_name_Click" Text="&larr;Save" Visible="False" />
                                  <asp:RequiredFieldValidator runat="server" controltovalidate="TextBox_short_name" errormessage="Under the Basic ID tab, please enter Service short name." font-bold="True" id="RequiredFieldValidator_short_name">!ERR!</asp:RequiredFieldValidator>
                                  <asp:CustomValidator ID="CustomValidator_short_name" runat="server" font-bold="True" ErrorMessage="The specified Service short name is already in use by " onservervalidate="CustomValidator_short_name_ServerValidate">!ERR!</asp:CustomValidator>
                                </td>
                              </tr>
                              <tr bgcolor="khaki">
                                <td align="right" valign="top"><font class=""><small><b>IMPORTANT:</b></small></font></td>
                                <td valign="top">
                                  <font class="">
                                    <small>
                                      <b>
                                        Keep the Service Short Name as short as possible without allowing it to be confused with other services in your region.&nbsp; It should generally reflect the way people refer to the service in
                                        very casual conversation amongst EMS personnel.&nbsp; Applications may use the short name in SMS messages and screen displays where excessive length will cause problems.&nbsp; For instance, leave
                                        out "Ambulance Service", "Bureau of", "City of", "Department", "EMS", "Hose Company", "Inc.", "VFD", etc.&nbsp; Abbreviate "Township" to "Twp".&nbsp; Include "Ambulance", "Fire", or "EMS" only if it
                                        prevents confusion in your region.&nbsp; "By way of example, the short name for "Kempsville Volunteer Rescue Squad Inc." should simply be "Kempsville".
                                      </b>
                                    </small>
                                  </font>
                                </td>
                              </tr>
                              <tr>
                                <td align="right" valign="top"><font class="">Memorandum Of Agreement material:</font></td>
                                <td><uc1:UserControl_attachment_explorer runat="server" ID="UserControl_attachment_explorer_control" enabled="false"/></td>
                              </tr>
                            </table>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr><td>&nbsp;</td></tr>
                  <tr>
                    <td>
                      <table cellpadding="0" cellspacing="0" style="border:1px solid Gainsboro">
                        <tr>
                          <td>
                            <asp:UpdatePanel ID="UpdatePanel_assignees" runat="server" UpdateMode="Conditional">
                              <ContentTemplate>
                                <table cellpadding="10" cellspacing="0">
                                  <tr bgcolor="#99CCFF"><td><b>SERVICE-level Officers</b></td></tr>
                                  <tr id="TableRow_none" runat="server" bgcolor="#99CCFF"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
                                  <tr id="TableRow_assignees" runat="server" bgcolor="#99CCFF">
                                    <td valign="top">
                                      <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="5" autogeneratecolumns="False" allowsorting="True" onsortcommand="DataGrid_control_SortCommand" onitemdatabound="DataGrid_control_ItemDataBound" oncancelcommand="DataGrid_control_CancelCommand" ondeletecommand="DataGrid_control_DeleteCommand" oneditcommand="DataGrid_control_EditCommand" onupdatecommand="DataGrid_control_UpdateCommand" Font-Size="85%" BackColor="White" onitemcommand="DataGrid_control_ItemCommand">
                                        <Columns>
                                          <asp:BoundColumn datafield="be_credentialed" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/dialog-warning-2.png&quot; alt=&quot;Uncredentialed&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Profile"></asp:ButtonColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Profile&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Profile"></asp:ButtonColumn>
                                          <asp:TemplateColumn HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" Visible="False">
                                            <HeaderTemplate>
                                              <small>Include in<br />QuickMessage</small><br /> All:<asp:CheckBox ID="CheckBox_force_all" runat="server" AutoPostBack="True" oncheckedchanged="CheckBox_force_all_CheckedChanged" style="outline:2px solid SlateGray" ToolTip="Select/Unselect all" Checked="True" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                              <asp:CheckBox ID="CheckBox_selected" runat="server" Checked="True" AutoPostBack="True" />
                                            </ItemTemplate>
                                            <HeaderStyle HorizontalAlign="Center" />
                                            <ItemStyle HorizontalAlign="Center" />
                                          </asp:TemplateColumn>
                                          <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete" Visible="False"></asp:ButtonColumn>
                                          <asp:BoundColumn datafield="practitioner_id" Visible="false" ReadOnly="True"></asp:BoundColumn>
                                          <asp:BoundColumn datafield="last_name" headertext="Last name" sortexpression="last_name%,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc"></asp:BoundColumn>
                                          <asp:BoundColumn datafield="first_name" headertext="First name" sortexpression="first_name%,last_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc"></asp:BoundColumn>
                                          <asp:BoundColumn datafield="middle_initial"></asp:BoundColumn>
                                          <asp:BoundColumn DataField="level_id" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="Level" SortExpression="practitioner_level.pecking_order%,last_name,first_name,middle_initial,certification_number,birth_date desc">
                                            <ItemTemplate><asp:Label ID="Label_level" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.level_short_description") %>'></asp:Label></ItemTemplate>
                                            <EditItemTemplate>
                                              <asp:DropDownList ID="DropDownList_level" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <ItemStyle Wrap="false" />
                                          </asp:TemplateColumn>
                                          <asp:BoundColumn datafield="certification_number_for_display" headertext="Cert#" sortexpression="certification_number%,last_name,first_name,middle_initial,practitioner_level.pecking_order,birth_date desc" ReadOnly="True"></asp:BoundColumn>
                                          <asp:BoundColumn DataField="be_birth_date_confirmed" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="DOB" SortExpression="birth_date%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number">
                                            <ItemTemplate><asp:Label ID="Label_dob" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.birth_date") %>'></asp:Label></ItemTemplate>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="TextBox_dob" runat="server" Columns="9" MaxLength="10" Text='<%# DataBinder.Eval(Container, "DataItem.birth_date") %>' enabled="false"></asp:TextBox>
                                              <asp:RequiredFieldValidator ID="RequiredFieldValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a Birth date." Font-Bold="True" >!ERR!</asp:RequiredFieldValidator>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a valid Birth date using the m/d/yyyy format." Font-Bold="True" ValidationExpression="\d{1,2}[-/]\d{1,2}[-/]\d{4}">!ERR!</asp:RegularExpressionValidator>
                                              <asp:CustomValidator ID="CustomValidator_dob" runat="server" ControlToValidate="TextBox_dob" Display="Dynamic" ErrorMessage="Please enter a valid Birth date consistent with an age of 16-130 years." Font-Bold="True" onservervalidate="CustomValidator_dob_ServerValidate">!ERR!</asp:CustomValidator>
                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_dob" runat="server" TargetControlID="TextBox_dob" WatermarkText="m/d/yyyy" WatermarkCssClass="textbox_watermark"></asp:TextBoxWatermarkExtender>
                                            </EditItemTemplate>
                                          </asp:TemplateColumn>
                                          <asp:BoundColumn DataField="role_id" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                          <asp:TemplateColumn HeaderText="Role" SortExpression="role.pecking_order%,last_name,first_name,middle_initial,certification_number,birth_date desc">
                                            <ItemTemplate><asp:Label ID="Label_role" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.role_name") %>'></asp:Label></ItemTemplate>
                                            <EditItemTemplate>
                                              <asp:DropDownList ID="DropDownList_role" runat="server"></asp:DropDownList>
                                            </EditItemTemplate>
                                            <HeaderStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                            <ItemStyle Font-Bold="False" Font-Italic="False" Font-Overline="False" Font-Strikeout="False" Font-Underline="False" HorizontalAlign="Center" />
                                          </asp:TemplateColumn>
                                          <asp:TemplateColumn HeaderText="Email address" SortExpression="email_address%,last_name,first_name,middle_initial,practitioner_level.pecking_order,certification_number,birth_date desc">
                                            <ItemTemplate><asp:Label ID="Label_email_address" runat="server" Text='<%# DataBinder.Eval(Container, "DataItem.email_address") %>'></asp:Label></ItemTemplate>
                                            <EditItemTemplate>
                                              <asp:TextBox ID="TextBox_email_address" runat="server" Columns="15" MaxLength="127" Text='<%# DataBinder.Eval(Container, "DataItem.email_address") %>'></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="RegularExpressionValidator_email_address" runat="server" ControlToValidate="TextBox_email_address" Display="Dynamic" ErrorMessage="Please enter a valid Email address." Font-Bold="True" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*">!ERR!</asp:RegularExpressionValidator>
                                              <asp:CustomValidator ID="CustomValidator_email_address" runat="server" ControlToValidate="TextBox_email_address" Display="Dynamic" ErrorMessage='Please enter an Email address with a valid Domain Name (the part after the "@").' Font-Bold="True" onservervalidate="CustomValidator_email_address_ServerValidate">!ERR!</asp:CustomValidator>
                                              <asp:TextBoxWatermarkExtender ID="TextBoxWatermarkExtender_email_address" runat="server" TargetControlID="TextBox_email_address" WatermarkText="user@domain.tld" WatermarkCssClass="textbox_watermark"></asp:TextBoxWatermarkExtender>
                                            </EditItemTemplate>
                                          </asp:TemplateColumn>
                                          <asp:EditCommandColumn CancelText="&lt;IMG src=&quot;~/protected/image/edit-undo-8.png&quot; alt=&quot;Cancel&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" EditText="&lt;IMG src=&quot;~/protected/image/draw_freehand_16_h.png&quot; alt=&quot;Edit&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" UpdateText="&lt;IMG src=&quot;~/protected/image/document-save-5.png&quot; alt=&quot;Update&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" Visible="False">
                                            <ItemStyle Wrap="false" />
                                          </asp:EditCommandColumn>
                                          <asp:BoundColumn DataField="practitioner_status_description" ReadOnly="True" Visible="false"></asp:BoundColumn>
                                        </Columns>
                                        <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                                      </asp:DataGrid>
                                    </td>
                                  </tr>
                                  <tr>
                                    <td>
                                      <asp:Label ID="Label_noncurrent_practitioner_on_roster" runat="server" Text="*This roster includes at least one non-current practitioner." BackColor="Gold" Font-Bold="True" Font-Italic="True" Font-Size="Small" Visible="False"></asp:Label>
                                    </td>
                                  </tr>
                                </table>
                              </ContentTemplate>
                              <Triggers>
                                <asp:AsyncPostBackTrigger ControlID="Button_add" EventName="Click" />
                                <asp:AsyncPostBackTrigger ControlID="ListBox_practitioner" EventName="SelectedIndexChanged" />
                              </Triggers>
                            </asp:UpdatePanel>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                  <tr><td>&nbsp;</td></tr>
                  <tr id="TableRow_quickmessage" runat="server" visible="false">
                    <td>
                      <table cellspacing="0" cellpadding="0" style="border:1px solid Gainsboro">
                        <tr>
	                        <td>
	                          <table cellspacing="0" cellpadding="10" border="0">
		                          <tr><td bgcolor="#f5f5f5"><a id="QuickMessage"><strong>QuickMessage</strong></a></td></tr>
		                          <tr>
			                          <td>
                                  <p>Send email to the assignees selected above.</p>
			                            <table cellspacing="0" cellpadding="10" width="100%" border="0">
                                    <tr>
                                      <td>Bcc:</td>
                                      <td><ASP:Literal id="Literal_author_email_address" runat="server"></ASP:Literal></td>
                                      <td></td>
                                    </tr>
				                            <tr>
					                            <td>Subject:</td>
					                            <td><ASP:TextBox id="TextBox_quick_message_subject" runat="server" maxlength="255" columns="72"></ASP:TextBox></td>
					                            <td></td>
				                            </tr>
				                            <tr>
					                            <td valign="top">Body:</td>
					                            <td><ASP:TextBox id="TextBox_quick_message_body" runat="server" columns="72" rows="18" textmode="MultiLine"></ASP:TextBox></td>
					                            <td nowrap="nowrap" valign="top">
                                        <ASP:RequiredFieldValidator id="RequiredFieldValidator_quick_message_body" runat="server" errormessage="Please enter a message body." font-bold="True" controltovalidate="TextBox_quick_message_body" ValidationGroup="QuickMessage">!ERR!</ASP:RequiredFieldValidator>
                                      </td>
				                            </tr>
				                            <tr>
					                            <td></td>
					                            <td>
                                        <asp:UpdatePanel ID="UpdatePanel_send_button" runat="server" UpdateMode="Conditional">
                                          <ContentTemplate>
                                            <ASP:Button id="Button_send" runat="server" text="Send" onclick="Button_send_Click" ValidationGroup="QuickMessage"></ASP:Button>
                                          </ContentTemplate>
                                          <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="DataGrid_control" EventName="ItemCommand" />
                                          </Triggers>
                                        </asp:UpdatePanel>
                                      </td>
					                            <td></td>
				                            </tr>
			                            </table>
                                </td>
  		                        </tr>
	                          </table>
                          </td>
                        </tr>
                      </table>
                    </td>
                  </tr>
                </table>
              </td>
            </tr>
          </table>
        </ContentTemplate>
        <Triggers>
          <asp:AsyncPostBackTrigger ControlID="DropDownList_strike_team_participation" EventName="SelectedIndexChanged" />
          <asp:PostBackTrigger ControlID="UserControl_attachment_explorer_control" />
        </Triggers>
      </asp:UpdatePanel>
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc3:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc3:UserControl_update_progress_blocker>
    </form>
  </body>
</html>