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
using System.Collections;

namespace CyberPunk2048
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int height = 4;
        const int width = 4;
        ButtonsContrloller gameController;
        Button[,] buttonsArray = new Button[width, height];

        public MainWindow()
        {
            InitializeComponent();
            BindButtons();
            gameController = new ButtonsContrloller(width, height);
            score.Text = "Score : 0";
            maxScore.Text = "MaxScore : 0";
            CreateValyeButton(); 
            CreateValyeButton();
        }
        private void BindButtons()
        {
            int i = 0;
            int j = 0;
            foreach (var child in buttonsGrid.Children)
            {
                if (i == height)
                    break;
                if (j == width)
                {
                    i++; j = 0;
                }
                if (child.GetType().Name == "Button")
                {
                    buttonsArray[i, j] = (Button)child; j++;
                }
            }
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Up || e.Key == Key.Left || e.Key == Key.Down || e.Key == Key.Right)
            {
                if (e.Key == Key.Up)
                {
                    gameController.MoveToUp();
                }
                else if (e.Key == Key.Left)
                {
                    gameController.MoveToLeft();
                }
                else if (e.Key == Key.Down)
                {
                    gameController.MoveToDown();
                }
                else if (e.Key == Key.Right)
                {
                    gameController.MoveToRight();
                }
                if(gameController.WinCheck())
                {
                    MessageBox.Show("You Win!");
                }
                else if(gameController.GameOver())
                {
                    MessageBox.Show("You Loose!");
                    CreateValyeButton();
                    CreateValyeButton();
                    VisualUpdate();
                    return;
                }
                CreateValyeButton();
                VisualUpdate();
            }
        }
        private void CreateValyeButton()
        {
            ButtonValuePoint tmp = gameController.GenerateNewButtons();
            var style = (Style)this.Resources["fillButton"];
            buttonsArray[tmp.x, tmp.y].Style = style;
            buttonsArray[tmp.x, tmp.y].Content = tmp.value;
        }
        private void VisualUpdate()
        {
            var styleEmpty = (Style)this.Resources["buttonEmty"];
            var styleFill = (Style)this.Resources["fillButton"];
            var styleSum = (Style)this.Resources["sumButton"];
            int[,] tmpLogicArray = gameController.GetLogicArray();

            for(int i = 0; i < width; i++)
            {
                for(int j = 0; j < height; j++)
                {
                    if(tmpLogicArray[i, j] == 0)
                    {
                        buttonsArray[i, j].Style = styleEmpty;
                        buttonsArray[i, j].Content = String.Empty;
                    }
                    else if(tmpLogicArray[i, j] == 2 || tmpLogicArray[i, j] == 4)
                    {
                        buttonsArray[i, j].Style = styleFill;
                        buttonsArray[i, j].Content = tmpLogicArray[i, j].ToString();
                    }
                    else
                    {
                        buttonsArray[i, j].Style = styleSum;
                        buttonsArray[i, j].Content = tmpLogicArray[i, j].ToString();
                    }
                }
            }
            score.Text = "Score : " + gameController.score;
            maxScore.Text = "MaxScore : " + gameController.maxScore;
        }

    }
}
