using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkWpf.Models
{
    internal class RepairShop
    { 
        // коллекция телевизоров
        private List<Television> _tvList;

        public List<Television> TvList
        {
            get => _tvList;
            set => _tvList = value;
        } 
        // название мастерской
        private string _title;

        public string Title
        {
            get => _title;
            set => _title = value;
        } 
        // адресс мастерской
        private string _address;

        public string Address
        {
            get => _address;
            set => _address = value;
        }
        // конструктор
        public RepairShop(string title, string address)
        {
            _tvList = new List<Television>();
            _title = title;
            _address = address;
        }
        public RepairShop()
        {
            _tvList = new List<Television>();
        }

        // начальное заполнение
        public List<Television> FillList()
        {
            _tvList.Clear();
            for (int i = 0; i < 15; i++)
                _tvList.Add(Television.CreateTv());
            return _tvList;
        }
        // находит индекс минимальной цены
        public int MinPriceTv()
        {
            Television minPrice = _tvList[0];
            int index = 0;
            for (int i = 0; i < _tvList.Count; i++)
            {
                if (minPrice.Price > _tvList[i].Price)
                {
                    minPrice = _tvList[i];
                    index = i;
                }
            }
            return index;
        }
        // находит все ТВ с минимальной ценой
        public List<Television> MinPriseList()
        {
            int tvPrice = _tvList[MinPriceTv()].Price;
            return _tvList.FindAll(a => a.Price == tvPrice);
        }
        // выборка по мастеру
        public List<Television> MasterList(string master)
            => _tvList.FindAll(a => a.Master == master);

        // выборка по диагонали
        public List<Television> DiagonalList(int diagonal)
            => _tvList.FindAll(a => a.Diagonal == diagonal);

        // выборка по владельцу
        public List<Television> OwnerList(string owner)
            => _tvList.FindAll(a => a.Owner == owner);
        // выборка по ТВ
        public List<Television> TeleList(string tv)
            => _tvList.FindAll(a => a.Manyfacturer == tv);

        public List<Television> Copy()
        {
            List<Television> temp = new List<Television>();
            temp.AddRange(_tvList);
            return temp;
        }
    }
}
