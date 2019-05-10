using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Media;

namespace DesktopBibleVerse
{
    public static class GH
    {
        public static byte ParseHexValue(string ch)
        {
            switch (ch)
            {
                case "00":
                    return 0;
                case "11":
                    return 1;
                case "22":
                    return 2;
                case "33":
                    return 3;
                case "44":
                    return 4;
                case "55":
                    return 5;
                case "66":
                    return 6;
                case "77":
                    return 7;
                case "88":
                    return 8;
                case "99":
                    return 9;
                case "AA":
                    return 10;
                case "BB":
                    return 11;
                case "CC":
                    return 12;
                case "DD":
                    return 13;
                case "EE":
                    return 14;
                case "FF":
                    return 15;
                default:
                    return 0;
            }
        }

        public static string HexLetter(int val)
        {
            switch (val)
            {
                case 0:
                    return "00";
                case 1:
                    return "11";
                case 2:
                    return "22";
                case 3:
                    return "33";
                case 4:
                    return "44";
                case 5:
                    return "55";
                case 6:
                    return "66";
                case 7:
                    return "77";
                case 8:
                    return "88";
                case 9:
                    return "99";
                case 10:
                    return "AA";
                case 11:
                    return "BB";
                case 12:
                    return "CC";
                case 13:
                    return "DD";
                case 14:
                    return "EE";
                case 15:
                    return "FF";
                default:
                    return "";
            }
        }

        public static byte AlphaByte(int val)
        {
            switch (val)
            {
                case 0:
                    return 0;
                case 1:
                    return 17;
                case 2:
                    return 34;
                case 3:
                    return 51;
                case 4:
                    return 68;
                case 5:
                    return 85;
                case 6:
                    return 102;
                case 7:
                    return 119;
                case 8:
                    return 136;
                case 9:
                    return 153;
                case 10:
                    return 170;
                case 11:
                    return 187;
                case 12:
                    return 204;
                case 13:
                    return 221;
                case 14:
                    return 238;
                case 15:
                    return 255;
                default:
                    return 0;
            }
        }

        public static PropertyInfo[] Barvy
        {
            get
            {
                var aaa = typeof(System.Windows.Media.Colors).GetProperties();
                var q = from PropertyInfo ppp in aaa
                        where
                            ppp.ToString() == "System.Windows.Media.Color Maroon" ||
                            ppp.ToString() == "System.Windows.Media.Color Chocolate" ||
                            ppp.ToString() == "System.Windows.Media.Color Crimson" ||
                            ppp.ToString() == "System.Windows.Media.Color DarkGreen" ||
                            ppp.ToString() == "System.Windows.Media.Color RoyalBlue" ||
                            ppp.ToString() == "System.Windows.Media.Color Sienna" ||
                            ppp.ToString() == "System.Windows.Media.Color MidnightBlue" ||
                            ppp.ToString() == "System.Windows.Media.Color Olive" ||
                            ppp.ToString() == "System.Windows.Media.Color Purple" ||
                            ppp.ToString() == "System.Windows.Media.Color Black" ||
                            ppp.ToString() == "System.Windows.Media.Color Teal" ||
                            ppp.ToString() == "System.Windows.Media.Color White"
                        select ppp;
                return q.ToArray();
            }
        }

        public static List<Verse> ReadVerses(string file)
        {
            List<Verse> lv = new List<Verse>();
            string[] radky = file.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string r in radky)
            {
                string[] a = r.Split(new string[] { "\t" }, StringSplitOptions.RemoveEmptyEntries);
                if (a.Length > 1)
                {
                    Verse v = new Verse(a[0], a[1]);
                    lv.Add(v);
                }
            }
            return lv;
        }
    }

    public class Verse
    {
        public string Text { get; set; }
        public string Ref { get; set; }

        public Verse(string text, string reff)
        {
            Text = text;
            Ref = reff;
        }
    }
}