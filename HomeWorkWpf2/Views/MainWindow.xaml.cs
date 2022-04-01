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

using HomeWorkWpf2.Models;
using Microsoft.Win32;

namespace HomeWorkWpf2.Views
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Company _company = new Company();

        public MainWindow()
        {
            InitializeComponent();
            _company.FillCompany();
        }

        public void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dgBaze.ItemsSource = null;
            dgBaze.ItemsSource = _company.ListSub;
            tbStatus.Text = "все подписки на издания";
            cbType.ItemsSource = lbMenuType.ItemsSource
                = _company.ListSub.Select(t => t.Pub.TypePub).Distinct().ToList();
            cbPeriod.ItemsSource = lbMenuPeriod.ItemsSource
                = _company.ListSub.Select(p => p.Period).Distinct().ToList();
            cbName.ItemsSource = lbMenuName.ItemsSource
                = _company.ListSub.Select(n => n.Pipl.Surname).Distinct().ToList();
        }
        // формирование коллекции
        public void Start_Click(object sender, RoutedEventArgs e)
        {
            _company.FillCompany();
            dgBaze.ItemsSource = _company.ListSub;
        }    

        // выход
        public void Exit_Click(object sender, RoutedEventArgs e)
            => Application.Current.Shutdown();

        // удаление
        public void Delet_Click(object sender, RoutedEventArgs e)
        {
            if (dgBaze.SelectedIndex < 0) return;
            _company.ListSub.RemoveAt(dgBaze.SelectedIndex);
            dgBaze.ItemsSource = null;
            dgBaze.ItemsSource = _company.ListSub;
        }
        // добавить
        public void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditOrAddWindow add = new EditOrAddWindow();
                add.Owner = this;
                add.ShowDialog();
                _company.ListSub.Add(
                    new Contract(
                    new Subscriber(add.tbName.Text, add.tbStreet.Text, int.Parse(add.tbHouse.Text), int.Parse(add.tbFlat.Text)),
                    new Publication(add.tbTitle.Text, add.tbType.Text, int.Parse(add.tbIndex.Text)),
                    DateTime.Parse(add.tbDate.Text), int.Parse(add.tbPeriod.Text)));
                dgBaze.ItemsSource = null;
                dgBaze.ItemsSource = _company.ListSub;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        // редактировать
        public void Edit_Click(object sender, RoutedEventArgs e)
        {
            var clon = dgBaze.SelectedItem as Contract;
            EditOrAddWindow edit = new EditOrAddWindow();
            edit.Owner = this;
            edit.tbName.Text = clon.Pipl.Surname;
            edit.tbStreet.Text = clon.Pipl.Street;
            edit.tbHouse.Text = clon.Pipl.House.ToString();
            edit.tbFlat.Text = clon.Pipl.Flat.ToString();

            edit.tbTitle.Text = clon.Pub.Title;
            edit.tbType.Text = clon.Pub.TypePub;
            edit.tbIndex.Text = clon.Pub.IndexPub.ToString();

            edit.tbDate.Text = clon.DateStart.ToString();
            edit.tbPeriod.Text = clon.Period.ToString();

            edit.ShowDialog();
            try
            {
                clon.Pipl.Surname = edit.tbName.Text;
                clon.Pipl.Street = edit.tbStreet.Text;
                clon.Pipl.House = int.Parse(edit.tbHouse.Text);
                clon.Pipl.Flat = int.Parse(edit.tbFlat.Text);

                clon.Pub.Title = edit.tbTitle.Text;
                clon.Pub.TypePub = edit.tbType.Text;
                clon.Pub.IndexPub = int.Parse(edit.tbIndex.Text);

                clon.DateStart = DateTime.Parse(edit.tbDate.Text);
                clon.Period = int.Parse(edit.tbPeriod.Text);

                dgBaze.Items.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //
        public void FileOpen_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            //openFile.Filter = "(Contract json).json";
            if (openFile.ShowDialog() == true)
            {
                string fileName = openFile.FileName;
                _company.ListSub = Utils.ReadJson<Contract>(fileName);
                dgBaze.ItemsSource = null;
                dgBaze.ItemsSource = _company.ListSub;
            }
        }

        public void FileSave_Click(object sender, RoutedEventArgs e)
        {
            Utils.WriteJson(@"..\..\Contract.json", _company.ListSub);
        }

        #region Сортировка
        // сортировка по индексу
        public void SortIndex_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 1;
            var request = _company.ListSub.OrderBy(i => i.Pub.IndexPub).ToList();
            dgSort.ItemsSource = null;
            dgSort.ItemsSource = request;
            tbStatus.Text = "сортировка по индексу";
        }
        // сортировка по адресу
        public void SortStreet_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 1;
            var request = _company.ListSub.OrderBy(s => s.Pipl.Street).ToList();
            dgSort.ItemsSource = null;
            dgSort.ItemsSource = request;
            tbStatus.Text = "сортировка по адресу";
        }
        // сортировка по периоду
        public void SortPeriod_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 1;
            var request = _company.ListSub.OrderBy(p => p.Period).ToList();
            dgSort.ItemsSource = null;
            dgSort.ItemsSource = request;
            tbStatus.Text = "сортировка по периоду";
        }
        #endregion

        #region выборка из меню
        // выборка по типу издания
        public void ChoiceType_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            dgChoice.ItemsSource = null;
            dgChoice.ItemsSource = _company.ChoiceType(lbMenuType.SelectedItem.ToString());
            tbStatus.Text = "выборка по типу издания";
        }
        // выборка по периоду
        public void ChoicePeriod_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            dgChoice.ItemsSource = null;
            dgChoice.ItemsSource = _company.ChoicePeriod((int)lbMenuPeriod.SelectedItem);
            tbStatus.Text = "выборка по периоду";
        }
        // выборка по фамилии
        public void ChoiceName_Click(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            dgChoice.ItemsSource = null;
            dgChoice.ItemsSource = _company.ChoiceName(lbMenuName.SelectedItem.ToString());
            tbStatus.Text = "выборка по фамилии";
        }
        #endregion

        #region выборка из панели задач
        // выборка из панели задач по типу
        public void CbType_Selected(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            ComboBox combo = (ComboBox)sender; 
            dgChoice.ItemsSource = _company.ChoiceType(combo.SelectedItem.ToString());
        }
        // выборка из панели задач по периоду
        public void CbPeriod_Selected(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            ComboBox combo = (ComboBox)sender;
            dgChoice.ItemsSource = _company.ChoicePeriod((int)combo.SelectedItem);
        }
        // выборка из панели задач по имени
        public void CbName_Selected(object sender, RoutedEventArgs e)
        {
            tbControl.SelectedIndex = 2;
            ComboBox combo = (ComboBox)sender;
            dgChoice.ItemsSource = _company.ChoiceName(combo.SelectedItem.ToString());
        }
        #endregion


    }
} 