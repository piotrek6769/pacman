using System;
using System.Threading;

namespace ConsoleApp1
{
    class Program
    {
        static public int x = 22, y = 22;
        static public int x_pos = 7, y_pos =7;
        static public string[,] mapq = new string[x,y];
        static public string course = "stop";

        static public void uzupelnij()
        {

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    mapq[i, j] = " ";
                }
            }

            for (int i = 0; i < y; i++)
            {
                mapq[0, i] = "#";
                mapq[x - 1, i] = "#";
            }

            for (int i = 0; i < x; i++)
            {
                mapq[i, 0] = "#";
                mapq[i, y - 1] = "#";
            }

        }

        static public void draw_maps()
        {
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(mapq[i, j]);
                }
            }


        }


        static void inside(Object a)
        {
            int b = Convert.ToInt16(a);

            int data = 1;
            System.Diagnostics.Stopwatch clock = new System.Diagnostics.Stopwatch();
            clock.Start();
            while (true)
            {
                data++;
                Console.SetCursorPosition(1, 2 + b);
                Console.Write("Current Value: " + data.ToString());
                Console.SetCursorPosition(1, 3 + b);
                Console.Write("Running Time: " + clock.Elapsed.TotalSeconds.ToString());

                Console.SetCursorPosition(1, 4 + b);
                Console.Write("thread" + Thread.GetCurrentProcessorId());
                Thread.Sleep(100);
            }
        }


        static void pac_man(Object a)
        {
            int b = Convert.ToInt16(a);
            Thread.Sleep(100); 

            for (int i = 1; i < 20; i++)
            {

                Console.SetCursorPosition(0, i-1);
                Console.Write("#       ");
         
                Console.SetCursorPosition(0, i);
                Console.Write("*gugu*");

                Thread.Sleep(100);
            }


        }

        static void view_table(Object a)
        {
            int b = Convert.ToInt16(a);

            Console.SetCursorPosition(0, 0);
            Console.Write("##############################################################################");
            for (int row = 1; row < 50; row++)
            {
                Console.SetCursorPosition(0, row);
                Console.Write("#                                                                            #");
            }
            Console.SetCursorPosition(0, 50);
            Console.Write("##############################################################################");

            Thread watek = new Thread(inside);
           // watek.Start(b);

        }





        static void key_press()
        {

            while (true)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo toets = Console.ReadKey(true);
                    if (toets.Key.Equals(ConsoleKey.UpArrow)){
                        Console.SetCursorPosition(0, 0);
                        Console.Write("^");
                        course = "up";
                    }
                    if (toets.Key.Equals(ConsoleKey.DownArrow))
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write("|");
                        course = "down";
                    }
                    if (toets.Key.Equals(ConsoleKey.LeftArrow))
                    {
                        Console.SetCursorPosition(0, 0);
                        Console.Write("<");
                        course = "left";
                       

                    }
                    if (toets.Key.Equals(ConsoleKey.RightArrow))
                    {
                        Console.SetCursorPosition(0,0);
                        Console.Write(">");
                        course = "right";
                    }

                }

            }
        }

        static void go(Object a)
        {
            while (true)
            {

                uzupelnij();
                draw_maps();
               
                if (course.Equals("up"))
                {
                    y_pos--;

                    Console.SetCursorPosition(x_pos,y_pos);
                    Console.Write("o");
                }
                else if(course.Equals("down"))
                {
                    y_pos++;
                    Console.SetCursorPosition(x_pos, y_pos);
                    Console.Write("o");
                } else if (course.Equals("left"))
                {
                    x_pos--;
                    Console.SetCursorPosition(x_pos, y_pos);
                    Console.Write("o");
                }
                else if (course.Equals("right"))
                {
                    x_pos++;
                    Console.SetCursorPosition(x_pos, y_pos);
                    Console.Write("o");
                }
                else
                {

                }
                Thread.Sleep(1000);

            }

        }

        static void Main(string[] args)
        {
            //  view_table(1);
                 uzupelnij();

              Thread watek2 = new Thread(go);
             watek2.Start(10);


             Thread watek = new Thread(key_press);
            watek.Start();
            int x = 15;
            int y = 15;

            /*
            for (int i = 0; i < x; i++)
            {
                for(int j = 0; j < y; j++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(mapq[i,j]);
                }
            }*/

          
            Console.ReadKey();

          

        }
    }
}
