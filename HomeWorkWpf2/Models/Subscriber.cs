using System;
using System.Runtime.Serialization;

namespace HomeWorkWpf2.Models
{
    [DataContract]
    internal class Subscriber
    {
        [DataMember]
        // фамилия и инициалы
        private string _surname;

        public string Surname
        {
            get => _surname;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Введите фамилию");
                _surname = value; }
        }
        [DataMember]
        // улица
        private string _street;

        public string Street
        {
            get => _street;
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Введите название улицы"); 
                _street = value; 
            }
        }
        [DataMember]
        // дом
        private int _house;

        public int House
        {
            get => _house;
            set {
                if (value < 1)
                    throw new Exception("Не верный номер дома");
                _house = value; 
            }
        }
        [DataMember]
        // квартира
        private int _flat;

        public int Flat
        {
            get => _flat;
            set { _flat = value; }
        } 

        public Subscriber(string surname, string street, int house, int flat = 0)
        {
            Surname = surname;
            Street = street;
            House = house;
            Flat = flat;
        }
    }
} 