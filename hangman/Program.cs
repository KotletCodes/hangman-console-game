using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int printhang(int n)
            {

                if (n == 0)
                {
                    return 1;
                
                }
                if (n == 1)
                {
                    return 2;
                }
                else
                {
                    return 3;
                }
            
            
            
            }
            string[] makelayout(string x, string[] y)
            {
                for (int a = 0; a < x.Length; a++)
                {
                    y[a] = "_";
                
                
                }
                return y;

            
            
            
            }
            void printlayout(string[] x)
            {
                Console.Write("layout is:");
                for (int i = 0; i < x.Length; i++)
                {
                    Console.Write(Convert.ToString(x[i]));
                }
                Console.WriteLine();

            
            
            
            }
            string hangman1 = "-----\n  | |\n    |\n    |\n    |\n -----";
            string hangman2 = "-----\n  | |\n  0 |\n    |\n    |\n -----";
            string hangman3 = "-----\n  | |\n  0 |\n  | |\n    |\n -----";
            string hangman4 = "-----\n  | |\n  0 |\n  | |\n /  |\n -----";
            StreamReader stream = new StreamReader("words.txt");
            string line;
            
            string[] all = new string[1000];
            int count = 0;
            while((line = stream.ReadLine()) != null)
            {
                all[count] = line;
                count++;
            
            
            }
            Random rnd = new Random();
            string chosenword = all[rnd.Next(0, count)];
            
            char[] chosenwordlist = new char[chosenword.Length];
            for (int i = 0; i < chosenwordlist.Length; i++)
            {
                chosenwordlist[i] = chosenword[i];
            
            
            }
            string[] layout = new string[chosenword.Length];
            layout = makelayout(chosenword, layout);
            bool done = false;
            int wrong = 0;
            int right = 0;
            Console.WriteLine(hangman1);
            while (done == false)
            {
                Console.WriteLine("enter your guess in the form of a letter");
                char letter = Convert.ToChar(Console.ReadLine());
                int num = Array.IndexOf(chosenwordlist, letter);
                if (num != -1)
                {
                    layout[num] = Convert.ToString(chosenwordlist[num]);
                    right++;
                    if (right == chosenword.Length)
                    {

                        done = true;
                    
                    }
                    printlayout(layout);



                }
                else
                {
                    int a = printhang(wrong);
                    if (a == 0)
                    {
                        Console.WriteLine(hangman2);


                    }
                    if (a == 1)
                    {
                        Console.WriteLine(hangman3);
                    
                    }
                    if (a == 2)
                    {
                        Console.WriteLine(hangman4);
                    
                    }
                    wrong++;
                    if (wrong == 3)
                    {
                        done = true;
                    
                    }
                
                
                }
                
            
            
            
            }
            if (right == chosenword.Length)
            {
                Console.WriteLine("You win");


            }
            else
            {
                Console.WriteLine("looser");
            }




            Console.ReadKey();            
        }
    }
}
