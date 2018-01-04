using System;
using System.Web.UI;
using ConferenceTrackManagement;

namespace ConferenceTracker
{
    public partial class _Default : Page
    {
        ConferenceTrackerManagement ConfTrackMangObj = new ConferenceTrackerManagement();
        private bool bInputFound = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnRunManager_Click(object sender, EventArgs e)
        {
            string sresult = "";
            if (userInput.Text != string.Empty)
            {
                string[] inputext = userInput.Text.Split(new[] { "\r\n", "\r", "\n" }, StringSplitOptions.None);
                if(inputext!=null)
                {
                    bInputFound = true;
                    sresult = ConfTrackMangObj.RunTrackerCode(bInputFound, inputext);
                    sResultTextBox.Text = sresult;
                }
            }
        }
    }
}