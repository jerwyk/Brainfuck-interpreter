using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Brainfuck
{
    class Program
    {
        static void Main(string[] args)
        {

            int bufSize = 1024;
            Stream inStream = Console.OpenStandardInput(bufSize);
            Console.SetIn(new StreamReader(inStream, Console.InputEncoding, false, bufSize));

            //input the brainfuck code
            string str = Console.ReadLine();
            //indicate which command is the current one
            int ptr = 0;

            int count = 0;

            //n used as a pointer, or the index in the array
            int n = 0;
            //the array, I used i list here so its easier to expande it
            List<int> a = new List<int>();
            //initialize the first cell
            a.Add(0);

            //a stack to implient loops
            Stack<int> loop = new Stack<int>();

            //read each character in the code
            while (ptr < str.Length)
            {
                //get the command from the string
                char c = str[ptr];

                if(c == '>')
                {
                    n++;
                    if (n >= a.Count)
                    {
                        a.Add(0);
                    }
                }
                else if(c == '<')
                {
                    n--;
                }
                else if(c == '+')
                {
                    a[n]++;
                }
                else if(c == '-')
                {
                    a[n]--;
                }
                else if(c == '.')
                {
                    Console.Write(Convert.ToChar(a[n]));
                }
                else if(c == '[')
                {
                    //if data pointer is 0, skip the loop
                    if(a[n] == 0)
                    {
                        //find the matching ]
                        while (str[ptr] != ']')
                        {
                            ptr++;
                        }
                        
                    }
                    //put the command of the loop in the stack
                    else
                    {
                        loop.Push(ptr);
                    }
                }
                else if(c == ']')
                {
                    ptr = loop.Pop() - 1;
                }

                ptr++;
                count++;

            }

            Console.ReadLine();


        }
    }
}
