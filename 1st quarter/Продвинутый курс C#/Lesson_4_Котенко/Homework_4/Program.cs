using System;
using System.Collections.Generic;
using System.Linq;

//2.Дана коллекция List<T>, требуется подсчитать,
//  сколько раз каждый элемент встречается в данной коллекции:
//    а) для целых чисел;
//    б) *для обобщенной коллекции;
//    в) *используя Linq.
//____________________________________________________________________
//3. *Дан фрагмент программы:
//    Dictionary<string, int> dict = new Dictionary<string, int>()
//    {
//        {"four",4 },
//        {"two",2 },
//        { "one",1 },
//        {"three",3 },
//    };
//    var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
//    foreach (var pair in d)
//        {
//            Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
//        }
//    а) Свернуть обращение к OrderBy с использованием лямбда-выражения $.
//    б) * Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
//________________________________________________________________________
namespace Homework_4
{
    #region Класс User для примера 2В
    /// <summary>
    /// Класс для примера
    /// </summary>
    public class User : IEquatable<User>
    {
        /// <summary>
        /// имя
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Возраст
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// соображалка
        /// </summary>
        public bool DumbAss { get; set; }
        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="isDumbAss"></param>
        public User(string name, int age, bool isDumbAss)
        {
            Name = name;
            Age = age;
            DumbAss = isDumbAss;
        }
        /// <summary>
        /// Сравнения для интерфейса IEquatable
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(User other)
        {
            return this.Name == other.Name &&
                    this.Age == other.Age &&
                    this.DumbAss == other.DumbAss;
        }
        /// <summary>
        ///  Вывод параметров класса в строку
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string ds = DumbAss == true ? " глупенький" : " соображает";
            return Name + ", " + Age + ", " + ds;
        }

    }
    #endregion
    class Program
    {
        public static Random rnd = new Random();

        static void Main(string[] args)
        {
            Ex2A();
            Ex2B();
            Ex2C();
            Ex3AndB();

            Console.ReadLine();
        }
        #region Решение задачи 2А
        /// <summary>
        /// Решение задачи 2А
        /// </summary>
        /// <param name="lookForNumberCount">Число, колличество которого нужно найти</param>
        public static void Ex2A()
        {
            List<int> listInt = new List<int>();

            for (int i = 0; i < 20; i++)
            {
                listInt.Add(rnd.Next(0, 10));
            }
            Console.WriteLine("Задание 2А");
            Console.WriteLine("Исходная коллекция целых чисел");
            Console.WriteLine("____________________________");
            foreach (var item in listInt)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("____________________________");
            foreach (var item in FindCountOfElements(listInt))
            {
                Console.WriteLine("Число " + item.Key + " встречается " + item.Value + " раз");
            }
            Console.WriteLine("");
            Console.WriteLine("[][][][][][][][][][][][][][][]");
        }
        /// <summary>
        /// Возвращает неотсортированный словарь в котором содержится пара:
        /// элемент и колличество его повторений в заданной коллекции
        /// </summary>
        /// <param name="collection">заданная коллекция</param>
        /// <returns></returns>
        public static Dictionary<int, int> FindCountOfElements(List<int> collection)
        {
            Dictionary<int, int> counter = new Dictionary<int, int>();
            foreach (var item in collection)
            {
                if (!counter.ContainsKey(item))
                {
                    counter.Add(item, FindCountOfElement(collection, item));
                }
            }

            return counter;
        }
        /// <summary>
        /// Возвращает, сколько раз повтаряется заданный элемент в заданной коллекции
        /// </summary>
        /// <param name="collection">заданный элемент</param>
        /// <param name="value">заданная коллекция</param>
        /// <returns></returns>
        public static int FindCountOfElement(List<int> collection, int value)
        {
            var i = 0;
            foreach (var item in collection)
            {
                if (item == value)
                {
                    i++;
                }
            }
            return i;
        }
        #endregion
        #region Решение задачи 2В
        /// <summary>
        /// решение задачи 2В
        /// </summary>
        public static void Ex2B()
        {
            List<User> listUser = new List<User>();


            for (int i = 0; i < 20; i++)
            {
                var tmpAge = rnd.Next(15, 60);


                var tmpBool = rnd.Next(0, 2) == 0 ? false : true;
                ///добавляю возраст к имени намеренно, что бы были совпадения
                listUser.Add(new User("User_" + tmpAge, tmpAge, tmpBool));
            }
            Console.WriteLine("Задание 2B");
            Console.WriteLine("Исходная коллекция юзеров");
            Console.WriteLine("____________________________");
            foreach (var item in listUser)
            {
                Console.WriteLine(item.ToString());
            }
            Console.WriteLine("");
            Console.WriteLine("____________________________");
            foreach (var item in FindCountOfElements(listUser))
            {
                Console.WriteLine("[" + item.Key.ToString() + "]"
                                      + " встречается "
                                      + item.Value
                                      + " раз");
            }
            Console.WriteLine("[][][][][][][][][][][][][][][]");
        }
        /// <summary>
        /// Возвращает, сколько раз повтаряется заданный элемент в заданной коллекции
        /// </summary>
        /// <param name="collection">заданная коллекция</param>
        /// <param name="element">заданный элесент</param>
        /// <returns></returns>
        public static int FindCountOfElement<T>(T element, List<T> collection)
            where T : IEquatable<T>
        {
            var i = 0;
            foreach (var item in collection)
            {
                if (item.Equals(element))
                {
                    i++;
                }
            }
            return i;
        }
        /// <summary>
        /// Возвращает неотсортированный словарь в котором содержится пара:
        /// элемент и колличество его повторений в заданной коллекции
        /// </summary>
        /// <param name="collection">заданная коллекция</param>
        /// <returns></returns>
        public static Dictionary<T, int> FindCountOfElements<T>(List<T> collection)
            where T : IEquatable<T>
        {
            Dictionary<T, int> counter = new Dictionary<T, int>();
            foreach (var item in collection)
            {
                if (!counter.ContainsKey(item))
                {
                    counter.Add(item, FindCountOfElement(item, collection));
                }
            }

            return counter;
        }
        #endregion
        #region Решение задачи 2С


        /// <summary>
        /// Решение задачи 2С
        /// </summary>
        public static void Ex2C()
        {
            List<int> listInt = new List<int>();
            for (int i = 0; i < 20; i++)
            {
                listInt.Add(rnd.Next(0, 10));
            }
            Console.WriteLine("Задание 2C");
            Console.WriteLine("Исходная коллекция целых чисел");
            Console.WriteLine("____________________________");
            foreach (var item in listInt)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("");
            Console.WriteLine("____________________________");

            ///Linq запрос
            var result = listInt.GroupBy(e => e);
            /// 

            foreach (var e in result)
            {
                Console.WriteLine("Число " + e.Key + " встречается " + e.Count() + " раз");
            }
            Console.WriteLine("");
            Console.WriteLine("[][][][][][][][][][][][][][][]");
        }
        #endregion
        #region Решение задачи 3А и 3Б

        
        /// <summary>
        /// Решение задачи 3А и 3Б
        /// </summary>
        public static void Ex3AndB()
        {

            Console.WriteLine("Задание 3А");
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };

            ///3A
            var ex3A = dict.OrderBy(e => e.Value);
            ///3B
            Func<KeyValuePair<string, int>, int> func = GetValue;
            var ex3B = dict.OrderBy(func);

            foreach (var pair in ex3A)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine("[][][][][][][][][][][][][][][][][][][]");
        }
        /// <summary>
        /// Возвращает значение из пары ключ-значение
        /// </summary>
        /// <param name="fromElement">пара</param>
        /// <returns></returns>
        static int GetValue(KeyValuePair<string, int> fromElement)
        {
            return fromElement.Value;
        }
        #endregion

    }
}
    

