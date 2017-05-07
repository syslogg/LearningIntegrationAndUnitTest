using System;
using Infrastructure.Log;

namespace TestProjects
{
    class Program
    {
        static void Main(string[] args)
        {
            IBKLog log = new BKLog();
            log.LogMessage("Teste de log feito direitinho");
            Console.WriteLine("Deu certo");

            Console.ReadLine();
        }
    }
}
