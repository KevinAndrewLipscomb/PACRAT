<!DOCTYPE html>
<!-- Derived from KiAspdotnetFramework/protected/template~protected~nonlanding.aspx~template -->
<%@ Page language="c#" codebehind="strike_team_deployment_detail.aspx.cs" AutoEventWireup="True" Inherits="strike_team_deployment_detail.TWebForm_strike_team_deployment_detail" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<%@ Register TagPrefix="uc3" TagName="UserControl_update_progress_blocker" Src="~/usercontrol/app/UserControl_update_progress_blocker.ascx" %>
<%@ Register src="../usercontrol/app/UserControl_strike_team_deployment.ascx" tagname="UserControl_strike_team_deployment" tagprefix="uc2" %>
<html>
  <head runat="server">
    <title></title>
    <!-- $Id: strike_team_deployment_detail.aspx 7189 2020-05-25 01:22:15Z kevinanlipscomb $ -->
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
  </head>
  <body id="Body_control" runat="server" bgcolor="white">
    <form runat="server" enctype="multipart/form-data">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <h3>Detail for strike team deployment</h3>
      <uc2:UserControl_strike_team_deployment ID="UserControl_strike_team_deployment_control" runat="server" />
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
      <uc3:UserControl_update_progress_blocker id="UserControl_update_progress_blocker_control" runat="server"></uc3:UserControl_update_progress_blocker>
    </form>
  </body>
</html>
