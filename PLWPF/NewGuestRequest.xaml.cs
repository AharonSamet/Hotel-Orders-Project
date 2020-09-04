using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using BE;
using BL;
using Utilities;


namespace PLWPF
{



    /// <summary>
    /// Interaction logic for NewGuestRequest.xaml
    /// </summary>
    /// 
    public partial class NewGuestRequest : Window
    {
        private readonly IBL _instance = FactoryBl.GetInstance;

        BackgroundWorker sendMailWorker;


        /// <summary>
        ///     the LoginDetails
        /// </summary> 
        private Login _login = new Login();

        GuestRequest GuestRequestWindow;
        #region C-tor

        public NewGuestRequest(Login login)
        {
            MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            App.numOfActivatedMainWindow++;
            FlowDirection = FlowDirection.LeftToRight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;

            InitializeComponent();
            SystemCommands.MaximizeWindow(this);

            sendMailWorker = new BackgroundWorker();
            sendMailWorker.DoWork += sendMail;

            for (var i = 0; i < 9; i++)
            {
                adults.Items.Add(i + 1);
                child.Items.Add(i);
            }


            AccomoType.ItemsSource = Enum.GetValues(typeof(enums.Type));
            roomType.ItemsSource = Enum.GetValues(typeof(enums.Style));
            area.ItemsSource = Enum.GetValues(typeof(enums.Area));



            GuestRequestWindow = new GuestRequest
            {
                GuestRequestKey = 0,
                ClientLoginDetails = new Login
                {
                    UserName = login.UserName,
                    Password = login.Password
                },
                OrderStatus = false,
                CheckInDate = DateTime.Today,
                CheckOutDate = DateTime.Today,
                Area = (enums.Area)0,
                SubArea = (enums.Districts)0,
                TypeOfAccommodationRequested = (enums.Type)0,
                StyleOfUnitRequested = (enums.Style).0,
                AmountOfAdults = 0,
                AmountOfChildren = 0,
                SpecificRequirements = new FilterElementsForGuest
                    {
                        Pool = 0,
                        Jacuzzi = 0,
                        Garden = 0,
                        Terrace = 0,
                        ChildrenAttractions = 0,
                        Tv = 0,
                        SmokingRoom = 0,
                        BabyCrib = 0,
                        Elevator = 0,
                        Spa = 0,
                        AirConditioning = 0,
                        WiFi = 0,
                        RoomService = 0,
                        DoubleBed = 0,
                        TwinBeds = 0,
                        Breakfast = 0,
                        Lunch = 0,
                        Dinner = 0,
                        FreeParking = 0,
                        Gym = 0,
                        PrivateBathroom = 0,
                        Bathtub = 0,
                        WashingMachine = 0
                    }};
            //
           // GuestRequestWindow.CheckInDate = DateTime.Today;
            //GuestRequestWindow.CheckOutDate = DateTime.Today;
            


            GridNewGustRequest.DataContext = GuestRequestWindow;



            _login.UserName = login.UserName;
            _login.Password = login.Password;




        }

        #endregion


        #region close_min_max_Windo

        //MinimizeWindow
        private void Button_Click_MinimizeWindow(object sender, RoutedEventArgs e)
        {
            SystemCommands.MinimizeWindow(this);
        }

        //MaximizeWindow
        private void Button_Click_MaximizeWindow(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Maximized)
                SystemCommands.RestoreWindow(this);
            else
                SystemCommands.MaximizeWindow(this);
        }

        //CloseWindow
        private void Button_Click_CloseWindow(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        //Mouse
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            ((Button)sender).Width *= 1.1;
            ((Button)sender).Height *= 1.1;
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            ((Button)sender).Width /= 1.1;
            ((Button)sender).Height /= 1.1;
        }

        #endregion

        #region Buttons

        public void sendMail(object sender, DoWorkEventArgs e)
        {
            string mail = (string)e.Argument;
            string FirstName = " ";
            //HostingUnit hostingUnit = _instance.GetHostingUnit(order.HostingUnitKey);
            //Guest guest = _instance.GetGuest(order.GuestRequestKey);
            string To = mail;
            string Subject = "VilaCheck ";
            string Body = "Hi" + FirstName +
                          " We're glad you joined our site " +
                          "We will soon send you the best and most appropriate offers at your request";
            

            for (int i = 0; i < 10; i++)
            {
                if (Tools.SendMail(To, Subject, Body))
                {
                   // order.Status = enums.OrderStatus.mail_has_been_sent;
                   // _instance.updateOrder(order);
                    return;
                }
            }
            MessageBox.Show("problem email address");
        }


        private void Send_OnClick(object sender, RoutedEventArgs e)
        {
            //need to ad the login dtails to the instance;;;


            GuestRequestWindow.ClientLoginDetails = _login;

            if (area.SelectedIndex == -1 || AccomoType.SelectedIndex == -1 || roomType.SelectedIndex == -1 ||
                adults.SelectedIndex == -1 || child.SelectedIndex == -1 || checkInTimeDatePicker.Text.Length == 0 ||
                Check_Out_Date.Text.Length == 0)
            {
                MessageBox.Show("You must enter all the details", "Failed", MessageBoxButton.OK, MessageBoxImage.Error,
                    MessageBoxResult.None);
                return;
            }

            if (checkInTimeDatePicker.SelectedDate >= Check_Out_Date.SelectedDate)
            {
                MessageBox.Show("Check in Date must Start before check out date", "Failed", MessageBoxButton.OK,
                    MessageBoxImage.Error, MessageBoxResult.None);
                return;
            }


            try
            {
                _instance.AddACustomerRequirement(GuestRequestWindow);
                MessageBox.Show(
                    "Your booking request has been received successfully, vacation offers will be sent to you soon ...");
                var customer = _instance.GetAllCustomers().FirstOrDefault(x =>
                    x.ClientInfo.LoginDetails.UserName == GuestRequestWindow.ClientLoginDetails.UserName);
                sendMailWorker.RunWorkerAsync(customer.ClientInfo.EmailAddress);
                var welcome = new Welcome();
                welcome.Show();
                Close();

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message, "Failed", MessageBoxButton.OK,
                    MessageBoxImage.Error, MessageBoxResult.None);
            }
        }

        #endregion



        private void Check_in_date_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            //checkInTimeDatePicker.DisplayDateStart = DateTime.Now.AddDays(-1);
            //checkInTimeDatePicker.DisplayDateEnd = DateTime.Now.AddMonths(11);
            //checkInTimeDatePicker.BlackoutDates.Clear();

            ////Blackout all the dates in the past and in more that 11 month
            //checkInTimeDatePicker.BlackoutDates.AddDatesInPast();
            //checkInTimeDatePicker.BlackoutDates.Add(
            //    new CalendarDateRange(DateTime.Now.AddMonths(11), DateTime.MaxValue));

            ////Check_Out_Date
            //Check_Out_Date.DisplayDateStart = DateTime.Now.AddDays(2);
            //Check_Out_Date.DisplayDateEnd = DateTime.Now.AddMonths(11);
            //Check_Out_Date.BlackoutDates.Clear();

            ////Blackout all the dates in the past and in more that 11 month
            //Check_Out_Date.BlackoutDates.AddDatesInPast();
            //Check_Out_Date.BlackoutDates.Add(
            //    new CalendarDateRange(DateTime.Now.AddMonths(11), DateTime.MaxValue));
        }


        private void area_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (area.SelectedIndex != -1)
            {
                subArea.Items.Clear();
                switch ((int)area.SelectedItem)
                {
                    case 1:
                        subArea.Items.Add(enums.Districts.Jerusalem);
                        break;
                    case 2:
                        subArea.Items.Add(enums.Districts.Tzfat);
                        subArea.Items.Add(enums.Districts.Kinneret);
                        subArea.Items.Add(enums.Districts.Yizreel);
                        subArea.Items.Add(enums.Districts.Akko);
                        subArea.Items.Add(enums.Districts.Golan);
                        break;
                    case 3:
                        subArea.Items.Add(enums.Districts.Haifa);
                        subArea.Items.Add(enums.Districts.Hadera);
                        break;
                    case 4:
                        subArea.Items.Add(enums.Districts.Sharon);
                        subArea.Items.Add(enums.Districts.PetahTikva);
                        subArea.Items.Add(enums.Districts.Ramla);
                        subArea.Items.Add(enums.Districts.Rehovot);
                        break;
                    case 5:
                        subArea.Items.Add(enums.Districts.TelAviv);

                        break;
                    case 6:
                        subArea.Items.Add(enums.Districts.Ashkelon);
                        subArea.Items.Add(enums.Districts.BeerSheva);
                        break;
                    case 7:
                        subArea.Items.Add(enums.Districts.JudeaAndSamaria);
                        break;
                }

            }
        }
    }
}