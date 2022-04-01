using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 

namespace HomeWorkWpf.Models
{
    public class Television
    {
        // производитель
        private string _manyfacturer;

        public string Manyfacturer
        {
            get => _manyfacturer;
            set {
                if (string.IsNullOrEmpty(value)) throw new Exception("Нет названия");
                _manyfacturer = value;
            }
        }
        // диагональ экрана
        private int _diagonal;

        public int Diagonal
        {
            get => _diagonal;
            set
            {
                if (value < 20) throw new Exception("Не коректная диагональ");
                _diagonal = value;
            }
        }
        // неисправность
        private string _defect;

        public string Defect
        {
            get => _defect;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Не указана диагональ");
                _defect = value;
            }
        }
        // мастер
        private string _master;

        public string Master
        {
            get => _master;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Не указан мастер");
            }
        }
        // владелец ТВ
        private string _owner;

        public string Owner
        {
            get => _owner;
            set
            {
                if (string.IsNullOrEmpty(value)) throw new Exception("Не указан владелец");
            }
        }
        // стоимость ремонта
        private int _price;

        public int Price
        {
            get => _price;
            set
            {
                if (value < 1) throw new Exception("Нет цены");
                    _price = value;
            }
        }

        // конструктор
        public Television
            (string manyfacturer, int diagonal, string defect,
             string master, string owner, int price)
        {
            // _id = id;
            _manyfacturer = manyfacturer;
            _diagonal = diagonal;
            _defect = defect;
            _master = master;
            _owner = owner;
            _price = price;
        }
        public Television() { }

        // создает экземпляр Television
        static public Television CreateTv()
        {
            string[] strName =
            { "Иванов", "Петров", "Сидоров", "Деревянко", "Проценко",
          "Игнатов", "Уваров", "Демин", "Ефремов", "Лабузов", "Карась",
          "Лавров", "Лазарев", "Нефедов", "Колытяк", "Метунов"
        };
            string[] strInitials =
            { "А.А.", "У.В.", "Е.Е.", "Д.Ф.", "В.А.",
          "К.О.", "О.Л.", "О.О", "Д.Д", "Р.У", "С.С.",
          "М.М.", "С.У.", "Л.Д.", "Р.Р.", "М.А"
        };
            string[] strTv =
            {
            "LG LED", "JVC LCD", "SONY PDP", "BQ LED", "POLAR LCD", "BBK LED",
            "PRESTIGIO LCD", "PHILIPS LED", "SAMSUNG LED", "KIVI LED", "ARTEL PDP",
            "LG LCD", "PHILIPS LCD", "SONY LED", "SAMSUNG LCD"
        };
            string[] strDiagonal =
            {
            "43", "50", "32", "40", "55"
        };
            string[] strDefect =
            {
            "полосы на экране", "телевизор не включается", "телевизор не показывает",
            "телевизор не ловит каналы", "показывает каналы с помехами", "нет звука"
        };
            string[] strPrice =
            {
            "300", "4500", "7000", "4000", "600", "500"
        };
            int price = Utils.GetRand(0, strDefect.Length - 1);
            int master = Utils.GetRand(0, 5);
            return new Television(
                    strTv[Utils.GetRand(0, strTv.Length - 1)],
                    Convert.ToInt32(strDiagonal[Utils.GetRand(0, strDiagonal.Length - 1)]),
                    strDefect[price],
                    strName[master] + " " + strInitials[master],
                    strName[Utils.GetRand(6, strName.Length - 1)] + " " + strInitials[Utils.GetRand(0, strInitials.Length - 1)],
                    Convert.ToInt32(strPrice[price])
                    );
        }
        public override string ToString()
        {
            return $"{_manyfacturer,-20}  {_diagonal,-5}  {_defect,-25}  {_master,-10}  {_owner}  {_price}";
        }
    }  
}
