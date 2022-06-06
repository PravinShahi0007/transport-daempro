using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Configuration;
using System.Text;

namespace ACC
{
    public partial class WebMapOper : System.Web.UI.Page
    {
        public string gTruck1
        {
            get
            {
                if (ViewState["Truck1"] == null)
                {
                    ViewState["Truck1"] = "-1";
                }
                return ViewState["Truck1"].ToString();
            }
            set { ViewState["Truck1"] = value; }
        }
        public string gTruck2
        {
            get
            {
                if (ViewState["Truck2"] == null)
                {
                    ViewState["Truck2"] = "-1";
                }
                return ViewState["Truck2"].ToString();
            }
            set { ViewState["Truck2"] = value; }
        }
        public string gTruck3
        {
            get
            {
                if (ViewState["Truck3"] == null)
                {
                    ViewState["Truck3"] = "-1";
                }
                return ViewState["Truck3"].ToString();
            }
            set { ViewState["Truck3"] = value; }
        }

        public string gCar1
        {
            get
            {
                if (ViewState["Car1"] == null)
                {
                    ViewState["Car1"] = "-1";
                }
                return ViewState["Car1"].ToString();
            }
            set { ViewState["Car1"] = value; }
        }
        public string gCar2
        {
            get
            {
                if (ViewState["Car2"] == null)
                {
                    ViewState["Car2"] = "-1";
                }
                return ViewState["Car2"].ToString();
            }
            set { ViewState["Car2"] = value; }
        }
        public string gCar3
        {
            get
            {
                if (ViewState["Car3"] == null)
                {
                    ViewState["Car3"] = "-1";
                }
                return ViewState["Car3"].ToString();
            }
            set { ViewState["Car3"] = value; }
        }

        public string gShip1
        {
            get
            {
                if (ViewState["Ship1"] == null)
                {
                    ViewState["Ship1"] = "-1";
                }
                return ViewState["Ship1"].ToString();
            }
            set { ViewState["Ship1"] = value; }
        }
        public string gShip2
        {
            get
            {
                if (ViewState["Ship2"] == null)
                {
                    ViewState["Ship2"] = "-1";
                }
                return ViewState["Ship2"].ToString();
            }
            set { ViewState["Ship2"] = value; }
        }
        public string gShip3
        {
            get
            {
                if (ViewState["Ship3"] == null)
                {
                    ViewState["Ship3"] = "-1";
                }
                return ViewState["Ship3"].ToString();
            }
            set { ViewState["Ship3"] = value; }
        }

        public string gWater1
        {
            get
            {
                if (ViewState["Water1"] == null)
                {
                    ViewState["Water1"] = "-1";
                }
                return ViewState["Water1"].ToString();
            }
            set { ViewState["Water1"] = value; }
        }
        public string gWater2
        {
            get
            {
                if (ViewState["Water2"] == null)
                {
                    ViewState["Water2"] = "-1";
                }
                return ViewState["Water2"].ToString();
            }
            set { ViewState["Water2"] = value; }
        }
        public string gWater3
        {
            get
            {
                if (ViewState["Water3"] == null)
                {
                    ViewState["Water3"] = "-1";
                }
                return ViewState["Water3"].ToString();
            }
            set { ViewState["Water3"] = value; }
        }

        public string gEmer1
        {
            get
            {
                if (ViewState["Emer1"] == null)
                {
                    ViewState["Emer1"] = "-1";
                }
                return ViewState["Emer1"].ToString();
            }
            set { ViewState["Emer1"] = value; }
        }
        public string gEmer2
        {
            get
            {
                if (ViewState["Emer2"] == null)
                {
                    ViewState["Emer2"] = "-1";
                }
                return ViewState["Emer2"].ToString();
            }
            set { ViewState["Emer2"] = value; }
        }
        public string gEmer3
        {
            get
            {
                if (ViewState["Emer3"] == null)
                {
                    ViewState["Emer3"] = "-1";
                }
                return ViewState["Emer3"].ToString();
            }
            set { ViewState["Emer3"] = value; }
        }

        public string gGas1
        {
            get
            {
                if (ViewState["Gas1"] == null)
                {
                    ViewState["Gas1"] = "-1";
                }
                return ViewState["Gas1"].ToString();
            }
            set { ViewState["Gas1"] = value; }
        }
        public string gGas2
        {
            get
            {
                if (ViewState["Gas2"] == null)
                {
                    ViewState["Gas2"] = "-1";
                }
                return ViewState["Gas2"].ToString();
            }
            set { ViewState["Gas2"] = value; }
        }
        public string gGas3
        {
            get
            {
                if (ViewState["Gas3"] == null)
                {
                    ViewState["Gas3"] = "-1";
                }
                return ViewState["Gas3"].ToString();
            }
            set { ViewState["Gas3"] = value; }
        }

        public string gCity
        {
            get
            {
                if (ViewState["City"] == null)
                {
                    ViewState["City"] = "-1";
                }
                return ViewState["City"].ToString();
            }
            set { ViewState["City"] = value; }
        }
        public string gTrip
        {
            get
            {
                if (ViewState["Trip"] == null)
                {
                    ViewState["Trip"] = "-1";
                }
                return ViewState["Trip"].ToString();
            }
            set { ViewState["Trip"] = value; }
        }
        public string gOnline
        {
            get
            {
                if (ViewState["Online"] == null)
                {
                    ViewState["Online"] = "-1";
                }
                return ViewState["Online"].ToString();
            }
            set { ViewState["Online"] = value; }
        }

        public string gOffline
        {
            get
            {
                if (ViewState["Offline"] == null)
                {
                    ViewState["Offline"] = "-1";
                }
                return ViewState["Offline"].ToString();
            }
            set { ViewState["Offline"] = value; }
        }
        public string gChkCar
        {
            get
            {
                if (ViewState["ChkCar"] == null)
                {
                    ViewState["ChkCar"] = "true";
                }
                return ViewState["ChkCar"].ToString();
            }
            set { ViewState["ChkCar"] = value; }
        }
        public string gChkShip
        {
            get
            {
                if (ViewState["ChkShip"] == null)
                {
                    ViewState["ChkShip"] = "true";
                }
                return ViewState["ChkShip"].ToString();
            }
            set { ViewState["ChkShip"] = value; }
        }

        public string gChkWater
        {
            get
            {
                if (ViewState["ChkWater"] == null)
                {
                    ViewState["ChkWater"] = "true";
                }
                return ViewState["ChkWater"].ToString();
            }
            set { ViewState["ChkWater"] = value; }
        }
        public string gChkGas
        {
            get
            {
                if (ViewState["ChkGas"] == null)
                {
                    ViewState["ChkGas"] = "true";
                }
                return ViewState["ChkGas"].ToString();
            }
            set { ViewState["ChkGas"] = value; }
        }
        public string gChkEmer
        {
            get
            {
                if (ViewState["ChkEmer"] == null)
                {
                    ViewState["ChkEmer"] = "true";
                }
                return ViewState["ChkEmer"].ToString();
            }
            set { ViewState["ChkEmer"] = value; }
        }

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
        public string gFDate
        {
            get
            {
                if (ViewState["FDate"] == null)
                {
                    ViewState["FDate"] = "-1";
                }
                return ViewState["FDate"].ToString();
            }
            set { ViewState["FDate"] = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["AreaNo"] != null)
                {
                    AreaNo = Request.QueryString["AreaNo"].ToString();
                }
                else
                {
                    AreaNo = Session["AreaNo"].ToString();
                }
                if (Session["AreaNo"] == null) Session.Add("AreaNo", AreaNo);

                if (Request.QueryString["StoreNo"] != null)
                {
                    StoreNo = Request.QueryString["StoreNo"].ToString();
                }
                else StoreNo = "1";
                if (Session["StoreNo"] == null) Session.Add("StoreNo", StoreNo);

                Cities myCity = new Cities();
                myCity.Branch = 1;
                if (Cache["Cities" + Session["CNN2"].ToString()] == null) Cache.Insert("Cities" + Session["CNN2"].ToString(), myCity.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
                ddlCity.DataTextField = "Name1";
                ddlCity.DataValueField = "Code";
                ddlCity.DataSource = (List<Cities>)(Cache["Cities" + Session["CNN2"].ToString()]);
                ddlCity.DataBind();

                RefreshAll();
            }
            else
            {
                gTruck1 = ddlTruck1.SelectedIndex.ToString();
                gTruck2 = ddlTruck2.SelectedIndex.ToString();
                gTruck3 = ddlTruck3.SelectedIndex.ToString();

                gCar1 = ddlCar1.SelectedIndex.ToString();
                gCar2 = ddlCar2.SelectedIndex.ToString();
                gCar3 = ddlCar3.SelectedIndex.ToString();

                gShip1 = ddlShip1.SelectedIndex.ToString();
                gShip2 = ddlShip2.SelectedIndex.ToString();
                gShip3 = ddlShip3.SelectedIndex.ToString();

                gWater1 = ddlWater1.SelectedIndex.ToString();
                gWater2 = ddlWater2.SelectedIndex.ToString();
                gWater3 = ddlWater3.SelectedIndex.ToString();

                gEmer1 = ddlService1.SelectedIndex.ToString();
                gEmer2 = ddlService2.SelectedIndex.ToString();
                gEmer3 = ddlService3.SelectedIndex.ToString();

                gGas1 = ddlGas1.SelectedIndex.ToString();
                gGas2 = ddlGas2.SelectedIndex.ToString();
                gGas3 = ddlGas3.SelectedIndex.ToString();

                gChkCar = this.ChkType.Items[0].Selected.ToString();
                gChkShip = this.ChkType.Items[1].Selected.ToString();
                gChkEmer = this.ChkType.Items[2].Selected.ToString();
                gChkWater = this.ChkType.Items[3].Selected.ToString();
                gChkGas = this.ChkType.Items[4].Selected.ToString();

                gCity = this.ddlCity.SelectedIndex.ToString();
                gTrip = this.ddlTrip.SelectedIndex.ToString();
                gOnline = this.ddlDriverOnLine.SelectedIndex.ToString();
                gOffline = this.ddlDriver2.SelectedIndex.ToString();
                gFDate = this.ddlFDate.SelectedIndex.ToString();
            }

            // string parameter = Request["__EVENTARGUMENT"]; // parameter
            // Request["__EVENTTARGET"]; // btnSave
        }

        public void RefreshAll()
        {
            lblBusyCar.Text = "0";
            lblCarDone.Text = "0";
            lblCarInv.Text = "0";
            lblCarOnLine.Text = "0";
            lblDamageCar.Text = "0";
            lblEmergDone.Text = "0";
            lblEmergInv.Text = "0";
            lblEmergOnLine.Text = "0";
            lblFreeCar.Text = "0";
            lblShipDone.Text = "0";
            lblShipInv.Text = "0";
            lblShipOnLine.Text = "0";
            lblWaterDone.Text = "0";
            lblWaterInv.Text = "0";
            lblWaterOnLine.Text = "0";

            lblGasInv1.Text = "0";
            lblGasInv2.Text = "0";
            lblGasInv3.Text = "0";

            lblBusyCar2.Text = "0";
            lblCarDone2.Text = "0";
            lblCarInv2.Text = "0";
            lblCarOnLine2.Text = "0";
            lblDamageCar2.Text = "0";
            lblEmergDone2.Text = "0";
            lblEmergInv2.Text = "0";
            lblEmergOnLine2.Text = "0";
            lblFreeCar2.Text = "0";
            lblShipDone2.Text = "0";
            lblShipInv2.Text = "0";
            lblShipOnLine2.Text = "0";
            lblWaterDone2.Text = "0";
            lblWaterInv2.Text = "0";
            lblWaterOnLine2.Text = "0";

            List<string> Truck1 = new List<string>();
            List<string> Truck2 = new List<string>();
            List<string> Truck3 = new List<string>();

            ddlTruck1.Items.Clear();
            ddlTruck2.Items.Clear();
            ddlTruck3.Items.Clear();

            int CarCount = 0;
            int FreeCar = 0;
            int BusyCar = 0;
            int DamageCar = 0;
            Cars myCar = new Cars();
            myCar.Branch = 1;
            if (Cache["Cars" + Session["CNN2"].ToString()] == null) Cache.Insert("Cars" + Session["CNN2"].ToString(), myCar.GetAll21(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString));
            myCar.CarsType = 1;
            try
            {
                foreach (Cars itm in (from sitm in (List<Cars>)(Cache["Cars" + Session["CNN2"].ToString()])
                                      where (bool)sitm.Status && (sitm.CarsType == 1 || sitm.CarsType == 3 || sitm.CarsType == 32 || sitm.CarsType == 33)
                                      orderby sitm.PlateNo
                                      select sitm).ToList())
                {
                    if ((bool)itm.Status)
                    {
                        CarCount += 1;
                        CarMove cm = new CarMove();
                        cm.CarCode = itm.Code;
                        cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                        if (cm != null)
                        {
                            CarMoveRCV Rcv = new CarMoveRCV();
                            Rcv.Branch = 1;
                            Rcv.CarMove = int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
                            Rcv = Rcv.Find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                            if (Rcv == null)
                            {
                                ddlTruck3.Items.Add(itm.Code);
                                Truck3.Add(itm.Code);
                                BusyCar += 1;
                            }
                            else
                            {
                                if (Rcv.LocNumber == 15 || Rcv.LocNumber == 17)
                                {
                                    ddlTruck2.Items.Add(itm.Code);
                                    Truck2.Add(itm.Code);
                                    DamageCar += 1;
                                }
                                else
                                {
                                    ddlTruck1.Items.Add(itm.Code);
                                    Truck1.Add(itm.Code);
                                    FreeCar += 1;
                                }
                            }
                        }
                        else
                        {
                            ddlTruck3.Items.Add(itm.Code);
                            Truck3.Add(itm.Code);
                            BusyCar += 1;
                        }
                    }
                }
            }
            catch { }
            lblBusyCar.Text = BusyCar.ToString();
            lblFreeCar.Text = FreeCar.ToString();
            lblDamageCar.Text = DamageCar.ToString();

            lblBusyCar2.Text = BusyCar.ToString();
            lblFreeCar2.Text = FreeCar.ToString();
            lblDamageCar2.Text = DamageCar.ToString();

            ddlTruck1.Items.Insert(0, new ListItem("---الجميع---", "0"));
            ddlTruck2.Items.Insert(0, new ListItem("---الجميع---", "0"));
            ddlTruck3.Items.Insert(0, new ListItem("---الجميع---", "0"));

            if (Session["Truck1"] != null) Session.Remove("Truck1");
            if (Session["Truck2"] != null) Session.Remove("Truck2");
            if (Session["Truck3"] != null) Session.Remove("Truck3");
            Session.Add("Truck1", Truck1);
            Session.Add("Truck2", Truck2);
            Session.Add("Truck3", Truck3);            

            //-----------------------------------------------------------------------------------------
            try
            {
                ddlCar1.Items.Insert(0, new ListItem("---الجميع---", "0"));

                List<InvOnLine> LInvNet = new List<InvOnLine>();
                InvOnLine InvNet = new InvOnLine();
                InvNet.Branch = 1;
                InvNet.VouLoc = "00000";
                InvNet.Site = AreaNo;
                LInvNet = InvNet.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString); 
                int? r = LInvNet.Count();
                if (r != null)
                {
                    lblCarOnLine.Text = r.ToString();
                    lblCarOnLine2.Text = r.ToString();
                }

                ddlCar2.DataTextField = "Code";
                ddlCar2.DataValueField = "Name1";
                ddlCar2.DataSource = (from itm in LInvNet
                                      select new CostCenter {
                                      Code = itm.VouNo.ToString(),
                                      Name1 = itm.SLat + "#" + itm.SLng + "#" + itm.VouNo.ToString()
                                      }).ToList();

                ddlCar2.DataBind();
                ddlCar2.Items.Insert(0, new ListItem("---الجميع---", "0"));

                ddlCar3.Items.Insert(0, new ListItem("---الجميع---", "0"));
            }
            catch { }
            //------------------------------------------------------------------------------------------
            try
            {
                List<Water> LWater = new List<Water>();
                Water WaterNet2 = new Water();
                LWater = WaterNet2.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                int? r = LWater.Count();
                if (r != null)
                {
                    lblWaterInv.Text = r.ToString();
                    lblWaterInv2.Text = r.ToString();
                }

                ddlWater1.DataTextField = "Code";
                ddlWater1.DataValueField = "Name1";
                ddlWater1.DataSource = (from itm in LWater
                                        select new CostCenter
                                        {
                                            Code = int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                            Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                        }).ToList();
                ddlWater1.DataBind();
                ddlWater1.Items.Insert(0, new ListItem("---الجميع---", "0"));

                List<WaterOnline> LWaterOnLine = new List<WaterOnline>();
                WaterOnline WaterNet = new WaterOnline();
                WaterNet.Branch = 1;
                WaterNet.VouLoc = "1";
                LWaterOnLine = WaterNet.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                r = LWaterOnLine.Count();
                if (r != null)
                {
                    lblWaterOnLine.Text = r.ToString();
                    lblWaterOnLine2.Text = r.ToString();
                }

                ddlWater2.DataTextField = "Code";
                ddlWater2.DataValueField = "Name1";
                ddlWater2.DataSource = (from itm in LWaterOnLine
                                        select new CostCenter
                                        {
                                            Code = itm.VouNo.ToString(),
                                            Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                        }).ToList();
                ddlWater2.DataBind();
                ddlWater2.Items.Insert(0, new ListItem("---الجميع---", "0"));

                ddlWater3.Items.Insert(0, new ListItem("---الجميع---", "0"));
            }
            catch { }
            //-------------------------------------------------------------------------------------------
            try
            {
                List<EmergInv> le = new List<EmergInv>();
                EmergInv Emerg = new EmergInv();
                le = Emerg.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                int? r = le.Count();
                if (r != null)
                {
                    lblEmergOnLine.Text = r.ToString();
                    lblEmergOnLine2.Text = r.ToString();
                }

                ddlService1.DataTextField = "Code";
                ddlService1.DataValueField = "Name1";
                ddlService1.DataSource = (from itm in le
                                          select new CostCenter
                                          {
                                              Code = int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                              Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                          }).ToList();
                ddlService1.DataBind();
                ddlService1.Items.Insert(0, new ListItem("---الجميع---", "0"));

                List<Emergency> leNet = new List<Emergency>();
                Emergency EmergNet = new Emergency();
                EmergNet.Branch = 1;
                EmergNet.VouLoc = "1";
                leNet = EmergNet.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
                r = leNet.Count();
                if (r != null)
                {
                    lblEmergOnLine.Text = r.ToString();
                    lblEmergOnLine2.Text = r.ToString();
                }
                ddlService2.DataTextField = "Code";
                ddlService2.DataValueField = "Name1";
                ddlService2.DataSource = (from itm in leNet
                                          select new CostCenter
                                          {
                                              Code = itm.VouNo.ToString(),
                                              Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                          }).ToList();
                ddlService2.DataBind();
                ddlService2.Items.Insert(0, new ListItem("---الجميع---", "0"));


                ddlService3.Items.Insert(0, new ListItem("---الجميع---", "0"));
            }
            catch { }
            //-------------------------------------------------------------------------------------------
            try
            {
                
                List<Shipment> lShip = new List<Shipment>();
                Shipment myShip = new Shipment();
                lShip = (from itm in myShip.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                         where itm.LocTo != "" || itm.LocFrom != ""
                         select itm).ToList();
                int? r = lShip.Count();
                if (r != null)
                {
                    lblShipInv.Text = r.ToString();
                    lblShipInv2.Text = r.ToString();
                }
                ddlShip1.DataTextField = "Code";
                ddlShip1.DataValueField = "Name1";
                ddlShip1.DataSource = (from itm in lShip
                                       select new CostCenter
                                       {
                                           Code = int.Parse(itm.VouLoc).ToString()+"/"+itm.VouNo.ToString(),
                                           Name1 = (itm.LocFrom != "" ? itm.LocFrom + "#" + itm.VouNo.ToString() : itm.LocTo + "#" + itm.VouNo.ToString())
                                       }).ToList();                                       
                ddlShip1.DataBind();
                ddlShip1.Items.Insert(0, new ListItem("---الجميع---", "0"));

                List<ShipOnLine> lShipNet = new List<ShipOnLine>();
                ShipOnLine myShipNet = new ShipOnLine();
                lShipNet = (from itm in myShipNet.GetAll(AreaNo, WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            where itm.LocTo != "" || itm.LocFrom != ""
                            select itm).ToList();
                r = lShipNet.Count();
                if (r != null)
                {
                    lblShipOnLine.Text = r.ToString();
                    lblShipOnLine2.Text = r.ToString();
                }
                ddlShip2.DataTextField = "Code";
                ddlShip2.DataValueField = "Name1";
                ddlShip2.DataSource = (from itm in lShipNet
                                       select new CostCenter
                                       {
                                           Code = itm.VouNo.ToString(),
                                           Name1 = (itm.LocFrom != "" ? itm.LocFrom + "#" + itm.VouNo.ToString() : itm.LocTo + "#" + itm.VouNo.ToString())
                                       }).ToList();                                       
                ddlShip2.DataBind();
                ddlShip2.Items.Insert(0, new ListItem( "---الجميع---","0"));

                ddlShip3.Items.Insert(0, new ListItem("---الجميع---", "0"));
            }
            catch { }
            //-------------------------------------------------------------------------------------------
            try
            {
                List<Gas> lGas = new List<Gas>();
                Gas myGas = new Gas();
                lGas = (from itm in myGas.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                         select itm).ToList();
                int? r = lGas.Count();
                if (r != null)
                {
                    lblGasInv1.Text = r.ToString();
                }
                ddlGas1.DataTextField = "Code";
                ddlGas1.DataValueField = "Name1";
                ddlGas1.DataSource = (from itm in lGas
                                       select new CostCenter
                                       {
                                           Code = int.Parse(itm.VouLoc).ToString() + "/" + itm.VouNo.ToString(),
                                           Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                       }).ToList();
                ddlGas1.DataBind();
                ddlGas1.Items.Insert(0, new ListItem("---الجميع---", "0"));

                List<GasOnline> lGasNet = new List<GasOnline>();
                GasOnline myGasNet = new GasOnline();
                myGasNet.Branch = 1;
                myGasNet.VouLoc = "1";
                lGasNet = (from itm in myGasNet.GetAll(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString)
                            select itm).ToList();
                r = lGasNet.Count();
                if (r != null)
                {
                    lblGasInv2.Text = r.ToString();
                }
                ddlGas2.DataTextField = "Code";
                ddlGas2.DataValueField = "Name1";
                ddlGas2.DataSource = (from itm in lGasNet
                                       select new CostCenter
                                       {
                                           Code = itm.VouNo.ToString(),
                                           Name1 = itm.PickLat + "#" + itm.PickLong + "#" + itm.VouNo.ToString()
                                       }).ToList();
                ddlGas2.DataBind();
                ddlGas2.Items.Insert(0, new ListItem("---الجميع---", "0"));

                ddlGas3.Items.Insert(0, new ListItem("---الجميع---", "0"));
            }
            catch { }

            TripWayPoints tp = new TripWayPoints();
            ddlTrip.DataTextField = "LocDateTime";
            ddlTrip.DataTextField = "LocDateTime";
            ddlTrip.DataSource = tp.GetAll2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            ddlTrip.DataBind();
            ddlTrip.Items.Insert(0, new ListItem("السائق  التاريخ  الشاحنة  المستند --- أختار المسار", "0"));

            TripLog mylog = new TripLog();
            List<TripLog> llog = new List<TripLog>();
            llog = mylog.GetAllFDate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            ddlFDate.DataTextField = "FTime";
            ddlFDate.DataValueField = "FDate";
            ddlFDate.DataSource = llog;
            ddlFDate.DataBind();
            ddlFDate.SelectedIndex = llog.Count()-1;
            ddlFDate_SelectedIndexChanged(ddlFDate, null);


            // Restore ViewState
            if (gTruck1 != "-1" && ddlTruck1.SelectedIndex != int.Parse(gTruck1))
            {
                ddlTruck1.SelectedIndex = int.Parse(gTruck1);                
            }
            if (gTruck2 != "-1" && ddlTruck2.SelectedIndex != int.Parse(gTruck2))
            {
                ddlTruck2.SelectedIndex = int.Parse(gTruck2);
            }
            if (gTruck3 != "-1" && ddlTruck3.SelectedIndex != int.Parse(gTruck3))
            {
                ddlTruck3.SelectedIndex = int.Parse(gTruck3);
            }

            if (gCar1 != "-1" && ddlCar1.SelectedIndex != int.Parse(gCar1))
            {
                ddlCar1.SelectedIndex = int.Parse(gCar1);
                ddlCar1_SelectedIndexChanged(ddlCar1,null);
            }

            if (gCar2 != "-1" && ddlCar2.SelectedIndex != int.Parse(gCar2))
            {
                ddlCar2.SelectedIndex = int.Parse(gCar2);
                ddlCar2_SelectedIndexChanged(ddlCar2, null);
            }

            if (gCar3 != "-1" && ddlCar3.SelectedIndex != int.Parse(gCar3))
            {
                ddlCar3.SelectedIndex = int.Parse(gCar3);
                ddlCar3_SelectedIndexChanged(ddlCar3, null);
            }

            if (gShip1 != "-1" && ddlShip1.SelectedIndex != int.Parse(gShip1))
            {
                ddlShip1.SelectedIndex = int.Parse(gShip1);
                ddlShip1_SelectedIndexChanged(ddlShip1, null);
            }

            if (gShip2 != "-1" && ddlShip2.SelectedIndex != int.Parse(gShip2))
            {
                ddlShip2.SelectedIndex = int.Parse(gShip2);
                ddlShip2_SelectedIndexChanged(ddlShip2, null);
            }

            if (gShip3 != "-1" && ddlShip3.SelectedIndex != int.Parse(gShip3))
            {
                ddlShip3.SelectedIndex = int.Parse(gShip3);
                ddlShip3_SelectedIndexChanged(ddlShip3, null);
            }

            if (gWater1 != "-1" && ddlWater1.SelectedIndex != int.Parse(gWater1))
            {
                ddlWater1.SelectedIndex = int.Parse(gWater1);
                ddlWater1_SelectedIndexChanged(ddlWater1, null);
            }

            if (gWater2 != "-1" && ddlWater2.SelectedIndex != int.Parse(gWater2))
            {
                ddlWater2.SelectedIndex = int.Parse(gWater2);
                ddlWater2_SelectedIndexChanged(ddlWater2, null);
            }

            if (gWater3 != "-1" && ddlWater3.SelectedIndex != int.Parse(gWater3))
            {
                ddlWater3.SelectedIndex = int.Parse(gWater3);
                ddlWater3_SelectedIndexChanged(ddlWater3, null);
            }

            if (gEmer1 != "-1" && ddlService1.SelectedIndex != int.Parse(gEmer1))
            {
                ddlService1.SelectedIndex = int.Parse(gEmer1);
                ddlService1_SelectedIndexChanged(ddlService1, null);
            }

            if (gEmer2 != "-1" && ddlService2.SelectedIndex != int.Parse(gEmer2))
            {
                ddlService2.SelectedIndex = int.Parse(gEmer2);
                ddlService2_SelectedIndexChanged(ddlService2, null);
            }

            if (gEmer3 != "-1" && ddlService3.SelectedIndex != int.Parse(gEmer3))
            {
                ddlService3.SelectedIndex = int.Parse(gEmer3);
                ddlService3_SelectedIndexChanged(ddlService3, null);
            }

            if (gGas1 != "-1" && ddlGas1.SelectedIndex != int.Parse(gGas1))
            {
                ddlGas1.SelectedIndex = int.Parse(gGas1);
                ddlGas1_SelectedIndexChanged(ddlGas1, null);                  
            }

            if (gGas2 != "-1" && ddlGas2.SelectedIndex != int.Parse(gGas2))
            {
                ddlGas2.SelectedIndex = int.Parse(gGas2);
                ddlGas2_SelectedIndexChanged(ddlGas2, null);
            }

            if (gGas3 != "-1" && ddlGas3.SelectedIndex != int.Parse(gGas3))
            {
                ddlGas3.SelectedIndex = int.Parse(gGas3);
                ddlGas3_SelectedIndexChanged(ddlGas3, null);
            }

            bool vdo = false;
            if (bool.Parse(gChkCar) != this.ChkType.Items[0].Selected)
            {
                this.ChkType.Items[0].Selected = bool.Parse(gChkCar);
                vdo = true;
            }

            if (bool.Parse(gChkShip) != this.ChkType.Items[1].Selected)
            {
                this.ChkType.Items[1].Selected = bool.Parse(gChkShip);
                vdo = true;
            }

            if (bool.Parse(gChkEmer) != this.ChkType.Items[2].Selected)
            {
                this.ChkType.Items[2].Selected = bool.Parse(gChkEmer);
                vdo = true;
            }

            if (bool.Parse(gChkWater) != this.ChkType.Items[3].Selected)
            {
                this.ChkType.Items[3].Selected = bool.Parse(gChkWater);
                vdo = true;
            }

            if (bool.Parse(gChkGas) != this.ChkType.Items[4].Selected)
            {
                this.ChkType.Items[4].Selected = bool.Parse(gChkGas);
                vdo = true;
            }

            if (vdo) ChkType_SelectedIndexChanged(ChkType, null);

            if (gCity != "-1" && this.ddlCity.SelectedIndex != int.Parse(gCity))
            {
                this.ddlCity.SelectedIndex = int.Parse(gCity);               
            }

            if (gTrip != "-1" && this.ddlTrip.SelectedIndex != int.Parse(gTrip))
            {
                this.ddlTrip.SelectedIndex = int.Parse(gTrip);                
            }

            if(gOnline != "-1" && this.ddlDriverOnLine.SelectedIndex != int.Parse(gOnline))
            {
                this.ddlDriverOnLine.SelectedIndex = int.Parse(gOnline);               
            }

            if (gOffline != "-1" && this.ddlDriver2.SelectedIndex != int.Parse(gOffline))
            {
                this.ddlDriver2.SelectedIndex = int.Parse(gOffline);
            }

            if (gFDate != "-1" && this.ddlFDate.SelectedIndex != int.Parse(gFDate))
            {
                this.ddlFDate.SelectedIndex = int.Parse(gFDate);
                ddlFDate_SelectedIndexChanged(ddlFDate, null);
            }

            //-------------------------------------------------------------------------------------------
            lblTime.Text = "تم تحديث البيانات بتاريخ " + moh.Nows().ToString(); 
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            RefreshAll();
        }


        [System.Web.Services.WebMethod(EnableSession = true)]
        public static string[] GetDate(string InvType)
        {
            if (InvType == "1")
            {
                ShipUsers myShipUsers = new ShipUsers();
                myShipUsers.Online = 1;
                string[] myData = (from d in myShipUsers.GetByOnline(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.UserType == 2 && d.PLat != "" && d.PLong != "" && CheckTruck((List<string>)HttpContext.Current.Session["Truck1"], GetCar(d.ID))
                                   select d.PLat + "#" + d.PLong + '#' + @"<i class='fa fa-truck' style='color: Blue;'></i>&ensp;" + GetCarNo(d.ID) +
                                   @"<br/><i class='fa fa-male' style='color: Blue;'></i>&ensp;&ensp;" + d.ID + @"&ensp;" + d.FirstName + @"&ensp;" + d.LastName +
                                   @"<br/><i class='fa fa-phone' style='color: Blue;'></i>&ensp;&ensp;" + '0' + d.MobileNo.Substring(3)).ToArray();
                return myData;
            }
            else if (InvType == "2")
            {

                InvOnLine myShipUsers = new InvOnLine();
                myShipUsers.Branch = 1;
                myShipUsers.VouLoc = "00000";
                myShipUsers.Site = "00001";
                string[] myData = (from d in myShipUsers.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.SLat != "" && d.SLng != ""
                                   select d.SLat + "#" + d.SLng + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" + d.VouNo.ToString() +
                                   @"<br/><i class='fa fa-thumbs-up' style='color: Blue;'></i>&ensp;&ensp;" +                                    
                                   @"<a target='_blank' href='WebInvoice.aspx?AreaNo=" + HttpContext.Current.Session["AreaNo"].ToString() + "&StoreNo=" +  HttpContext.Current.Session["StoreNo"].ToString() + "&FMode=99&FNum=" + d.VouNo.ToString() + @"'>أعتماد الفاتورة</a>").ToArray();
                return myData;
            }
            else if (InvType == "3")
            {
                WaterOnline myShipUsers = new WaterOnline();
                myShipUsers.Branch = 1;
                myShipUsers.VouLoc = "1";
                string[] myData = (from d in myShipUsers.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" + d.VouNo.ToString() +
                                   @"<br/><i class='fa fa-thumbs-up' style='color: Blue;'></i>&ensp;&ensp;" +
                                   @"<a target='_blank' href='WebWater.aspx?AreaNo=" + HttpContext.Current.Session["AreaNo"].ToString() + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&InvNo=" + d.VouNo.ToString() + @"'>أعتماد الفاتورة</a>").ToArray();
                return myData;
            }
            else if (InvType == "4")
            {
                Water myShipUsers = new Water();
                string[] myData = (from d in myShipUsers.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" +
                                   @"<a target='_blank' href='WebWater.aspx?AreaNo=" + moh.MakeMask(d.VouLoc,5) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&Flag=0&FNum=" + d.VouNo.ToString() + @"'>" + int.Parse(d.VouLoc).ToString() + "/" + d.VouNo.ToString() + @"</a>").ToArray();
                return myData;
            }
            //else if (InvType == "5")
            //{
                //Invoice myInv = new Invoice();
                //return myData;
            //}
            else if (InvType == "6")
            {
                Shipment myShip = new Shipment();
                string[] myData = (from d in myShip.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.LocTo != "" || d.LocFrom != ""
                                   select (d.LocFrom != "" ?  d.LocFrom + '#' +                                    
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" +
                                   @"<a target='_blank' href='WebShipment.aspx?AreaNo=" + moh.MakeMask(d.VouLoc,5) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&Flag=0&FNum=" + d.VouNo.ToString() + @"'>" + int.Parse(d.VouLoc).ToString() + "/" + d.VouNo.ToString() + @"</a>"
                                  // @"<br/><i class='fa fa-link' style='color: Blue;'></i>&ensp;" +
                                  // "<a href='javascript:__doPostBack(\"Hello\",\"b2\");'" + @"'>" + "تجميع الفاتورة" + @"</a>"                                                                                                       
                                   : d.LocTo + '#' +
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" +
                                   @"<a target='_blank' href='WebShipment.aspx?AreaNo=" + moh.MakeMask(d.VouLoc,5) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&Flag=0&FNum=" + d.VouNo.ToString() + @"'>" + int.Parse(d.VouLoc).ToString() + "/" + d.VouNo.ToString() + @"</a><br/>"
                                   // @"<i class='fa fa-link' style='color: Blue;'></i>&ensp;" +
                                   // "<a href='javascript:__doPostBack(\"Hello\",\"b2\");'" + @"'>" + "تجميع الفاتورة" + @"</a>"                                                                     
                                   )).ToArray();
                return myData;
            }
            else if (InvType == "7")
            {
                ShipOnLine myShip = new ShipOnLine();
                string[] myData = (from d in myShip.GetAll("00001",WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.SLat != "" && d.SLng != ""
                                   select d.SLat + "#" + d.SLng + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" + d.VouNo.ToString() +
                                   @"<br/><i class='fa fa-thumbs-up' style='color: Blue;'></i>&ensp;&ensp;" +
                                   @"<a target='_blank' href='WebShipment.aspx?AreaNo=" + HttpContext.Current.Session["AreaNo"].ToString() + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&FMode=99&FNum=" + d.VouNo.ToString() + @"'>أعتماد الفاتورة</a>").ToArray();
                return myData;
            }
            else if (InvType == "8")
            {
                EmergInv InvNet = new EmergInv();
                string[] myData = (from d in InvNet.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" +
                                   @"<a target='_blank' href='WebEmergInv.aspx?AreaNo=" + moh.MakeMask(d.VouLoc,5) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&Flag=0&FNum=" + d.VouNo.ToString() + @"'>" + int.Parse(d.VouLoc).ToString() + "/" + d.VouNo.ToString() + @"</a>").ToArray();
                return myData;
            }
            else if (InvType == "9")
            {
                Emergency InvNet = new Emergency();
                InvNet.Branch = 1;
                InvNet.VouLoc = "1";
                string[] myData = (from d in InvNet.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" + d.VouNo.ToString() +
                                   @"<br/><i class='fa fa-thumbs-up' style='color: Blue;'></i>&ensp;&ensp;" +
                                   @"<a target='_blank' href='WebEmergInv.aspx?AreaNo=" + HttpContext.Current.Session["AreaNo"].ToString() + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&InvNo=" + d.VouNo.ToString() + @"'>أعتماد الفاتورة</a>").ToArray();
                return myData;
            }
            else if (InvType == "10")
            {
                Gas InvNet = new Gas();
                string[] myData = (from d in InvNet.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" +
                                   @"<a target='_blank' href='WebGas.aspx?AreaNo=" + moh.MakeMask(d.VouLoc,5) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&Flag=0&FNum=" + d.VouNo.ToString() + @"'>" + int.Parse(d.VouLoc).ToString() + "/" + d.VouNo.ToString() + @"</a>").ToArray();
                return myData;
            }

            else if (InvType == "11")
            {
                GasOnline InvNet = new GasOnline();
                InvNet.Branch = 1;
                InvNet.VouLoc = "00001";
                string[] myData = (from d in InvNet.GetAll(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.PickLat != "" && d.PickLong != ""
                                   select d.PickLat + "#" + d.PickLong + '#' + 
                                   @"<i class='fa fa-file-text-o' style='color: Blue;'></i>&ensp;" + d.VouNo.ToString() +
                                   @"<br/><i class='fa fa-thumbs-up' style='color: Blue;'></i>&ensp;&ensp;" +
                                   @"<a target='_blank' href='WebGas.aspx?AreaNo=" + HttpContext.Current.Session["AreaNo"].ToString() + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&InvNo=" + d.VouNo.ToString() + @"'>أعتماد الفاتورة</a>").ToArray();
                return myData;
            }
            else if (InvType == "13")
            {
                ShipUsers myShipUsers = new ShipUsers();
                myShipUsers.Online = 1;
                string[] myData = (from d in myShipUsers.GetByOnline(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.UserType == 2 && d.PLat != "" && d.PLong != "" && CheckTruck((List<string>)HttpContext.Current.Session["Truck2"], GetCar(d.ID))
                                   select d.PLat + "#" + d.PLong + '#' + @"<i class='fa fa-truck' style='color: Blue;'></i>&ensp;" + GetCarNo(d.ID) +
                                   @"<br/><i class='fa fa-male' style='color: Blue;'></i>&ensp;&ensp;" + d.ID + @"&ensp;" + d.FirstName + @"&ensp;" + d.LastName +
                                   @"<br/><i class='fa fa-phone' style='color: Blue;'></i>&ensp;&ensp;" + '0' + d.MobileNo.Substring(3)).ToArray();

                return myData;
            }
            else if (InvType == "14")
            {
                ShipUsers myShipUsers = new ShipUsers();
                myShipUsers.Online = 1;
                string[] myData = (from d in myShipUsers.GetByOnline(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString)
                                   where d.UserType == 2 && d.PLat != "" && d.PLong != "" && CheckTruck((List<string>)HttpContext.Current.Session["Truck3"], GetCar(d.ID))
                                   select d.PLat + "#" + d.PLong + '#' + @"<i class='fa fa-truck' style='color: Blue;'></i>&ensp;" + GetCarNo(d.ID) +
                                   @"<br/><i class='fa fa-male' style='color: Blue;'></i>&ensp;&ensp;" + d.ID + @"&ensp;" + d.FirstName + @"&ensp;" + d.LastName +
                                   @"<br/><i class='fa fa-phone' style='color: Blue;'></i>&ensp;&ensp;" + '0' + d.MobileNo.Substring(3) +
                                   @"<br/><i class='fa fa-file-text' style='color: Blue;'></i>&ensp;&ensp;" +
                                   @"<a target='_blank' href='WebCarMove.aspx?AreaNo=" + GetCarMoveArea(GetCar(d.ID)) + "&StoreNo=" + HttpContext.Current.Session["StoreNo"].ToString() + "&FMode=99&FNum=" + GetCarMove(GetCar(d.ID)) + @"'>" + GetMyCarMove(GetCar(d.ID)) + @"</a>"
                                   + "#" + GetMyDirection(GetCar(d.ID),d.ID)).ToArray();                                                   
                return myData;
            }

            else return new string[] { "111", "222", "333", "444", "555" };
        }

        public static string GetMyCarMove(string CarNo)
        {
            CarMove cm = new CarMove();
            cm.CarCode = CarNo;
            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
            if (cm != null) return int.Parse(cm.VouLoc).ToString() + "/" + cm.Number.ToString();
            else return "";
        }


        public static string GetMyDirection(string CarNo, string DriverId)
        {
            CarMove cm = new CarMove();
            cm.CarCode = CarNo;
            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
            if (cm != null)
            {
                List<TripLog> ltrip = new List<TripLog>();
                TripLog myTripLog = new TripLog();
                myTripLog.Branch = 1;
                myTripLog.VouLoc = cm.VouLoc;
                myTripLog.VouNo = cm.Number;
                myTripLog.DriverId = DriverId;
                myTripLog.FDate = String.Format("{0:dd/MM/yyyy}", moh.Nows());
                ltrip = myTripLog.GetByDriverID2(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
                if(ltrip != null)
                {
                    string vStart = (from itm in ltrip
                                    orderby itm.FNo
                                    select itm.Lng).FirstOrDefault();
                    string vLast = (from itm in ltrip
                                    orderby itm.FNo
                                    select itm.Lng).LastOrDefault();
                    if(vStart != null && vLast != null)
                    {
                        if(double.Parse(vStart) > double.Parse(vLast)) return "1";
                        else return "2";                        
                    }
                    else return "1";                
                }
                else return "1";
            }
            else
            {
                return "1";
            };
        }


        public static string GetCarMove(string CarNo)
        {
            CarMove cm = new CarMove();
            cm.CarCode = CarNo;
            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
            if (cm != null) return cm.Number.ToString();
            else return "";
        }

        public static string GetCarMoveArea(string CarNo)
        {
            CarMove cm = new CarMove();
            cm.CarCode = CarNo;
            cm = cm.FindLast(WebConfigurationManager.ConnectionStrings[HttpContext.Current.Session["CNN"].ToString()].ConnectionString);
            if (cm != null) return cm.VouLoc;
            else return "";
        }

        public static string GetCarNo(string DriverID)
        {
            Cars myCar = new Cars();
            myCar.Branch = 1;
            myCar.DriverCode = moh.MakeMask(DriverID,5);
            myCar = (from sitm in (List<Cars>)(HttpRuntime.Cache["Cars" + HttpContext.Current.Session["CNN2"].ToString()])
                     where sitm.DriverCode == myCar.DriverCode 
                     select sitm).FirstOrDefault();
            return myCar != null ? myCar.Code  + @"&ensp;" + myCar.PlateNo : "";
        
        }

        public static bool CheckTruck(List<string> myList,string CarNo)
        {
            bool result = false;
            foreach (string itm in myList)
            {
                if (itm == CarNo)
                {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static string GetCar(string DriverID)
        {
            Cars myCar = new Cars();
            myCar.Branch = 1;
            myCar.DriverCode = moh.MakeMask(DriverID, 5);
            myCar = (from sitm in (List<Cars>)(HttpRuntime.Cache["Cars" + HttpContext.Current.Session["CNN2"].ToString()])
                     where sitm.DriverCode == myCar.DriverCode && (bool)sitm.Status
                     select sitm).FirstOrDefault();
            return myCar != null ? myCar.Code: "";

        }

        protected void ChkType_SelectedIndexChanged(object sender, EventArgs e)
        {
            divCar1.Visible = ChkType.Items[0].Selected;
            divCar2.Visible = ChkType.Items[0].Selected;
            divCar3.Visible = ChkType.Items[0].Selected;
            lblCar1.Visible = ChkType.Items[0].Selected;
            lblCar2.Visible = ChkType.Items[0].Selected;
            lblCar3.Visible = ChkType.Items[0].Selected;
            div0Car1.Visible = ChkType.Items[0].Selected;
            div0Car2.Visible = ChkType.Items[0].Selected;
            div0Car3.Visible = ChkType.Items[0].Selected;

            divExpress1.Visible = ChkType.Items[1].Selected;
            divExpress2.Visible = ChkType.Items[1].Selected;
            divExpress3.Visible = ChkType.Items[1].Selected;
            lblExpress1.Visible = ChkType.Items[1].Selected;
            lblExpress2.Visible = ChkType.Items[1].Selected;
            lblExpress3.Visible = ChkType.Items[1].Selected;
            div0Express1.Visible = ChkType.Items[1].Selected;
            div0Express2.Visible = ChkType.Items[1].Selected;
            div0Express3.Visible = ChkType.Items[1].Selected;

            diver1.Visible = ChkType.Items[2].Selected;
            diver2.Visible = ChkType.Items[2].Selected;
            diver3.Visible = ChkType.Items[2].Selected;
            lblEr1.Visible = ChkType.Items[2].Selected;
            lblEr2.Visible = ChkType.Items[2].Selected;
            lblEr3.Visible = ChkType.Items[2].Selected;
            div0Er1.Visible = ChkType.Items[2].Selected;
            div0Er2.Visible = ChkType.Items[2].Selected;
            div0Er3.Visible = ChkType.Items[2].Selected;

            divWater1.Visible = ChkType.Items[3].Selected;
            divWater2.Visible = ChkType.Items[3].Selected;
            divWater3.Visible = ChkType.Items[3].Selected;
            lblWater1.Visible = ChkType.Items[3].Selected;
            lblWater2.Visible = ChkType.Items[3].Selected;
            lblWater3.Visible = ChkType.Items[3].Selected;
            div0Water1.Visible = ChkType.Items[3].Selected;
            div0Water2.Visible = ChkType.Items[3].Selected;
            div0Water3.Visible = ChkType.Items[3].Selected;

            lblGas1.Visible = ChkType.Items[4].Selected;
            lblGas2.Visible = ChkType.Items[4].Selected;
            lblGas3.Visible = ChkType.Items[4].Selected;
            div0Gas1.Visible = ChkType.Items[4].Selected;
            div0Gas2.Visible = ChkType.Items[4].Selected;
            div0Gas3.Visible = ChkType.Items[4].Selected;
        }

        protected void ddlCar1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCar1.SelectedIndex > 0)
            {
                this.HlnkViewCar1.NavigateUrl = "WebInvoice.aspx?AreaNo=" + moh.MakeMask(ddlCar1.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlCar1.SelectedItem.Text.Split('/')[1];
                this.HlnkViewCar1.Visible = true;
                this.MarkCar1.Visible = true;
                this.BtnCCar1.Visible = true;
                this.BtnDCar1.Visible = true;
            }
            else
            {
                this.HlnkViewCar1.NavigateUrl = "";
                this.HlnkViewCar1.Visible = false;
                this.MarkCar1.Visible = false;
                this.BtnCCar1.Visible = false;
                this.BtnDCar1.Visible = false;
            }
        }

        protected void ddlCar3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCar3.SelectedIndex > 0)
            {
                this.HlnkViewCar3.NavigateUrl = "WebInvoice.aspx?AreaNo=" + moh.MakeMask(ddlCar3.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlCar3.SelectedItem.Text.Split('/')[1];
                this.HlnkViewCar3.Visible = true;
                this.MarkCar3.Visible = true;
            }
            else
            {
                this.HlnkViewCar3.NavigateUrl = "";
                this.HlnkViewCar3.Visible = false;
                this.MarkCar3.Visible = false;
            }
        }

        protected void ddlCar2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlCar2.SelectedIndex > 0)
            {
                this.hlnkCar.NavigateUrl = "WebInvoice.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99&FNum=" + ddlCar2.SelectedItem.Text;
                this.hlnkCar.Visible = true;
                this.MarkCar2.Visible = true;
            }
            else
            {
                this.hlnkCar.NavigateUrl = "";
                this.hlnkCar.Visible = false;
                this.MarkCar2.Visible = false;
            }
        }

        protected void ddlShip1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShip1.SelectedIndex > 0)
            {
                HlnkViewExpress1.NavigateUrl = "WebShipment.aspx?AreaNo=" + moh.MakeMask(ddlShip1.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlShip1.SelectedItem.Text.Split('/')[1];
                HlnkViewExpress1.Visible = true;
                MarkExpress1.Visible = true;
                BtnCExpress1.Visible = true;
                BtnDExpress1.Visible = true;
            }
            else
            {
                HlnkViewExpress1.NavigateUrl = "";
                HlnkViewExpress1.Visible = false;
                MarkExpress1.Visible = false;
                BtnCExpress1.Visible = false;
                BtnDExpress1.Visible = false;
            }
        }

        protected void ddlShip3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShip3.SelectedIndex > 0)
            {
                this.HlnkViewExpress3.NavigateUrl = "WebShipment.aspx?AreaNo=" + moh.MakeMask(ddlShip3.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlShip3.SelectedItem.Text.Split('/')[1];
                this.HlnkViewExpress3.Visible = true;
                this.MarkExpress3.Visible = true;
            }
            else
            {
                this.HlnkViewExpress3.NavigateUrl = "";
                this.HlnkViewExpress3.Visible = false;
                this.MarkExpress3.Visible = false;
            }
        }

        protected void ddlShip2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlShip2.SelectedIndex > 0)
            {
                this.HlnkExpress.NavigateUrl = "WebShipment.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&FMode=99&FNum=" + ddlShip2.SelectedItem.Text;
                this.HlnkExpress.Visible = true;
                this.MarkExpress2.Visible = true;
            }
            else
            {
                this.HlnkExpress.NavigateUrl = "";
                this.HlnkExpress.Visible = false;
                this.MarkExpress2.Visible = false;
            }
        }

        protected void ddlWater1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWater1.SelectedIndex > 0)
            {
                this.HlnkViewWater1.NavigateUrl = "WebWater.aspx?AreaNo=" + moh.MakeMask(ddlWater1.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlWater1.SelectedItem.Text.Split('/')[1];
                this.HlnkViewWater1.Visible = true;
                this.MarkWater1.Visible = true;
            }
            else
            {
                this.HlnkViewWater1.NavigateUrl = "";
                this.HlnkViewWater1.Visible = false;
                this.MarkWater1.Visible = false;
            }
        }

        protected void ddlWater3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWater3.SelectedIndex > 0)
            {
                this.HlnkViewWater3.NavigateUrl = "WebWater.aspx?AreaNo=" + moh.MakeMask(ddlWater3.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlWater3.SelectedItem.Text.Split('/')[1];
                this.HlnkViewWater3.Visible = true;
                this.MarkWater3.Visible = true;
            }
            else
            {
                this.HlnkViewWater3.NavigateUrl = "";
                this.HlnkViewWater3.Visible = false;
                this.MarkWater3.Visible = false;
            }
        }

        protected void ddlWater2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlWater2.SelectedIndex > 0)
            {
                this.HlnkWater.NavigateUrl = "WebWater.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&InvNo=" + ddlWater2.SelectedItem.Text;
                this.HlnkWater.Visible = true;
                this.MarkWater2.Visible = true;
            }
            else
            {
                this.HlnkWater.NavigateUrl = "";
                this.HlnkWater.Visible = false;
                this.MarkWater2.Visible = false;
            }
        }

        protected void ddlService1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlService1.SelectedIndex > 0)
            {
                this.HlnkViewEr1.NavigateUrl = "WebEmergInv.aspx?AreaNo=" + moh.MakeMask(ddlService1.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlService1.SelectedItem.Text.Split('/')[1];
                this.HlnkViewEr1.Visible = true;
                this.MarkEr1.Visible = true;
            }
            else
            {
                this.HlnkViewEr1.NavigateUrl = "";
                this.HlnkViewEr1.Visible = false;
                this.MarkEr1.Visible = false;
            }
        }

        protected void ddlService3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlService3.SelectedIndex > 0)
            {
                this.HlnkViewEr3.NavigateUrl = "WebEmergInv.aspx?AreaNo=" + moh.MakeMask(ddlService3.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlService3.SelectedItem.Text.Split('/')[1];
                this.HlnkViewEr3.Visible = true;
                this.MarkEr3.Visible = true;
            }
            else
            {
                this.HlnkViewEr3.NavigateUrl = "";
                this.HlnkViewEr3.Visible = false;
                this.MarkEr3.Visible = false;
            }
        }

        protected void ddlService2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlService2.SelectedIndex > 0)
            {
                this.HlnkEr.NavigateUrl = "WebEmergInv.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&InvNo=" + ddlService2.SelectedItem.Text;
                this.HlnkEr.Visible = true;
                this.MarkEr2.Visible = true;
            }
            else
            {
                this.HlnkEr.NavigateUrl = "";
                this.HlnkEr.Visible = false;
                this.MarkEr2.Visible = false;
            }
        }

        protected void ddlGas1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGas1.SelectedIndex > 0)
            {
                this.HlnkViewGas1.NavigateUrl = "WebGas.aspx?AreaNo=" + moh.MakeMask(ddlGas1.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlGas1.SelectedItem.Text.Split('/')[1];
                this.HlnkViewGas1.Visible = true;
                this.MarkGas1.Visible = true;
            }
            else
            {
                this.HlnkViewGas1.NavigateUrl = "";
                this.HlnkViewGas1.Visible = false;
                this.MarkGas1.Visible = false;
            }
        }

        protected void ddlGas3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGas3.SelectedIndex > 0)
            {
                this.HlnkViewGas3.NavigateUrl = "WebGas.aspx?AreaNo=" + moh.MakeMask(ddlGas3.SelectedItem.Text.Split('/')[0], 5) + "&StoreNo=1" + "&Flag=0" + "&FNum=" + ddlGas3.SelectedItem.Text.Split('/')[1];
                this.HlnkViewGas3.Visible = true;
                this.MarkGas3.Visible = true;
            }
            else
            {
                this.HlnkViewGas3.NavigateUrl = "";
                this.HlnkViewGas3.Visible = false;
                this.MarkGas3.Visible = false;
            }
        }

        protected void ddlGas2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlGas2.SelectedIndex > 0)
            {
                this.HlnkGas.NavigateUrl = "WebGas.aspx?AreaNo=" + AreaNo + "&StoreNo=" + StoreNo + "&InvNo=" + ddlGas2.SelectedItem.Text;
                this.HlnkGas.Visible = true;
                this.MarkGas2.Visible = true;
            }
            else
            {
                this.HlnkGas.NavigateUrl = "";
                this.HlnkGas.Visible = false;
                this.MarkGas2.Visible = false;
            }
        }

        protected void BtnClear1_Click(object sender, EventArgs e)
        {
            this.lstCollect.Items.Clear();
        }

        protected void BtnClear2_Click(object sender, EventArgs e)
        {
            this.lstDist.Items.Clear();
        }

        protected void BtnCCar1_Click(object sender, EventArgs e)
        {
            if (ddlCar1.SelectedIndex > 0)
            {
                bool vfound = false;
                for (int i = 0; i < lstCollect.Items.Count; i++)
                {
                    if (lstCollect.Items[i].Text == ddlCar1.SelectedItem.Text)
                    {
                        vfound = true;
                        break;
                    }
                }
                if (!vfound) lstCollect.Items.Add(ddlCar1.SelectedItem.Text);
            }
        }

        protected void BtnCExpress1_Click(object sender, EventArgs e)
        {
            if (this.ddlShip1.SelectedIndex > 0)
            {
                bool vfound = false;
                for (int i = 0; i < lstCollect.Items.Count; i++)
                {
                    if (lstCollect.Items[i].Text == ddlShip1.SelectedItem.Text)
                    {
                        vfound = true;
                        break;
                    }
                }
                if (!vfound) lstCollect.Items.Add(ddlShip1.SelectedItem.Text);
            }
        }

        protected void ddlFDate_SelectedIndexChanged(object sender, EventArgs e)
        {
            TripLog mylog = new TripLog();
            mylog.FDate = ddlFDate.SelectedValue;
            grdCodes.DataSource = mylog.GetAllByFDate(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString);
            grdCodes.DataBind();
        }

        protected void ddlTrip_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlTrip.SelectedIndex > 0)
            {
                ListWayPoints.Items.Clear();
                string[] tokens = ddlTrip.SelectedValue.Split(' ');
                TripWayPoints tp = new TripWayPoints();
                tp.ID = tokens[0];
                tp.LocDateTime = tokens[1];
                tp.CarNo = tokens[2];
                tp.VouLoc = (tokens[3].Split('/')[0] == "0" ? tokens[3].Split('/')[0] : moh.MakeMask(tokens[3].Split('/')[0],5));
                tp.VouNo = int.Parse(tokens[3].Split('/')[1]);
                foreach (TripWayPoints itm in tp.find2(WebConfigurationManager.ConnectionStrings[Session["CNN"].ToString()].ConnectionString))
                {
                    bool vFound = false;
                    for (int i = 0; i < ListWayPoints.Items.Count - 1; i++)
                    {
                        if (ListWayPoints.Items[i].Text == itm.PLat + "#" + itm.PLong)
                        {
                            vFound = true;
                            break;
                        }
                    }
                    if(!vFound) ListWayPoints.Items.Add(itm.PLat + "#" + itm.PLong);
                }
            }
        }

    }





}