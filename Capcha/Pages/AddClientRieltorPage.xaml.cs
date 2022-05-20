using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Capcha.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddClientRieltorPage.xaml
    /// </summary>
    public partial class AddClientRieltorPage : Page
    {
        Client LocalClient;
       
        public AddClientRieltorPage(Client clientik)
        {
            InitializeComponent();
            LocalClient = clientik;
            
            

        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            Client localClient = LocalClient;
            if (emailTB.Text.Length > 10 || PhoneTB.Text.Length > 11)
            {
                localClient.LastName = LastNameTB.Text;
                localClient.MiddleName = MiddleNameTB.Text;
                localClient.FirstName = FirstNameTB.Text;
                localClient.Phone = PhoneTB.Text;
                localClient.Email = emailTB.Text;
                MainWindow.db.Client.Add(localClient);
                MainWindow.db.SaveChanges();
                
            }
            else
            {
                MessageBox.Show("Нужно заполнить телефон или почту");   
            }
            
        }

        private void FirstNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(FirstNameTB.Text, "[^А-я]"))
            {
                FirstNameTB.Text = FirstNameTB.Text.Remove(FirstNameTB.Text.Length - 1);
                FirstNameTB.SelectionStart = FirstNameTB.Text.Length;
            }
        }

        private void MiddleNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(FirstNameTB.Text, "[^А-я]"))
            {
                FirstNameTB.Text = FirstNameTB.Text.Remove(FirstNameTB.Text.Length - 1);
                FirstNameTB.SelectionStart = FirstNameTB.Text.Length;
            }
        }

        private void LastNameTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(LastNameTB.Text, "[^А-я]"))
            {
                LastNameTB.Text = LastNameTB.Text.Remove(LastNameTB.Text.Length - 1);
                LastNameTB.SelectionStart = LastNameTB.Text.Length;
            }
        }

        private void PhoneTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(PhoneTB.Text, "[^1-9]"))
            {
                PhoneTB.Text = PhoneTB.Text.Remove(PhoneTB.Text.Length - 1);
                PhoneTB.SelectionStart = PhoneTB.Text.Length;
            }
        }

        private void emailTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            if (Regex.IsMatch(emailTB.Text, @"^[A-Z 0-9._%+-] + @[A-Z] +\.[A-Z]{2,4}$"))
            {
                emailTB.Text = emailTB.Text.Remove(emailTB.Text.Length - 1);
                emailTB.SelectionStart = emailTB.Text.Length;
            }
        }
    }
}
