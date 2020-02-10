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
using System.Windows.Shapes;

namespace Kmp
{
    /// <summary>
    /// Логика взаимодействия для SearchWindow.xaml
    /// </summary>
    public partial class SearchWindow : Window
    {
        List<Procedure> id = new List<Procedure>();
        Procedure ed = new Procedure();
        int indexOfChange;

        public SearchWindow(List<Procedure> Procedures)
        {
            id = Procedures;
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            if (rb1.IsChecked == true)
            {
                string code = SearchBy.Text;

                foreach (Procedure proced in id)
                {
                    if (code == proced.code)
                    {
                        SDataGrid.Items.Clear();
                        SDataGrid.Items.Add(proced);
                        indexOfChange = id.IndexOf(proced);
                        ed = proced;
                        break;
                    }
                }
            }
            else 
            {
                foreach (Procedure proc in id)
                {
                    string name = SearchBy.Text;
                    if (name == proc.nameId)
                    {
                        SDataGrid.Items.Clear();
                        SDataGrid.Items.Add(proc);
                        indexOfChange = id.IndexOf(proc);
                        ed = proc;
                        break;
                    }
                }
            }
        }

        private void ChangeDataButton_Click(object sender, RoutedEventArgs e)
        {
            ChangeWindow cw = new ChangeWindow(ed);
            if (cw.ShowDialog() == true)
            {
                ed = cw.returnId();
                id[indexOfChange] = ed;
                SDataGrid.Items.Clear();
                SDataGrid.Items.Add(ed);
                
            }
        }

        public List<Procedure> getProced()
        {
            return id;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
