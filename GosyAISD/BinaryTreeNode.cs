using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//Бинарное дерево(binary tree) – это структура данных, которая состоит из узлов, при этом каждый узел может иметь не более двух дочерних.
//Первый узел называется корневым или родительским, а дочерние – правым и левым наследником(потомком).
//Двоичное дерево поиска(binary search tree) – это бинарное дерево, которое соответствует следующим условиям:

//Дочерние узлы являются двоичными деревьями поиска;
//Для произвольного узла:
//Все значения левого поддерева, меньше значения родительского узла;
//Все значения правого поддерева, больше значения родительского узла.


/// <summary>
/// Расположения узла относительно родителя
/// </summary>
public enum Side
{
    Left,
    Right
}

namespace GosyAISD
{
    /// Узел бинарного дерева

    public class BinaryTreeNode<T> where T : IComparable
    {
        /// <summary>
        /// Конструктор класса
        /// </summary>
        /// <param name="data">Данные</param>
        public BinaryTreeNode(T data)
        {
            Data = data;
        }

        /// <summary>
        /// Данные которые хранятся в узле
        /// </summary>
        public T Data { get; set; }

        /// <summary>
        /// Левая ветка
        /// </summary>
        public BinaryTreeNode<T> LeftNode { get; set; }

        /// <summary>
        /// Правая ветка
        /// </summary>
        public BinaryTreeNode<T> RightNode { get; set; }

        /// <summary>
        /// Родитель
        /// </summary>
        public BinaryTreeNode<T> ParentNode { get; set; }

        /// <summary>
        /// Расположение узла относительно его родителя
        /// </summary>
        public Side? NodeSide =>
            ParentNode == null
            ? (Side?)null
            : ParentNode.LeftNode == this
                ? Side.Left
                : Side.Right;

        /// <summary>
        /// Преобразование экземпляра класса в строку
        /// </summary>
        /// <returns>Данные узла дерева</returns>
        public override string ToString() => Data.ToString();
    }
}
