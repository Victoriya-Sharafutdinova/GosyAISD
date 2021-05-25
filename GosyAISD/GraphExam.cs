using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosyAISD
{
    class GraphExam
    {
        //Graph graph = new Graph();

        //public GraphExam()
        //{
        //    Random rand = new Random();
        //    Queue<GraphVertex> q = new Queue<GraphVertex>();    //Это очередь, хранящая номера вершин
        //    string exit = "";
        //    int u;
        //    string[] name = new string[] { "A", "B", "C", "D", "E", "F", "G", };
        //    u = rand.Next(4, 7);
        //    bool[] used = new bool[u + 1];  //массив отмечающий посещённые вершины
        //    int[][] g = new int[u + 1][];   //массив содержащий записи смежных вершин

        //    for (int i = 0; i < u + 1; i++)
        //    {
        //        g[i] = new int[u + 1];
        //        graph.AddVertex(name[i]);
        //        Console.Write("\n({0}) вершина -->[", name[i]);
        //        for (int j = 0; j < u + 1; j++)
        //        {
        //            g[i][j] = rand.Next(0, 2);
        //            if (g[i][j] == 1)
        //                graph.AddEdge(name[i], name[j], g[i][j]);
        //        }
        //        g[i][i] = 0;
        //        foreach (var item in g[i])
        //        {
        //            Console.Write(" {0}", item);
        //        }
        //        Console.Write("]");
        //    }
        //    // ширину




        //    //used[u] = true;     //массив, хранящий состояние вершины(посещали мы её или нет)
        //    GraphVertex vartex = graph.FindVertex(name[rand.Next(1, u)]);
        //    vartex.Flag = true;
        //    q.Enqueue(vartex);
        //    Console.WriteLine("\nНачинаем обход с {0} вершины", vartex.Name);
        //    while (q.Count != 0)
        //    {
        //        vartex = q.Peek();
        //        q.Dequeue();
        //        Console.WriteLine("Перешли к узлу {0}", vartex.Name);

        //        for (int i = 0; i < vartex.Edges.Count; i++)
        //        {
        //            if (Convert.ToBoolean(vartex.Edges[i].EdgeWeight))
        //            {
        //                if (!vartex.Edges[i].ConnectedVertex.Flag)
        //                {
        //                    vartex.Edges[i].ConnectedVertex.Flag = true;
        //                    q.Enqueue(vartex.Edges[i].ConnectedVertex);
        //                    Console.WriteLine("Добавили в очередь узел {0}", vartex.Edges[i].ConnectedVertex.Name);
        //                }
        //            }
        //        }
        //    }
        //}

        //public void BFS(string vName)
        //{
        //    var v0 = graph.FindVertex(vName);
        //    v0.wasVisited = true;
        //    qVertex.Enqueue(v0);
        //    Console.Write(v0.ToString());

        //    var v2 = graph.FindVertex(vName);
        //    while (qVertex.Count > 0)
        //    {
        //        var v1 = qVertex.Dequeue();
        //        while ((v2 = getAdjUnvisitedVertex(v1.Edges)) != null)
        //        {
        //            v2.wasVisited = true;
        //            Console.Write(v2.ToString());
        //            qVertex.Enqueue(v2);
        //        }
        //    }

        //    foreach (GraphVertex v in Vertices) //Обнуляем посещение вершин, чтобы можно было использовать алгоритм повторно
        //        v.wasVisited = false;
        //}

        //public void DFS(string vName)
        //{
        //    var v0 = FindVertex(vName);
        //    v0.wasVisited = true;
        //    sVertex.Push(v0);
        //    Console.Write(v0.ToString());

        //    while (sVertex.Count > 0)
        //    {
        //        var v1 = getAdjUnvisitedVertex(sVertex.Peek().Edges);
        //        if (v1 == null)
        //        {
        //            sVertex.Pop();
        //        }
        //        else
        //        {
        //            v1.wasVisited = true;
        //            Console.Write(v1.ToString());
        //            sVertex.Push(v1);
        //        }
        //    }

        //    foreach (GraphVertex v in Vertices) //Обнуляем посещение вершин, чтобы можно было использовать алгоритм повторно
        //        v.wasVisited = false;
        //}
    }
}
