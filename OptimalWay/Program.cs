using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OptimalWay
{
    class Program
    {
        static void Main(string[] args)
        {
            float totalTime = 48;
            float sleepTime = 16;

            Console.OutputEncoding = Encoding.UTF8;
            List<Showplace> showplaces = GetInfoAboutShowplacesFromTextFile("data.txt");
            CalcOptimalWay(totalTime, sleepTime, showplaces);

            Console.ReadKey();
        }

        static List<Showplace> GetInfoAboutShowplacesFromTextFile(string path = null)
        {
            StreamReader stream = File.OpenText(path);

            List<Showplace> showplaces = new List<Showplace>();
            /*
             * Пропуски линий вызваны форматом документа.
             * После каждого названия достопримечательности и времени на посещение следует два переноса строки
             * После каждого приоритета один перенос строки
             */
            while(!stream.EndOfStream)
            {
                string nameOfShowplace = stream.ReadLine();
                stream.ReadLine();
                stream.ReadLine();
                string timeToVisitShowplaceWithChar = stream.ReadLine();
                stream.ReadLine();
                stream.ReadLine();
                string priorityOfShowplace = stream.ReadLine();
                stream.ReadLine();

                /*
                 * Удаляем символ "ч" и изменяем запятую на точку для float
                 */
                string timeToVisitShowplace = timeToVisitShowplaceWithChar.Replace("ч", String.Empty).Replace(",", ".");
                float finalTimeToVisit = 0;
                float.TryParse(timeToVisitShowplace, out finalTimeToVisit);


                Showplace newShowplace = new Showplace(nameOfShowplace, finalTimeToVisit, Convert.ToInt32(priorityOfShowplace));
               
                showplaces.Add(newShowplace);
            }

            stream.Close();

            return showplaces;
        }

        static void CalcOptimalWay(float totalTime, float sleepTime, List<Showplace> showplaces)
        {
            totalTime -= sleepTime;
            SortShowplacesByPriority(showplaces);

            foreach(Showplace showplace in showplaces)
            {
                if (totalTime - showplace.TimeToVisit < 0)
                    continue;

                totalTime -= showplace.TimeToVisit;
                PrintShowplace(showplace);
                
                if(totalTime <= 0)
                {
                    break;
                }
            }

            Console.WriteLine($"Оставшееся время {totalTime}ч");
        }

        static void SortShowplacesByPriority(List<Showplace> showplaces)
        {
            showplaces.Sort((x, y) => y.Importance.CompareTo(x.Importance));
        }

        static void PrintShowplace(Showplace showplace)
        {
            Console.WriteLine($"{showplace.Name}, {showplace.TimeToVisit}ч, {showplace.Importance}");
        }



    }
}
