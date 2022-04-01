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
using HomeWorkWpf.Models;

namespace HomeWorkWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для AddWindow.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public Television Tv;

        public AddWindow()
        {
            InitializeComponent();
            Tv = new Television();
        } 

        public void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Tv.Manyfacturer = tbModel.Text;
                Tv.Diagonal = Convert.ToInt32(tbDiagonal.Text);
                Tv.Defect = tbDiagonal.Text;
                Tv.Master = tbMaster.Text;
                Tv.Owner = tbOwner.Text;
                Tv.Price = Convert.ToInt32(tbPrice.Text);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
