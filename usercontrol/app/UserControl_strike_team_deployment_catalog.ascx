<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_strike_team_deployment_catalog.ascx.cs" Inherits="UserControl_strike_team_deployment_catalog.TWebUserControl_strike_team_deployment_catalog"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~datagrid~sortable.ascx-template -->
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
      <tr>
        <td>
          <table cellspacing="0" cellpadding="10" border="0">
            <tr>
              <td bgcolor="#dcdcdc">
                <table cellspacing="0" cellpadding="0" border="0">
                  <tr>
                    <td><strong>Filter:&nbsp;<asp:DropDownList id="DropDownList_filter" runat="server" autopostback="True"></asp:DropDownList></strong></td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td align="right"><asp:Literal ID="Literal_num_strike_team_deployments" runat="server"></asp:Literal> strike team deployments</td>
                    <td>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
                    <td><asp:LinkButton ID="LinkButton_add" runat="server" Font-Bold="True" onclick="LinkButton_new_Click" Visible="False">NEW</asp:LinkButton></td>
                  </tr>
                </table>
              </td>
            </tr>
            <tr id="TableRow_none" runat="server"><td><em>--&nbsp;NONE&nbsp;--</em></td></tr>
            <tr>
              <td>
                <table id="Table_hint" runat="server" cellpadding="10" cellspacing="0" visible="false">
                  <tr>
                    <td bgcolor="Khaki">
                      <asp:Literal ID="Literal_aplication_name" runat="server"></asp:Literal> will automatically mark a deployment Concluded when its last operational period has ended.
                    </td>
                  </tr>
                </table>
                <asp:DataGrid id="DataGrid_control" runat="server" gridlines="Horizontal" cellpadding="10" autogeneratecolumns="False" allowsorting="True" ondeletecommand="DataGrid_control_DeleteCommand" Width="100%">
                  <Columns>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/open_document16_h.png&quot; alt=&quot;Detail&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Select"></asp:ButtonColumn>
                    <asp:BoundColumn datafield="id" Visible="false"></asp:BoundColumn>
                    <asp:BoundColumn datafield="creation_date" headertext="Created" sortexpression="creation_date%,name"></asp:BoundColumn>
                    <asp:BoundColumn datafield="name" headertext="Name" sortexpression="name%,creation_date"></asp:BoundColumn>
                    <asp:ButtonColumn CommandName="Select" DataTextField="status" HeaderText="Status" Text="Select" SortExpression="status%,creation_date,name">
                      <HeaderStyle HorizontalAlign="Center" />
                      <ItemStyle HorizontalAlign="Center" />
                    </asp:ButtonColumn>
                    <asp:ButtonColumn text="&lt;IMG src=&quot;~/protected/image/delete_x16_h.png&quot; alt=&quot;Delete&quot; border=&quot;0&quot; height=&quot;16&quot; width=&quot;16&quot; /&gt;" commandname="Delete" Visible="false"></asp:ButtonColumn>
                  </Columns>
                  <HeaderStyle backcolor="WhiteSmoke"></HeaderStyle>
                </asp:DataGrid>
              </td>
            </tr>
          </table>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>
