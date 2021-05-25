using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosyAISD
{
    public class Graph
    {
        //вложенный класс для скрытия данных и алгоритмов 
        private class Node
        {
            private int[,] array; //матрица смежности    
            //индексатор для обращения к матрице смежности 
            public int this[int i, int j]
            {
                get
                {
                    return array[i, j];
                }
                set
                {
                    array[i, j] = value;
                }
            }
            //свойство для получения числа строк/столбцов //матрицы смежности
            public int Size
            {
                get
                {
                    return array.GetLength(0);
                }
            }
            //вспомогательный массив: если i-ый элемент массива равен 
            //true, то i-ая вершина еще не просмотрена; если i-ый
            //элемент равен false, то i-ая вершина просмотрена 
            private bool[] nov;
            //метод помечает все вершины графа как непросмотреные 
            public void NovSet()
            {
                for (int i = 0; i < Size; i++)
                {
                    nov[i] = true;
                }
            }
            //конструктор вложенного класса, инициализирует матрицу 
            // смежности и вспомогательный массив
            public Node(int[,] a)
            {
                array = a;
                nov = new bool[a.GetLength(0)];
            }
            //реализация алгоритма обхода графа в глубину
            public void Dfs(int v)
            {
                //просматриваем текущую вершину
                Console.Write("{0} ", v);
                nov[v] = false; //помечаем ее как просмотренную 
                // в матрице смежности просматриваем строку с номером v 
                for (int u = 0; u < Size; u++)
                {
                    //если вершины v и u смежные, к тому же вершина u 
                    //не просмотрена,
                    if (array[v, u] != 0 && nov[u])
                    {
                        Dfs(u); // то рекурсивно просматриваем вершину
                    }
                }
            }
            //реализация алгоритма обхода графа в ширину
            public void Bfs(int v)
            {
               
                Queue q = new Queue(); // инициализируем очередь
                q.Enqueue(v); //помещаем вершину v в очередь
                nov[v] = false; // помечаем вершину v как просмотренную
                while (q.Count != 0) // пока очередь не пуста          
                {
                    v = (int) q.Dequeue(); //извлекаем вершину из очереди
                    Console.Write("{0} ", v);
                    //просматриваем ее

                    //находим все вершины
                    for (int u = 0; u < Size; u++)
                    {
                        // смежные с данной и еще не просмотренные 
                        if (array[v,u] != 0 && nov[u])
                        {
                            //помещаем их в очередь
                            q.Enqueue(u);
                            //и помечаем как просмотренные 
                            nov[u] = false;

                        }

                    }

                }

            }

        }
        private Node graph;//закрытое поле, реализующее АТД «граф»

        public Graph(string name) //конструктор внешнего класса
        {
            using (StreamReader file = new StreamReader(name))
            {
                int n = int.Parse(file.ReadLine());
                int[,] a = new int[n, n];
                for (int i = 0; i < n; i++)
                {
                    string line = file.ReadLine();
                    string[] mas = line.Split(' ');
                    for (int j = 0; j < n; j++)
                    {
                        a[i, j] = int.Parse(mas[j]);
                    }
                }           
                graph = new Node(a);
            }
        }
        public void Show()
        {
            for (int i = 0; i < graph.Size; i++)
            {
                for (int j = 0; j < graph.Size; j++)
                {
                    Console.Write("{0,4}", graph[i, j]);
                }
                Console.WriteLine();
            }
        }

        public void Dfs(int v)
        {
            //помечаем все вершины графа как непросмотренные 
            graph.NovSet();
            graph.Dfs(v); //запускаем алгоритм обхода графа в глубину
            Console.WriteLine();
        }

        public void Bfs(int v)
        {
            //помечаем все вершины графа как непросмотренные 
            graph.NovSet();
            graph.Bfs(v); //запускаем алгоритм обхода графа в ширину
            Console.WriteLine();
        }
    }
}