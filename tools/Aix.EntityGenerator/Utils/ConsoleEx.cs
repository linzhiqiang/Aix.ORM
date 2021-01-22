using System;
using System.Collections.Generic;
using System.Text;

namespace Aix.EntityGenerator.Utils
{
 public static  class ConsoleEx
    {
        public static void Write(ConsoleColor consoleColor,string value)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(value);
            Console.ResetColor();
        }
        public static void WriteLine(ConsoleColor consoleColor, string value)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(value);
            Console.ResetColor();
        }

        public static void Write(ConsoleColor consoleColor, string format, object arg0)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(format, arg0);
            Console.ResetColor();
        }
        public static void WriteLine(ConsoleColor consoleColor, string format, object arg0)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(format, arg0);
            Console.ResetColor();
        }

        public static void Write(ConsoleColor consoleColor, string format, object arg0, object arg1)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(format, arg0, arg1);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor consoleColor, string format, object arg0, object arg1)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(format, arg0, arg1);
            Console.ResetColor();
        }

        public static void Write(ConsoleColor consoleColor, string format, object arg0, object arg1, object arg2)
        {
            Console.ForegroundColor = consoleColor;
            Console.Write(format, arg0, arg1,arg2);
            Console.ResetColor();
        }

        public static void WriteLine(ConsoleColor consoleColor, string format, object arg0, object arg1, object arg2)
        {
            Console.ForegroundColor = consoleColor;
            Console.WriteLine(format, arg0, arg1, arg2);
            Console.ResetColor();
        }
    }
}
