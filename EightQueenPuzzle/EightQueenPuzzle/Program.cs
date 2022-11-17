using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EightQueenPuzzle
{
    class Program
    {
        static int iNum = 8; //Queen數量
        static int icnt = 0; //解法數量
        static int[] iarray = new int[iNum]; //紀錄各行Queen的欄位序號
        static void Main(string[] args)
        {
            CheckQueen(0); //從0位子開始檢查

            Console.WriteLine("共有" + icnt + "種答案");
            Console.ReadLine(); 
        }

        //n的序號
        static void CheckQueen(int n)
        {
            if (n == iNum)   //8個位置都試完
            {
                icnt++;
                PrintResult();
                Console.WriteLine();
                return;
            }

            //依次放入皇后并判断是否冲突
            for (int i = 0; i < iNum; i++)
            {
                //把第n個Queen放在第i欄
                iarray[n] = i;

                //判斷放置第n个Queen到i欄是否符合條件
                if (Judge(n))   //不衝突
                {
                    //接著放n+1個位置
                    CheckQueen(n + 1);
                }

                //如果冲突，繼續執行for迴圈，array[n]=i; 即把第n个Queen放在最後
            }
        }

        static void PrintResult()
        {
            Console.WriteLine("Solution " + icnt.ToString() + ":"); 
            Console.WriteLine("["); 
            for (int i = 0; i < iarray.Length; i++)
            {
                string[] strarray = new string[] { "，","，","，","，","，","，","，","，" };
                strarray[iarray[i]] = "Ｑ";
                Console.WriteLine(string.Join("", strarray)); 
            }
            Console.WriteLine("]");
        }

        //檢查是否衝突
        static bool Judge(int n)
        {
            for (int i = 0; i < n; i++)
            {
                //iarray[i] == iarray[n] 檢查是否在同一欄
                //Math.Abs(n - i) == Math.Abs(iarray[n] - iarray[i]) 座標行數差 等於座標欄數差 表示45度衝突
                if (iarray[i] == iarray[n] || Math.Abs(n - i) == Math.Abs(iarray[n] - iarray[i]))
                {
                    return false;
                }
            }
            return true;
        }
    }
}