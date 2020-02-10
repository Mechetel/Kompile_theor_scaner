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
using Microsoft.Win32;
using System.IO;

namespace Kmp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Procedure> Procedures = new List<Procedure>();
        List<string> Service = new List<string>{"private", "public"};
        List<string> service1 = new List<string> { "for", "while", "foreach", "return", "if" };
        string tcode;

        string line;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddProcedure(object sender, RoutedEventArgs e)
        {
            addProcedureWidnow addProcedureWidnow = new addProcedureWidnow();
            if (addProcedureWidnow.ShowDialog() == true)
            {
                Procedure id = addProcedureWidnow.getId();
                if (ProcedureAdd(id) == true)
                    ClearAndOut();
            }
        }


        public bool ProcedureAdd(Procedure id)
        {
            bool addition = true;
            foreach(Procedure a in Procedures)
                if (id.nameId == a.nameId)
                {
                    addition = false;
                    break;
                }

            if (addition != false)
            {
                //place
                int i = id.nameId.Length - 1;
                int place = 0;
                while (i != 0)
                {
                    char p = id.nameId[i];
                    place += (int)p;
                    i--;
                }
                place %= 100;

                //get right place

                while (true)
                {
                    bool fine = true;
                    foreach (Procedure proced in Procedures)
                        if (proced.codeN == place)
                        {
                            fine = false;
                            place++;
                            break;
                        }

                    if (fine == true)
                    {
                        id.codeN = place;
                        break;
                    }
                }

                id.code = "x" + place;

                //add
                int count = Procedures.Count();
                int newIndex = 0;

                if (count > 0)
                {
                    bool lastPlace = true;
                    foreach (Procedure proced in Procedures)
                        if (proced.codeN > place)
                        {
                            newIndex = Procedures.IndexOf(proced);
                            lastPlace = false;
                            break;
                        }



                    if (lastPlace == false)
                    {
                        Procedure newId = new Procedure();
                        Procedures.Add(newId);
                        int last = count - 1;

                        while (newIndex <= last)
                        {
                            Procedures[last + 1] = Procedures[last];
                            last--;
                        }
                        Procedures[newIndex] = id;
                    }
                    else
                        Procedures.Add(id);
                }
                else
                    Procedures.Add(id);
            }
            return addition;
        }

        public void ClearAndOut()
        {
            IdDataGrid.Items.Clear();
            foreach(Procedure proced in Procedures)
                IdDataGrid.Items.Add(proced);
        }

        private void FindClick(object sender, RoutedEventArgs e)
        {
            SearchWindow sw = new SearchWindow( Procedures);
            if(sw.ShowDialog() == true)
            {
                Procedures = sw.getProced();
                ClearAndOut();
            }
        }

        private void LoadFromFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                string line;
                string[] ar;
                while (!sr.EndOfStream)
                {
                    line = sr.ReadLine();
                    ar = line.Split(' ');
                  
                    Procedure id = new Procedure(ar[0], ar[1], ar[2]);
                    if (ProcedureAdd(id) == true)
                        ClearAndOut();
                }
            }
        }

        private void LoadCodeFileClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                CodeList.Text = " ";
                StreamReader sr = new StreamReader(openFileDialog.FileName);
                line = "";
                while (!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();
                    if (temp == "")
                    {
                        line += temp + "\n";
                        CodeList.Text += temp;
                        CodeList.Text += " \n ";
                    }
                        else if(temp.First() != '#')
                        {
                            line += temp + "\n";
                            CodeList.Text += temp;
                            CodeList.Text += " \n ";
                        }
                    
                }
            }
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            char[] splitArr = line.ToArray();

            int textSize = splitArr.Length;
            char[] codeArr = new char[textSize+20];
            int i = 0, j = 0, ti = 0;

            while(i < textSize)
            {
                if(splitArr[i] == '"')
                {
                    i++;
                    while(splitArr[i] != '"')
                        i++;
                    i++;
                }

                if(splitArr[i] == '(')
                {
                    //word
                    int k = i - 1;
                    string word = "";
                    while (splitArr[k] != ' ')
                    {
                        word += splitArr[k];
                        k--;
                    }
                    word = new string(word.ToCharArray().Reverse().ToArray());
                    int tk = k + 1;
                    int tl = i;
                    bool fine = IsFine(word);

                    //type
                    if (fine)
                    {
                        bool added = false;
                        foreach(Procedure proc in Procedures)
                        {
                            if(proc.nameId == word)
                            {
                                added = true;
                                tcode = proc.code;
                                break;
                            }
                        }

                        if (!added)
                        {
                            k--;

                            string type = "";
                            string preType = "";
                            while (char.IsLetter(splitArr[k]))
                            {

                                type += splitArr[k];
                                k--;
                                if (k < 0) { break; }
                            }
                            type = new string(type.ToCharArray().Reverse().ToArray());

                            bool fType = IsFine(type);

                            //pretype
                            if (fType)
                            {
                                k--;
                                string ptype = "";
                                if (k > 0)
                                {
                                    while (char.IsLetter(splitArr[k]))
                                    {
                                        ptype += splitArr[k];
                                        k--;
                                        if (k < 0) { break; }
                                    }
                                    ptype = new string(ptype.ToCharArray().Reverse().ToArray());

                                    bool fptype = IsFine(ptype);

                                    if (fptype)
                                    {
                                        fptype = false;
                                        foreach (string s in Service)
                                            if (s == ptype)
                                            {
                                                fptype = true;
                                                break;
                                            }
                                        if (fptype) { preType = ptype; }
                                    }
                                }

                                i++;
                                string value = "(";
                                while (splitArr[i] != ')')
                                {
                                    value += splitArr[i];
                                    i++;
                                }
                                value += ")";
                                Procedure proc = new Procedure(word, preType + " " + type, value);
                                ProcedureAdd(proc);

                                int p;
                                for (p = j; ti < tk; p++, ti++)
                                    codeArr[p] = splitArr[ti];

                                j = p;
                                foreach (char ch in proc.code)
                                {
                                    codeArr[j] = ch;
                                    j++;
                                }
                                ti = tl;
                            }
                        }
                        else
                        {
                            int p;
                            for (p = j; ti < tk; p++, ti++)
                                codeArr[p] = splitArr[ti];

                            j = p;
                            
                            foreach (char ch in tcode)
                            {
                                codeArr[j] = ch;
                                j++;
                            }
                            ti = tl;
                        }
                    }
                }
                i++;
            }

            while (ti < splitArr.Length)
            {
                codeArr[j] = splitArr[ti];
                ti++;
                j++;
            }

            char[] c = new char[j];
            for (int m = 0; m < j; m++)
                c[m] = codeArr[m];

            string code = new string(c);

            Code1List.Text = code;

            ClearAndOut();
        }

        bool IsFine(string word)
        {
            bool fine = true;

            foreach (char c in word)
                if (!char.IsLetter(c))
                    fine = false;

            foreach (string s in service1)
                if (s == word)
                    fine = false;


            return fine;
        }
    }
}

