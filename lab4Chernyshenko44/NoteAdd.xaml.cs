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

namespace lab4Chernyshenko44
{
    /// <summary>
    /// </summary>
    public partial class NoteAdd : Window
    {
        public NoteAdd()
        {
            InitializeComponent();
        }
        public int FName
        {
            get
            {
                return int.Parse(tbFName.Text);
            }
            set
            {
                tbFName.Text = value.ToString();
            }
        }
        public string? LName
        {
            get
            {
                return tbLName.Text;
            }
            set
            {
                tbLName.Text = value;
            }
        }
        public int Number
        {
            get
            {
                return int.Parse(tbPhone.Text);
            }
            set
            {
                tbPhone.Text = value.ToString();
            }
        }
        public int Birth
        {
            get
            {
                return int.Parse(tbBirth.Text);
            }
            set
            {
                tbBirth.Text = value.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

