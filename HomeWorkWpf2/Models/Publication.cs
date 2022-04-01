using System;
using System.Runtime.Serialization;

namespace HomeWorkWpf2.Models
{
    [DataContract]
    // издание
    internal class Publication
    {
        [DataMember]
        // название издания
        private string _title;

        public string Title
        {
            get { return _title; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Нет названия");
                _title = value; 
            }
        }
        [DataMember]
        // тип издания
        private string _typePub;

        public string TypePub
        {
            get { return _typePub; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("не указан тип издания");
                _typePub = value; 
            }
        }
        [DataMember]
        // индекс издания
        private int _indexPub;

        public int IndexPub
        {
            get { return _indexPub; }
            set {
                if (value == 0)
                    throw new Exception("не указан индекс");
                _indexPub = value; }
        }

        public Publication(string title, string typePub, int indexPub)
        {
            Title = title;
            TypePub = typePub;
            IndexPub = indexPub;
        } 
    }
}
