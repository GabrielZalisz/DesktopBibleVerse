using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace DesktopBibleVerse
{
    /// <summary>
    /// Interaction logic for winSettings.xaml
    /// </summary>
    public partial class winSettings : Window
    {
        MainWindow mw;

        public winSettings(MainWindow mw)
        {
            InitializeComponent();
            this.mw = mw;
            sliderPruhlednost.Value = GH.ParseHexValue(Properties.Settings.Default.Alpha);
            sliderMaxWidth.Value = mw.bbb.MaxWidth;
            sliderFontSizeVerse.Value = mw.lblVerse.FontSize;
            sliderFontSizeRef.Value = mw.lblRef.FontSize;

            sliderPruhlednost.ValueChanged += SliderPruhlednost_ValueChanged;
            sliderMaxWidth.ValueChanged += SliderMaxWidth_ValueChanged;
            sliderFontSizeVerse.ValueChanged += SliderFontSizeVerse_ValueChanged;
            sliderFontSizeRef.ValueChanged += SliderFontSizeRef_ValueChanged;

            cbBarvaPozadi.ItemsSource = GH.Barvy;
            cbBarvaPisma.ItemsSource = GH.Barvy;

            Color cp = ((SolidColorBrush)mw.bbb.Background).Color;
            Color cl = ((SolidColorBrush)mw.lblVerse.Foreground).Color;
            string aaa = $"{cp.R},{cp.G},{cp.B}";
            string bbb = $"{cl.R},{cl.G},{cl.B}";
            cbBarvaPozadi.SelectedItem = GH.Barvy.
                Where(q => GetRGB(q) == $"{cp.R},{cp.G},{cp.B}").FirstOrDefault();
            cbBarvaPisma.SelectedItem = GH.Barvy.
                Where(q => GetRGB(q) == $"{cl.R},{cl.G},{cl.B}").FirstOrDefault();

            cbBarvaPozadi.SelectionChanged += CbBarvaPozadi_SelectionChanged;
            cbBarvaPisma.SelectionChanged += CbBarvaPisma_SelectionChanged;

            string font = mw.lblVerse.FontFamily.FamilyNames.ElementAt(0).Value;
            int index_sel = 0;
            int index = 0;
            foreach (var ci in cbFont.Items)
            {
                string s = ci.ToString();
                if (s.Contains(font))
                {
                    index_sel = index;
                    break;
                }
                index++;
            }
            cbFont.SelectedIndex = index_sel;
            cbFont.SelectionChanged += CbFont_SelectionChanged;
        }

        string GetRGB(PropertyInfo pi)
        {
            Color ccc = (Color)ColorConverter.ConvertFromString(pi.Name);
            string ret = $"{ccc.R},{ccc.G},{ccc.B}";
            return ret;
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void SliderPruhlednost_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            byte alpha = GH.AlphaByte(Convert.ToInt32(sliderPruhlednost.Value));
            SolidColorBrush scb = (SolidColorBrush)mw.bbb.Background;
            Color c = scb.Color;
            c.A = alpha;
            mw.bbb.Background = new SolidColorBrush(c);
            mw.SaveSettings();
        }

        private void SliderMaxWidth_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mw.bbb.MaxWidth = sliderMaxWidth.Value;
            mw.SaveSettings();
        }

        private void SliderFontSizeVerse_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mw.lblVerse.FontSize = sliderFontSizeVerse.Value;
            mw.SaveSettings();
        }

        private void SliderFontSizeRef_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            mw.lblRef.FontSize = sliderFontSizeRef.Value;
            mw.SaveSettings();
        }

        private void CbBarvaPozadi_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ppp = (PropertyInfo)cbBarvaPozadi.SelectedItem;
            Color ccc = (Color)ColorConverter.ConvertFromString(ppp.Name);
            ccc.A = (byte)GH.AlphaByte(Convert.ToInt32(sliderPruhlednost.Value));
            mw.bbb.Background = new SolidColorBrush(ccc);
            mw.SaveSettings();
        }

        private void CbBarvaPisma_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var ppp = (PropertyInfo)cbBarvaPisma.SelectedItem;
            Color ccc = (Color)ColorConverter.ConvertFromString(ppp.Name);
            mw.lblVerse.Foreground = new SolidColorBrush(ccc);
            mw.lblRef.Foreground = new SolidColorBrush(ccc);
            mw.SaveSettings();
        }

        private void CbFont_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string font = cbFont.SelectedValue.ToString();
            mw.lblVerse.FontFamily = new FontFamily(font);
            mw.lblRef.FontFamily = new FontFamily(font);
            mw.SaveSettings();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Hyperlink_RequestNavigate(object sender, System.Windows.Navigation.RequestNavigateEventArgs e)
        {
            Process.Start((sender as Hyperlink).NavigateUri.ToString());
        }
    }
}
