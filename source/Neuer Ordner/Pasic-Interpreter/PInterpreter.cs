using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.bp.pasic
{
    public class PInterpreter
    {

        private readonly PSolution _solution;




        public PInterpreter(string solutionPath)
        {
            try
            {
                //TODO: refactor out of constructor
                var solutionContent = File.ReadAllText(solutionPath);

                _solution = JsonConvert.DeserializeObject<PSolution>(solutionContent);
                _solution.InitPath(solutionPath);
                _solution.CheckSourcesForExistence();
                _solution.CheckForValidEntryPath();



            }
            catch (Exception ex)
            {
                //TODO: runtime error output formating
            }
        }

        public void RunProgram()
        {
            var startFilePath = _solution.SourcePaths[_solution.Entry];
            var entryClass = LoadClass(startFilePath);
            entryClass.GenerateVariables();

            entryClass.Run(entryClass.EntryLine);

        }



        private PClass LoadClass(string classPath)
        {
            var path = _solution.GetPath(classPath);
            var lines = File.ReadAllLines(_solution.GetPath(classPath));
            return PClass.GenerateClass(lines);
        }


    }
}
