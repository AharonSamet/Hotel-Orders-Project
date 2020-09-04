using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for GuestPanel.xaml
    /// </summary>
    public partial class GuestPanel : Window
    {
        private readonly IBL _instance = FactoryBl.GetInstance;
        Customer CustomerWindow;

        #region cot-r
        public GuestPanel()
        {
            var bl = FactoryBl.GetInstance;

            InitializeComponent();
            //MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            App.numOfActivatedMainWindow++;
            FlowDirection = FlowDirection.LeftToRight;
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            SystemCommands.MinimizeWindow(this);
            Gender.ItemsSource = Enum.GetValues(typeof(enums.Gender));
            CustomerWindow = new Customer
            {
                ClientInfo = new Contact
                {
                    FirstName = null,
                    LastName = null,
                    PhoneNumber = null,
                    Gender = (enums.Gender)0,
                    EmailAddress = null,
                    DateOfBirth = DateTime.Today,
                    SystemRegistrationDate = DateTime.Today,
                    LoginDetails = new Login
                    {
                        UserName = null,
                        Password = null
                    }
                }
            };
            //CustomerWindow.ClientInfo.SystemRegistrationDate = DateTime.Now;
            //DateBirth.DisplayDate = DateTime.Now;
            //DateBirth.DisplayDateStart = DateTime.Now.AddYears(-80);
            //DateBirth.DisplayDateEnd = DateTime.Now;
            GridCustomerWindow.DataContext = CustomerWindow;

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

        #region validations



        //first name
        private void FirstName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (firstName.Text.Length <= 3 /*|| !firstName.Text.All(x => x == ' ' || char.IsLetter(x)) || !Utilities.Validation.IsValidName(firstName.Text)*/)
                firstName.Background = Brushes.Red;
            else
                firstName.BorderBrush = Brushes.Green;
        }

        private void FirstName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            firstName.Background = Brushes.White;
            firstName.BorderBrush = Brushes.Gray;
        }

        //last name
        private void LastName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (lastName.Text.Length <= 3/* || !lastName.Text.All(x => x == ' ' || char.IsLetter(x)) || !Utilities.Validation.IsValidName(lastName.Text)*/)
                lastName.Background = Brushes.Red;
            else
                firstName.BorderBrush = Brushes.Green;
        }

        private void LastName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            lastName.Background = Brushes.White;
            lastName.BorderBrush = Brushes.Gray;
        }


        //phone number
        private void Phon_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!phon.Text.All(char.IsDigit) || (phon.Text.Length != 10)
                /*!Utilities.Validation.IsValidPhoneNumber(phon.Text)*/)
                phon.Background = Brushes.Red;
            else
                phon.BorderBrush = Brushes.Green;
        }

        private void Phon_OnGotFocus(object sender, RoutedEventArgs e)
        {
            phon.Background = Brushes.White;
            phon.BorderBrush = Brushes.Gray;
        }

        //email
        private void Email_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (/*!email.Text.All(char.IsDigit) ||*/ (email.Text.Length < 6) 
                /*!Utilities.Validation.IsValidEmail(email.Text)*/)
                email.Background = Brushes.Red;
            else
                email.BorderBrush = Brushes.Green;
        }

        private void Email_OnGotFocus(object sender, RoutedEventArgs e)
        {
            email.Background = Brushes.White;
            email.BorderBrush = Brushes.Gray;
        }

        #endregion

        #region userName_password

        private void UserName_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (userName.Text.Length == 0 /*|| !userName.Text.All(x => x == ' ' || char.IsLetter(x)) ||
            //    !Utilities.Validation.IsValidUserName(userName.Text)*/)
                userName.Background = Brushes.Red;
            else
                userName.BorderBrush = Brushes.Green;
        }

        private void UserName_OnGotFocus(object sender, RoutedEventArgs e)
        {
            userName.Background = Brushes.White;
            userName.BorderBrush = Brushes.Gray;
        }

        private void PasswordBox_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Utilities.Validation.IsValidPassword(PasswordBox.Password))
                PasswordBox.Background = Brushes.Red;
            else
                PasswordBox.BorderBrush = Brushes.Green;
        }

        private void PasswordBox_OnGotFocus(object sender, RoutedEventArgs e)
        {
            PasswordBox.Background = Brushes.White;
            PasswordBox.BorderBrush = Brushes.Gray;
        }

        //confirm
        private void Confirme_OnLostFocus(object sender, RoutedEventArgs e)
        {
            if (!Utilities.Validation.IsValidPassword(confirme.Password) || PasswordBox.Password != confirme.Password)
                confirme.Background = Brushes.Red;
            else
                confirme.BorderBrush = Brushes.Green;
        }

        private void Confirme_OnGotFocus(object sender, RoutedEventArgs e)
        {
            confirme.Background = Brushes.White;
            confirme.BorderBrush = Brushes.Gray;
        }

        #endregion


        private void SignIn_OnClick(object sender, RoutedEventArgs e)
        {
            CustomerWindow.ClientInfo.LoginDetails.Password = PasswordBox.Password;
           

            if (firstName.Background != Brushes.White && firstName.BorderBrush != Brushes.Gray
                || lastName.Background != Brushes.White && lastName.BorderBrush != Brushes.Gray
                || phon.Background != Brushes.White && phon.BorderBrush != Brushes.Gray
                || email.Background != Brushes.White && email.BorderBrush != Brushes.Gray
                || userName.Background != Brushes.White && userName.BorderBrush != Brushes.Gray
                || PasswordBox.Background != Brushes.White && PasswordBox.BorderBrush != Brushes.Gray
                || confirme.Background != Brushes.White && confirme.BorderBrush != Brushes.Gray
                || Gender.SelectedIndex == -1 /* dp1.Length == 0*/)
            {
                MessageBox.Show("Some details you entered are incorrect, please try again", "Failed",
                    MessageBoxButton.OK, MessageBoxImage.Information,
                    MessageBoxResult.None);
                return;
            }

            try
            {

                try
                {
                    _instance.AddCustomerContactInfo(CustomerWindow);
                    MessageBox.Show("Your registration has been successfully completed");

                    NewGuestRequest newRequest = new NewGuestRequest(CustomerWindow.ClientInfo.LoginDetails);
                    newRequest.Show();
                    this.Close();
                }
                catch (Exception exception)
                {
                 
                    MessageBox.Show(exception.Message);
                    return;

                }

            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
                return;

            }

        }

        private void DateBirth_OnSelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            

        }
    }
}
