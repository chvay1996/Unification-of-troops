using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Unification_of_troops
{
    class Program
    {
        static void Main ( string [] args )
        {
            DataBase dataBase = new DataBase ();
            dataBase.Work ();
        }
    }

    class DataBase
    {
        private List<Soldier> _soldiers = new List<Soldier> ();
        private List<Soldier> _soldiersTwo = new List<Soldier> ();

        public DataBase ()
        {
            _soldiers.Add ( new Soldier ( "Бван", "Lithgow L1A1", "Полковник", 36 ) );
            _soldiers.Add ( new Soldier ( "Роман", "Lithgow L1A1-F1", "Капитан", 22 ) );
            _soldiers.Add ( new Soldier ( "Владимир", "Lithgow L2A1", "Майор", 18 ) );
            _soldiers.Add ( new Soldier ( "Балександр", "Lithgow MCEM", "Генерал майор", 30 ) );
            _soldiers.Add ( new Soldier ( "Блина", "F1 SMG", "Маршал россии", 56 ) );
            _soldiers.Add ( new Soldier ( "Алина", "F1 SMG", "Маршал россии", 56 ) );
            _soldiers.Add ( new Soldier ( "Алина", "F1 SMG", "Маршал россии", 56 ) );
            _soldiers.Add ( new Soldier ( "Блаина", "F1 SMG", "Маршал россии", 56 ) );
            _soldiers.Add ( new Soldier ( "Брлина", "F1 SMG", "Маршал россии", 56 ) );
        }

        public void Work ()
        {
            bool isWork = true;
            string input;

            while ( isWork == true )
            {
                Console.WriteLine ( "1 - показать весь список военных." +
                    "\n2 - Список новых отрядов." +
                    "\n3 - Выход" );
                input = Console.ReadLine ();

                switch ( input )
                {
                    case "1":
                        ShowSoldiersInfo (_soldiers);
                        break;
                    case "2":
                        Works ();
                        break;
                    case "3":
                        isWork = false;
                        break;
                    default:
                        Console.WriteLine ( "Хмммм... Что-то пошло не так!" );
                        break;
                }
                Console.ReadLine ();
                Console.Clear ();
            }
        }

        private void Works ()
        {
            Console.WriteLine ( "==========Общий отряд==========" );
            ShowSoldiersInfo ( _soldiers );
            MoveSelectedSoldiers ();
            Console.WriteLine ( "\n==========Отряд 1==========" );
            ShowSoldiersInfo ( _soldiers );
            Console.WriteLine ( "==========Отряд 2==========" );
            ShowSoldiersInfo ( _soldiersTwo );
        }

        private void MoveSelectedSoldiers ()
        {
            var soldiers = _soldiers.Where ( soldier => soldier.Name.Contains ( "Б" ) );
            _soldiersTwo = _soldiersTwo.Union ( soldiers ).ToList ();
            _soldiers = _soldiers.Except ( soldiers ).ToList ();
        }

        private void ShowSoldiersInfo ( List<Soldier> soldiers )
        {
            foreach ( var soldier in soldiers )
            {
                soldier.ShowInfo ();
            }
        }
    }

    class Soldier
    {
        private string _armament;
        private byte _serviceLife;
        private string _title;

        public Soldier ( string name, string armament, string title, byte serviceLife )
        {
            _armament = armament;
            _serviceLife = serviceLife;
            Name = name;
            _title = title;
        }

        public string Name { get; private set; }

        public void ShowInfo ()
        {
            Console.WriteLine ( $"Солдат {Name} вооружение {_armament} звание {_title} срок службы {_serviceLife}\n" );
        }
    }
}
/*Задача:
Есть 2 списка в солдатами.
Всех бойцов из отряда 1 у которых фамилия начинается на букву Б требуется перевести в отряд 2.*/