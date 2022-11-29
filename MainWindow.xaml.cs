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

namespace Pong
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool start = false, touch = false;
        private static Random rng = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            btn.Visibility = Visibility.Hidden;
            start = true;
            switch (rng.Next(0, 4))
            {
                case 0:
                    while (!touch)
                    {
                        Canvas.SetTop(ball, Canvas.GetTop(ball) - 5);
                        Canvas.SetLeft(ball, Canvas.GetLeft(ball) + 5);
                        await Task.Delay(200);
                        if (Canvas.GetTop(ball) <= 0) touch = true;
                        if (Canvas.GetTop(ball) >= 421) touch = true;
                    }
                    break;
                case 1:
                    while (!touch)
                    {
                        Canvas.SetTop(ball, Canvas.GetTop(ball) - 5);
                        Canvas.SetLeft(ball, Canvas.GetLeft(ball) - 5);
                        await Task.Delay(200);
                        if (Canvas.GetTop(ball) <= 0) touch = true;
                    }
                    break;
                case 2:
                    while (!touch)
                    {
                        Canvas.SetTop(ball, Canvas.GetTop(ball) + 5);
                        Canvas.SetLeft(ball, Canvas.GetLeft(ball) + 5);
                        await Task.Delay(200);
                        if (Canvas.GetTop(ball) >= 421) touch = true;
                    }
                    break;
                case 3:
                    while (!touch)
                    {
                        Canvas.SetTop(ball, Canvas.GetTop(ball) + 5);
                        Canvas.SetLeft(ball, Canvas.GetLeft(ball) - 5);
                        await Task.Delay(200);
                        if (Canvas.GetTop(ball) >= 421) touch = true;
                    }
                    break;
            }
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (start)
            {
                if (e.Key == Key.Up)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) - 10);
                }
                if (e.Key == Key.Down)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + 10);
                }
                if (e.Key == Key.W)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - 10);
                }
                if (e.Key == Key.S)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + 10);
                }
            }
        }
    }
}
