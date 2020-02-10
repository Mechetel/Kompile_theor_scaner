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
    /// Логика взаимодействия для addProcedureWidnow.xaml
    /// </summary>
    public partial class addProcedureWidnow : Window
    {
        Procedure newId;
        public addProcedureWidnow()
        {
            InitializeComponent();
        }
        private void OkButton(object sender, RoutedEventArgs e)
        {
            if (nameBox.Text != "" & TypeBox.Text != "" & ValueBox.Text != "")
            {
                newId = new Procedure(nameBox.Text, TypeBox.Text, ValueBox.Text);
                this.DialogResult = true;
            }
           // newId = new Procedure(nameBox.Text, ValueBox.Text, TypeBox.Text, LaBox.Text);
            
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public Procedure getId()
        {
            return newId;
        }

    }
}
