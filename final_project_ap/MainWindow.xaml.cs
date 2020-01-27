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

namespace final_project_ap
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Clock clock;
        public List<string> shomare_query = new List<string>();
     public List<information> information_1 = new List<information>();
        public MainWindow()
        {
            InitializeComponent();
            clock = new Clock(LeftCanvas, ClockDayLabel, SecondCounter, MinuteCounter, MinutePointer, HourCounter, HourPointer);
            clock.Run();
        }

        private void click_query(object sender, RoutedEventArgs e)
        {
            safe.Text = "";
            List<string> infor = new List<string>();
            List<int> index = new List<int>();
            if (shomare_query.Contains("check_1"))
            {
                float num =float.Parse(query_sen_bala.Text);
                IEnumerable<string> res = information_1.Where(x => x.sen > num).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);

            }
            if (shomare_query.Contains("check_2"))
            {
                float num = float.Parse(query_sen_paeen.Text);
                IEnumerable<string> res = information_1.Where(x => x.sen < num).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);
            }
            if (shomare_query.Contains("check_3"))
            {
                int sen = 2020 - int.Parse(query_sal_tavalod.Text);
                IEnumerable<string> res = information_1.Where(x => x.sen == sen).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);

            }
            if (shomare_query.Contains("check_4"))
            {
                string name = query_esm.Text;
                IEnumerable<string> res = information_1.Where(x => string.Equals(x.esm, name)).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);
            }
            if (shomare_query.Contains("check_5"))
            {
                string moadele = query_moadele_koli.Text;
                IEnumerable<string> res = information_1.Where(x => string.Equals(x.moadele_1, moadele) || string.Equals(x.moadele_2, moadele)).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);
            }
            if (shomare_query.Contains("check_6"))
            {
                double javab_x =double.Parse( query_x.Text);
                double javab_y =double.Parse( query_y.Text);
                IEnumerable<string> res = information_1.Where(x => x.x == javab_x && x.y == javab_y).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);
            }
            if (shomare_query.Contains("check_7"))
            {
                string city = query_shahr.Text;
                IEnumerable<string> res = information_1.Where(x => string.Equals(x.shahr, city)).Select(x => x.esm + " " + x.family);
                foreach (string str in res)
                    infor.Add(str);
            }
            for(int i = 0; i < infor.Count; i++)
            {
                string str = infor[i];
                for(int j = i + 1; j < infor.Count; j++)
                {
                    if (str.Equals(infor[j]))
                        index.Add(j);
                }
            }
            if (shomare_query.Count == 1)
            {
                for(int i = 0; i < infor.Count; i++)
                {
                    safe.Text += infor[i];
                    safe.Text += Environment.NewLine;
                }
            }
            else
            {
                for(int i=0;i<index.Count;i++)
                {
                    safe.Text += infor[index[i]];
                    safe.Text += Environment.NewLine;
                }
            }


            shomare_query = new List<string>();
        }

        private void click_save(object sender, RoutedEventArgs e)
        {
            var sen = 0;
            var moadele_1 = "";
            var moadele_2 = "";
            var equ = new List<int>();
            var data = safe.Text;
            var harf = new List<char>();
            var input = new List<string>();
            var moteghayer = new List<char>();
            var array = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < array.Length; i++)
                input.Add(array[i]);
            for(int i = 3; i < input.Count; i++)
            {
                var str = input[i];
                if (information.num(str))
                    sen = int.Parse(str);
                if((str.Contains("+") && str.Contains("=")) || (str.Contains("-") && str.Contains("=")))
                {
                    for (int k = 0; k < str.Length; k++)
                    {
                        if (str[k] == 'a' || str[k] == 'b' || str[k] == 'b' || str[k] == 'c' || str[k] == 'd' || str[k] == 'e' ||
                            str[k] == 'f' || str[k] == 'g' || str[k] == 'h' || str[k] == 'i' || str[k] == 'j' || str[k] == 'k' ||
                            str[k] == 'l' || str[k] == 'm' || str[k] == 'n' || str[k] == 'o' || str[k] == 'p' || str[k] == 'q' || str[k] == 'w' ||
                            str[k] == 'r' || str[k] == 't' || str[k] == 'y' || str[k] == 'u' || str[k] == 'z' || str[k] == 'x' || str[k] == 'v'
                            )
                            moteghayer.Add(str[k]);
                    }
                    string zarib2 = "";
                    string[] zaribaval = str.Split(moteghayer[0]);
                    string[] zaribdovom = zaribaval[1].Split(moteghayer[1]);
                    string[] adad_sabet = str.Split('=');
                    for (int y = 0; y < zaribdovom[0].Length; y++)
                    {
                        zarib2 += zaribdovom[0][y];
                    }
                    if (zaribaval[0] == "")
                    {
                        zaribaval[0] = "1";
                    }
                    if (zarib2 == "")
                    {
                        zarib2 = "1";
                    }
                    if (equ.Count == 0)
                    {
                        equ.Add(int.Parse(zaribaval[0]));
                        equ.Add(int.Parse(zarib2));
                        equ.Add(int.Parse(adad_sabet[1]));
                        harf.Add(moteghayer[0]);
                        harf.Add(moteghayer[1]);
                        moadele_1 = str;
                    }
                    else
                    {
                        if(harf[0]==moteghayer[0] && harf[1] == moteghayer[1])
                        {
                            equ.Add(int.Parse(zaribaval[0]));
                            equ.Add(int.Parse(zarib2));
                            equ.Add(int.Parse(adad_sabet[1]));
                            moadele_2 = str;
                        }
                    }
                }
                if (equ.Count == 6)
                    break;
               
            }
            moadele moadele = new moadele(equ[0], equ[1], equ[2], equ[3], equ[4], equ[5]);
            moadele.cal();
            int check = 0;
            for(int i = 0; i < information_1.Count; i++)
            {
                if (information_1[i].esm == input[0] && information_1[i].family == input[1] && information_1[i].sen == sen &&
                    information_1[i].shahr == input[2] && information_1[i].x == moadele.res_1 && information_1[i].y ==
                    moadele.res_2)
                {
                    check = 1;
                    break;
                }
                else
                    check = 0;
                      }
            if(check==0)
                information_1.Add(new information(input[0], input[1], sen, input[2], moadele.res_1, moadele.res_2, moadele_1, moadele_2));

            if (information_1.Count == 0)
                information_1.Add(new information(input[0], input[1], sen, input[2], moadele.res_1, moadele.res_2, moadele_1, moadele_2));
        }

        private void click_new(object sender, RoutedEventArgs e)
        {
            safe.Clear();
        }

        private void Checkbox_Checked(object sender, RoutedEventArgs e)
        {
            shomare_query.Add(((CheckBox)sender).Name);
        }
    }
}
