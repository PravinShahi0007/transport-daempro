using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Configuration;

namespace ACC
{
    public partial class WebProject1 : System.Web.UI.Page
    {
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
                    ViewState["StoreNo"] = "00001";
                }
                return ViewState["StoreNo"].ToString();
            }
            set { ViewState["StoreNo"] = value; }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ScriptManager.GetCurrent(this).RegisterPostBackControl(BtnAttach);

            if (!Page.IsPostBack)
            {
                this.Page.Header.Title = "مشروع ديوان المظالم";
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
                ddlArea_SelectedIndexChanged(sender, e);
            }
        }

        protected void ddlArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetArea(ddlArea.SelectedValue);
        }

        public void GetArea(string ID)
        {
            if (ID == "1")
            {
                txtSponsor.Text = "محمد عبد الحميد حسن العواوده";
                txtSponsor2.Text = "";
                txtMobile.Text = "0552796175";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "36" : "150");

                txtPerson.Text = "خالد العقيف";
                txtPMobileNo.Text = "0505299293";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;
                
                txtPerson1.Text = "عبدالمحسن العتيبي";
                txtPerson2.Text = "فيصل السعودي";
                txtPerson3.Text = "فهد الحربي";

                txtPMobileNo1.Text = "0532227789";
                txtPMobileNo2.Text = "0503418620";
                txtPMobileNo3.Text = "0503725072";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=24.6559783563947&lng=46.7121452093124";

            }
            else if (ID == "2")
            {
                txtSponsor.Text = "سامح محمد رشاد محمد خليل";
                txtSponsor2.Text = "محمد السيد عبد الفتاح";
                txtMobile.Text = "0594282642";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "4" : "61");

                txtPerson.Text = "يوسف عبداللطيف الثنيان";
                txtPMobileNo.Text = "0504230894";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = true;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = true;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = true;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = true;

                txtPerson1.Text = "أحمد راشد التميمي";
                txtPerson2.Text = "حسن سعد النتيفات";
                txtPerson3.Text = "عبدالملك بن عبدالله المرشد";
                txtPerson4.Text = "عبده يحيى محنشي";
                txtPerson5.Text = "أحمد عبدالله الخالدي";

                txtPMobileNo1.Text = "0531084444";
                txtPMobileNo2.Text = "0556784355";
                txtPMobileNo3.Text = "0565191730";
                txtPMobileNo4.Text = "0501703054";
                txtPMobileNo5.Text = "0555213318";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=24.6559783563947&lng=46.6555130481719";

            }
            else if (ID == "3")
            {
                txtSponsor.Text = "محمد محمد البياع سرحان";
                txtSponsor2.Text = "";
                txtMobile.Text = "0568822845";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "21" : "166");

                txtPerson.Text = "أحمد علي المهنا";
                txtPMobileNo.Text = "0505602201";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = true;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = true;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = true;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = true;

                txtPerson1.Text = "مبروك محمد السفري";
                txtPerson2.Text = "فهد سعيد الغامدي";
                txtPerson3.Text = "محمد عبدالله البركاتي";
                txtPerson4.Text = "عبدالملك محمد نصرت";
                txtPerson5.Text = "عالي عبدالله العرياني";

                txtPMobileNo1.Text = "0505657746";
                txtPMobileNo2.Text = "0555716559";
                txtPMobileNo3.Text = "0553558829";
                txtPMobileNo4.Text = "0508339542";
                txtPMobileNo5.Text = "0544224413";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=21.5955320826813&lng=39.1600692272186";
            }
            else if (ID == "4")
            {
                txtSponsor.Text = "هاني فرغلي قرني عبدالقوي";
                txtSponsor2.Text = "سائق";
                txtMobile.Text = "0556920557";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "9" : "48");

                txtPerson.Text = "سعيد الغامدي";
                txtPMobileNo.Text = "";

                txtPerson1.Visible = false;
                txtPerson2.Visible = false;
                txtPerson3.Visible = false;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = false;
                lblPerson2.Visible = false;
                lblPerson3.Visible = false;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = false;
                txtPMobileNo2.Visible = false;
                txtPMobileNo3.Visible = false;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = false;
                lblPMobileNo2.Visible = false;
                lblPMobileNo3.Visible = false;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "";
                txtPerson2.Text = "";
                txtPerson3.Text = "";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "";
                txtPMobileNo2.Text = "";
                txtPMobileNo3.Text = "";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=21.621035&lng=39.195303";
            }
            else if (ID == "5")
            {
                txtSponsor.Text = "هاني فرغلي قرني عبدالقوي";
                txtSponsor2.Text = "سائق";
                txtMobile.Text = "0556920557";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "13" : "14"); 

                txtPerson.Text = "منصور محمد القوبع";
                txtPMobileNo.Text = "0555532097";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = true;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = true;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = true;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = true;

                txtPerson1.Text = "ماجد محمد العريفي";
                txtPerson2.Text = "عبدالله محمد الصاعدي";
                txtPerson3.Text = "أحمد سلطان مدني";
                txtPerson4.Text = "منصور عبدالغني عسكر";
                txtPerson5.Text = "حامد علي الحارثي";

                txtPMobileNo1.Text = "0555561691";
                txtPMobileNo2.Text = "0555549622";
                txtPMobileNo3.Text = "0503544002";
                txtPMobileNo4.Text = "0569946365";
                txtPMobileNo5.Text = "0560083148";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=21.444226&lng=39.860115";
            }
            else if (ID == "6")
            {
                txtSponsor.Text = "اسامة محمود سليمان الكلاوي";
                txtSponsor2.Text = "توفيق شهيد";
                txtMobile.Text = "0502460388";
                txtCar.Text = "ونيت الفرع مع تركيب فيبر جلاس";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "11" : "49");

                txtPerson.Text = "علي إبراهيم الزبن";
                txtPMobileNo.Text = "0505885445";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "طارق محمد العمودي";
                txtPerson2.Text = "حناف أحمد كعبي";
                txtPerson3.Text = "علي محمد الدويل";
                txtPerson4.Text = "مكي أحمد مجرشي";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0502106860";
                txtPMobileNo2.Text = "0564026131";
                txtPMobileNo3.Text = "0500881324";
                txtPMobileNo4.Text = "0507080611";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=26.455811&lng=50.122068";
            }
            else if (ID == "7")
            {
                txtSponsor.Text = "اسامة محمود سليمان الكلاوي";
                txtSponsor2.Text = "توفيق شهيد";
                txtMobile.Text = "0502460388";
                txtCar.Text = "ونيت الفرع مع تركيب فيبر جلاس";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "4" : "30"); 

                txtPerson.Text = "أحمد محمد الزبن";
                txtPMobileNo.Text = "0530748884";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "عبدالمحسن إبراهيم الجعفر";
                txtPerson2.Text = "خالد علي الزهراني";
                txtPerson3.Text = "نواف نجر العتيبي";
                txtPerson4.Text = "نايف عبدالعزيز الرشيد";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0503845550";
                txtPMobileNo2.Text = "0509969111";
                txtPMobileNo3.Text = "0506103004";
                txtPMobileNo4.Text = "0509655653";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=26.4105319899553&lng=50.091068744659";
            }
            else if (ID == "8")
            {
                txtSponsor.Text = "سميح السيد السيد لاشين";
                txtSponsor2.Text = "";
                txtMobile.Text = "0500465209";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "16" : "16");

                txtPerson.Text = "د.عبدالله سعد البسامي";
                txtPMobileNo.Text = "0544320660";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "محمد علي الزهراني";
                txtPerson2.Text = "مازن حامد الرادادي";
                txtPerson3.Text = "مهند أنور سلطان";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0535557078";
                txtPMobileNo2.Text = "0506622298";
                txtPMobileNo3.Text = "0500333545";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=24.496319&lng=39.600868";
            }
            else if (ID == "9")
            {
                txtSponsor.Text = "سميح السيد السيد لاشين";
                txtSponsor2.Text = "";
                txtMobile.Text = "0500465209";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "2" : "5");

                txtPerson.Text = "محمد علي حجازي";
                txtPMobileNo.Text = "0503313428";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "أحمد عبدالله الراجح";
                txtPerson2.Text = "سعود عبدالله الصاعدي";
                txtPerson3.Text = "فهد سعد الحازمي";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0566337166";
                txtPMobileNo2.Text = "0552860715";
                txtPMobileNo3.Text = "0561982161";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=24.462829&lng=39.665322";
            }
            else if (ID == "10")
            {
                txtSponsor.Text = "طه صالح";
                txtSponsor2.Text = "سائق";
                txtMobile.Text = "0534661376";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "5" : "10");

                txtPerson.Text = "إبراهيم عبدالله التويجري";
                txtPMobileNo.Text = "0504880831";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "ربيع يوسف الصولي";
                txtPerson2.Text = "أحمد عبدالرحمن السلامة";
                txtPerson3.Text = "سليمان جبران حريصي";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0506148376";
                txtPMobileNo2.Text = "0504896220";
                txtPMobileNo3.Text = "0544908800";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=26.417152&lng=43.926433";
            }
            else if (ID == "11")
            {
                txtSponsor.Text = "حكيم";
                txtSponsor2.Text = "";
                txtMobile.Text = "0563924446";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "1" : "9");

                txtPerson.Text = "بدر محمد السبلان";
                txtPMobileNo.Text = "0503993926";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "سعود عبدالعزيز الصويغ";
                txtPerson2.Text = "سلطان إبراهيم العواد";
                txtPerson3.Text = "فواز عايد الشمري";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0551655576";
                txtPMobileNo2.Text = "0557953339";
                txtPMobileNo3.Text = "0500894678";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=27.4989835244678&lng=41.7059469223022";
            }
            else if (ID == "12")
            {
                txtSponsor.Text = "سيد رشدي";
                txtSponsor2.Text = "سائق";
                txtMobile.Text = "0549342100";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "4" : "45");

                txtPerson.Text = "شبيلي مرعي القرني";
                txtPMobileNo.Text = "0552233289";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = false;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = false;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = false;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = false;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "بندر محمد القرني";
                txtPerson2.Text = "أحمد عامر البارقي";
                txtPerson3.Text = "";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0555553086";
                txtPMobileNo2.Text = "0506291541";
                txtPMobileNo3.Text = "";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=18.2168651316964&lng=42.5147777795792";
            }
            else if (ID == "13")
            {
                txtSponsor.Text = "سيد رشدي";
                txtSponsor2.Text = "سائق";
                txtMobile.Text = "0549342100";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "1" : "17");

                txtPerson.Text = "سعد يحيى الجروي";
                txtPMobileNo.Text = "0507106874";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "خالد يحيى الفيفي";
                txtPerson2.Text = "يحيى علي الزهراني";
                txtPerson3.Text = "رائد فالح الثبيتي";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0542917009";
                txtPMobileNo2.Text = "0566545045";
                txtPMobileNo3.Text = "0557702416";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=18.216666&lng=42.512469";
            }
            else if (ID == "14")
            {
                txtSponsor.Text = "طاهر أبو زيد";
                txtSponsor2.Text = "عبدالرحمن الثبيتي";
                txtMobile.Text = "0548034900";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "2" : "5");

                txtPerson.Text = "عواد عطالله العطوي";
                txtPMobileNo.Text = "0509035324";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "نايف أحمد الزهراني";
                txtPerson2.Text = "محمد صالح الماضي";
                txtPerson3.Text = "أحمد سالم العنزي";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0553844899";
                txtPMobileNo2.Text = "0567798778";
                txtPMobileNo3.Text = "0534046484";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=29.9621570159085&lng=40.1791906356812";

            }
            else if (ID == "15")
            {
                txtSponsor.Text = "أشرف عبدالحميد زايد";
                txtSponsor2.Text = "";
                txtMobile.Text = "0548034900";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "1" : "6");

                txtPerson.Text = "الحميدي إبراهيم الحميمص";
                txtPMobileNo.Text = "0553395668";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = true;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = true;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = true;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = true;

                txtPerson1.Text = "عبدالسلام مرزوق الرشيد";
                txtPerson2.Text = "محمد خالد الشمري";
                txtPerson3.Text = "غربي علي الشمري";
                txtPerson4.Text = "محمد عبدالرحيم الفالح";
                txtPerson5.Text = "محمد حجاج السماره";

                txtPMobileNo1.Text = "0505388406";
                txtPMobileNo2.Text = "0557905700";
                txtPMobileNo3.Text = "0550946048";
                txtPMobileNo4.Text = "0553029699";
                txtPMobileNo5.Text = "0551270097";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=29.9621570159085&lng=40.1791906356812";
            }
            else if (ID == "16")
            {
                txtSponsor.Text = "جمعة حميد العنزي";
                txtSponsor2.Text = "";
                txtMobile.Text = "0558511749";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "5" : "4");

                txtPerson.Text = "محمد وادي العنزي";
                txtPMobileNo.Text = "0506380812";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = false;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = false;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = false;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = false;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "عبدالرحمن حسب العنزي";
                txtPerson2.Text = "عبدالرحمن محمد الهزيمي";
                txtPerson3.Text = "";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0553544987";
                txtPMobileNo2.Text = "0550440144";
                txtPMobileNo3.Text = "";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=30.9902286916641&lng=41.007091999054";
            }
            else if (ID == "17")
            {
                txtSponsor.Text = "فضل الله عبدالماجد";
                txtSponsor2.Text = "";
                txtMobile.Text = "0557834769";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "6" : "8");

                txtPerson.Text = "سعد محمد الوادعي";
                txtPMobileNo.Text = "0542557632";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = false;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = false;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = false;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = false;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "مبارك سعدون الدوسري";
                txtPerson2.Text = "صالح هندي العتيبي";
                txtPerson3.Text = "";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0552224870";
                txtPMobileNo2.Text = "0548481848";
                txtPMobileNo3.Text = "";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=17.5459255124011&lng=44.2235219478607";
            }
            else if (ID == "18")
            {
                txtSponsor.Text = "محمد عطية";
                txtSponsor2.Text = "";
                txtMobile.Text = "";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "2" : "5");

                txtPerson.Text = "عبدالله موسى السلماني";
                txtPMobileNo.Text = "0565622198";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = true;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = true;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = true;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = true;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "فيصل مكي هجري";
                txtPerson2.Text = "إبراهيم موسى هجري";
                txtPerson3.Text = "حسن محمد خرمي";
                txtPerson4.Text = "محمد علي معيدي";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0557969208";
                txtPMobileNo2.Text = "0557027231";
                txtPMobileNo3.Text = "055137038";
                txtPMobileNo4.Text = "0550120063";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=16.9234997570024&lng=42.563202381134";
            }
            else if (ID == "19")
            {
                txtSponsor.Text = "عبدالقوي رشدي";
                txtSponsor2.Text = "";
                txtMobile.Text = "";
                txtCar.Text = "كيا كرنفال";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "2" : "3");

                txtPerson.Text = "محمد عيضه الحارثي";
                txtPMobileNo.Text = "0555685105";

                txtPerson1.Visible = true;
                txtPerson2.Visible = true;
                txtPerson3.Visible = true;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = true;
                lblPerson2.Visible = true;
                lblPerson3.Visible = true;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = true;
                txtPMobileNo2.Visible = true;
                txtPMobileNo3.Visible = true;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = true;
                lblPMobileNo2.Visible = true;
                lblPMobileNo3.Visible = true;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "حسن إبراهيم الزبيدي";
                txtPerson2.Text = "سمير علي الغامدي";
                txtPerson3.Text = "فهد سعد الغامدي";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "0535860497";
                txtPMobileNo2.Text = "0597174446";
                txtPMobileNo3.Text = "0590343411";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=20.00534&lng=41.4623";
            }
            else if (ID == "20")
            {
                txtSponsor.Text = "سامح محمد رشاد محمد خليل";
                txtSponsor2.Text = "محمد السيد عبد الفتاح";
                txtMobile.Text = "0594282642";
                txtCar.Text = "H1";
                txtBoxNo.Text = (rdoStep.SelectedIndex == 0 ? "8" : "4");

                txtPerson.Text = "بدر سعود";
                txtPMobileNo.Text = "0567052999";

                txtPerson1.Visible = false;
                txtPerson2.Visible = false;
                txtPerson3.Visible = false;
                txtPerson4.Visible = false;
                txtPerson5.Visible = false;
                lblPerson1.Visible = false;
                lblPerson2.Visible = false;
                lblPerson3.Visible = false;
                lblPerson4.Visible = false;
                lblPerson5.Visible = false;

                txtPMobileNo1.Visible = false;
                txtPMobileNo2.Visible = false;
                txtPMobileNo3.Visible = false;
                txtPMobileNo4.Visible = false;
                txtPMobileNo5.Visible = false;

                lblPMobileNo1.Visible = false;
                lblPMobileNo2.Visible = false;
                lblPMobileNo3.Visible = false;
                lblPMobileNo4.Visible = false;
                lblPMobileNo5.Visible = false;

                txtPerson1.Text = "";
                txtPerson2.Text = "";
                txtPerson3.Text = "";
                txtPerson4.Text = "";
                txtPerson5.Text = "";

                txtPMobileNo1.Text = "";
                txtPMobileNo2.Text = "";
                txtPMobileNo3.Text = "";
                txtPMobileNo4.Text = "";
                txtPMobileNo5.Text = "";

                BtnMyLoc.NavigateUrl = @"WebMap.aspx?lat=24.700637&lng=46.679310";
            }
            LoadAttachData();
        }

        protected void BtnAttach_Click(object sender, ImageClickEventArgs e)
        {
            if (FileUpload1.HasFile)
                try
                {
                    MyConfig mySetting = new MyConfig();
                    mySetting.Branch = short.Parse(Session["Branch"].ToString());
                    if (Cache["MyConfig" + Session["CNN2"].ToString()] == null) Cache.Insert("MyConfig" + Session["CNN2"].ToString(), mySetting.Get(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                    mySetting = (MyConfig)(Cache["MyConfig" + Session["CNN2"].ToString()]);
                    if (mySetting != null)
                    {
                        string fileExt = System.IO.Path.GetExtension(FileUpload1.FileName);
                        String FileName = Config.GetImageName(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString) + fileExt;
                        FileUpload1.SaveAs(mySetting.ImagePath + FileName);

                        Arch myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(rdoStep.SelectedValue);
                        myArch.Number = int.Parse(ddlArea.SelectedValue);
                        myArch.DocType = 991;

                        short? i = myArch.GetNewFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (i == null) i = 1;
                        else i++;

                        myArch = new Arch();
                        myArch.Branch = short.Parse(Session["Branch"].ToString());
                        myArch.LocNumber = short.Parse(rdoStep.SelectedValue);
                        myArch.Number = int.Parse(ddlArea.SelectedValue);
                        myArch.DocType = 991;
                        myArch.FileName = FileUpload1.FileName;
                        myArch.FileName2 = mySetting.ImagePath2 + FileName;
                        myArch.FNo = (short)i;
                        myArch.Add(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);

                        LoadAttachData();
                    }
                }
                catch (Exception ex)
                {
                }
            else
            {
            }
        }

        protected void grdAttach_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            try
            {
                string FNo = grdAttach.DataKeys[e.RowIndex]["FNo"].ToString();
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(rdoStep.SelectedValue);
                myArch.Number = int.Parse(ddlArea.SelectedValue);
                myArch.DocType = 991;
                myArch.FNo = short.Parse(FNo);
                myArch.DeleteFNo(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                LoadAttachData();
            }
            catch (Exception ex)
            {
            }
        }

        public void LoadAttachData()
        {
            try
            {
                Arch myArch = new Arch();
                myArch.Branch = short.Parse(Session["Branch"].ToString());
                myArch.LocNumber = short.Parse(rdoStep.SelectedValue);
                myArch.Number = int.Parse(ddlArea.SelectedValue);
                myArch.DocType = 991;
                grdAttach.DataSource = myArch.Find(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                grdAttach.DataBind();
                if (((List<Arch>)grdAttach.DataSource).Count > 0)
                {
                    cpeDemo.Collapsed = false;
                    cpeDemo.ClientState = "false";
                }
                else
                {
                    cpeDemo.Collapsed = true;
                    cpeDemo.ClientState = "true";
                }
            }
            catch (Exception ex)
            {
            }
        }

        protected void BtnSendSMS_Click(object sender, EventArgs e)
        {
            string ID = ddlArea.SelectedValue;
            string vlat = "";
            if (ID == "1")
            {
                vlat = @"https://goo.gl/1mqsox";
            }
            else if (ID == "2")
            {
                vlat = @"https://goo.gl/2Vek2L";

            }
            else if (ID == "3")
            {
                vlat = @"https://goo.gl/adBcEk";
            }
            else if (ID == "4")
            {
                vlat = @"https://goo.gl/mluMRK";
            }
            else if (ID == "5")
            {
                vlat = @"https://goo.gl/HMXS6l";
            }
            else if (ID == "6")
            {
                vlat = @"https://goo.gl/zAfuhw";
            }
            else if (ID == "7")
            {
                vlat = @"https://goo.gl/hx5YB6";
            }
            else if (ID == "8")
            {
                vlat = @"https://goo.gl/8GUXTm";
            }
            else if (ID == "9")
            {
                vlat = @"https://goo.gl/iM3Yjn";
            }
            else if (ID == "10")
            {
                vlat = @"https://goo.gl/w53iAZ";
            }
            else if (ID == "11")
            {
                vlat = @"https://goo.gl/cVo5KK";
            }
            else if (ID == "12")
            {
                vlat = @"https://goo.gl/xh3JLH";
            }
            else if (ID == "13")
            {
                vlat = @"https://goo.gl/MAowFr";
            }
            else if (ID == "14")
            {
                vlat = @"https://goo.gl/izdczC";

            }
            else if (ID == "15")
            {
                vlat = @"https://goo.gl/izdczC";
            }
            else if (ID == "16")
            {
                vlat = @"https://goo.gl/0HFxs7";
            }
            else if (ID == "17")
            {
                vlat = @"https://goo.gl/jLC1K8";
            }
            else if (ID == "18")
            {
                vlat = @"https://goo.gl/KO9QcY";
            }
            else if (ID == "19")
            {
                vlat = @"https://goo.gl/szJ5i7";
            }
            else if (ID == "20")
            {
                vlat = @"https://goo.gl/Rv1Ye2";
            }
            sms.SendMessage("شكرا لتعاملك مع ناقلات البرية موقع " + ddlArea.SelectedItem.Text  + " " + vlat, "naqelat", "966" + txtMobile.Text.Substring(1, 9));
            lblStatus.Text = "لقد تم الارسال بنجاح";
        }

        protected void BtnBarCode_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=951&Loc="+ddlArea.SelectedValue+"&Number=" + txtBoxNo.Text + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

        protected void BtnBarCode0_Click(object sender, EventArgs e)
        {
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ajax", @"<script language='javascript'> window.open('WebPrint.aspx?FType=952&Loc=" + ddlArea.SelectedValue + "&Number=" + txtBoxNo.Text + "', '_blank', 'toolbar=yes, scrollbars=yes, resizable=yes,width=1000, height=800');</script>", false);
            return;
        }

    }
}