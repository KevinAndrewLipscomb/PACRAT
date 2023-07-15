using Class_biz_scheduled_tasks;
using System;

namespace verify_practitioner_attributes
  {
  public partial class TWebForm_verify_practitioner_attributes: ki_web_ui.page_class
    {
        // / <summary>
        // / Required method for Designer support -- do not modify
        // / the contents of this method with the code editor.
        // / </summary>
        private void InitializeComponent()
        {
        }

        protected void Page_Load(object sender, System.EventArgs e)
        {
            new TClass_biz_scheduled_tasks().VerifyPractitionerAttributes();
        }

        protected override void OnInit(EventArgs e)
        {
            // Required for Designer support
            InitializeComponent();
            base.OnInit(e);
        }

    }

}
