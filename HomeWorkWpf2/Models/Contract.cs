using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkWpf2.Models
{
    [DataContract]
    internal class Contract
    { 
        [DataMember]
        // подписчик
        private Subscriber _pipl;

        public Subscriber Pipl
        {
            get { return _pipl; }
            set {
                if (value == null)
                    throw new Exception("не указан подписчик");
                _pipl = value; }
        }
        [DataMember]
        // издание
        private Publication _pub;

        public Publication Pub 
        {
            get { return _pub; }
            set {
                if (value == null)
                    throw new Exception("нет издания");
                _pub = value; }
        }
        [DataMember]
        // дата подписки
        private DateTime _dateStart;

        public DateTime DateStart
        {
            get { return _dateStart; }
            set { _dateStart = value; }
        }
        [DataMember]
        // срок подписки
        private int _period;

        public int Period
        {
            get { return _period; }
            set
            {
                if (value == 3 || value == 1 || value == 6 || value == 12)
                    _period = value;
                else
                    throw new Exception("подписка возможна только на 1, 3, 6 или 12 месяцев");
            }
        }

        public Contract(Subscriber pipl, Publication pub, DateTime dateStart, int period)
        {
            Pipl = pipl;
            Pub = pub;
            DateStart = dateStart;
            Period = period; 
        } 
    }
}
