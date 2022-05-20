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

namespace Capcha.Pages
{
    /// <summary>
    /// Логика взаимодействия для FirstPage.xaml
    /// </summary>
    public partial class FirstPage : Page
    {
        Random rnd = new Random();
        public FirstPage()
        {
            InitializeComponent();
        }

        private void CapchaBtn_Click(object sender, RoutedEventArgs e)
        {
            UpdateCaptcha();
        }

        private void UpdateCaptcha()
        {

            Symbols.Children.Clear();
            CanvasCV.Children.Clear();
            GenerateNoise(10);
            GenerateSymbol(rnd.Next(3, 10));
            
            
            
        }
        private void GenerateSymbol(int count)
        {
            string anf = "QWERTYUIOPASDFGHJKLZCXVBNM";
            for (int i = 0; i < count; i++)
            {
                string symbol = anf.ElementAt(rnd.Next(0,anf.Length)).ToString();
                TextBlock tb = new TextBlock();
                tb.Text = symbol;
                tb.FontSize = rnd.Next(20, 60);
                tb.RenderTransform = new RotateTransform(rnd.Next(-45, 45));
                tb.Margin = new Thickness(10, 0, 10, 0);
                Symbols.Children.Add(tb);

            }
        }
        private void GenerateNoise(int noise)
        {
            for (int i = 0; i < noise; i++)
            {
                Rectangle ellipse = new Rectangle();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 200),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256)));
                ellipse.Height = ellipse.Width = rnd.Next(10, 100);

                CanvasCV.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(-500, 500));
                Canvas.SetTop(ellipse, rnd.Next(-120, 120));
            }
            for (int i = 0; i < noise; i++)
            {
                Ellipse ellipse = new Ellipse();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 200),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256)));
                ellipse.Height = ellipse.Width = rnd.Next(10, 100);

                CanvasCV.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(-500, 500));
                Canvas.SetTop(ellipse, rnd.Next(-120, 120));
            }
            for (int i = 0; i < noise; i++)
            {
                Rectangle ellipse = new Rectangle();
                ellipse.Fill = new SolidColorBrush(Color.FromArgb((byte)rnd.Next(100, 200),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256),
                    (byte)rnd.Next(0, 256)));
                ellipse.Height = rnd.Next(10, 100);
                    ellipse.Width = rnd.Next(10, 100);

                CanvasCV.Children.Add(ellipse);
                Canvas.SetLeft(ellipse, rnd.Next(-500, 500));
                Canvas.SetTop(ellipse, rnd.Next(-120, 120));
            }

        }

        private void AddCRBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new ClientPage());
        }

        private void AddAgentBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AgentPage());
        }
    }
}
