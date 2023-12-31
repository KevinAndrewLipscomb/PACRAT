<%@ Control Language="c#" AutoEventWireup="True" Codebehind="UserControl_member_binder.ascx.cs" Inherits="UserControl_member_binder.TWebUserControl_member_binder"%>
<%@ Register TagPrefix="cc1" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit" %>
<asp:UpdatePanel id="UpdatePanel_control" runat="server" updatemode="Conditional">
  <ContentTemplate>
    <table cellspacing="0" cellpadding="0" width="100%" border="0">
      <tr>
        <td>
          <cc1:TabContainer id="TabContainer_control" runat="server" autopostback="True" cssclass="ajax__tab_ki" CssTheme="None">
            <cc1:TabPanel runat="server" headertext="My profile" id="TabPanel_member_profile"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Preparation" enabled="false" id="TabPanel_preparation"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Coordination" enabled="false" id="TabPanel_coordination"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="Config" id="TabPanel_config"></cc1:TabPanel>
            <cc1:TabPanel runat="server" headertext="About" id="TabPanel_about"></cc1:TabPanel>
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
