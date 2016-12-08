using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApplication1
{
    class DataComparer : IComparer<List<string>>
    {
        public int Compare(List<string> x, List<string> y)
        {
            return x[1].CompareTo(y[1]);
        }
    }
    class Program
         {
             static void Main(string[] args)
             {
                 bool quit = false;
                 List<List<string>> plList = new List<List<string>>();
                 int row = 0, x = 0;
                 Console.WriteLine("Введите самолёт в формате: {название},{бортовой номер},{количество мест},{дальность полёта}");
                 do
                 {
                     string plane = Console.ReadLine().Trim();
                     if (string.IsNullOrEmpty(plane))
                     {
                        if (plList.Count == 0| x==0)
                        {
                            Console.WriteLine("Вы должны ввести хотя бы 1 самолёт!");
                            continue;
                        }
                        else
                        {
                            quit = true;
                            continue;
                        }
                     }
                     string[] array = plane.Split(',');
                     if (array.Length > 4 | array.Length <4)
                     {
                        Console.WriteLine("Самолёт может содержать только 4 параметра!(каждый параметр отделяется запятой) Повторите ввод.");
                        continue;
                     }
                    for (int i = 0; i < array[2].Length; i++)
                    {
                        
                        if (!char.IsDigit(Convert.ToChar(array[2][i])))
                        {
                            Console.WriteLine("Количество мест и дальность полёта должны быть целыми числами!");
                            goto xxx;
                        }
                    }
                    for (int i = 0; i < array[3].Length; i++)
                    {

                        if (!char.IsDigit(Convert.ToChar(array[3][i])))
                        {
                            Console.WriteLine("Количество мест и дальность полёта должны быть целыми числами!");
                            goto xxx;
                        }
                    }
                //--------------------------------------------------------------------------------------
                plList.Add(new List<string>());
                     for (int i=0; i < array.Length; i++)
                     {
                           plList[row].Add(array[i]);
                           x++;
                     }
                     row++;
                 xxx:;
                 }
                 while (!quit);

                 Console.Clear();
                 Console.WriteLine("Список самолётов:");
                 for (int i=0; i<row; i++)
                 {
                     for (int j=0; j<plList[i].Count; j++)
                     {
                         if (j != plList[i].Count-1)
                             Console.Write(plList[i][j].ToString() + ", ");
                         else
                             Console.Write(plList[i][j].ToString());
                     }
                     Console.WriteLine();
                 }
                Console.WriteLine();

                plList.Sort(new DataComparer());
                Console.WriteLine("Отсортированные в алфавитном порядке по бортовому номеру:");
                for (int i = 0; i < row; i++)
                {
                    for (int j = 0; j < plList[i].Count; j++)
                    {
                        if (j != plList[i].Count - 1)
                            Console.Write(plList[i][j].ToString() + ", ");
                        else
                        { 
                            Console.Write(plList[i][j].ToString());
                            Console.WriteLine();
                        }
                    }
                }
                Console.WriteLine();

                Console.WriteLine("Самолёты с максимальным количеством мест:");
                int maxPl = 0;
                for (int i = 0; i < row; i++)
                    if (maxPl < Convert.ToInt32(plList[i][2].ToString()))
                        maxPl = Convert.ToInt32(plList[i][2].ToString());
                for (int i = 0; i < row; i++)
                {
                    if (maxPl == Convert.ToInt32(plList[i][2].ToString()))
                    {
                        for (int j = 0; j < plList[i].Count; j++)
                        {
                            if (j != plList[i].Count - 1)
                                Console.Write(plList[i][j].ToString() + ", ");
                            else
                            {
                                Console.Write(plList[i][j].ToString());
                                Console.WriteLine();
                            }
                        }                      
                    }
                }
                Console.WriteLine();

                int minRange = Convert.ToInt32(plList[0][3].ToString()), maxRange = 0, srednRange = 0;
                    for (int i = 0; i < row; i++)
                    {
                        if (minRange > Convert.ToInt32(plList[i][3].ToString()))
                            minRange = Convert.ToInt32(plList[i][3].ToString());
                        if (maxRange < Convert.ToInt32(plList[i][3].ToString()))
                            maxRange = Convert.ToInt32(plList[i][3].ToString());
                        srednRange = Convert.ToInt32(plList[i][3].ToString()) + srednRange;
                    }
                srednRange = srednRange / row;
                Console.WriteLine("Минимальная дальность полёта = {0} км\nCредняя дльность полёта = {1} км\nМаксимальная дальность полёта = {2} км", minRange, srednRange, maxRange);
                Console.WriteLine();

                Console.WriteLine("Пассажирские самолёты(больше 20 мест):");
                int pl = 20;
                for (int i = 0; i < row; i++)
                { 
                    if (Convert.ToInt32(plList[i][2].ToString())>=pl)
                        for (int j = 0; j < plList[i].Count; j++)
                        {
                            if (j != plList[i].Count - 1)
                                Console.Write(plList[i][j].ToString() + ", ");
                            else
                            {
                                Console.Write(plList[i][j].ToString());
                                Console.WriteLine();
                            }
                        }
                    
                }
                Console.WriteLine();
                Console.WriteLine("Грузовые самолёты(менее 20 мест):");
                for (int i = 0; i < row; i++)
                {
                    if (Convert.ToInt32(plList[i][2].ToString()) < pl)
                        for (int j = 0; j < plList[i].Count; j++)
                        {
                            if (j != plList[i].Count - 1)
                                Console.Write(plList[i][j].ToString() + ", ");
                            else
                            { 
                                Console.Write(plList[i][j].ToString());
                                Console.WriteLine();
                            }
                        }
                    
                }
                Console.WriteLine();
                Console.WriteLine("Вывод самолётов содержащих в бортовом номере букву.");
                yyy:
                Console.Write("Введите букву:");
                string letter = Console.ReadLine().Trim();
                if (letter.Length >1)
                {
                    Console.WriteLine("Вы ввели больше 1 символа! Повторите ввод.");
                    goto yyy;
                }
                int ii = 0; 
                for (int i = 0; i < row; i++)
                {
                    bool letterCont = plList[i][1].Contains(letter);
                    if (letterCont)
                    {
                        for (int j = 0; j < plList[i].Count; j++)
                        {
                            if (j != plList[i].Count - 1)
                                Console.Write(plList[i][j].ToString() + ", ");
                            else
                            {
                                Console.Write(plList[i][j].ToString());
                                Console.WriteLine();
                                ii++;
                            }
                        }
                        
                    }                    
                }
                if (ii == 0)
                    Console.WriteLine("Таких самолётов не найдено!");
            }
         }
    }
