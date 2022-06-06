using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ACC
{
    public partial class MySiteNoMenu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void btnLangImg_Click(object sender, EventArgs e)
        {
         //   Response.Cookies.Add(new HttpCookie("Lang", btnLangImg.ToolTip.ToString()));
            Response.Redirect(Request.Url.PathAndQuery);
        }
    }
}