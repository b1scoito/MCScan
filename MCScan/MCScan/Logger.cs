using System;   

namespace MCScan
{
    class Logger
    {
        public void ASCII(string programa)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@" /$$        /$$                                 /$$   /$$              ");
            Console.WriteLine(@"| $$      /$$$$                                |__/  | $$              ");
            Console.WriteLine(@"| $$$$$$$|_  $$    /$$$$$$$  /$$$$$$$  /$$$$$$  /$$ /$$$$$$    /$$$$$$ ");
            Console.WriteLine(@"| $$__  $$ | $$   /$$_____/ /$$_____/ /$$__  $$| $$|_  $$_/   /$$__  $$");
            Console.WriteLine(@"| $$  \ $$ | $$  |  $$$$$$ | $$      | $$  \ $$| $$  | $$    | $$  \ $$");
            Console.WriteLine(@"| $$  | $$ | $$   \____  $$| $$      | $$  | $$| $$  | $$ /$$| $$  | $$");
            Console.WriteLine(@"| $$$$$$$//$$$$$$ /$$$$$$$/|  $$$$$$$|  $$$$$$/| $$  |  $$$$/|  $$$$$$/");
            Console.WriteLine(@"|_______/|______/|_______/  \_______/ \______/ |__/   \___/   \______/ ");
            Console.WriteLine(@"            " + programa);
            Console.WriteLine("");
        }
        public void Custom(string message, string info, ConsoleColor infoColor, ConsoleColor messageColor)
        {
            Console.ForegroundColor = infoColor;
            Console.Write("[" + info + "] ");
            Console.ForegroundColor = messageColor;
            Console.Write(message);
            Console.ForegroundColor = infoColor;
            Console.WriteLine("[" + info + "] ");

        }
        public void Resetar()
        {
            Console.ResetColor();
        }
        public void Info(string str)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[i] ");
            Console.ResetColor();
            Console.WriteLine(str);
        }
        public void Warning(string str)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("[!] ");
            Console.ResetColor();
            Console.WriteLine(str);
        }
        public void Fixed(string str)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("[-] ");
            Console.ResetColor();
            Console.WriteLine(str);
        }
        public void Error(string str)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("[x] ");
            Console.ResetColor();
            Console.WriteLine(str);
        }
        public void Success(string str)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("[+] ");
            Console.ResetColor();
            Console.WriteLine(str);
        }
    }
}
