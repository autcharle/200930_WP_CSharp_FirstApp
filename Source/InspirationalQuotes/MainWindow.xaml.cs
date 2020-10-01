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

namespace InspirationalQuotes {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        #region Global Variables
        public Random rng = new Random();
        private Timer timer;
        private int prevIndex = -1;
        string[] images = {
            "motiv1.jpg",
            "motiv2.jpg",
            "motiv3.jpg",
            "motiv4.jpg",
            "motiv5.jpg",
            "motiv6.jpg",
            "motiv7.jpg",
            "motiv8.jpg",
            "motiv9.jpg",
            "motiv10.jpg",
            "motiv11.jpg",
            "motiv12.jpg",
            "motiv13.jpg",
            "motiv14.jpg",
            "motiv15.jpg",
            "motiv16.jpg",
            "motiv17.jpg",
            "motiv18.jpg",
            "motiv19.jpg",
            "motiv20.jpg"
        };
        #endregion

        #region Components_Loaded
        public MainWindow() {
            InitializeComponent();
        }
        
        private void Window_Loaded(
            object sender,
            RoutedEventArgs e) {
                timer = new Timer();
                timer.Interval = 3000;
                timer.Elapsed += Timer_Elapsed;
                timer.Start();
        }

        private void quotesImage_Loaded(
            object sender,
            RoutedEventArgs e) {
                showQuotesImage();
        }
        #endregion

        #region Functions Setup
        private void Timer_Elapsed(
            object sender,
            ElapsedEventArgs e) {
                Dispatcher.Invoke(() =>
                    showQuotesImage()
                );
        }

        private void showQuotesImage() {
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
            quotesImage.Source = imageToShow;
        }
        #endregion

        #region Buttons_Click
        private void nextButton_Click(
            object sender,
            RoutedEventArgs e) {
                timer.Stop();
                timer.Start();
                showQuotesImage();
        }

        private void aboutButton_Click(
            object sender,
            RoutedEventArgs e) {
            MessageBoxResult aboutMessageBoxResult = MessageBox.Show(
                "My favorite quote is\nYour limitation - it’s only your imagination.\n\t\t\t__ TTT __",
                "About",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
        #endregion
    }
}
