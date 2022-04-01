using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorkWpf2.Models
{
    [DataContract]
    internal class Company
    {
        [DataMember]
        // название компании
        public string NameCompany { get; set; }
        [DataMember]
        // список подписок на издания
        public List<Contract> ListSub { get; set; }

        public Company(string nameCompany = "Почта Донбасса")
        {
            NameCompany = nameCompany;
            ListSub = new List<Contract>();
        }
        // выборка по типу издания
        public List<Contract> ChoiceType(string t) 
            => ListSub.Where(item => item.Pub.TypePub == t).ToList();
        
        // выборка по периоду
        public List<Contract> ChoicePeriod(int p) 
            => ListSub.Where(period => period.Period == p).ToList();

        // выборка по фамилии
        public List<Contract> ChoiceName(string pname)
            => ListSub.Where(name => name.Pipl.Surname == pname).ToList();

        // начальное заполнение
        public void FillCompany()
        {
            ListSub = new List<Contract>{
                new Contract(
                    new Subscriber("Иванов И.И.", "Северная", 12, 5),
                    new Publication("Здоровье", "журнал", 43044),
                    new DateTime(2021, 10, 1), 3),
                new Contract(
                    new Subscriber("Петров П.П.", "Южная", 18),
                    new Publication("Наука и жизнь", "журнал", 43555),
                    new DateTime(2021, 1, 1), 12),
                new Contract(
                    new Subscriber("Марченко М.М", "Южная", 10),
                    new Publication("Наука и жизнь", "журнал", 43555),
                    new DateTime(2021, 5, 23), 1),
                new Contract(
                    new Subscriber("Уваров Ф.А.", "Пирогова", 150, 35),
                    new Publication("Дача", "журнал", 43005),
                    new DateTime(2021, 8, 8), 3),
                new Contract(
                    new Subscriber("Ефремов С.И.", "Комсомольская", 29, 33),
                    new Publication("Правда", "газета", 55233),
                    new DateTime(2021, 11, 3), 6),
                new Contract(
                    new Subscriber("Демин С.А.", "Макеевская", 210, 45),
                    new Publication("Досуг", "газета", 42454),
                    new DateTime(2021, 2, 15), 12),
                new Contract(
                    new Subscriber("Проценко И.И.", "Ватутина", 310, 20),
                    new Publication("Наука и жизнь", "журнал", 43555),
                    new DateTime(2021, 9, 11), 1),
                new Contract(
                    new Subscriber("Перетятько И.С.", "Артема", 8, 10),
                    new Publication("Мурзилка", "журнал", 50033),
                    new DateTime(2021, 7, 7), 3),
                new Contract(
                    new Subscriber("Деревянко В.В.", "Енгельса", 33, 5),
                    new Publication("Правда", "газета", 55233),
                    new DateTime(2021, 11, 15), 6),
                new Contract(
                    new Subscriber("Курзин А.С.", "Финская", 18),
                    new Publication("В мире науки", "журнал", 50005),
                    new DateTime(2021, 3, 12), 1)
            };
        }
         
    }
}
