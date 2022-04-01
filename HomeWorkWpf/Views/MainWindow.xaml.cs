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
using HomeWorkWpf.Models;

namespace HomeWorkWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        RepairShop _repair = new RepairShop();

        public MainWindow()
        {
            InitializeComponent();
            _repair.FillList();  
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            lvMenuTV.ItemsSource = _repair.TvList.Select(t => t.Manyfacturer).Distinct();
            lvMenuDiagonal.ItemsSource = _repair.TvList.Select(d => d.Diagonal).Distinct();
            lvMenuMaster.ItemsSource = _repair.TvList.Select(m => m.Master).Distinct();
            dgTv.ItemsSource = _repair.TvList;
        }
        // начальное формирование
        public void Start_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 0;
            _repair.FillList();
            dgTv.Items.Refresh();
        }
        // выход
        public void Exit_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        #region сортировка
        // сортировка по ТВ
        public void SortTv_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 1;
            dgSort.ItemsSource = _repair.TvList.OrderBy(t => t.Manyfacturer);
        }

        // сортирока по диагонали
        public void SortDiagonal_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 1;
            dgSort.ItemsSource = _repair.TvList.OrderBy(d => d.Diagonal);
        }

        // сортировка по мастеру
        public void SortMaster_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 1;
            dgSort.ItemsSource = _repair.TvList.OrderBy(m => m.Master);
        }

        // сортировка по владельцу
        public void SortOwner_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 1;
            dgSort.ItemsSource = _repair.TvList.OrderBy(o => o.Owner);
        }
        #endregion

        // выборка по ТВ
        public void Tv_SelectionChanged(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 2; 
            dgChoice.ItemsSource = _repair.TeleList(lvMenuTV.SelectedItem.ToString()); 
        }
        // выборка по мастеру
        public void Master_SelectionChanged(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 2;
            dgChoice.ItemsSource = _repair.MasterList(lvMenuMaster.SelectedItem.ToString());
        }
        // выборка по диагонали
        public void Diagonal_SelectionChanged(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 2;
            dgChoice.ItemsSource = _repair.DiagonalList((int)lvMenuDiagonal.SelectedItem);
        }
        // выборка по минимальной цене
        public void TvPriceMin_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 2;
            dgChoice.ItemsSource = _repair.MinPriseList();
        }
        // редактировать
        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            tbConrol.SelectedIndex = 0;
            dgTv.IsReadOnly = false;
        }

        // отмена редактирования
        public void EndEdit_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if ((int)e.Row.GetIndex() < dgTv.Items.Count - 2)
            { 
                dgTv.ItemsSource = null;
                dgTv.ItemsSource = _repair.TvList;
                dgTv.IsReadOnly = true;
            }
            else
            {
                _repair.TvList.Add((Television)dgTv.SelectedItem);
                dgTv.ItemsSource = null;
                dgTv.ItemsSource = _repair.TvList;
                dgTv.IsReadOnly = true;
            }
        }

        //
        public void Del_Click(object sender, RoutedEventArgs e)
        {
            if (dgTv.SelectedIndex < 0) return;
            _repair.TvList.RemoveAt(dgTv.SelectedIndex);
            dgTv.ItemsSource = null;
            dgTv.ItemsSource = _repair.TvList;
        } 
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            AddWindow addWindow = new AddWindow();
            addWindow.ShowDialog();
            _repair.TvList.Add(addWindow.Tv);
            dgTv.ItemsSource = null;
            dgTv.ItemsSource = _repair.TvList;
        } 
        // информащия
        public void Info_Click(object sender, RoutedEventArgs e)
        {
            InfoWindow info = new InfoWindow();
            info.ShowDialog();
        }
    }
}
