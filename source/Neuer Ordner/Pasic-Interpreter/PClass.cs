using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace de.bp.pasic
{
    public class PClass
    {

        #region properties

        public List<string> Lines { get; private set; }

        public int EntryLine { get; private set; }

        public Dictionary<string, PVariable> Variables { get; private set; }

        #endregion

        #region ctor

        public PClass(int entryIndex)
        {
            Lines = new List<string>();
            Variables = new Dictionary<string, PVariable>();
            EntryLine = entryIndex;
        }

        #endregion

        #region init

        public void GenerateVariables()
        {
            //TODO: runtime error handling
            foreach (var varLine in Lines.Where(v => PVariable.IsVar(v)))
            {
                var split = varLine.Split(' ');

                var variable = new PVariable(split[0], varLine.Replace(split[0], string.Empty).Trim());
                Variables.Add(variable.Name, variable);

            }
        }

        #endregion

        #region run

        public void Run(int index)
        {
            var scope = 0;
            var shouldRun = true;
            while (shouldRun == true)
            {
                index++;
                var lineSplit = Lines[index].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                switch (lineSplit[0])
                {
                    case "{": scope++; break;
                    case "}": scope--; break;
                    case "Print":
                        PerformPrint(Lines[index].Replace("Print ", "")); break;
                    default:
                        EvaluateExpression(Lines[index]); break;
                }


                if (scope == 0) { shouldRun = false; }
            }
        }


        #endregion

        #region performer

        private void PerformPrint(string expression)
        {
            if (expression.StartsWith("\"") && expression.EndsWith("\""))
            {
                Console.WriteLine(expression.Replace("\"", ""));
            }
            else
            {
                if (Variables.ContainsKey(expression))
                {
                    var variable = Variables[expression];
                    Console.WriteLine(variable.GetValueAsString());
                }
                else
                {
                    //TODO: error
                }
            }
        }

        private void EvaluateExpression(string expression)
        {
            var split = Regex.Split(expression, "[=|+|-|*|/|]");


        }

        #endregion

        #region static factory

        public static PClass GenerateClass(string[] lines)
        {
            //TODO: runtime error handline
            var lineList = new List<string>();

            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line) || line.StartsWith("//")) { continue; }

                lineList.Add(line.Trim());
            }

            var entry = lineList.IndexOf(lineList.Where(l => l.Contains("Entry:")).FirstOrDefault());

            var returnClass = new PClass(entry);
            returnClass.Lines.AddRange(lineList);

            return returnClass;
        }


        #endregion

    }

}
