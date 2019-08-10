using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.bp.pasic
{
    class Program
    {
        static void Main(string[] args)
        {


            var interpreter = new PInterpreter("Demo/project1.psol");

            interpreter.RunProgram();


            Console.ReadKey();

        }
    }
}
