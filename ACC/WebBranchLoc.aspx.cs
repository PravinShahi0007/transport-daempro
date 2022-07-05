using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;
using System.Globalization;
using BLL;

namespace ACC
{
    public partial class WebBranchLoc : System.Web.UI.Page
    {
        public string[] vBranch = {"","فرع النسيم",
                                      "فرع الشفا",
                                      "فرع الدمام",
                                      "فرع شمال جدة",
                                      "فرع جنوب جدة",
                                      "فرع المدينة",
                                      "فرع الطائف",
                                      "فرع أبها",
                                      "فرع بريدة",
                                      "فرع تبوك",
                                      "فرع القريات",
                                      "فرع الحفر"};
        public string[] vLat = {"",@"http://bit.ly/1osch0b",
                                      @"http://bit.ly/221JZH3",
                                      @"http://bit.ly/221KnFj",
                                      @"http://bit.ly/1RxgDPg",
                                      @"http://bit.ly/1pWDARk",
                                      @"http://bit.ly/30vPnLO",
                                      @"http://bit.ly/1UBgk8o",
                                      @"http://bit.ly/3LP4qFc",     // https://bit.ly/3pgbzEw",
                                      @"http://bit.ly/231ZjJr",
                                      @"http://bit.ly/35mHFoC",
                                      @"http://bit.ly/1ZW3bXg",
                                      @"http://bit.ly/1RGj7rf"};
        public string AreaNo
        {
            get
            {
                if (ViewState["AreaNo"] == null)
                {
                    ViewState["AreaNo"] = "00001";
                }
                return ViewState["AreaNo"].ToString();
            }
            set { ViewState["AreaNo"] = value; }
        }
        public string StoreNo
        {
            get
            {
                if (ViewState["StoreNo"] == null)
                {
                    ViewState["StoreNo"] = "1";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
        }

        protected override void InitializeCulture()
        {
            HttpCookie cultureCookie = Request.Cookies["Lang"];
            String Lang = (cultureCookie != null) ? cultureCookie.Value : null;
            if (!string.IsNullOrEmpty(Lang))
            {
                String selectedLanguage = Lang;
                UICulture = selectedLanguage;
                Culture = selectedLanguage;

                Thread.CurrentThread.CurrentCulture =
                    CultureInfo.CreateSpecificCulture(selectedLanguage);
                Thread.CurrentThread.CurrentUICulture = new
                    CultureInfo(selectedLanguage);
            }
            CultureInfo newCulture = (CultureInfo)System.Threading.Thread.CurrentThread.CurrentCulture.Clone();
            newCulture.NumberFormat.CurrencyDecimalDigits = 2;
            newCulture.NumberFormat.NumberNegativePattern = 0;
            newCulture.NumberFormat.CurrencyNegativePattern = 0;
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            Thread.CurrentThread.CurrentCulture = newCulture;
            Thread.CurrentThread.CurrentUICulture = newCulture;
            base.InitializeCulture();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["AreaNo"] != null) AreaNo = Request.QueryString["AreaNo"].ToString();
                else
                {
                    if (Session["AreaNo"] != null) AreaNo = Session["AreaNo"].ToString();
                }

                if (Request.QueryString["StoreNo"] != null) StoreNo = Request.QueryString["StoreNo"].ToString();
                else
                {
                    if (Session["StoreNo"] == null) Session["StoreNo"] = 1;
                    StoreNo = Session["StoreNo"].ToString();
                }
            }
            else
            {
                for (int i = 1; i < 14; i++)
                {
                    if (Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != null && Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != "" && Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] != "لقد تم الارسال بنجاح")
                    {
                        string txt = Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()];
                        sms.SendMessage("شكرا لتعاملك مع ناقلات البرية موقع " + vBranch[i] + " " + vLat[i], "naqelat", "966" + txt.Substring(1, 9));
                      //  Request.Form["ctl00$ContentPlaceHolder1$txtMobileNo" + i.ToString()] = "لقد تم الارسال بنجاح";
                    }
                }
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BtnSend1_Click(object sender, EventArgs e)
        {

            TextBox tx = ((Button)sender).NamingContainer.FindControl("txtMobileNo" + ((Button)sender).CommandArgument) as TextBox;
            if (tx != null)
            {
                sms.SendMessage("شكرا لتعاملك مع ناقلات البرية موقع " + vBranch[int.Parse(((Button)sender).CommandArgument)] + " " +vLat[int.Parse(((Button)sender).CommandArgument)], "naqelat", "966" + tx.Text.Substring(1, 9));
                tx.Text = "لقد تم الارسال بنجاح";
            }
        }

        public string getStartData(short Task)
        {
            string htmlStr = "";
            TblStart myStart = new TblStart();
            myStart.FType = Task;
            foreach (TblStart itm in (List<TblStart>)Cache["Starter" + Session["CNN2"].ToString()])
            {
                if (itm.FType == Task && itm.Fd1 != "")
                {
                    if (Task == 1) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td></tr>";
                    else if (Task == 2 || Task == 3) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td><td>" + itm.Fd4 + "</td><td>" + itm.Fd5 + "</td></tr>";
                    else if (Task == 4 || Task == 5) htmlStr += "<tr><td>" + itm.Fd1 + "</td><td>" + itm.Fd2 + "</td><td>" + itm.Fd3 + "</td><td>" + itm.Fd4 + "</td></tr>";
                    else if (Task == 6)
                    {
                        htmlStr += "<tr><td>" + @"<a target='_blank' href='http://www.naqelat.com/branches" + itm.FNo.ToString().Trim() + @".html'><i class='fa fa-map-marker'></i>&nbsp;" + itm.Fd1 + @"</a>" + "</td><td>" + itm.Fd2 + "أرقام الاتصال بالفرع:  " + @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itm.Fd3 + @"&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + itm.Fd4 + @"<br/><br/>أرسال رسالة بموقع الفرع على جوال رقم&nbsp;&nbsp;" + "<input id='ContentPlaceHolder1_txtMobileNo" + itm.FNo.ToString().Trim() + @"' name='ctl00$ContentPlaceHolder1$txtMobileNo" + itm.FNo.ToString().Trim() + "' type='text'><input id='ContentPlaceHolder1_BtnSend" + itm.FNo.ToString().Trim() + @"' name='ctl00$ContentPlaceHolder1$BtnSend" + itm.FNo.ToString().Trim() + @"' value='أرسال' type='submit'>" + "</td></tr>";
                    }
                }
            }
            return htmlStr;
        }
    }
}


            //string from = "966549249288";
            //string to =   "966502690963";//Sender Mobile
            //string msg = "First Message from Mohamed .............";

            //WhatsApp wa = new WhatsApp(from, "OBgA1DcTlTYaKeaVDe4cLqR0JKY=", "Mohamed", true, true);

            //wa.OnConnectSuccess += () =>
            //{
                
            //    lblError.Text += "Connected to whatsapp...";

            //    wa.OnLoginSuccess += (phoneNumber, data) =>
            //    {
            //        wa.SendMessage(to, msg);
            //        lblError.Text += "Message Sent...";
            //    };

            //    wa.OnLoginFailed += (data) =>
            //    {
            //        lblError.Text += string.Format("Login Failed : {0}", data);
            //    };

            //    wa.Login();
            //};

            //wa.OnConnectFailed += (ex) =>
            //{

            //    lblError.Text +=  "Connection Failed";
            //};

            //wa.Connect();







        //string from = "9199********";
        //string to = txtTo.Text;//Sender Mobile
        //string msg = txtMessage.Text;

        //WhatsApp wa = new WhatsApp(from, "BnXk*******B0=", "NickName", true, true);

        //wa.OnConnectSuccess += () =>
        //{
        //    MessageBox.Show("Connected to whatsapp...");

        //    wa.OnLoginSuccess += (phoneNumber, data) =>
        //    {
        //        wa.SendMessage(to, msg);
        //        MessageBox.Show("Message Sent...");
        //    };

        //    wa.OnLoginFailed += (data) =>
        //    {
        //        MessageBox.Show("Login Failed : {0}", data); 
        //    };

        //    wa.Login();
        //};

        //wa.OnConnectFailed += (ex) =>
        //{
        //    MessageBox.Show("Connection Failed...");
        //};
        //wa.Connect();