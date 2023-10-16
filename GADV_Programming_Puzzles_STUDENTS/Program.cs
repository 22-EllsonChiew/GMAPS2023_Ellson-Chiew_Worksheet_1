using System;

namespace GADV_Programming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Square square = new Square();

            square.DrawFilled(5);
            Console.WriteLine();
            Console.ReadLine();

            square.DrawHollow(5);
            Console.WriteLine();
            Console.ReadLine();

            //Triangle triangle = new Triangle();

           
            //triangle.Draw(10);
            //Console.WriteLine(" ");
            //Console.ReadLine();

            Triangle triangle = new Triangle();
            triangle.Draw1();
            Console.WriteLine();
            Console.ReadLine();

            triangle.Draw2();
            Console.WriteLine();
            Console.ReadLine();

            triangle.Draw3();
            Console.ReadLine();
        }
    }

    internal class Square
    {
        public void DrawFilled(int size)
        {
            for(int roll = 0; roll < size; roll++)
            {
                for(int col = 0; col < size; col++)
                {
                    Console.Write("*");
                }

                Console.WriteLine();
            }
        
        }

        public void DrawHollow(int size)
        {
            for (int row = 0; row < size; row++)
            {

                for (int col = 0; col < size; col++)
                {
                    if(row == 4 )
                    {
                        Console.Write(" ");
                    }
                    Console.Write("*");
                    
                }

                Console.WriteLine();
            }
        }
    }

    internal class Triangle
    {
        public void Draw(int rows)
        {
            
        }

        public void Draw1()
        {
            Console.Write("*");
        }

        public void Draw2()
        {
            Console.Write(" ");
            Console.Write("*");
            Console.WriteLine();

            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
        }

        public void Draw3()
        {
            Console.Write(" ");
            Console.Write(" ");
            Console.Write("*");
            Console.WriteLine();

            Console.Write(" ");
            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
            Console.WriteLine();

            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
            Console.Write("*");
            Console.WriteLine();
        }
    }
}
