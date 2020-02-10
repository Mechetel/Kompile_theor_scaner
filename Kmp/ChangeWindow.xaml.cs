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
    /// Логика взаимодействия для ChangeWindow.xaml
    /// </summary>
    public partial class ChangeWindow : Window
    {
        Procedure ed = new Procedure();
        public ChangeWindow(Procedure id)
        {

            InitializeComponent();
            nameBox.Text = id.nameId;
            TypeBox.Text = id.type;
            ValueBox.Text = id.value;
            ed = id;
        }

        private void CancelButton(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void OkButton(object sender, RoutedEventArgs e)
        {
            ed.nameId = nameBox.Text;
            ed.type = TypeBox.Text;
            ed.value = ValueBox.Text;
            this.Close();
        }

        public Procedure returnId()
        {
            return ed;
        }
    }
}
