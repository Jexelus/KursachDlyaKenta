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
            try
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

                for (int i = 0; i < Summs.Count; i++)
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
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }

        private void zad2Res(object sender, RoutedEventArgs e)
        {
            try 
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
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }

        private void zad3Res(object sender, RoutedEventArgs e)
        {
            try
            {
                var arrM = Zad3TextBoxMain.Text.Split(' ').ToList();
                var arrA = Zad3TextBoxA.Text.Split(' ').ToList();
                var arrB = Zad3TextBoxB.Text.Split(' ').ToList();
                var p = Convert.ToInt32(TextBoxp.Text);
                var q = Convert.ToInt32(TextBoxq.Text);
                string temp = "";
                int z = 0;
                int y = 0;

                for(int i = 0; i < arrB.Count; i++)
                {
                    for (int j = 0; j < arrB.Count; j++)
                    {
                        temp += " " + arrM[y];
                        y++;
                        if (j == q)
                        {
                            temp += " " + arrB[z];
                            z++;
                        }

                    }
                    temp += "\n";
                    if (i+1 == p)
                    {
                        foreach (var item in arrA)
                        {
                            temp += " " + item;
                        }
                        temp += "\n";
                    }
                }


                MessageBox.Show("Если матрица выглядит некорректно проверьте введённые данные" + "\n" + temp);

            }
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }

        private void zad4Res(object sender, RoutedEventArgs e)
        {
            try
            {
                var arrA = Zad4TextBoxA.Text.Split(' ').ToList();
                var m = Convert.ToInt32(Zad4TextBoxM.Text);
                int k = 0;
                List<Double> diag = new List<Double>();
                Double[,] Z = new Double[m, m];
                string temp = "";

                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        Z[i, j] = Convert.ToDouble(arrA[k]);
                        k++;
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        if (i == j)
                        {
                            diag.Add(Z[i, j]);
                        } 
                    }
                }
                for (int i = 0; i < m; i++)
                {
                    for (int j = 0; j < m; j++)
                    {
                        temp += " " + Z[i, j]/diag[j]; 
                    }
                    temp += "\n";
                }
                MessageBox.Show("Если матрица выглядит некорректно проверьте введённые данные" + "\n" + temp);
            }
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }

        static int GetLastStanding(int n, int step)
        {
            var items = Enumerable.Range(0, n)
                            .Select(position => new Item { Position = position }).ToArray();
            var i = 0;
            var stepCounter = 0;
            var nCounter = n;
            while (nCounter > 1)
            {
                if (!items[i].Marked && ++stepCounter == step)
                {
                    stepCounter = 0;
                    items[i].Marked = true;
                    --nCounter;
                    Console.WriteLine(string.Join(", ",
                        items.Select(item => item.Marked ?
                            "_" : (item.Position + 1).ToString())));
                }

                i = (i + 1) % n;
            }
            return items.Single(item => !item.Marked).Position;
        }

        struct Item
        {
            public int Position;
            public bool Marked;
        }


        private void zad5Res(object sender, RoutedEventArgs e)
        {

            try
            {
                int n = Convert.ToInt32(Zad5TextBoxn.Text);
                int m = Convert.ToInt32(Zad5TextBoxm.Text);
                var Res = GetLastStanding(n, m) + 1;
                int mCounter = 2;
                int temp = 0;

                for (int i = 2; i < n; i++)
                {
                    temp = GetLastStanding(n, i);
                    if (temp+1 == 1)
                    {
                        mCounter = i;
                        break;
                    }
                }
            
                MessageBox.Show("Жив остался человек: " + Res.ToString() + "\n m при котором 1 человек останеться жив: " + mCounter.ToString());

            }
            catch
            {
                MessageBox.Show("Некорректно введены данные!");
            }
        }
    }
    
}
