using System;
using System.Collections;

namespace GR09_12202230
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SeaIslands.GenerateIslands(CheckSea.sea);
            SeaIslands.PrintSea(CheckSea.sea);
            Console.WriteLine($"\n We have {SeaIslands.GetIslandsCount(CheckSea.sea)} islands");
        }
    }

    class SeaIslands
    {
        public static int Count { get; private set; }
        public static void PrintSea(int[,] sea)
        {
            //Console.ForegroundColor = ConsoleColor.Red;
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    if (sea[i, j] == 0)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                    }
                    else
                    {
                        Console.BackgroundColor = ConsoleColor.Green;
                    }

                    Console.Write($" {sea[i, j]} ");
                }

                Console.WriteLine();
            }
            Console.ResetColor();
        }
        public static int GetIslandsCount(int[,] sea)
        {
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    if (sea[i, j] == 1)
                    {
                        sea[i, j] = 2;
                        Count++;
                        CheckSea.CheckAround(i, j, sea.GetLength(0), sea.GetLength(1));
                    }

                }
            }


            return Count;
        }

        public static void GenerateIslands(int[,] sea)
        {
            for (int i = 0; i < sea.GetLength(0); i++)
            {
                for (int j = 0; j < sea.GetLength(1); j++)
                {
                    int random = Random.Shared.Next(10);
                    sea[i, j] = random > 7 ? 1 : 0;
                }
            }
        }

    }

    static class CheckSea
    {
        static public int[,] sea = new int[Random.Shared.Next(10, 20), Random.Shared.Next(10, 20)];

        static public bool CheckLeft(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (nj + 1 < sea.GetLength(1))
                    {
                        if (sea[ni, nj + 1] == 1)
                        {
                            sea[ni, nj + 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckRight(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (nj - 1 > 0)
                    {
                        if (sea[ni, nj - 1] == 1)
                        {
                            sea[ni, nj + 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckTop(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni - 1 > 0)
                    {
                        if (sea[ni - 1, nj] == 1)
                        {
                            sea[ni - 1, nj] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckBottom(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni + 1 < sea.GetLength(0))
                    {
                        if (sea[ni + 1, nj] == 1)
                        {
                            sea[ni + 1, nj] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckTopLeft(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni - 1 > 0 && nj + 1 < sea.GetLength(1))
                    {
                        if (sea[ni - 1, nj + 1] == 1)
                        {
                            sea[ni - 1, nj + 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckTopRight(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni - 1 > 0 && nj - 1 > 0)
                    {
                        if (sea[ni - 1, nj - 1] == 1)
                        {
                            sea[ni - 1, nj - 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }

        static public bool CheckBottomLeft(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni + 1 < sea.GetLength(0) && nj + 1 < sea.GetLength(1))
                    {
                        if (sea[ni + 1, nj + 1] == 1)
                        {
                            sea[ni + 1, nj + 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }

                }
            }
            return false;
        }

        static public bool CheckBottomRight(int ni, int nj)
        {
            for (; ni < sea.GetLength(0); ni++)
            {
                for (; nj < sea.GetLength(1); nj++)
                {
                    if (ni + 1 < sea.GetLength(0) && nj - 1 > 0)
                    {
                        if (sea[ni + 1, nj - 1] == 1)
                        {
                            sea[ni + 1, nj - 1] = 2;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            return false;
        }


        static public void CheckAround(int index0, int index1, int lenght0, int lenght1)
        {
            if (index1 < lenght1)
            {
                if (CheckLeft(index0, index1))
                {
                    index1++;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }

            if (index1 > 0)
            {
                if (CheckRight(index0, index1))
                {
                    index1++;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }

            if (index0 > 0)
            {
                if (CheckTop(index0, index1))
                {
                    index0--;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }
            if (index0 < lenght0)
            {
                if (CheckBottom(index0, index1))
                {
                    index0++;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }
            if (index0 > 0 && index1 < lenght1)
            {
                if (CheckTopLeft(index0, index1))
                {
                    index0--;
                    index1++;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }
            if (index0 > 0 && index1 > 0)
            {
                if (CheckTopRight(index0, index1))
                {
                    index0--;
                    index1--;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }

            if (index0 < lenght0 && index1 > 0)
            {
                if (CheckBottomRight(index0, index1))
                {
                    index0++;
                    index1--;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }

            if (index0 < lenght0 && index1 < lenght1)
            {
                if (CheckBottomLeft(index0, index1))
                {
                    index0++;
                    index1++;
                    CheckAround(index0, index1, lenght0, lenght1);
                }
            }

        }
    }
}
