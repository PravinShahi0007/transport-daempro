using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Globalization;
using System.Web.Configuration;
using BLL;
using System.Configuration;
using System.Media;
using System.Web.SessionState;

namespace ACC
{
    public partial class SupportSite : System.Web.UI.MasterPage
    {
        public string vHomeRoleName
        {
            get
            {
                if (ViewState["HomeRoleName"] == null)
                {
                    ViewState["HomeRoleName"] = "Roll";
                }
                return ViewState["HomeRoleName"].ToString();
            }
            set { ViewState["HomeRoleName"] = value; }
        }

        protected void Page_PreInit(object sender, EventArgs e)
        {
            CultureInfo currentCulture = System.Threading.Thread.CurrentThread.CurrentCulture;
            CultureInfo newCulture = new CultureInfo(currentCulture.IetfLanguageTag);
            newCulture.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";
            newCulture.DateTimeFormat.DateSeparator = "/";
            newCulture.NumberFormat.CurrencyDecimalDigits = 2;
            newCulture.NumberFormat.NumberNegativePattern = 0;
            newCulture.NumberFormat.CurrencyNegativePattern = 0;
            System.Threading.Thread.CurrentThread.CurrentCulture = newCulture;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Session["Branch"] = "1";
                Session["Modal"] = true;
                if (!Page.IsPostBack)
                {
                    if (Session["CurrentUser"] == null || Session["FullUser"] == null)
                    {
                        Response.Redirect("logout.aspx");
                    }
                    else
                    {
                        LblUser.Text = Session["FullUser"].ToString() + " - " + ((List<TblRoles>)(Session["Roll"]))[0].RoleName;
                    }
                    if (Session["Roll"] == null)
                    {
                        Response.Redirect("logout.aspx");
                    }
                    else
                    {
                        lblData.Text = Session["CNN2"].ToString();
                        lblSite.Text = GetGlobalResourceObject("Resource", "HeadOffice").ToString();  // "الادارة العامة";

                        if (Request.QueryString["AreaNo"] != null)
                        {
                            myArea.Value = Request.QueryString["AreaNo"].ToString();
                        }
                        else
                        {
                            myArea.Value = Session["AreaNo"].ToString();
                        }

                        MyConfig mySetting = new MyConfig();
                        mySetting.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                        if (mySetting != null)
                        {
                            //Label1.Text = mySetting.CompanyName;
                            ClosedPeriod.Value = mySetting.ClosePeriod;
                            if (mySetting.UpdateTime != "")
                            {
                                ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(
                                GetGlobalResourceObject("Resource", "SysUpdate").ToString() + " " + mySetting.UpdateTime + " " + GetGlobalResourceObject("Resource", "PleaseWait").ToString(), true, false, "4000000"), true);
                                //"يتم تحديث النظام اليوم الساعة  " + mySetting.UpdateTime + " برجاء حفظ البيانات الحالية و شكرا", true, false, "4000000"), true);
                            }
                        }

                        ddlSender.DataTextField = "FName";
                        ddlSender.DataValueField = "UserName";
                        if (HttpRuntime.Cache["Users" + Session["CNN2"].ToString()] == null)
                        {
                            TblUsers myuser = new TblUsers();
                            Cache.Insert("Users" + Session["CNN2"].ToString(), myuser.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        }
                        ddlSender.DataSource = (List<TblUsers>)HttpRuntime.Cache["Users" + Session["CNN2"].ToString()];
                        ddlSender.DataBind();
                        ddlSender.Items.Insert(0, new ListItem(GetGlobalResourceObject("Resource", "AllUsers").ToString(), "-1", true));  // "جميع المستخدمين"

                        if (HttpRuntime.Cache["Chats" + Session["CNN2"].ToString()] == null)
                        {
                            Chat myChat = new Chat();
                            Cache.Insert("Chats" + Session["CNN2"].ToString(), myChat.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        }
                        LoadChatData();

                        TblUsers ax = new TblUsers();
                        if (Cache["Users" + Session["CNN2"].ToString()] == null) Cache.Insert("Users" + Session["CNN2"].ToString(), ax.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        vHomeRoleName = moh.GetCurrentRole(myArea.Value, (from useritm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                                                                         where useritm.UserName == Session["CurrentUser"].ToString()
                                                                         select useritm).FirstOrDefault());
                        if (Session[vHomeRoleName] == null)
                        {
                            Response.Redirect("WebNotPrev.aspx", false);
                            return;
                        }
                        LblUser.Text = Session["FullUser"].ToString() + " - " + ((List<TblRoles>)(Session[vHomeRoleName]))[0].RoleName;
                        ImgPhoto.Src = "images/123.jpg";
                        bool vPassit = false;
                        ax.UserName = Session["CurrentUser"].ToString();
                        ax = (from uitm in (List<TblUsers>)(Cache["Users" + Session["CNN2"].ToString()])
                              where uitm.UserName == ax.UserName
                              select uitm).FirstOrDefault();
                        if (ax != null)
                        {
                            if (mySetting != null)
                            {
                                if (!string.IsNullOrEmpty(ax.Photo))
                                {
                                    string url = mySetting.ImagePath2 + ax.Photo;
                                    ImgPhoto.Src = url;
                                }
                            }
                        }                                              
                    }
                }
            }
            finally
            {

            }
        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetGlobalResourceObject("Resource", "Home").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetGlobalResourceObject("Resource", "Tally").ToString(), "" , IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
            moh.Tally(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString, short.Parse(Session["Branch"].ToString()));
            ScriptManager.RegisterStartupScript(this.Page, this.Page.GetType(), Guid.NewGuid().ToString(), moh.DisptopMessage(GetGlobalResourceObject("Resource", "SuccessTally").ToString(), false, true), true); // "لقد تم تشغيل مطابقة الارصدة بنجاح"
        }

        protected void LoginStatus1_LoggingOut(object sender, LoginCancelEventArgs e)
        {
            //HttpContext.Current.Profile.SetPropertyValue("LastVisitedDate", moh.Nows());
            Response.Redirect(@"~\Logout.aspx", true);
        }

        protected void BtnSend_Click(object sender, EventArgs e)
        {
            if (ddlSender.SelectedValue == "-1")
            {
                Chat myChat = new Chat();
                myChat.MyDate = moh.Nows();
                myChat.FromUser = Session["CurrentUser"].ToString();
                myChat.Msg = txtMsg.Text;
                myChat.FRead = false;
                myChat.FDisplay = true;
                for (int i = 0; i < ddlSender.Items.Count; i++)
                {
                    myChat.ToUser = ddlSender.Items[i].Value;
                    myChat.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                }
            }
            else
            {
                Chat myChat = new Chat();
                myChat.MyDate = moh.Nows();
                myChat.FromUser = Session["CurrentUser"].ToString();
                myChat.Msg = txtMsg.Text;
                myChat.ToUser = ddlSender.SelectedValue;
                myChat.FRead = false;
                myChat.FDisplay = true;
                myChat.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            }
            if (HttpRuntime.Cache["Chats" + Session["CNN2"].ToString()] != null)
            {
                Cache.Remove("Chats" + Session["CNN2"].ToString());
            }
            Chat myChat2 = new Chat();
            Cache.Insert("Chats" + Session["CNN2"].ToString(), myChat2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            LoadChatData();
            txtMsg.Text = "";
        }

        public void LoadChatData()
        {
            int i = 0;
            foreach (Chat item in (from itm in (List<Chat>)HttpRuntime.Cache["Chats" + Session["CNN2"].ToString()]
                                   where itm.ToUser == Session["CurrentUser"].ToString()
                                   select itm).ToList())
            {
                if (!(bool)item.FRead)
                {
                    item.FRead = true;
                    i++;
                }
            }
            if (i > 0)
            {
                Chat myChat = new Chat();
                myChat.ToUser = Session["CurrentUser"].ToString();
                myChat.SetRead(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                for (int r = 0; r < i; r++)
                {
                    SoundPlayer sp = new SoundPlayer(Server.MapPath("") + @"/ching.wav");
                    sp.Play();
                }
            }

            grdCodes.DataSource = (from itm in (List<Chat>)HttpRuntime.Cache["Chats" + Session["CNN2"].ToString()]
                                   where itm.ToUser == "-1" || itm.ToUser == Session["CurrentUser"].ToString() || itm.FromUser == Session["CurrentUser"].ToString()
                                   select itm).ToList();
            grdCodes.DataBind();
        }

        protected void grdCodes_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            try
            {
                grdCodes.PageIndex = e.NewPageIndex;
                LoadChatData();
            }
            catch (Exception ex)
            {
                if (ConfigurationManager.AppSettings["ExitOnError"].ToString() == "1")
                {
                    Session.Add("Error", ex);
                    Response.Redirect("GeneralServerError.aspx", false);
                }
            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                //LoadChatData();
                SoundPlayer sp = new SoundPlayer(Server.MapPath("") + @"/ching.wav");
                sp.Play();
            }
            catch (Exception)
            {
            }
        }

        protected void btnLangImg_Click(object sender, EventArgs e)
        {
            Response.Cookies.Add(new HttpCookie("Lang", btnLangImg.ToolTip.ToString()));
            Response.Redirect(Request.Url.PathAndQuery);
        }


    }


    public class SessionHeartbeatHttpHandler : IHttpHandler, IRequiresSessionState
    {
        public bool IsReusable { get { return false; } }

        public void ProcessRequest(HttpContext context)
        {
            context.Session["Heartbeat"] = DateTime.Now;
        }
    }
}