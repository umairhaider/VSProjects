using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis;
using System.Threading;

namespace SyntaxChecker
{
    class Program
    {
        public static String inputCode = "";
        public static void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("Welcome to Code Syntax Analyser: ");
            Console.WriteLine("Press E to write Code in C#");
            Console.WriteLine("Press F5 to to compile the Code");
            if (Console.ReadKey(true).Key== ConsoleKey.E)
            {
                Console.Clear();
                Console.WriteLine("Start Writing your Code:");
               do
               {
                    if(Console.ReadKey(true).Key == ConsoleKey.Escape)
                    {
                        break;
                    }
                        else
                    {

                        inputCode += Console.ReadLine();
                        inputCode += Environment.NewLine;
                    }

                   
                } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
                mainMenu();
            }

            else if (Console.ReadKey(true).Key == ConsoleKey.F5)
            {
                if (inputCode.Length > 1)
                {
                    
                    myParser(inputCode);
                }
                else
                {
                    Console.Clear();
                    Console.Beep();
                    Console.Write("Please Write Code Before Analysing");
                    for(int i=0; i<5; i++)
                    {
                        Console.Write(".");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    mainMenu();
                }
                    
            }
        }

       public static void myParser(String _inputCode)
            {
            String strDetail = "";
            Diagnostic[] temp;
            Diagnostic obj;

            var stTree = CSharpSyntaxTree.ParseText(@_inputCode);

            Console.Clear();
            Console.Write("Parsing");
            for(int i=0; i<3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }
            Console.WriteLine();

            if (stTree.GetDiagnostics().Count() == 0)
            {
                strDetail += "No Errors Detected!";
                Console.Read();
                mainMenu();

            }


            temp = stTree.GetDiagnostics().ToArray();

            for (int i = 0; i < temp.Length; i++)
            {
                obj = temp[i];

                strDetail += (i + 1).ToString() + ". Info:  " + obj.GetMessage().ToString() + Environment.NewLine;
                strDetail += "Warning Level:  " + obj.WarningLevel.ToString() + Environment.NewLine;
                strDetail += "Severity Level:  " + obj.Severity.ToString() + Environment.NewLine;
                strDetail += "Location:  " + obj.Location.Kind.ToString() + Environment.NewLine;
                strDetail += "Character at:  " + obj.Location.GetLineSpan().StartLinePosition.Character.ToString() + Environment.NewLine;
                strDetail += "On Line:  " + obj.Location.GetLineSpan().StartLinePosition.Line.ToString() + Environment.NewLine;
                strDetail += Environment.NewLine;
            }

            Console.WriteLine(strDetail);
            Console.Read();
            mainMenu();

        }

 
        static void Main(string[] args)
        {
            mainMenu();
            Console.Clear();
            Console.WriteLine("Program Ended!!");
            Console.Read();
        }
    }
}
