<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_preparation_binder.ascx.cs" Inherits="UserControl_preparation_binder.TWebUserControl_preparation_binder"%>
<!-- Derived from KiAspdotnetFramework/usercontrol/app/UserControl~template~binder.ascx-template -->
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" border="0" width="100%">
      <tr>
        <td>
          <cc1:TabContainer id="TabContainer_control" runat="server" autopostback="True" cssclass="ajax__tab_ki" CssTheme="None">
            <cc1:TabPanel runat="server" headertext="Service" id="TabPanel_service"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Region" id="TabPanel_region"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="State" id="TabPanel_state"></cc1:TabPanel>
          </cc1:TabContainer>
        </td>
      </tr>
      <tr>
        <td class="ki_tab_body">
          <ASP:PlaceHolder id="PlaceHolder_content" runat="server"></ASP:PlaceHolder>
        </td>
      </tr>
    </table>
  </ContentTemplate>
</asp:UpdatePanel>