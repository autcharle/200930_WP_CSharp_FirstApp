using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnglishByImages
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        #region Global Variables
        public Random rng = new Random();
        private Timer timer;
        private int prevIndex = -1;
        private int prevColorIdx = -1;
        private int prevTextColorIdx = -1;
        string[] images = {
            "animal1.png",
            "animal2.png",
            "animal3.png",
            "animal4.png",
            "animal5.png",
            "animal6.png",
            "animal7.png",
            "animal8.png",
            "animal9.png",
            "animal10.png",
            "animal11.png",
            "animal12.png",
            "animal13.png",
            "animal14.png",
            "animal15.png",
            "animal16.png",
            "animal17.png",
            "animal18.png",
            "animal19.png",
            "animal20.png"
        };
        string[] words = {
            "lion",
            "tiger",
            "elephant",
            "giraffe",
            "zebra",
            "hippo",
            "rhino",
            "crocodile",
            "monkey",
            "camel",
            "kangaroo",
            "penguin",
            "polar bear",
            "fox",
            "panda bear",
            "koala",
            "seal",
            "wolf",
            "deer",
            "squirrel"
        };
        Color[] colors = {
                Colors.DarkRed,
                Colors.DarkOrange,
                Colors.LightGoldenrodYellow,
                Colors.LightGreen,
                Colors.DarkGreen,
                Colors.DarkCyan,
                Colors.LightSkyBlue,
                Colors.DarkBlue,
                Colors.DarkOrchid,
                Colors.DarkMagenta,
                Colors.LightPink
            };
        Color[] textColors = {
            Colors.DarkSlateGray,
            Colors.Black,
            Colors.WhiteSmoke
        };
        #endregion

        #region Components_Loaded
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void Window_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            timer = new Timer();
            timer.Interval = 1500;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void Images_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            showImage();
            showWord();
        }

        private void MainCanvas_Loaded(
            object sender,
            RoutedEventArgs e)
        {
            changeBackground();
        }
        #endregion

        #region Functions Setup
        private void Timer_Elapsed(
            object sender,
            ElapsedEventArgs e)
        {
            Dispatcher.Invoke(() => {
                changeBackground();
                changeForeground();
                }
            );
        }

        private void showImage()
        {
            int index = -1;

            do
            {
                index = rng.Next(images.Length);
            } while (index == prevIndex);

            prevIndex = index;
            string selectedImage = images[index];
            BitmapImage imageToShow = new BitmapImage(
                        new Uri(
                            "Images/" + selectedImage,
                             UriKind.Relative
                               )
                    );
            Images.Source = imageToShow;
        }

        private void showWord()
        {
            string selectedWord = words[prevIndex];
            wordLabel.Content = selectedWord;
        }

        private void changeBackground()
        {
            int index = -1;

            do
            {
                index = rng.Next(colors.Length);
                MainCanvas.Background = new SolidColorBrush(colors[index]);
            } while (index == prevColorIdx);

            prevColorIdx = index;
        }

        private void changeForeground()
        {
            int index = -1;
            do
            {
                index = rng.Next(textColors.Length);
                wordLabel.Foreground = new SolidColorBrush(textColors[index]);
            } while (index == prevTextColorIdx);

            prevTextColorIdx = index;
        }
        #endregion

        #region Buttons_Click
        private void nextButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            showImage();
            showWord();
        }

        private void infoButton_Click(
            object sender,
            RoutedEventArgs e)
        {
            MessageBoxResult aboutMessageBoxResult = MessageBox.Show(
                "App học tiếng Anh đơn giản.\n\tVersion: 1.0",
                "About app",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
        #endregion
    }
}
