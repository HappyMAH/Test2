using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Capcha.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddAgentPage.xaml
    /// </summary>
    public partial class AddAgentPage : Page
    {
        public AddAgentPage(Agent agentik)
        {
            InitializeComponent();

        }

        private void FirstNameAgentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(FirstNameAgentTB.Text, "[^А-я]"))
            {
                FirstNameAgentTB.Text = FirstNameAgentTB.Text.Remove(FirstNameAgentTB.Text.Length - 1);
                FirstNameAgentTB.SelectionStart = FirstNameAgentTB.Text.Length;
            }
        }

        private void AddAgentBtn_Click(object sender, RoutedEventArgs e)
        {
            Agent localagent = new Agent();
            if (DealShareTB.Text.Length > 0)
            {
                int Part = Convert.ToInt32(DealShareTB.Text.ToString());
                if (FirstNameAgentTB.Text.Length > 2 && MiddleNameAgentTB.Text.Length > 2 && LastNameAgentTB.Text.Length > 2 && Part > -1 && Part < 100)
                {

                    localagent.FirstName = FirstNameAgentTB.Text;
                    localagent.MiddleName = MiddleNameAgentTB.Text;
                    localagent.LastName = LastNameAgentTB.Text;
                    localagent.DealShare = Convert.ToInt32(DealShareTB.Text.ToString());
                    MainWindow.db.Agent.Add(localagent);
                    MainWindow.db.SaveChanges();
                    NavigationService.Navigate(new AgentPage());
                }
                else
                {
                    MessageBox.Show("Некорректные значения");
                }
            }
            else
            {
                MessageBox.Show("Необходимо заполнить все поля");
            }
        }

        private void MiddleNameAgentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(MiddleNameAgentTB.Text, "[^А-я]"))
            {
                MiddleNameAgentTB.Text = MiddleNameAgentTB.Text.Remove(MiddleNameAgentTB.Text.Length - 1);
                MiddleNameAgentTB.SelectionStart = MiddleNameAgentTB.Text.Length;
            }
        }

        private void LastNameAgentTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(LastNameAgentTB.Text, "[^А-я]"))
            {
                LastNameAgentTB.Text = LastNameAgentTB.Text.Remove(LastNameAgentTB.Text.Length - 1);
                LastNameAgentTB.SelectionStart = LastNameAgentTB.Text.Length;
            }
        }

        private void DealShareTB_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (Regex.IsMatch(DealShareTB.Text, "[^0-9]"))
            {
                DealShareTB.Text = DealShareTB.Text.Remove(DealShareTB.Text.Length - 1);
                DealShareTB.SelectionStart = DealShareTB.Text.Length;
            }
        }
    }
}
