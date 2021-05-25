using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GosyAISD
{
    class GraphMatrix
    {
        public static int i, j, k, n, kol;
        //алгоритмді алдыңғы қалпына «қайтаруды» орындау ҥшін стекттерді қолданады, графты  жҥріп ӛткен кезде 
        //tizimge jana elementti kosu adisi
        static void vkl(Stack vst, int n)
        { vst.Push(n); }
        //tizimnen elementti joyu
        static void iskl(Stack vst)
        {
            if (vst == null)//eger tizim sonina barsa
                Console.WriteLine("Stek bos!");
            else n = (int)vst.Pop();
        }
        //Bagdarlama basi 
        //
        public static void DFS()
        {
            Stack vstek = new Stack();//Stack kurilimin kurdik
            //int i, j, k, n;  
            bool[] nov = new bool[16];//16 tobe simvoldar turinde
            int[,] p = new int[16, 16];//p matricasi jol boyinwa tekseru uwin
            int[,] a = new int[16, 16]//a matricasi bagan boyinwaa
//16-16 matrica kurip alasin grafta eger tobeler baylanissa 0 dep alasin, baylanispasa 1000 oz ozine ten bolsa 0 
      {{0, 1,1000,1000, 1, 1000, 1000, 1000,1000,1000,1000,1000,1000,1000,1000,1000},//0
{1, 0, 1,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000},//1
{1000,1,0,1,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000},//2
{1000,1000,1,0,1000,1000,1000,1,1000,1000,1000,1000,1000,1000,1000,1000},//3
{1,1000,1000,1000,0,1,1000,1000,1,1000,1000,1000,1000,1000,1000,1000}, //4
{1000,1000,1000,1000,1,0,1,1000,1000,1000,1000,1000,1000,1000,1000,1000},//5
{1000,1000,1000,1000,1000,1,0,1,1000,1000,1000,1000,1000,1000,1000,1000},//6
{1000,1000,1000,1,1000,1000,1,0,1000,1000,1000,1,1000,1000,1000,1000},//7
{1000,1000,1000,1000,1,1000,1000,1000,0,1,1000,1000,1,1000,1000,1000},//8
{1000,1000,1000,1000,1000,1000,1000,1000,1,0,1,1000,1000,1000,1000,1000},//9
{1000,1000,1000,1000,1000,1000,1000,1000,1000,1,0,1,1000,1000,1000,1000},//10
{1000,1000,1000,1000,1000,1000,1000,1000,1,1000,1,0,1000,1000,1000,1},//11
{1000,1000,1000,1000,1000,1000,1000,1000,1,1000,1000,1000,0,1,1000,1000},//12
{1000,1000,1000,1000,1000,1000,1000,1000,1000,1,1000,1000,1000,0,1,1000},//13
{1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1,0,1},//14
{1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1,1000,1000,1,0}};//15
            //Sibailas tobelerdi kuru algoritmi
            for (i = 0; i < 16; i++)
            {
                p[i, 0] = i; k = 1;//birinwi turgan tobelerden 
                for (j = 0; j < 16; j++)
                    if ((a[i, j] != 1000) && (a[i, j] != 0))//eger tobeler baylanispagan jane oz ozine ten bolsa
                    { p[i, k] = j; k++; }// Sibaylaskan tobelerdi tabadi
                p[i, k] = 1000;
            }
            //Olardi ekranga wigaradi
            for (i = 0; i < 16; i++)
            {
                k = 0; while (p[i, k] != 1000)//p matricasindagi 1000 baska barlik tobelerdi wigaru
                { Console.Write(" {0}", p[i, k]); k++; }
                Console.WriteLine();
            }
            Console.WriteLine();
            // Graftin  Gamiltondi jurip otuine terendigi boyinwa jurip otu algoritmin koldandik
            Console.WriteLine(" Graftin Gamilton cikli boinsha jurip otui:");
            bool b;
            // Бастапқы шарттарды беру  
            for (i = 0; i < 16; i++)
                nov[i] = true;//jana tobe karaladi
            vkl(vstek, p[0, 0]); kol = 1;//tizimge jana tobe kosiladi
            Console.Write(" {0}", p[0, 0]);
            nov[0] = false;//birinwi tobe karalmaydi
            // графты «тереңдігі» бойынша жyріп 0ту цикл 
            while (kol != 0)
            {
                i = (int)vstek.Peek();//Graftin elementin kaytaradi
                if (p[i, 0] == 1000) b = false;//eger 1000 ten bolsa tobe karalmaydi
                else b = !nov[p[i, 0]];//onda b jana tobesi tabilmaydi
                // графтың жаңа тoбесін іздеу 
                k = 0; while (b == true)//b tobe kkaralatin bolsa
                {
                    k++; if (p[i, k] == 1000)//eger 1000 ten bolsa
                                             //onda b tobesi karalmaydi
                        b = false;
                    //onda 
                    else
                    {
                        //onda b jana tobesi tabilmaydi
                        b = !nov[p[i, k]];
                        //eger jana tobe sibaylas tobeler tiziminde bolsa
                        if (nov[p[i, k]])
                        //  jana tobe tabiladi 
                        { vkl(vstek, p[i, k]); kol++; }
                    }
                }
                if (p[i, k] != 1000)   // егер графтың жаңа тoбесі табылса  
                {
                    i = p[i, k];

                    Console.Write(" {0} ", i); nov[i] = false;
                }


                else  // тізімде жаңа тoбе жоқ болса, алдынғы тӛбеге оралу керек  
                { iskl(vstek); i = n; kol--; }
            }
            Console.WriteLine();
            Console.WriteLine("Enter pernesin basiniz ");
            Console.ReadLine();
        }
    }
}
