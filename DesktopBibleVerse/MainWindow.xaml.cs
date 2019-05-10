using System;
using System.Collections.Generic;
using System.IO;
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
        List<Verse> lv = new List<Verse>();

        public MainWindow()
        {
            InitializeComponent();
            WPS.WPS_Window_Constructor(this);
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            WPS.WPS_Window_Loaded(this);
            this.Width = 1000;//zrušit WPS width
            string text = File.ReadAllText("verselist.txt");
            lv = GH.ReadVerses(text);

            LoadSettings();

            origL = Left;
            origT = Top;
        }

        public void LoadSettings()
        {
            string color = Properties.Settings.Default.Background;
            string alpha = Properties.Settings.Default.Alpha;
            string fontcolor = Properties.Settings.Default.FontColor;
            bbb.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + alpha + color));
            bbb.MaxWidth = Properties.Settings.Default.MaxWidth;
            lblVerse.FontSize = Properties.Settings.Default.FontSizeVerse;
            lblRef.FontSize = Properties.Settings.Default.FontSizeRef;
            SolidColorBrush b = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#" + fontcolor));
            lblVerse.Foreground = b;
            lblRef.Foreground = b;
            lblVerse.FontFamily = new FontFamily(Properties.Settings.Default.Font);
            lblRef.FontFamily = new FontFamily(Properties.Settings.Default.Font);
            VerseSet(Properties.Settings.Default.VerseIndex);
        }

        public void SaveSettings()
        {
            SolidColorBrush b = (SolidColorBrush)bbb.Background;
            string color = BitConverter.ToString(new byte[] { b.Color.R, b.Color.G, b.Color.B }).Replace("-", "");
            string alpha = BitConverter.ToString(new byte[] { b.Color.A });
            SolidColorBrush b2 = (SolidColorBrush)lblVerse.Foreground;
            string fontcolor = BitConverter.ToString(new byte[] { b2.Color.R, b2.Color.G, b2.Color.B }).Replace("-", "");

            Properties.Settings.Default.Font = lblVerse.FontFamily.FamilyNames.ElementAt(0).Value;
            Properties.Settings.Default.Background = color;
            Properties.Settings.Default.Alpha = alpha;
            Properties.Settings.Default.MaxWidth = bbb.MaxWidth;
            Properties.Settings.Default.FontSizeVerse = lblVerse.FontSize;
            Properties.Settings.Default.FontSizeRef = lblRef.FontSize;
            Properties.Settings.Default.FontColor = fontcolor;
            Properties.Settings.Default.VerseIndex = index;
            Properties.Settings.Default.Save();
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            SaveSettings();
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

        int index;

        void VerseSet(int index)
        {
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            this.index = index;
            SaveSettings();
        }

        void VersePlus()
        {
            index++;
            if (index >= lv.Count)
                index = 0;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        void VerseMinus()
        {
            index--;
            if (index < 0)
                index = lv.Count - 1;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        void VerseRandom()
        {
            int old_index = index;
            Random r = new Random(DateTime.Now.Millisecond);
            for (int i = 0; i < 10; i++)
            {
                index = r.Next(0, lv.Count - 1);
                if (index != old_index)
                    break;
            }
            
            if (index < 0)
                index = lv.Count - 1;
            if (index >= lv.Count)
                index = 0;
            lblVerse.Text = lv[index].Text;
            lblRef.Content = lv[index].Ref;
            SaveSettings();
        }

        private void MiNext_Click(object sender, RoutedEventArgs e)
        {
            VersePlus();
        }

        private void MiPrevious_Click(object sender, RoutedEventArgs e)
        {
            VerseMinus();
        }

        private void MiRandom_Click(object sender, RoutedEventArgs e)
        {
            VerseRandom();
        }

        private void MiSetup_Click(object sender, RoutedEventArgs e)
        {
            winSettings ws = new winSettings(this);
            ws.Show();
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.LeftCtrl)
                lblVerse.MaxWidth = 400;
        }

        private void MiClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void Window_StateChanged(object sender, EventArgs e)
        {
            if (this.WindowState == WindowState.Minimized)
                this.WindowState = WindowState.Normal;
        }

        private void Window_LocationChanged(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch
            {

            }
        }
    }
}
