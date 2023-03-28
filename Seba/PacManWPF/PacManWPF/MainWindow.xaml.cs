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
using System.Windows.Threading;

namespace PacManWPF
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DispatcherTimer gameTimer = new DispatcherTimer();
        public bool moveLeft, moveRight, moveUp, moveDown;
        public int playerSpeed = 5;
        public MainWindow()
        {
            InitializeComponent();

            gameTimer.Interval = TimeSpan.FromMilliseconds(20);
            gameTimer.Tick += GameLoop;
            gameTimer.Start();

            GameWindow.Focus();
        }

        private void GameLoop(object sender, EventArgs e)
        {
            TopCord.Content = "Top: " + Canvas.GetTop(Player);
            LeftCord.Content = "Left: " + Canvas.GetLeft(Player);
            if(moveLeft == true && Canvas.GetLeft(Player) > 0)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) - playerSpeed);
            }
            if (moveRight == true && Canvas.GetLeft(Player) + 80 < Application.Current.MainWindow.Width)
            {
                Canvas.SetLeft(Player, Canvas.GetLeft(Player) + playerSpeed);
            }
            if (moveUp == true && Canvas.GetTop(Player) > 0)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) - playerSpeed);
            }
            if (moveDown == true && Canvas.GetTop(Player) + 80 < Application.Current.MainWindow.Height)
            {
                Canvas.SetTop(Player, Canvas.GetTop(Player) + playerSpeed);
            }
        }

        private void GameWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Left)
            {
                moveLeft = true;
            }
            if (e.Key == Key.Right)
            {
                moveRight = true;
            }
            if (e.Key == Key.Up)
            {
                moveUp = true;
            }
            if (e.Key == Key.Down)
            {
                moveDown = true;
            }
        }

        private void GameWindow_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Left)
            {
                moveLeft = false;
            }
            if (e.Key == Key.Right)
            {
                moveRight = false;
            }
            if (e.Key == Key.Up)
            {
                moveUp = false;
            }
            if (e.Key == Key.Down)
            {
                moveDown = false;
            }    
        }
    }
}
