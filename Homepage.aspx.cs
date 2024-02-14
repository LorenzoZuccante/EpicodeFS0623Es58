using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CinemaAdmin
{
    public partial class Homepage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connessione = ConfigurationManager.ConnectionStrings[DbConnection]
        }

        protected void PrenotaBtn_Click(object sender, EventArgs e)
        {

        }
    }
}