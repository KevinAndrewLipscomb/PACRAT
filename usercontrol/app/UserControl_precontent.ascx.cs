using Class_db__information_schema;
using kix;
using System;
using System.Configuration;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Security;

namespace UserControl_precontent
{
    public partial class TWebUserControl_precontent: ki_web_ui.usercontrol_class
    {
        protected void Page_Load(object sender, System.EventArgs e)
        {
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetNoStore();
            Response.Cache.AppendCacheExtension("must-revalidate");
            Response.Cache.SetMaxAge(TimeSpan.Zero);
            //
            if (!IsPostBack)
            {
                Label_application_name.Text = ConfigurationManager.AppSettings["application_name"];
                if (Session["username"] == null)
                {
                    TableRow_account_control.Visible = false;
                }
                else
                {
                    Label_username.Text = Session["username"].ToString();
                }
            }

        }

        protected override void OnInit(System.EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);

        }

        private void ScriptManager_control_AsyncPostBackError(object sender, System.Web.UI.AsyncPostBackErrorEventArgs e)
        {
            //
            // NOTE that this is one of TWO places in the application that k.EscalatedException gets called.  The other place is in ~/exception.aspx.cs Page_Load().  Consider keeping them relatively consistent.
            //
            var engine_innodb_status = k.EMPTY;
            var cause = k.alert_cause_type.LOGIC;
            var key = "xparposbac";
            var alert_message_value = "OOPS!" + k.NEW_LINE
            + k.NEW_LINE
            + "The application encountered an unexpected error." + k.NEW_LINE
            + k.NEW_LINE
            + "The Application Administrator has been notified by pager and email.";
            //
            if
              (
                e.Exception.ToString().Contains("Validation of viewstate MAC failed.")              
              ||
                e.Exception.ToString().Contains("Failed to load viewstate.  The control tree into which viewstate is being loaded must match")
              ||
                e.Exception.ToString().Contains("The state information is invalid for this page and might be corrupted.")
              ||
                e.Exception.ToString().Contains("A potentially dangerous Request.QueryString value was detected from the client")
              )
              {
              cause = k.alert_cause_type.OTHER;
              key = "ppbvwsterr";
              alert_message_value = "To continue, please use your browser's Page Refresh/Reload feature after dismissing this message.";
              }
            else if (Regex.IsMatch(e.Exception.ToString(),"A potentially dangerous Request.* value was detected from the client", RegexOptions.IgnoreCase))
              {
              cause = k.alert_cause_type.USER;
              key = "pdangreqval";
              alert_message_value = "HOLD ON..." + k.NEW_LINE
              + k.NEW_LINE
              + "You entered something that resembles a hacking attempt." + k.NEW_LINE
              + k.NEW_LINE
              + "For security reasons, you are not allowed to input the following special character combinations into this system:" + k.NEW_LINE
              + k.NEW_LINE
              + k.SPACE + k.SPACE + " <       (XML/HTML tag start token)" + k.NEW_LINE
              + k.NEW_LINE
              + k.SPACE + k.SPACE + "&#       (XML/HTML numeric character reference)" + k.NEW_LINE;
              }
            else if (!e.Exception.ToString().Contains("The client disconnected."))
              {
              if (e.Exception.ToString().Contains("Deadlock found when trying to get lock; try restarting transaction"))
                {
                engine_innodb_status = new TClass_db__information_schema().EngineInnodbStatus();
                cause = k.alert_cause_type.DBMS;
                key = "deadlock";
                alert_message_value = "DEADLOCK!" + k.NEW_LINE
                + k.NEW_LINE
                + "The application's database subsystem had to abort your operation to relieve a deadlock." + k.NEW_LINE
                + k.NEW_LINE
                + "You and another user (or process) tried to access the same server data at the same time in an incompatible way." + k.NEW_LINE
                + k.NEW_LINE
                + "Please close and re-open your browser, log back in, and try again.";
                }
              else if
                (
                  Regex.IsMatch(e.Exception.ToString(), "Connection.*to MySQL server", RegexOptions.IgnoreCase)
                ||
                  e.Exception.ToString().Contains("Connection open failed. Too many connections")
                ||
                  e.Exception.ToString().Contains("Unable to connect to any of the specified MySQL hosts.")
                ||
                  e.Exception.ToString().Contains("No connection could be made because the target machine actively refused it 127.0.0.1:3306")
                )
                {
                cause = k.alert_cause_type.DBMS;
                key = "dbmsdown";
                alert_message_value = "SORRY!" + k.NEW_LINE
                + k.NEW_LINE
                + "The application's database subsystem is unavailable." + k.NEW_LINE
                + k.NEW_LINE
                + "This is a temporary condition.  Please try again later.";
                }
              k.EscalatedException
                (
                the_exception:e.Exception,
                user_identity_name:HttpContext.Current.User.Identity.Name + (HttpContext.Current.User.Identity.Name.Length > 0 ? k.SPACE : k.EMPTY) + "from " + Request.UserHostAddress + k.SPACE + "(" + k.DomainNameOfIpAddress(Request.UserHostAddress) + ")",
                session:Session,
                engine_innodb_status:engine_innodb_status
                );
              }
            ScriptManager_control.AsyncPostBackErrorMessage = APP_HANDLED_ASYNC_POST_BACK_ERROR_MESSAGE_MARK + AlertMessage
              (
              cause:cause,
              state:k.alert_state_type.FAILURE,
              key:key,
              value:alert_message_value
              );
            Server.ClearError();
        }

        protected void LinkButton_change_email_address_Click(object sender, System.EventArgs e)
        {
            DropCrumbAndTransferTo(k.ExpandTildePath("~/protected/change_email_address.aspx"));
        }

        protected void LinkButton_change_password_Click(object sender, System.EventArgs e)
        {
            DropCrumbAndTransferTo(k.ExpandTildePath("~/protected/change_password.aspx"));
        }

        protected void LinkButton_logout_Click(object sender, System.EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.Clear();
            Session.Abandon();
            Server.Transfer(k.ExpandTildePath("~/Default.aspx"));
        }

        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
            ScriptManager_control.AsyncPostBackError += ScriptManager_control_AsyncPostBackError;
        }

    } // end TWebUserControl_precontent

}
