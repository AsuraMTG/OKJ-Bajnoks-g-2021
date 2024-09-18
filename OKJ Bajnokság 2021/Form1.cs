using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OKJ_Bajnokság_2021
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public string[] csapatSzinek = { "Barna", "Lila", "Narancs", "Kék", "Piros", "Fehér", "Zöld", "Fekete" };
        

        public List<string> fordulok = new List<string>();
        public List<string> meccsek = new List<string>();
        private void Form1_Load(object sender, EventArgs e)
        {
            //0210 1344 4614 5741

            //mérkőzések száma:56 a 12 számú forduló tartalma: 3541 2440 1741 0630

            FileStream folyam = new FileStream("eredmények.txt", FileMode.Open);
            StreamReader olvas = new StreamReader(folyam);

            string resz;

            while (!olvas.EndOfStream)
            {
                resz = olvas.ReadLine();
                if (resz != "")
                {
                    fordulok.Add(resz);
                }
            }

            label1.Text += $"2. feladat: mérkőzések száma: {fordulok.Count * 4} a 12 számú forduló tartalma: {fordulok[12]}\n";


            //3.feladat
            //A csapatoknak válasszon színt, mindegyik csapatnak mást és mást Pl: 5 számú csapat legyen a bordó, a 0 számú csapat legyen a lila.
            //Ekkor a csapat neve: 5bordó, 0lila.
            //Írja ki a 2 számú forduló első találkozójának részvevőit és az eredményt az alábbi formában egy címkébe!

            //0lila - 3kék  0:1

            label1.Text += $"{fordulok[1][0]}{csapatSzinek[Convert.ToInt32(fordulok[1][0].ToString())]}-{fordulok[1][1]}{csapatSzinek[Convert.ToInt32(fordulok[1][2].ToString())]}  {fordulok[1][2]}:{fordulok[1][3]}\n";


            //Olvassa be a fájl tartalmát egy megfelelő adatszerkezetbe. X
            //Írja ki a mérkőzések számát és a 12 számú forduló tartalmát írja ki a form-ra az alábbi formában egy cimkébe.
            //Az első forduló a 0 sorszámú.

            for (int i = 0; i < fordulok.Count * 4; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    if (j % 4 == 0)
                    {
                        meccsek.Add(fordulok[i][j].ToString());
                        meccsek.Add("\n");
                    }
                    else
                    {                         
                        meccsek.Add(fordulok[i][j].ToString());
                    }
                }
            }


            label1.Text += $"{meccsek[7]}";

            //4.	feladat
            //Egy megfelelő adatszerkezetben tárolja a találkozókat egyenként a szöveges fájlnak megfelelő sorrendben!
            //Az adatszerkezet neve legyen meccsek
            //pl: az első találkozó a 0. „0210”
            //Írja ki a 8 -as sorszámú találkozó információit
            //A 8 sorszámú találkozó: 0401




        }
    }
}
