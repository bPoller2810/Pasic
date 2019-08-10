using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.bp.pasic
{
    public class PVariable
    {
        #region static 

        public static List<string> Types { get; private set; }

        static PVariable()
        {
            Types = new List<string>
            {
                "int"
            };
        }

        public static bool IsVar(string line)
        {
            try
            {
                var split = line.Split(' ');
                return Types.Contains(split[0]);
            }
            catch { }
            return false;
        }

        #endregion

        #region private memeber

        private readonly string _type;

        private int _intValue;

        #endregion

        #region properties

        public string Name { get; private set; }

        #endregion

        #region ctor

        public PVariable(string type, string expression)
        {
            //TODO: refactor
            var expressionSplit = expression.Split('=');

            _type = type;
            Name = expressionSplit[0];
            switch (_type)
            {
                case "int":
                    _intValue = int.Parse(expressionSplit[1]);
                    break;
            }

        }

        #endregion

        #region getter

        public string GetValueAsString()
        {
            switch (_type)
            {
                case "int": return _intValue.ToString();
            }
            return string.Empty;
        }

        #endregion

        #region override

        public override string ToString()
        {
            var valstring = string.Empty;
            switch (_type)
            {
                case "int": valstring = _intValue.ToString(); break;
            }
            return $"{Name}: {valstring}";
        }

        #endregion
    }
}
