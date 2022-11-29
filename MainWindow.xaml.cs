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
        private static bool start = false, touch = false, pressUp, pressDown, pressW, pressS;
        private static Random rng = new Random();
        private static int score1 = 0, score2 = 0, x = 0, y = 0;

        public MainWindow()
        {
            InitializeComponent();
        }

        

        private async void btn_Click(object sender, RoutedEventArgs e)
        {
            btn.Visibility = Visibility.Hidden;
            start = true;
            score_player1.Content = score1;
            score_player2.Content = score2;
            score_player1.Visibility = Visibility.Visible;
            score_player2.Visibility = Visibility.Visible;
            dots.Visibility = Visibility.Visible;
            while (x == 0)
            {
                x = rng.Next(-5, 6);
                y = rng.Next(-5, 6);
            }
            while (!touch)
            {
                Canvas.SetTop(ball, Canvas.GetTop(ball) + y);
                Canvas.SetLeft(ball, Canvas.GetLeft(ball) + x);
                if (Canvas.GetLeft(ball) + 5 >= Canvas.GetLeft(player2) - 10)
                {
                    if (Canvas.GetTop(ball) >= Canvas.GetTop(player2) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player2) + 15)
                    {
                        x = -x;
                    }
                    else if (Canvas.GetTop(ball) + 5 >= Canvas.GetTop(player2) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player2) + 15)
                    {
                        x = -x;
                    }
                    else if (Canvas.GetTop(ball) - 5 >= Canvas.GetTop(player2) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player2) + 15)
                    {
                        x = -x;
                    }
                }
                if (Canvas.GetLeft(ball) - 5 <= Canvas.GetLeft(player1) + 10)
                {
                    if (Canvas.GetTop(ball) >= Canvas.GetTop(player1) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player1) + 15)
                    {
                        x = -x;
                    }
                    else if (Canvas.GetTop(ball) + 5 >= Canvas.GetTop(player1) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player1) + 15)
                    {
                        x = -x;
                    }
                    else if (Canvas.GetTop(ball) - 5 >= Canvas.GetTop(player1) - 15 && Canvas.GetTop(ball) <= Canvas.GetTop(player1) + 15)
                    {
                        x = -x;
                    }
                }
                if (Canvas.GetTop(ball) <= 0)
                {
                    y = -y;
                }
                if (Canvas.GetTop(ball) >= 400)
                {
                    y = -y;
                }
                if (Canvas.GetLeft(ball) <= 0)
                {
                    touch = true;
                    score2++;
                    score_player2.Content = score2;
                }
                if (Canvas.GetLeft(ball) >= 780)
                {
                    touch = true;
                    score1++;
                    score_player1.Content = score1;
                }
                await Task.Delay(20);
            }
            start = false;
            touch = false;
            x = 0;
            y = 0;
            Canvas.SetLeft(ball, 389);
            Canvas.SetTop(ball, 210);
            Canvas.SetTop(player1, 201);
            Canvas.SetTop(player2, 201);
            btn.Visibility = Visibility.Visible; 
        }
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                Environment.Exit(0);
            }
            if (e.Key == Key.Up)
            {
                pressUp = true;
            }
            if (e.Key == Key.Down)
            {
                pressDown = true;
            }
            if (e.Key == Key.W)
            {
                pressW = true;
            }
            if (e.Key == Key.S)
            {
                pressS = true;
            }
            if (start)
            {
                if (pressUp && pressW && Canvas.GetTop(player2) >= 15 && Canvas.GetTop(player1) >= 15)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) - 10);
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - 10);
                }
                else if (pressUp && pressS && Canvas.GetTop(player2) >= 15 && Canvas.GetTop(player1) <= 370)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) - 10);
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + 10);
                }
                else if (pressDown && pressW && Canvas.GetTop(player2) <= 370 && Canvas.GetTop(player1) >= 15)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + 10);
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - 10);
                }
                else if (pressDown && pressS && Canvas.GetTop(player2) <= 370 && Canvas.GetTop(player1) <= 370)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + 10);
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + 10);
                }
                else if (pressUp && Canvas.GetTop(player2) >= 15)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) - 10);
                }
                else if (pressDown && Canvas.GetTop(player2) <= 370)
                {
                    Canvas.SetTop(player2, Canvas.GetTop(player2) + 10);
                }
                else if (pressW && Canvas.GetTop(player1) >= 15)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) - 10);
                }
                else if (pressS && Canvas.GetTop(player1) <= 370)
                {
                    Canvas.SetTop(player1, Canvas.GetTop(player1) + 10);
                }
            }
        }
        private void Window_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up)
            {
                pressUp = false;
            }
            if (e.Key == Key.Down)
            {
                pressDown = false;
            }
            if (e.Key == Key.W)
            {
                pressW = false;
            }
            if (e.Key == Key.S)
            {
                pressS = false;
            }
        }
    }
}
