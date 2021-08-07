using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;


namespace NESTEDTREEVIEW
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {


        // DATA CATEGORIES
        public class CAR
        {

            public INFO Info = new INFO();
            public MECHANIC Mechanic = new MECHANIC();
            public ELECTRONIC Electronic = new ELECTRONIC();
            public INTERIOR Interior = new INTERIOR();
            public BODY Body = new BODY();



            public class INFO
            {
                public string BrandName;
                public string ModelName;
                public string OwnerName;
                public string OwnerSurName;
                public string OwnerAddress;
                public string OwnerPhone;
                public string OwnerEmail;
                public string FuelType;
                public string ZeroHundredSecond;
                public string TopSpeed;
                public string Color;
                public double BuyPrice;
                public double SellPrice;
                public double Mileage;
                public double Weight;

            }
            public class MECHANIC
            {

                public ENGINE Engine = new ENGINE();
                public TRANSMISSION Transmission = new TRANSMISSION();
                public CHASIS Chasis = new CHASIS();


                public class ENGINE
                {
                    public int CylinderCount;
                    public double HorsePower;
                    public double Litre;
                    public string ModelName;
                    public string IdentificationNumber;
                    public double AverageConsumptionPerKm;
                    public string Turbo;


                }
                public class TRANSMISSION
                {
                    public int GearCount;
                    public string ManualAutomatic;
                    public string TransmissionModel;
                }
                public class CHASIS
                {

                    public string ShockAbsorberType;
                    public string ShockAbsorberModel;
                    public string BrakeModel;
                    public string SteeringType;
                    public string WheelDimension;
                }

            }
            public class ELECTRONIC
            {
                public string HiFiStere;
                public string TouchScreen;
                public string SeatHeating;
                public string MirrorHeating;
                public string HeadLightType;
                public string BackSideAC;
                public string Airbag;

            }
            public class BODY
            {
                public int DoorCount;
                public string AutomaticTrunk;
            }
            public class INTERIOR
            {
                public string SeatMaterial;
                public string SoundInsulation;
                public string ArmRest;
                public string RacingSeats;
            }

        }
        public class MOTORCYCLE
        {

            public INFO Info = new INFO();
            public MECHANIC Mechanic = new MECHANIC();
            public ELECTRONIC Electronic = new ELECTRONIC();


            public class INFO
            {
                public string BrandName;
                public string ModelName;
                public string OwnerName;
                public string OwnerSurName;
                public string OwnerAddress;
                public string OwnerPhone;
                public string OwnerEmail;
                public string FuelType;
                public string ZeroHundredSecond;
                public string TopSpeed;
                public string Color;
                public double BuyPrice;
                public double SellPrice;
                public double Mileage;
                public double Weight;
            }
            public class MECHANIC
            {

                public ENGINE Engine = new ENGINE();
                public TRANSMISSION Transmission = new TRANSMISSION();
                public CHASIS Chasis = new CHASIS();

                public class ENGINE
                {
                    public int CylinderCount;
                    public double HorsePower;
                    public double Litre;
                    public string ModelName;
                    public string IdentificationNumber;
                    public double AverageConsumptionPerKm;
                    public string Turbo;
                }
                public class TRANSMISSION
                {
                    public int GearCount;
                    public string ManualAutomatic;
                    public string TransmissionModel;
                }

                public class CHASIS
                {
                    public string ShockAbsorberType;
                    public string ShockAbsorberModel;
                    public string BrakeModel;
                    public string SteeringType;
                    public string WheelDimension;
                }

            }
            public class ELECTRONIC
            {
                public string HeadLightType;
                public string ElectronicSuspensionAdjustment;
            }

        }
        public class BICYCLE
        {
            public INFO Info = new INFO();
            public MECHANIC Mechanic = new MECHANIC();

            public class INFO
            {
                public string BrandName;
                public string ModelName;
                public string OwnerName;
                public string OwnerSurName;
                public string OwnerAddress;
                public string OwnerPhone;
                public string OwnerEmail;
                public string Color;
                public double BuyPrice;
                public double SellPrice;
                public double Weight;

            }
            public class MECHANIC
            {


                public TRANSMISSION Transmission = new TRANSMISSION();
                public CHASIS Chasis = new CHASIS();


                public class TRANSMISSION
                {
                    public int GearCount;
                    public string TransmissionModel;
                }

                public class CHASIS
                {
                    public string ChasisMaterial;
                    public string ShockAbsorber;
                }

            }


        }

       
        // TREEVIEW SOURCE LIST
        List<object> VehiclesInStock = new List<object>();
      
        // BUFFER TREEVIEWITEM FOR KEEPING TRACK OF RIGHT CLICKED TREEVIEWITEM
        TreeViewItem RightClickedTreeViewItem;



        public MainWindow()
        {
            InitializeComponent();
            CreateSampleVehicles();
        }

        //POPULATE TREEVIEW FROM DATA AFTER THE WINDOW IS LOADED SO ALL VISUAL UI ELEMENTS ARE RENDERED AND ACTUALWIDTH PROPERTY OF UI ELEMENTS ARE AVAILABLE
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (var v in VehiclesInStock)
            {
                if (v.GetType() == typeof(CAR))
                {
                    #region FIRST LEVEL
                    CAR car = (CAR)v;


                    CreateBasicRootTreeItem(tvStockVehicles, "car", car.Info.BrandName + " " + car.Info.ModelName, "CAR");

                    /*
                    TreeViewItem tvi_Main0 = new TreeViewItem();
                    tvi_Main0.Tag                  = "CAR";
                    StackPanel Sp_Main             = new StackPanel { Orientation = Orientation.Horizontal };
                    Image      Icon_Main           = new Image { Source = new BitmapImage(new Uri("/Resources/car.png", UriKind.Relative)), Height=50,Width=50 };
                    Label      HeaderText_Main     = new Label { Content= car.Info.BrandName+" "+ car.Info.ModelName , VerticalContentAlignment=VerticalAlignment.Center };

                    Sp_Main.Children.Add(Icon_Main);
                    Sp_Main.Children.Add(HeaderText_Main);

                    tvi_Main0.Header = Sp_Main;
                    tvStockVehicles.Items.Add(tvi_Main0);
                    */
                    #endregion


                    int IndexOfPArentTreeItem = tvStockVehicles.Items.Count - 1;

                    #region SECOND LEVEL


                    // Optional - Using a method to  make code shorter
                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "info", "INFO", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Info1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;



                    /*
                    TreeViewItem tvi_Info1 = new TreeViewItem();
                    tvi_Info1.Tag = IndexOfPArentTreeItem.ToString();
                    StackPanel Sp_Info = new StackPanel { Orientation = Orientation.Horizontal };
                    Image Icon_Info = new Image { Source = new BitmapImage(new Uri("/Resources/info.png", UriKind.Relative)), Height = 25, Width = 25 };
                    Label HeaderText_Info = new Label { Content = "INFO" };

                    Sp_Info.Children.Add(Icon_Info);
                    Sp_Info.Children.Add(HeaderText_Info);
                    tvi_Info1.Header = Sp_Info;
                    (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Add(tvi_Info1);
                    */


                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "mechanic", "MECHANIC", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;



                    #region THIRD LEVEL - MECHANIC


                    CreateBasicChildTreeItem(tvi_Mechanic1, "engine", "ENGINE", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Engine2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem(tvi_Mechanic1, "shiftstick", "TRANSMISSON", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Transmission2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem(tvi_Mechanic1, "chasis", "CHASIS", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Chasis2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;
                    #endregion




                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "electronic", "ELECTRONIC", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Electronic1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "seat", "INTERIOR", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Interior1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "body", "BODY", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Body1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;


                    #endregion






                    #region FINAL LEVEL - INFO
                    CreateDataChildTreeItem(tvi_Info1, "Brand", "tbBrand", IndexOfPArentTreeItem.ToString(), car.Info.BrandName);
                    CreateDataChildTreeItem(tvi_Info1, "ModelName", "tbModelName", IndexOfPArentTreeItem.ToString(), car.Info.ModelName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerName", "tbOwnerName", IndexOfPArentTreeItem.ToString(), car.Info.OwnerName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerSurName", "tbOwnerSurName", IndexOfPArentTreeItem.ToString(), car.Info.OwnerSurName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerAddress", "tbOwnerAddress", IndexOfPArentTreeItem.ToString(), car.Info.OwnerAddress);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerPhone", "tbOwnerPhone", IndexOfPArentTreeItem.ToString(), car.Info.OwnerPhone);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerEmail", "tbOwnerEmail", IndexOfPArentTreeItem.ToString(), car.Info.OwnerEmail);
                    CreateDataChildTreeItem(tvi_Info1, "FuelType", "tbFuelType", IndexOfPArentTreeItem.ToString(), car.Info.FuelType);
                    CreateDataChildTreeItem(tvi_Info1, "ZeroHundredSecond", "tbZeroHundredSecond", IndexOfPArentTreeItem.ToString(), car.Info.ZeroHundredSecond);
                    CreateDataChildTreeItem(tvi_Info1, "TopSpeed", "tbTopSpeed", IndexOfPArentTreeItem.ToString(), car.Info.TopSpeed);
                    CreateDataChildTreeItem(tvi_Info1, "Color", "tbColor", IndexOfPArentTreeItem.ToString(), car.Info.Color);
                    CreateDataChildTreeItem(tvi_Info1, "BuyPrice", "tbBuyPrice", IndexOfPArentTreeItem.ToString(), car.Info.BuyPrice.ToString("0.00"));
                    CreateDataChildTreeItem(tvi_Info1, "SellPrice", "tbSellPrice", IndexOfPArentTreeItem.ToString(), car.Info.SellPrice.ToString("0.00"));
                    CreateDataChildTreeItem(tvi_Info1, "Mileage", "tbMileage", IndexOfPArentTreeItem.ToString(), car.Info.Mileage.ToString());
                    CreateDataChildTreeItem(tvi_Info1, "Weight", "tbWeight", IndexOfPArentTreeItem.ToString(), car.Info.Weight.ToString("0.00"));
                    #endregion

                    #region FINAL LEVEL - ELECTRONIC
                    CreateDataChildTreeItem(tvi_Electronic1, "HiFiStere", "tbHiFiStere", IndexOfPArentTreeItem.ToString(), car.Electronic.HiFiStere);
                    CreateDataChildTreeItem(tvi_Electronic1, "TouchScreen", "tbTouchScreen", IndexOfPArentTreeItem.ToString(), car.Electronic.TouchScreen);
                    CreateDataChildTreeItem(tvi_Electronic1, "SeatHeating", "tbSeatHeating", IndexOfPArentTreeItem.ToString(), car.Electronic.SeatHeating);
                    CreateDataChildTreeItem(tvi_Electronic1, "MirrorHeating", "tbMirrorHeating", IndexOfPArentTreeItem.ToString(), car.Electronic.MirrorHeating);
                    CreateDataChildTreeItem(tvi_Electronic1, "HeadLightType", "tbHeadLightType", IndexOfPArentTreeItem.ToString(), car.Electronic.HeadLightType);
                    CreateDataChildTreeItem(tvi_Electronic1, "BackSideAC", "tbBackSideAC", IndexOfPArentTreeItem.ToString(), car.Electronic.BackSideAC);
                    CreateDataChildTreeItem(tvi_Electronic1, "Airbag", "tbAirbag", IndexOfPArentTreeItem.ToString(), car.Electronic.Airbag);
                    #endregion

                    #region FINAL LEVEL - INTERIOR
                    CreateDataChildTreeItem(tvi_Interior1, "SeatMaterial", "tbSeatMaterial", IndexOfPArentTreeItem.ToString(), car.Interior.SeatMaterial);
                    CreateDataChildTreeItem(tvi_Interior1, "SoundInsulation", "tbSoundInsulation", IndexOfPArentTreeItem.ToString(), car.Interior.SoundInsulation);
                    CreateDataChildTreeItem(tvi_Interior1, "ArmRest", "tbArmRest", IndexOfPArentTreeItem.ToString(), car.Interior.ArmRest);
                    CreateDataChildTreeItem(tvi_Interior1, "RacingSeats", "tbRacingSeats", IndexOfPArentTreeItem.ToString(), car.Interior.RacingSeats);
                    #endregion

                    #region FINAL LEVEL - BODY
                    CreateDataChildTreeItem(tvi_Body1, "DoorCount", "tbDoorCount", IndexOfPArentTreeItem.ToString(), car.Body.DoorCount.ToString());
                    CreateDataChildTreeItem(tvi_Body1, "AutomaticTrunk", "tbAutomaticTrunk", IndexOfPArentTreeItem.ToString(), car.Body.AutomaticTrunk);
                    #endregion

                    #region FINAL LEVEL - MECHANIC - ENGINE
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "CylinderCount", "tbCylinderCount", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.CylinderCount.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "HorsePower", "tbHorsePower", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.HorsePower.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "Litre", "tbLitre", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.Litre.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "ModelName", "tbModelName", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.ModelName.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "IdentificationNumber", "tbIdentificationNumber", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.IdentificationNumber.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "AvgConsumptionPerKm", "tbAverageConsumptionPerKm", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.AverageConsumptionPerKm.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "Turbo", "tbTurbo", IndexOfPArentTreeItem.ToString(), car.Mechanic.Engine.Turbo.ToString());

                    #endregion

                    #region FINAL LEVEL - MECHANIC - TRANSMISSON

                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "GearCount", "tbGearCount", IndexOfPArentTreeItem.ToString(), car.Mechanic.Transmission.GearCount.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "ManualAutomatic", "tbManualAutomatic", IndexOfPArentTreeItem.ToString(), car.Mechanic.Transmission.ManualAutomatic.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "TransmissionModel", "tbTransmissionModel", IndexOfPArentTreeItem.ToString(), car.Mechanic.Transmission.TransmissionModel.ToString());

                    #endregion

                    #region FINAL LEVEL - MECHANIC - CHASIS
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "ShockAbsorberType", "tbShockAbsorberType", IndexOfPArentTreeItem.ToString(), car.Mechanic.Chasis.ShockAbsorberType);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "ShockAbsorberModel", "tbShockAbsorberModel", IndexOfPArentTreeItem.ToString(), car.Mechanic.Chasis.ShockAbsorberModel);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "BrakeModel", "tbBrakeModel", IndexOfPArentTreeItem.ToString(), car.Mechanic.Chasis.BrakeModel);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "SteeringType", "tbSteeringType", IndexOfPArentTreeItem.ToString(), car.Mechanic.Chasis.SteeringType);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "WheelDimension", "tbWheelDimension", IndexOfPArentTreeItem.ToString(), car.Mechanic.Chasis.WheelDimension);

                    #endregion


                }
                else if (v.GetType() == typeof(MOTORCYCLE))
                {
                    MOTORCYCLE motorcycle = (MOTORCYCLE)v;

                    CreateBasicRootTreeItem(tvStockVehicles, "motorcycle", motorcycle.Info.BrandName + " " + motorcycle.Info.ModelName, "MOTORCYCLE");
                    int IndexOfPArentTreeItem = tvStockVehicles.Items.Count - 1;




                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "info", "INFO", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Info1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;




                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "mechanic", "MECHANIC", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;

                    #region SUB CATEGORIES OF MECHANIC
                    CreateBasicChildTreeItem(tvi_Mechanic1, "engine", "ENGINE", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Engine2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem(tvi_Mechanic1, "shiftstick", "TRANSMISSON", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Transmission2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem(tvi_Mechanic1, "chasis", "CHASIS", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Chasis2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;
                    #endregion



                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "electronic", "ELECTRONIC", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Electronic1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;



                    #region FINAL LEVEL - INFO
                    CreateDataChildTreeItem(tvi_Info1, "Brand", "tbBrand", IndexOfPArentTreeItem.ToString(), motorcycle.Info.BrandName);
                    CreateDataChildTreeItem(tvi_Info1, "ModelName", "tbModelName", IndexOfPArentTreeItem.ToString(), motorcycle.Info.ModelName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerName", "tbOwnerName", IndexOfPArentTreeItem.ToString(), motorcycle.Info.OwnerName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerSurName", "tbOwnerSurName", IndexOfPArentTreeItem.ToString(), motorcycle.Info.OwnerSurName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerAddress", "tbOwnerAddress", IndexOfPArentTreeItem.ToString(), motorcycle.Info.OwnerAddress);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerPhone", "tbOwnerPhone", IndexOfPArentTreeItem.ToString(), motorcycle.Info.OwnerPhone);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerEmail", "tbOwnerEmail", IndexOfPArentTreeItem.ToString(), motorcycle.Info.OwnerEmail);
                    CreateDataChildTreeItem(tvi_Info1, "FuelType", "tbFuelType", IndexOfPArentTreeItem.ToString(), motorcycle.Info.FuelType);
                    CreateDataChildTreeItem(tvi_Info1, "ZeroHundredSecond", "tbZeroHundredSecond", IndexOfPArentTreeItem.ToString(), motorcycle.Info.ZeroHundredSecond);
                    CreateDataChildTreeItem(tvi_Info1, "TopSpeed", "tbTopSpeed", IndexOfPArentTreeItem.ToString(), motorcycle.Info.TopSpeed);
                    CreateDataChildTreeItem(tvi_Info1, "Color", "tbColor", IndexOfPArentTreeItem.ToString(), motorcycle.Info.Color);
                    CreateDataChildTreeItem(tvi_Info1, "BuyPrice", "tbBuyPrice", IndexOfPArentTreeItem.ToString(), motorcycle.Info.BuyPrice.ToString("0.00"));
                    CreateDataChildTreeItem(tvi_Info1, "SellPrice", "tbSellPrice", IndexOfPArentTreeItem.ToString(), motorcycle.Info.SellPrice.ToString("0.00"));
                    CreateDataChildTreeItem(tvi_Info1, "Mileage", "tbMileage", IndexOfPArentTreeItem.ToString(), motorcycle.Info.Mileage.ToString());
                    CreateDataChildTreeItem(tvi_Info1, "Weight", "tbWeight", IndexOfPArentTreeItem.ToString(), motorcycle.Info.Weight.ToString("0.00"));
                    #endregion

                    #region FINAL LEVEL - ELECTRONIC

                    CreateDataChildTreeItem(tvi_Electronic1, "HeadLightType", "tbHeadLightType", IndexOfPArentTreeItem.ToString(), motorcycle.Electronic.HeadLightType);

                    #endregion


                    #region FINAL LEVEL - MECHANIC - ENGINE
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "CylinderCount", "tbCylinderCount", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.CylinderCount.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "HorsePower", "tbHorsePower", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.HorsePower.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "Litre", "tbLitre", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.Litre.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "ModelName", "tbModelName", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.ModelName.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "IdentificationNumber", "tbIdentificationNumber", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.IdentificationNumber.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "AvgConsumptionPerKm", "tbAverageConsumptionPerKm", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.AverageConsumptionPerKm.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Engine2, "Turbo", "tbTurbo", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Engine.Turbo.ToString());

                    #endregion

                    #region FINAL LEVEL - MECHANIC - TRANSMISSON

                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "GearCount", "tbGearCount", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Transmission.GearCount.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "ManualAutomatic", "tbManualAutomatic", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Transmission.ManualAutomatic.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "TransmissionModel", "tbTransmissionModel", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Transmission.TransmissionModel.ToString());

                    #endregion

                    #region FINAL LEVEL - MECHANIC - CHASIS
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "ShockAbsorberType", "tbShockAbsorberType", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Chasis.ShockAbsorberType);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "ShockAbsorberModel", "tbShockAbsorberModel", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Chasis.ShockAbsorberModel);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "BrakeModel", "tbBrakeModel", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Chasis.BrakeModel);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "SteeringType", "tbSteeringType", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Chasis.SteeringType);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "WheelDimension", "tbWheelDimension", IndexOfPArentTreeItem.ToString(), motorcycle.Mechanic.Chasis.WheelDimension);

                    #endregion









                }
                else if (v.GetType() == typeof(BICYCLE))
                {
                    BICYCLE bicycle = (BICYCLE)v;



                    #region FIRST LEVEL

                    CreateBasicRootTreeItem(tvStockVehicles, "bike", bicycle.Info.BrandName + " " + bicycle.Info.ModelName, "BICYCLE");
                    int IndexOfPArentTreeItem = tvStockVehicles.Items.Count - 1;

                    #endregion



                    #region SECOND LEVEL



                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "info", "INFO", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Info1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem((tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem), "mechanic", "MECHANIC", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic1 = (tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items[(tvStockVehicles.Items[IndexOfPArentTreeItem] as TreeViewItem).Items.Count - 1] as TreeViewItem;



                    #region THIRD LEVEL - MECHANIC

                    CreateBasicChildTreeItem(tvi_Mechanic1, "shiftstick", "TRANSMISSON", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Transmission2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;

                    CreateBasicChildTreeItem(tvi_Mechanic1, "chasis", "CHASIS", IndexOfPArentTreeItem.ToString());
                    TreeViewItem tvi_Mechanic_Chasis2 = tvi_Mechanic1.Items[tvi_Mechanic1.Items.Count - 1] as TreeViewItem;
                    #endregion

                    #endregion




                    #region FINAL LEVEL - INFO

                    CreateDataChildTreeItem(tvi_Info1, "Brand", "tbBrand", IndexOfPArentTreeItem.ToString(), bicycle.Info.BrandName);
                    CreateDataChildTreeItem(tvi_Info1, "ModelName", "tbModelName", IndexOfPArentTreeItem.ToString(), bicycle.Info.ModelName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerName", "tbOwnerName", IndexOfPArentTreeItem.ToString(), bicycle.Info.OwnerName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerSurName", "tbOwnerSurName", IndexOfPArentTreeItem.ToString(), bicycle.Info.OwnerSurName);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerAddress", "tbOwnerAddress", IndexOfPArentTreeItem.ToString(), bicycle.Info.OwnerAddress);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerPhone", "tbOwnerPhone", IndexOfPArentTreeItem.ToString(), bicycle.Info.OwnerPhone);
                    CreateDataChildTreeItem(tvi_Info1, "OwnerEmail", "tbOwnerEmail", IndexOfPArentTreeItem.ToString(), bicycle.Info.OwnerEmail);

                    CreateDataChildTreeItem(tvi_Info1, "Color", "tbColor", IndexOfPArentTreeItem.ToString(), bicycle.Info.Color);
                    CreateDataChildTreeItem(tvi_Info1, "BuyPrice", "tbBuyPrice", IndexOfPArentTreeItem.ToString(), bicycle.Info.BuyPrice.ToString("0.00"));
                    CreateDataChildTreeItem(tvi_Info1, "SellPrice", "tbSellPrice", IndexOfPArentTreeItem.ToString(), bicycle.Info.SellPrice.ToString("0.00"));

                    CreateDataChildTreeItem(tvi_Info1, "Weight", "tbWeight", IndexOfPArentTreeItem.ToString(), bicycle.Info.Weight.ToString("0.00"));

                    #endregion



                    #region FINAL LEVEL - MECHANIC - TRANSMISSON

                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "GearCount", "tbGearCount", IndexOfPArentTreeItem.ToString(), bicycle.Mechanic.Transmission.GearCount.ToString());
                    CreateDataChildTreeItem(tvi_Mechanic_Transmission2, "TransmissionModel", "tbTransmissionModel", IndexOfPArentTreeItem.ToString(), bicycle.Mechanic.Transmission.TransmissionModel.ToString());

                    #endregion

                    #region FINAL LEVEL - MECHANIC - CHASIS

                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "Chasis Material", "tbChasisMaterial", IndexOfPArentTreeItem.ToString(), bicycle.Mechanic.Chasis.ChasisMaterial);
                    CreateDataChildTreeItem(tvi_Mechanic_Chasis2, "Shock Absorber", "tbShockAbsorber", IndexOfPArentTreeItem.ToString(), bicycle.Mechanic.Chasis.ShockAbsorber);


                    #endregion







                }
            }
        }


    
        //CREATE TREEVIEW ITEMS
        private void CreateBasicRootTreeItem(TreeView TreeViewToAdd, string IconPNGName, string HeaderString, string TreeItemTag)
        {

            TreeViewItem tvi_NewTreeViewItem = new TreeViewItem();
            StackPanel SP_Container = new StackPanel { Orientation = Orientation.Horizontal };
            Image Icon = new Image { Source = new BitmapImage(new Uri("/Resources/" + IconPNGName + ".png", UriKind.Relative)), Height = 40, Width = 40 };
            Label HeaderText = new Label { Content = HeaderString };
            tvi_NewTreeViewItem.Tag = TreeItemTag;

            SP_Container.Children.Add(Icon);
            SP_Container.Children.Add(HeaderText);
            tvi_NewTreeViewItem.Header = SP_Container;

            TreeViewToAdd.Items.Add(tvi_NewTreeViewItem);

            tvi_NewTreeViewItem.PreviewMouseRightButtonUp += Tvi_NewTreeViewItem_PreviewMouseRightButtonUp;



        }
        private void CreateBasicChildTreeItem(TreeViewItem ParentTreeItem, string IconPNGName, string HeaderString, string TreeItemTag)
        {

            TreeViewItem tvi_NewChildTreeViewItem = new TreeViewItem();
            StackPanel SP_Container = new StackPanel { Orientation = Orientation.Horizontal };
            Image Icon = new Image { Source = new BitmapImage(new Uri("/Resources/" + IconPNGName + ".png", UriKind.Relative)), Height = 25, Width = 25 };
            Label HeaderText = new Label { Content = HeaderString };
            tvi_NewChildTreeViewItem.Tag = TreeItemTag;

            SP_Container.Children.Add(Icon);
            SP_Container.Children.Add(HeaderText);
            tvi_NewChildTreeViewItem.Header = SP_Container;

            ParentTreeItem.Items.Add(tvi_NewChildTreeViewItem);


            tvi_NewChildTreeViewItem.PreviewMouseRightButtonUp += Tvi_NewChildTreeViewItem_PreviewMouseRightButtonUp; ;

        }
        private void CreateDataChildTreeItem (TreeViewItem ParentTreeItem, string Caption,     string TextBoxName,  string TreeItemTag, string DataValue)
        {

            TreeViewItem tvi_NewTreeViewItem = new TreeViewItem();
            tvi_NewTreeViewItem.Margin = new Thickness(-(tvStockVehicles.ActualWidth/7.2), 0, 0, 0);

            Grid GR_Container                = new Grid() { Width = tvStockVehicles.ActualWidth/1.1};
            GR_Container.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            GR_Container.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });

            TextBox HeaderText               = new TextBox { Text = Caption  , IsReadOnly=true, Background=Brushes.LightGray , Tag= TreeItemTag };
            TextBox DataTextBox              = new TextBox { Text = DataValue, Name= TextBoxName, };
            tvi_NewTreeViewItem.Tag          = TreeItemTag;

            GR_Container.Children.Add(HeaderText);
            GR_Container.Children.Add(DataTextBox);
            Grid.SetColumn(HeaderText , 0);
            Grid.SetColumn(DataTextBox, 1);

            tvi_NewTreeViewItem.Header = GR_Container;
          
            ParentTreeItem.Items.Add(tvi_NewTreeViewItem);


            DataTextBox.PreviewKeyUp += DataTextBox_PreviewKeyUp; ;
            DataTextBox.LostFocus    += DataTextBox_LostFocus;

        }


        #region RIGHT CLICK TREEVIEW ITEMS EVENT HANDLERS
      
        //SAVE DATA
        private void DataTextBox_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            SaveTextBoxData(sender as TextBox);
        }
        private void DataTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveTextBoxData(sender as TextBox);
        }
        private void SaveTextBoxData(TextBox TB)
        {

            object EditedObject       = VehiclesInStock[Convert.ToInt32(TB.Tag)];
            string EditedPropertyName = TB.Name.Substring(2, TB.Name.Length - 2);

            if (EditedObject is CAR)
            {

                CAR car = EditedObject as CAR;



                if (EditedPropertyName == "BrandName"        ) { car.Info.BrandName         = TB.Text;}
                if (EditedPropertyName == "ModelName"        ) { car.Info.ModelName         = TB.Text;}
                if (EditedPropertyName == "OwnerName"        ) { car.Info.OwnerName         = TB.Text;}
                if (EditedPropertyName == "OwnerSurName"     ) { car.Info.OwnerSurName      = TB.Text;}
                if (EditedPropertyName == "OwnerAddress"     ) { car.Info.OwnerAddress      = TB.Text;}
                if (EditedPropertyName == "OwnerPhone"       ) { car.Info.OwnerPhone        = TB.Text;}
                if (EditedPropertyName == "OwnerEmail"       ) { car.Info.OwnerEmail        = TB.Text;}
                if (EditedPropertyName == "FuelType"         ) { car.Info.FuelType          = TB.Text;}
                if (EditedPropertyName == "ZeroHundredSecond") { car.Info.ZeroHundredSecond = TB.Text;}
                if (EditedPropertyName == "TopSpeed"         ) { car.Info.TopSpeed          = TB.Text;}
                if (EditedPropertyName == "Color"            ) { car.Info.Color             = TB.Text;}
                if (EditedPropertyName == "BuyPrice"         ) { car.Info.BuyPrice          = Convert.ToDouble(TB.Text);}
                if (EditedPropertyName == "SellPrice"        ) { car.Info.SellPrice         = Convert.ToDouble(TB.Text);}
                if (EditedPropertyName == "Mileage"          ) { car.Info.Mileage           = Convert.ToDouble(TB.Text);}
                if (EditedPropertyName == "Weight"           ) { car.Info.Weight            = Convert.ToDouble(TB.Text);}




                 if (EditedPropertyName == "CylinderCount"               ) { car.Mechanic.Engine.CylinderCount           = Convert.ToInt32(TB.Text);}
                 if (EditedPropertyName == "HorsePower"                  ) { car.Mechanic.Engine.HorsePower              = Convert.ToDouble(TB.Text);}
                 if (EditedPropertyName == "Litre"                       ) { car.Mechanic.Engine.Litre                   = Convert.ToDouble(TB.Text);}
                 if (EditedPropertyName == "ModelName"                   ) { car.Mechanic.Engine.ModelName               = TB.Text;}
                 if (EditedPropertyName == "IdentificationNumber"        ) { car.Mechanic.Engine.IdentificationNumber    = TB.Text;}
                 if (EditedPropertyName == "AverageConsumptionPerKm"     ) { car.Mechanic.Engine.AverageConsumptionPerKm = Convert.ToDouble(TB.Text);}
                 if (EditedPropertyName == "Turbo"                       ) { car.Mechanic.Engine.Turbo                   = TB.Text;}
                                                                       
                                                                       
                 if (EditedPropertyName == "GearCount"                   ) { car.Mechanic.Transmission.GearCount         = Convert.ToInt32(TB.Text);}
                 if (EditedPropertyName == "ManualAutomatic"             ) { car.Mechanic.Transmission.ManualAutomatic   = TB.Text;}
                 if (EditedPropertyName == "TransmissionModel"           ) { car.Mechanic.Transmission.TransmissionModel = TB.Text;}
                                                                       
                                                                         
                 if (EditedPropertyName == "ShockAbsorberType"           ) { car.Mechanic.Chasis.ShockAbsorberType  = TB.Text;}
                 if (EditedPropertyName == "ShockAbsorberModel"          ) { car.Mechanic.Chasis.ShockAbsorberModel = TB.Text;}
                 if (EditedPropertyName == "BrakeModel"                  ) { car.Mechanic.Chasis.BrakeModel         = TB.Text;}
                 if (EditedPropertyName == "SteeringType"                ) { car.Mechanic.Chasis.SteeringType       = TB.Text;}
                 if (EditedPropertyName == "WheelDimension"              ) { car.Mechanic.Chasis.WheelDimension     = TB.Text;}
                                                                      
                                                                  
                 if (EditedPropertyName == "HiFiStere"                   ) { car.Electronic.HiFiStere     = TB.Text;}
                 if (EditedPropertyName == "TouchScreen"                 ) { car.Electronic.TouchScreen   = TB.Text;}
                 if (EditedPropertyName == "SeatHeating"                 ) { car.Electronic.SeatHeating   = TB.Text;}
                 if (EditedPropertyName == "MirrorHeating"               ) { car.Electronic.MirrorHeating = TB.Text;}
                 if (EditedPropertyName == "HeadLightType"               ) { car.Electronic.HeadLightType = TB.Text;}
                 if (EditedPropertyName == "BackSideAC"                  ) { car.Electronic.BackSideAC    = TB.Text;}
                 if (EditedPropertyName == "Airbag"                      ) { car.Electronic.Airbag        = TB.Text;}
                                                                       
                 if (EditedPropertyName == "DoorCount"                   ) { car.Body.DoorCount      =Convert.ToInt32( TB.Text);}
                 if (EditedPropertyName == "AutomaticTrunk"              ) { car.Body.AutomaticTrunk = TB.Text;}
                                                                      
                 if (EditedPropertyName == "SeatMaterial"                ) { car.Interior.SeatMaterial    = TB.Text;}
                 if (EditedPropertyName == "SoundInsulation"             ) { car.Interior.SoundInsulation = TB.Text;}
                 if (EditedPropertyName == "ArmRest"                     ) { car.Interior.ArmRest         = TB.Text;}
                 if (EditedPropertyName == "RacingSeats"                 ) { car.Interior.RacingSeats     = TB.Text; }


            }

            if (EditedObject is MOTORCYCLE)
            {





                MOTORCYCLE car = EditedObject as MOTORCYCLE;



                if (EditedPropertyName == "BrandName") {               car.Info.BrandName = TB.Text; }
                if (EditedPropertyName == "ModelName") {               car.Info.ModelName = TB.Text; }
                if (EditedPropertyName == "OwnerName") {               car.Info.OwnerName = TB.Text; }
                if (EditedPropertyName == "OwnerSurName") {            car.Info.OwnerSurName = TB.Text; }
                if (EditedPropertyName == "OwnerAddress") {            car.Info.OwnerAddress = TB.Text; }
                if (EditedPropertyName == "OwnerPhone") {              car.Info.OwnerPhone = TB.Text; }
                if (EditedPropertyName == "OwnerEmail") {              car.Info.OwnerEmail = TB.Text; }
                if (EditedPropertyName == "FuelType") {                car.Info.FuelType = TB.Text; }
                if (EditedPropertyName == "ZeroHundredSecond") {       car.Info.ZeroHundredSecond = TB.Text; }
                if (EditedPropertyName == "TopSpeed") {                car.Info.TopSpeed = TB.Text; }
                if (EditedPropertyName == "Color") {                   car.Info.Color = TB.Text; }
                if (EditedPropertyName == "BuyPrice") {                car.Info.BuyPrice = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "SellPrice") {               car.Info.SellPrice = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "Mileage") {                 car.Info.Mileage = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "Weight") {                  car.Info.Weight = Convert.ToDouble(TB.Text); }




                if (EditedPropertyName == "CylinderCount") {           car.Mechanic.Engine.CylinderCount = Convert.ToInt32(TB.Text); }
                if (EditedPropertyName == "HorsePower") {              car.Mechanic.Engine.HorsePower = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "Litre") {                   car.Mechanic.Engine.Litre = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "ModelName") {               car.Mechanic.Engine.ModelName = TB.Text; }
                if (EditedPropertyName == "IdentificationNumber") {    car.Mechanic.Engine.IdentificationNumber = TB.Text; }
                if (EditedPropertyName == "AverageConsumptionPerKm") { car.Mechanic.Engine.AverageConsumptionPerKm = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "Turbo") {                   car.Mechanic.Engine.Turbo = TB.Text; }


                if (EditedPropertyName == "GearCount") {               car.Mechanic.Transmission.GearCount = Convert.ToInt32(TB.Text); }
                if (EditedPropertyName == "ManualAutomatic") {         car.Mechanic.Transmission.ManualAutomatic = TB.Text; }
                if (EditedPropertyName == "TransmissionModel") {       car.Mechanic.Transmission.TransmissionModel = TB.Text; }


                if (EditedPropertyName == "ShockAbsorberType") {       car.Mechanic.Chasis.ShockAbsorberType = TB.Text; }
                if (EditedPropertyName == "ShockAbsorberModel") {      car.Mechanic.Chasis.ShockAbsorberModel = TB.Text; }
                if (EditedPropertyName == "BrakeModel") {              car.Mechanic.Chasis.BrakeModel = TB.Text; }
                if (EditedPropertyName == "SteeringType") {            car.Mechanic.Chasis.SteeringType = TB.Text; }
                if (EditedPropertyName == "WheelDimension") {          car.Mechanic.Chasis.WheelDimension = TB.Text; }



                if (EditedPropertyName == "HeadLightType") {           car.Electronic.HeadLightType = TB.Text; }







            }

            if (EditedObject is BICYCLE)
            {


                BICYCLE car = EditedObject as BICYCLE;

                if (EditedPropertyName == "BrandName") {         car.Info.BrandName = TB.Text; }
                if (EditedPropertyName == "ModelName") {         car.Info.ModelName = TB.Text; }
                if (EditedPropertyName == "OwnerName") {         car.Info.OwnerName = TB.Text; }
                if (EditedPropertyName == "OwnerSurName") {      car.Info.OwnerSurName = TB.Text; }
                if (EditedPropertyName == "OwnerAddress") {      car.Info.OwnerAddress = TB.Text; }
                if (EditedPropertyName == "OwnerPhone") {        car.Info.OwnerPhone = TB.Text; }
                if (EditedPropertyName == "OwnerEmail") {        car.Info.OwnerEmail = TB.Text; }
             
                if (EditedPropertyName == "Color") {             car.Info.Color = TB.Text; }
                if (EditedPropertyName == "BuyPrice") {          car.Info.BuyPrice = Convert.ToDouble(TB.Text); }
                if (EditedPropertyName == "SellPrice") {         car.Info.SellPrice = Convert.ToDouble(TB.Text); }
          
                if (EditedPropertyName == "Weight") {            car.Info.Weight = Convert.ToDouble(TB.Text); }

                if (EditedPropertyName == "GearCount") {         car.Mechanic.Transmission.GearCount = Convert.ToInt32(TB.Text); }
 
                if (EditedPropertyName == "TransmissionModel") { car.Mechanic.Transmission.TransmissionModel = TB.Text; }










            }
        }

        //DELETE ROOT TREEVIEWITEM
        private void Tvi_NewTreeViewItem_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {

            RightClickedTreeViewItem = sender as TreeViewItem;

            ContextMenu cm = new ContextMenu();
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            cm.HorizontalAlignment = HorizontalAlignment.Stretch;


            MenuItem DELETE = new MenuItem { Name = "DELETEITEM", Header = "DELETE" };
            DELETE.PreviewMouseDown += DELETE_PreviewMouseDown; ;
            cm.Items.Add(DELETE);

            cm.IsOpen = true;

        }
        private void DELETE_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            VehiclesInStock.RemoveAt(tvStockVehicles.Items.IndexOf(RightClickedTreeViewItem));
            tvStockVehicles.Items.Remove(RightClickedTreeViewItem);
        }

        //PAINT CHILD TREEVIEWITEM RED
        private void Tvi_NewChildTreeViewItem_PreviewMouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            RightClickedTreeViewItem = sender as TreeViewItem;

            ContextMenu cm = new ContextMenu();
            cm.Placement = System.Windows.Controls.Primitives.PlacementMode.MousePoint;
            cm.HorizontalAlignment = HorizontalAlignment.Stretch;


            MenuItem PAINTRED = new MenuItem { Name = "PAINTRED", Header = "PAINT RED" };
            PAINTRED.PreviewMouseDown += PAINTRED_PreviewMouseDown; ; ;
            cm.Items.Add(PAINTRED);

            cm.IsOpen = true;
        }
        private void PAINTRED_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            RightClickedTreeViewItem.Background = Brushes.Red;
        }

        #endregion



        // CREATE SAMPLE DATA FOR TUTORIAL
        private void CreateSampleVehicles()
        {

            #region ADD A SAMPLE CAR TO OBJECT LIST TO BE VIEWED IN TREEVIEW

            CAR samplecar1 = new CAR();

            samplecar1.Info.BrandName                          = "TOYOTA";
            samplecar1.Info.ModelName                          = "COROLLA";
            samplecar1.Info.OwnerName                          = "John";
            samplecar1.Info.OwnerSurName                       = "Smith";
            samplecar1.Info.OwnerAddress                       = "132 Erlanger Blv. 54 Ohio";
            samplecar1.Info.OwnerPhone                         = "+01 885 455 5858";
            samplecar1.Info.OwnerEmail                         = "JPop69@gmail.com";
            samplecar1.Info.FuelType                           = "Diesel";
            samplecar1.Info.ZeroHundredSecond                  = "20-25";
            samplecar1.Info.TopSpeed                           = "220 kmh";
            samplecar1.Info.Color                              = "Red";
            samplecar1.Info.BuyPrice                           = 13000;
            samplecar1.Info.SellPrice                          = 15000;
            samplecar1.Info.Mileage                            = 0;
            samplecar1.Info.Weight                             = 1200;

            samplecar1.Mechanic.Engine.CylinderCount           = 4;
            samplecar1.Mechanic.Engine.HorsePower              = 65;
            samplecar1.Mechanic.Engine.Litre                   = 1.6;
            samplecar1.Mechanic.Engine.ModelName               = "XYF16";
            samplecar1.Mechanic.Engine.IdentificationNumber    = "4587212663";
            samplecar1.Mechanic.Engine.AverageConsumptionPerKm = 7;
            samplecar1.Mechanic.Engine.Turbo                   = "AVAILABLE";

            samplecar1.Mechanic.Transmission.GearCount         = 7;
            samplecar1.Mechanic.Transmission.ManualAutomatic   = "AUTOMATIC";
            samplecar1.Mechanic.Transmission.TransmissionModel = "Super CVT-i";

            samplecar1.Mechanic.Chasis.ShockAbsorberType       = "Sport";
            samplecar1.Mechanic.Chasis.ShockAbsorberModel      = "X1000";
            samplecar1.Mechanic.Chasis.BrakeModel              = "Sport";
            samplecar1.Mechanic.Chasis.SteeringType            = "Hydraulic";
            samplecar1.Mechanic.Chasis.WheelDimension          = "16";

            samplecar1.Electronic.HiFiStere                    = "YES";
            samplecar1.Electronic.TouchScreen                  = "YES";
            samplecar1.Electronic.SeatHeating                  = "NO";
            samplecar1.Electronic.MirrorHeating                = "NO";
            samplecar1.Electronic.HeadLightType                = "XENON";
            samplecar1.Electronic.BackSideAC                   = "NO";
            samplecar1.Electronic.Airbag                       = "YES";

            samplecar1.Interior.SeatMaterial                   = "LEATHER";
            samplecar1.Interior.SoundInsulation                = "NO";
            samplecar1.Interior.ArmRest                        = "YES";
            samplecar1.Interior.RacingSeats                    = "NO";

            samplecar1.Body.DoorCount                          = 4;
            samplecar1.Body.AutomaticTrunk                     = "NO";


            VehiclesInStock.Add((object)samplecar1);

            #endregion


            #region ADD A SAMPLE CAR TO OBJECT LIST TO BE VIEWED IN TREEVIEW

            MOTORCYCLE samplemotorcycle1                              = new MOTORCYCLE();

            samplemotorcycle1.Info.BrandName                          = "YAMAHA";
            samplemotorcycle1.Info.ModelName                          = "WR125";
            samplemotorcycle1.Info.OwnerName                          = "Michael";
            samplemotorcycle1.Info.OwnerSurName                       = "Jackson";
            samplemotorcycle1.Info.OwnerAddress                       = "132 Erlanger Blv. 54 Ohio";
            samplemotorcycle1.Info.OwnerPhone                         = "+01 885 455 5858";
            samplemotorcycle1.Info.OwnerEmail                         = "JPop69@gmail.com";
            samplemotorcycle1.Info.FuelType                           = "Petrol";
            samplemotorcycle1.Info.ZeroHundredSecond                  = "20-25";
            samplemotorcycle1.Info.TopSpeed                           = "300 kmh";
            samplemotorcycle1.Info.Color                              = "Black";
            samplemotorcycle1.Info.BuyPrice                           = 5000;
            samplemotorcycle1.Info.SellPrice                          = 7000;
            samplemotorcycle1.Info.Mileage                            = 0;
            samplemotorcycle1.Info.Weight                             = 200;

            samplemotorcycle1.Mechanic.Engine.CylinderCount           = 4;
            samplemotorcycle1.Mechanic.Engine.HorsePower              = 65;
            samplemotorcycle1.Mechanic.Engine.Litre                   = 1.6;
            samplemotorcycle1.Mechanic.Engine.ModelName               = "6V52";
            samplemotorcycle1.Mechanic.Engine.IdentificationNumber    = "4587212663";
            samplemotorcycle1.Mechanic.Engine.AverageConsumptionPerKm = 7;
            samplemotorcycle1.Mechanic.Engine.Turbo                   = "AVAILABLE";

            samplemotorcycle1.Mechanic.Transmission.GearCount         = 7;
            samplemotorcycle1.Mechanic.Transmission.ManualAutomatic   = "AUTOMATIC";
            samplemotorcycle1.Mechanic.Transmission.TransmissionModel = "Super CVT-i";

            samplemotorcycle1.Mechanic.Chasis.ShockAbsorberType       = "Sport";
            samplemotorcycle1.Mechanic.Chasis.ShockAbsorberModel      = "X1000";
            samplemotorcycle1.Mechanic.Chasis.BrakeModel              = "Sport";
            samplemotorcycle1.Mechanic.Chasis.SteeringType            = "Hydraulic";
            samplemotorcycle1.Mechanic.Chasis.WheelDimension          = "16";


            samplemotorcycle1.Electronic.HeadLightType                = "Racing Gear";

            VehiclesInStock.Add((object)samplemotorcycle1);

            #endregion


            #region ADD A SAMPLE BICYCLE TO OBJECT LIST TO BE VIEWED IN TREEVIEW
            BICYCLE samplebicycle1 = new BICYCLE();

            samplebicycle1.Info.BrandName                          = "BIANCHI";
            samplebicycle1.Info.ModelName                          = "X1";
            samplebicycle1.Info.OwnerName                          = "April";
            samplebicycle1.Info.OwnerSurName                       = "Oneil";
            samplebicycle1.Info.OwnerAddress                       = "155 Shitsu Blv. 22 Sydney";
            samplebicycle1.Info.OwnerPhone                         = "+01 885 455 5858";
            samplebicycle1.Info.OwnerEmail                         = "KPop19@gmail.com";

            samplebicycle1.Info.Color                              = "Blue";
            samplebicycle1.Info.BuyPrice                           = 1000;
            samplebicycle1.Info.SellPrice                          = 1200;

            samplebicycle1.Info.Weight                             = 30;


            samplebicycle1.Mechanic.Transmission.GearCount         = 7;
            samplebicycle1.Mechanic.Transmission.TransmissionModel = "Shimano";

            samplebicycle1.Mechanic.Chasis.ChasisMaterial          = "Aluminium";
            samplebicycle1.Mechanic.Chasis.ShockAbsorber           = "Mountain";


            VehiclesInStock.Add((object)samplebicycle1);
            #endregion

        }


    }
}
