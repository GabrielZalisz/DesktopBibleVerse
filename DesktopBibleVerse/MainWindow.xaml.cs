using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WindowPositionSaver;

namespace DesktopBibleVerse
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<string> l = new List<string>();

        public MainWindow()
        {
            InitializeComponent();
            WPS.WPS_Window_Constructor(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WPS.WPS_Window_Loaded(this);
            l.Add("aaa");
            l.Add("bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb bbb");
            l.Add("ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc ccc");
            l.Add("ddd ddd ddd ddd ddd ddd ddd ddd ddd");
            l.Add("eee eee eee eee");

            VersePlus();

            LoadSettings();
            SaveSettings();
        }

        void LoadSettings()
        {
            string color = Properties.Settings.Default.Background;
            string alpha = Properties.Settings.Default.Alpha;
            string fontcolor = Properties.Settings.Default.FontColor;
            bbb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + alpha + color));
            bbb.MaxWidth = Properties.Settings.Default.MaxWidth;
            lblVerse.FontSize = Properties.Settings.Default.FontSizeVerse;
            lblScripture.FontSize = Properties.Settings.Default.FontSizeScripture;
            SolidColorBrush b = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + fontcolor));
            lblVerse.Foreground = b;
            lblScripture.Foreground = b;
        }

        void SaveSettings()
        {
            SolidColorBrush b = (SolidColorBrush)bbb.Background;
            string color = BitConverter.ToString(new byte[] { b.Color.R, b.Color.G, b.Color.B }).Replace("-", "");
            string alpha = BitConverter.ToString(new byte[] { b.Color.A });
            SolidColorBrush b2 = (SolidColorBrush)lblVerse.Foreground;
            string fontcolor = BitConverter.ToString(new byte[] { b2.Color.R, b2.Color.G, b2.Color.B }).Replace("-", "");

            Properties.Settings.Default.Background = color;
            Properties.Settings.Default.Alpha = alpha;
            Properties.Settings.Default.MaxWidth = bbb.MaxWidth;
            Properties.Settings.Default.FontSizeVerse = lblVerse.FontSize;
            Properties.Settings.Default.FontSizeScripture = lblScripture.FontSize;
            Properties.Settings.Default.FontColor = fontcolor;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            WPS.WPS_Window_Closing(this);
        }

        double origL;
        double origT;

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton != MouseButtonState.Pressed)
                return;
            DragMove();
            origL = Left;
            origT = Top;
        }

        private void Window_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton != MouseButton.Left)
                return;
            if (origL == Left && origT == Top)
                VersePlus();
        }

        void VersePlus()
        {
            int index = l.IndexOf(lblVerse.Text);
            index++;
            if (index >= l.Count)
                index = 0;
            lblVerse.Text = l[index];
        }

        void VerseMinus()
        {
            int index = l.IndexOf(lblVerse.Text);
            index--;
            if (index < 0)
                index = l.Count - 1;
            lblVerse.Text = l[index];
        }

        private void MiNext_Click(object sender, RoutedEventArgs e)
        {
            VersePlus();
        }

        private void MiPrevious_Click(object sender, RoutedEventArgs e)
        {
            VerseMinus();
        }

        private void MiSetup_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                lblVerse.MaxWidth = 400;
        }
    }
}
