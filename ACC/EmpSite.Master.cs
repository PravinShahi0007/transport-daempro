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

namespace ACC
{
    public partial class EmpSite : System.Web.UI.MasterPage
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

                        Shop myShop = new Shop();
                        myShop.FType = 2;
                        myShop.Bran = 1;
                        myShop.Number = (Request.QueryString["StoreNo"] != null ? short.Parse(Request.QueryString["StoreNo"].ToString()) : short.Parse(Session["StoreNo"].ToString()));
                        if (myShop.GetShop(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                        {
                            lblStore.Text = myShop.Name1;
                        }
                        myStore.Value = myShop.Number.ToString();



                        CostCenter myCost = new CostCenter();
                        myCost.Branch = 1;
                        if (Cache["LastCostCenter" + Session["CNN2"].ToString()] == null) Cache.Insert("LastCostCenter" + Session["CNN2"].ToString(), myCost.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        myCost.Code = myArea.Value;
                        myCost = (from citm in (List<CostCenter>)(Cache["LastCostCenter" + Session["CNN2"].ToString()])
                                  where citm.Code == myCost.Code
                                  select citm).FirstOrDefault();
                        if (myCost != null) lblArea.Text = myCost.Name1;
                        myArea.Value = myCost.Code;
                        this.Page.Header.Title += " - " + myCost.Name1;


                        MyConfig mySetting = new MyConfig();
                        mySetting.Branch = short.Parse(Session["Branch"].ToString());
                        if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                        mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                        if (mySetting != null)
                        {
                            //Label1.Text = mySetting.CompanyName;
                            ClosedPeriod.Value = mySetting.ClosePeriod;
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
                        // حسابات
                        liA1.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass1;
                        liA10.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass10;
                        liA11.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass11;
                        liA12.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass12;
                        liA13.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass13;
                        liA14.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass14;
                        liA15.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass15;
                        liA16.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass16;
                        liA17.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass17;
                        liA18.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass18;
                        liA19.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass19;

                        liA24.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass24;
                        liA25.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass25;
                        liA26.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass26;
                        liA27.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass27;
                        liA28.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass28;
                        liA29.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass29;
                        liA30.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass30;

                        liA35.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass35;
                        liA36.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass36;
                        liA37.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass37;

                        liA40.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass40;
                        liA41.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass41;
                        liA42.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass42;
                        liA43.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass43;
                        liA44.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass44;
                        liA45.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass45;
                        liA46.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass46;
                        liA47.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass47;

                        liA60.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass60;
                        liA61.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass61;

                        // تشغيل
                        liB1.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass1;
                        liB10.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass10;
                        liB11.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass11;
                        liB12.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass12;
                        liB13.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass13;
                        liB14.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass14;
                        liB15.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass15;
                        liB16.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass16;
                        liB17.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass17;
                        liB18.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass18;
                        liB19.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass19;

                        liB20.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass20;
                        liB21.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass21;
                        liB22.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass22;
                        liB23.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass23;
                        liB24.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass24;
                        liB25.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass25;
                        liB26.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass26;
                        liB27.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass27;
                        liB28.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass28;

                        liB30.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass30;
                        liB31.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass31;
                        liB32.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass32;

                        liB41.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass41;
                        liB42.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass42;
                        liB43.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass43;
                        liB44.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass44;
                        liB45.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass45;
                        liB46.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass46;
                        liB47.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass47;
                        liB48.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass48;
                        liB49.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass49;
                        liB50.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass50;
                        liB51.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass51;
                        liB52.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass52;
                        liB53.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[1].Pass53;

                        // صيانة و مستودع
                        liC1.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass1;
                        liC01.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass1;
                        liC10.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass10;
                        liC11.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass11;
                        liC12.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass12;
                        liC13.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass13;
                        liC14.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass14;
                        liC15.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass15;
                        liC16.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass16;
                        liC17.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass17;
                        liC18.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass18;
                        liC19.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass19;

                        liC30.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass30;
                        liC31.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass31;
                        liC32.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass32;
                        liC33.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass33;
                        liC34.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass34;
                        liC35.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass35;
                        //liC36.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass36;
                        liC37.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass37;
                        liC38.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass38;

                        liC41.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass41;
                        liC42.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass42;
                        liC43.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass43;
                        liC44.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass44;
                        liC45.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass45;
                        liC46.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass46;
                        liC47.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass47;
                        liC48.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass48;
                        liC49.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass49;
                        liC50.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass50;
                        liC51.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass51;

                        liC60.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass60;
                        liC61.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[2].Pass61;

                        // الشئون الادارية
                        liD1.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass1;
                        liD10.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass10;
                        liD11.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass11;
                        liD12.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass12;

                        liD30.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass30;

                        liD20.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[0].Pass20;
                        liD21.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass21;
                        liD22.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass22;
                        liD23.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass23;
                        liD24.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass24;
                        liD25.Visible = (bool)((List<TblRoles>)(Session[vHomeRoleName]))[3].Pass25;
                    }
                }
            }
            finally
            {

            }
        }

        protected void BtnProcess_Click(object sender, EventArgs e)
        {
            if (ConfigurationManager.AppSettings["TraceUserLog"].ToString() == "1") moh.AddUserTrans(Session["CurrentUser"].ToString(), GetGlobalResourceObject("Resource", "Home").ToString(), GetGlobalResourceObject("Resource", "Select").ToString(), GetGlobalResourceObject("Resource", "Tally").ToString(), "", IPNetworking.GetIP4Address(), WebConfigurationManager.ConnectionStrings["MyCnnlog"].ConnectionString);
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
}