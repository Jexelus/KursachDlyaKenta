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

namespace ForAlbich
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void zad1Res(object sender, RoutedEventArgs e)
        {
            var arr = Zad1TextBox.Text.Split(' ').ToList();
            int OtSumma = 0;
            int maxSumm = -100000;
            List<string> Res = new List<string>();
            List<int> Summs = new List<int>();

            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = i; j < arr.Count; j++)
                {
                    for (int p = i; p <= j; p++)
                    {
                        OtSumma += Convert.ToInt32(arr[p]);
                    }
                    Summs.Add(OtSumma);
                    string mstr = "i: " + i.ToString() + " j: " + j.ToString();
                    Res.Add(mstr);
                    OtSumma = 0;
                }
            }
            
            for (int i = 0; i<Summs.Count; i++)
            {
                if (Summs[i] > maxSumm)
                {
                    maxSumm = Summs[i];
                }
            }
            for (int i = 0; i < Summs.Count; i++)
            {
                if (Summs[i] == maxSumm)
                {
                    Zad1Result.Text = Res[i].ToString();
                }
            }
            
        }

        private void zad2Res(object sender, RoutedEventArgs e)
        {
            var arrA = Zad2TextBoxA.Text.Split(' ').ToList();
            var arrB = Zad2TextBoxB.Text.Split(' ').ToList();
            string temp = "";


            List<int> Result = new List<int>();
            List<string> VRes = new List<string>();

            foreach(var i in arrA)
            {
                foreach(var j in arrB)
                {
                    int p = Convert.ToInt32(i) / (1 + Math.Abs(Convert.ToInt32(j)));
                    Result.Add(p);
                    temp += " " + (Convert.ToInt32(i) / (1 + Math.Abs(Convert.ToInt32(j)))).ToString();        
                }
                temp += "\n";
            }

            MessageBox.Show(temp);
        }
    }
    
}
