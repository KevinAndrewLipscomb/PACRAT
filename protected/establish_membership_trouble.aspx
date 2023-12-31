<!DOCTYPE html>
<%@ Page language="c#" codebehind="establish_membership_trouble.aspx.cs" AutoEventWireup="True" Inherits="establish_membership_trouble.TWebForm_establish_membership_trouble" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_precontent" Src="~/usercontrol/app/UserControl_precontent.ascx" %>
<%@ Register TagPrefix="uc1" TagName="UserControl_postcontent" Src="~/usercontrol/app/UserControl_postcontent.ascx" %>
<html>
  <head runat="server">
    <title></title>
    <link href="../css/standard.css" rel="stylesheet" type="text/css" />
    <!--[if lt IE 7]> <style type="text/css">@import "../css/standard-overrides-for-ie6.css";</style><![endif]-->
    <!-- $Id: establish_membership_trouble.aspx 7189 2020-05-25 01:22:15Z kevinanlipscomb $ -->
  </head>
  <body bgcolor="white">
    <form runat="server">
      <uc1:UserControl_precontent id="UserControl_precontent" runat="server"></uc1:UserControl_precontent>
      <p>
        <table bordercolor="#dcdcdc" cellspacing="0" cellpadding="0" border="1">
          <tr>
            <td>
              <table cellspacing="0" cellpadding="10" border="0">
                <tr>
                  <td bgcolor="#f5f5f5"><strong>Report trouble establishing membership</strong></td>
                </tr>
                <tr>
                  <td>
                    <p>
                      <table cellspacing="0" cellpadding="10" border="0">
                        <tr>
                          <td>
                            <p>Enter your full name:</p>
                            <blockquote>
                              <p><ASP:TextBox id="TextBox_full_name" runat="server" columns="40"></ASP:TextBox></p>
                            </blockquote>
                          </td>
                          <td valign="top" nowrap="nowrap">
                            <ASP:RequiredFieldValidator id="RequiredFieldValidator_full_name" runat="server" errormessage="Please enter your full name." font-bold="True" controltovalidate="TextBox_full_name">!ERR!</ASP:RequiredFieldValidator>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <p>If you have some idea why <ASP:Label id="Label_sponsor_1" runat="server"></ASP:Label>&nbsp;may not have correct data on file for you, please explain:</p>
                            <blockquote>
                              <p><ASP:TextBox id="TextBox_explanation" runat="server" columns="72" rows="7" textmode="MultiLine"></ASP:TextBox></p>
                            </blockquote>
                          </td>
                          <td valign="top" nowrap="nowrap">
                            <ASP:RequiredFieldValidator id="RequiredFieldValidator_explanation" runat="server" errormessage="Please enter an explanation." font-bold="True" controltovalidate="TextBox_explanation">!ERR!</ASP:RequiredFieldValidator>
                          </td>
                        </tr>
                        <tr>
                          <td>
                            <p>Both of the following must occur before you can use <ASP:Label id="Label_application_name_1" runat="server"></ASP:Label>:</p>
                            <ul>
                              <li><p>A&nbsp;liaison from <ASP:Label id="Label_sponsor_2" runat="server"></ASP:Label>&nbsp;will advise you how to get your membership record updated.</p></li>
                              <li><p>The <ASP:Label id="Label_application_name_2" runat="server"></ASP:Label>&nbsp;Application Administrator will advise you when to log into <ASP:Label id="Label_application_name_3" runat="server"></ASP:Label>&nbsp;again.</p></li>
                            </ul>
                            <p>
                              <ASP:Button id="Button_submit" runat="server" text="Send message and LOG OUT" onclick="Button_submit_Click"></ASP:Button>&nbsp;&nbsp;&nbsp;&nbsp;
                              <asp:Button id="Button_cancel" runat="server" text="Cancel" causesvalidation="False" onclick="Button_cancel_Click"></asp:Button>
                            </p>
                          </td>
                          <td></td>
                        </tr>
                      </table>
                    </p>
                  </td>
                </tr>
              </table>
            </td>
          </tr>
        </table>
      </p>
      <uc1:UserControl_postcontent id="UserControl_postcontent" runat="server"></uc1:UserControl_postcontent>
    </form>
  </body>
</html>
