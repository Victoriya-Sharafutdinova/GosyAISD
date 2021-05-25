using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosyAISD
{
    class Program
    {
        //Quick Sort (Быстрая сортировка). Один из быстрых известных универсальных алгоритмов сортировки массивов. Суть алгоритма:
        // из массива выбирается элемент.Как правило, в качестве этого элемента берется центральный элемент массива. 
        //остальные элементы распределяются таким образом, чтобы слева  оказались все элементы, меньшие или равные опорному элементу.Элементы, большие или равные опорному элементу, помещаются справа. 

        static void Sort(int[] arr, int l, int r)
        {
            //i и j нужны для цикла
            int i = l;
            int j = r;
            int x = arr[(l + r) / 2]; //Опорная
            //Цикл сортировка
            while (i <= j)
            {
                //Деление на меньше и больше опорного
                while (arr[i] < x) i++;
                while (arr[j] > x) j--;
                //Если i<=j:
                if (i <= j)
                {
                    //меняем значение элемонтов
                    int temp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = temp;
                    i++;
                    j--;
                }
            }
            //Рекурсия
            if (l < j) Sort(arr, l, j);
            if (i < r) Sort(arr, i, r);
        }

        //Сортировка слиянием (Merge sort) – алгоритм сортировки массива, который реализован по принципу “разделяй и властвуй”. 
        //Задача сортировки массива разбивается на несколько подзадач сортировки массивов меньшего размера, после выполнения которых, результат комбинируется, что и приводит к решению начальной задачи.

        //Входной массив разбивается на две части одинакового размера;
        //Каждый из подмассивов сортируется отдельно, по этому же принципу, тоесть производится повторное разбитие до тех пор, пока длина подмассива не достигнет единицы.В таком случае каждый единичный массив считается отсортированным;
        //После этого осуществляется слияние всех подмассивов в один, в результате чего получаем отсортированные данные.

        //метод для слияния массивов
        static void Merge(int[] array, int lowIndex, int middleIndex, int highIndex)
        {
            var left = lowIndex;
            var right = middleIndex + 1;
            var tempArray = new int[highIndex - lowIndex + 1];
            var index = 0;

            while ((left <= middleIndex) && (right <= highIndex))
            {
                if (array[left] < array[right])
                {
                    tempArray[index] = array[left];
                    left++;
                }
                else
                {
                    tempArray[index] = array[right];
                    right++;
                }

                index++;
            }

            for (var i = left; i <= middleIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = right; i <= highIndex; i++)
            {
                tempArray[index] = array[i];
                index++;
            }

            for (var i = 0; i < tempArray.Length; i++)
            {
                array[lowIndex + i] = tempArray[i];
            }
        }

        //сортировка слиянием
        static int[] MergeSort(int[] array, int lowIndex, int highIndex)
        {
            if (lowIndex < highIndex)
            {
                var middleIndex = (lowIndex + highIndex) / 2;
                MergeSort(array, lowIndex, middleIndex);
                MergeSort(array, middleIndex + 1, highIndex);
                Merge(array, lowIndex, middleIndex, highIndex);
            }

            return array;
        }

        static int[] MergeSort(int[] array)
        {
            return MergeSort(array, 0, array.Length - 1);
        }

        //Применение поразрядной сортировки имеет одно ограничение: перед началом сортировки необходимо знать
        //length - максимальное количество разрядов в сортируемых величинах(например, при сортировке слов необходимо знать максимальное количество букв в слове), 
        //range - количество возможных значений одного разряда(при сортировке слов - количество букв в алфавите).
        //Количество проходов равно числу length.
        //
        //Пошаговое описание алгоритма

        //1. Создаем пустые списки, количество которых равно числу range.

        //2. Распределяем исходные числа по этим спискам в зависимости от величины младшего разряда(по возрастанию).

        //Для нашего примера получим:
        //41
        //32
        //54, 34
        //47
        //59, 39

        //(Вообще надо создать 10 списков, но некоторые из них оказались пустыми)

        //3. Собираем числа в той последовательности, в которой они находятся после распределения по спискам.

        //Получим: 41, 32, 54, 34, 47, 59, 39

        //4. Повторяем пункты 2 и 3 для всех более старших разрядов поочередно.

        //Для двузначных чисел мы должны сделать еще один проход.Распределение по спискам будет выглядеть так:
        //32, 34, 39
        //41, 47
        //54, 59
        //Объединив числа в последовательность, получим отсортированный массив.
        //

        public static void sorting(int[] arr, int range, int length)
        {
            ArrayList[] lists = new ArrayList[range];
            for (int i = 0; i < range; ++i)
                lists[i] = new ArrayList();

            for (int step = 0; step < length; ++step)
            {
                //распределение по спискам
                for (int i = 0; i < arr.Length; ++i)
                {
                    int temp = (arr[i] % (int)Math.Pow(range, step + 1)) /
                    (int)Math.Pow(range, step);
                    lists[temp].Add(arr[i]);
                }
                //сборка
                int k = 0;
                for (int i = 0; i < range; ++i)
                {
                    for (int j = 0; j < lists[i].Count; ++j)
                    {
                        arr[k++] = (int)lists[i][j];
                    }
                }
                for (int i = 0; i < range; ++i)
                    lists[i].Clear();
            }
        }

        //Сортировка подсчетом(Counting sort) – алгоритм сортировки, который применяется при небольшом количестве разных значений элементов массива данных.

        //Время работы алгоритма, линейно зависит от общего количества элементов массива и от количества разных элементов.

        //Принцип работы алгоритма сортировки подсчетом
        //Идея алгоритма заключается в следующем:


        //считаем количество вхождений каждого элемента массива;
        //исходя из данных полученных на первом шаге, формируем отсортированный массив.


        //простой вариант сортировки подсчетом
        static int[] BasicCountingSort(int[] array, int k)
        {
            var count = new int[k + 1];
            for (var i = 0; i < array.Length; i++)
            {
                count[array[i]]++;
            }

            var index = 0;
            for (var i = 0; i < count.Length; i++)
            {
                for (var j = 0; j < count[i]; j++)
                {
                    array[index] = i;
                    index++;
                }
            }

            return array;
        }

        //метод для получения массива заполненного случайными числами
        static int[] GetRandomArray(int arraySize, int minValue, int maxValue)
        {
            var random = new Random();
            var randomArray = new int[arraySize];
            for (var i = 0; i < randomArray.Length; i++)
            {
                randomArray[i] = random.Next(minValue, maxValue);
            }

            return randomArray;
        }

        //Гномья сортировка(Gnome sort) – простой в реализации алгоритм сортировки массива, назван в честь садового гнома, который предположительно таким методом сортирует садовые горшки.

        //Принцип работы алгоритма сортировки Гнома
        //Алгоритм находит первую пару неотсортированных элементов массива и меняет их местами.
        //При этом учитывается факт, что обмент приводит к неправильному расположению элементов примыкающих с обеих сторон к только что переставленным.Поскольку все элементы массива после переставленных не отсортированны, необходимо перепроверить только элементы до переставленных.

        //метод для обмена элементов
        static void Swap(ref int item1, ref int item2)
        {
            var temp = item1;
            item1 = item2;
            item2 = temp;
        }

        //Гномья сортировка
        static int[] GnomeSort(int[] unsortedArray)
        {
            var index = 1;
            var nextIndex = index + 1;

            while (index < unsortedArray.Length)
            {
                if (unsortedArray[index - 1] < unsortedArray[index])
                {
                    index = nextIndex;
                    nextIndex++;
                }
                else
                {
                    Swap(ref unsortedArray[index - 1], ref unsortedArray[index]);
                    index--;
                    if (index == 0)
                    {
                        index = nextIndex;
                        nextIndex++;
                    }
                }
            }

            return unsortedArray;
        }


        static void Main(string[] args)
        {
            // Создаем новый объект Stopwatch
            Stopwatch stopwatch = new Stopwatch();
            // Запускаем внутренний таймер объекта Stopwatch
            stopwatch.Start();

            //БЫСТРАЯ СОРТИРОВКА
            /*int[] arr = { 255, 457, 34564, 1442, 4795, 4422, 10, 0, 1124, 3424 };
            //вывод элемонтов массива
            Console.WriteLine("Быстрая сортировка");
            foreach (int ar in arr)
                Console.WriteLine(ar + " ");
            Console.WriteLine("Сортировка");
            Sort(arr, 0, arr.Length - 1);
            foreach (int ar in arr)
                Console.WriteLine(ar + " ");
            Console.ReadLine();*/

            //СОРТИРОВКА СЛИЯНИЕМ 
            /* Console.WriteLine("Сортировка слиянием");
             Console.Write("Введите элементы массива: ");
             var s = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
             var array = new int[s.Length];
             for (int i = 0; i < s.Length; i++)
             {
                 array[i] = Convert.ToInt32(s[i]);
             }

             Console.WriteLine("Упорядоченный массив: {0}", string.Join(", ", MergeSort(array)));

             Console.ReadLine();*/

            //ПОРАЗРЯДНАЯ СОРТИРОВКА
            /*int[] arr = new int[100];
            //fill the array with random numbers
            Random rd = new Random();
            for (int i = 0; i < arr.Length; ++i)
            {
                arr[i] = rd.Next(0, 100);
            }
            System.Console.WriteLine("The array before sorting:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }
            sorting(arr, 10, 2);
            System.Console.WriteLine("\n\nThe array after sorting:");
            foreach (double x in arr)
            {
                System.Console.Write(x + " ");
            }
            System.Console.WriteLine("\n\nPress the <Enter> key");
            System.Console.ReadLine();*/

            //СОРТИРОВКА ПОДСЧЕТОМ
            /*var arr = GetRandomArray(10, 0, 9);
            Console.WriteLine("Входные данные: {0}", string.Join(", ", arr));
            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", BasicCountingSort(arr, 9)));
            Console.ReadLine();*/

            //ГНОМЬЯ СОРТИРОВКА
            /*Console.WriteLine("Гномья сортировка");
            Console.Write("Введите элементы массива: ");
            var parts = Console.ReadLine().Split(new[] { " ", ",", ";" }, StringSplitOptions.RemoveEmptyEntries);
            var array = new int[parts.Length];
            for (int i = 0; i < parts.Length; i++)
            {
                array[i] = Convert.ToInt32(parts[i]);
            }

            Console.WriteLine("Отсортированный массив: {0}", string.Join(", ", GnomeSort(array)));

            Console.ReadLine();*/

            //ДВУСВЯЗНЫЙ СПИСОК
            /*DoublyLinkedList<string> linkedList = new DoublyLinkedList<string>();
            // добавление элементов
            linkedList.Add("Bob");
            linkedList.Add("Bill");
            linkedList.Add("Tom");
            linkedList.AddFirst("Kate");

            foreach (var item in linkedList)
            {
                Console.WriteLine(item);
            }
            // удаление
            linkedList.Remove("Bill");

            // перебор с последнего элемента
            foreach (var t in linkedList.BackEnumerator())
            {
                Console.WriteLine(t);
            }
            Console.ReadLine();*/


            //КОЛЬЦЕВОЙ ДВУСВЯЗНЫЙ СПИСОК
            /* CircularDoublyLinkedList<string> circularList = new CircularDoublyLinkedList<string>();
             circularList.Add("Tom");
             circularList.Add("Bob");
             circularList.Add("Alice");
             circularList.Add("Sam");

             foreach (var item in circularList)
             {
                 Console.WriteLine(item);
             }

             circularList.Remove("Bob");
             Console.WriteLine("\n После удаления: \n");
             foreach (var item in circularList)
             {
                 Console.WriteLine(item);
             }
             Console.ReadLine();*/


            //БИНАРНОЕ ДЕРЕВО ПОИСКА
            /* var binaryTree = new BinaryTree<int>();

             binaryTree.Add(8);
             binaryTree.Add(3);
             binaryTree.Add(10);
             binaryTree.Add(1);
             binaryTree.Add(6);
             binaryTree.Add(4);
             binaryTree.Add(7);
             binaryTree.Add(14);
             binaryTree.Add(16);

             binaryTree.PrintTree();

             Console.WriteLine(new string('-', 40));
             binaryTree.Remove(3);
             binaryTree.PrintTree();

             Console.WriteLine(new string('-', 40));
             binaryTree.FindNode(1);
             binaryTree.PrintTree();

             Console.WriteLine(new string('-', 40));
             binaryTree.Add(9);
             binaryTree.PrintTree();

             Console.ReadLine();
             */

            //БИНАРНОЕ ДЕРЕВО ПОИСКА2

            /* var tree = new BinaryTree2();
             tree.Insert(20);
             tree.Insert(40);
             tree.Insert(10);
             tree.Insert(30);
             tree.Insert(80);
             tree.Insert(29);
             tree.Insert(31);
             tree.Insert(32);
             tree.Insert(70);
             BinaryTree2Extensions.Print(tree);
             tree.Remove(40);
             BinaryTree2Extensions.Print(tree);
             tree.Remove(20);
             BinaryTree2Extensions.Print(tree);

             Console.WriteLine("Поиск");
             BinaryTree2Extensions.Print(tree.Find(20));

             Console.WriteLine("Поиск");
             BinaryTree2Extensions.Print(tree.Find(31));

             Console.WriteLine("Поиск");
             BinaryTree2Extensions.Print(tree.Find(10));

             tree.Insert(5);
             BinaryTree2Extensions.Print(tree);

             Console.WriteLine("Поиск");
             BinaryTree2Extensions.Print(tree.Find(30));

             */

            Graph g = new Graph("C:/Users/ВИКА/source/repos/GosyAISD/GosyAISD/bin/Debug/input.txt");
            Console.WriteLine("Graph:");
            g.Show();
            Console.WriteLine();
            Console.WriteLine("DFS:");
            g.Dfs(4);
            Console.WriteLine();
            Console.WriteLine("BFS:");
            g.Bfs(4);
            Console.WriteLine();


            stopwatch.Stop();
            Console.WriteLine("Потрачено тактов на выполнение: " + stopwatch.ElapsedTicks);
            Console.ReadLine();

        }
    }
}
