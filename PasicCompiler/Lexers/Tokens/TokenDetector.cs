using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.Lexers.Tokens
{
    internal class TokenDetector
    {

        #region private member

        private Dictionary<string, ETokenType> _validTokens;

        #endregion

        #region ctor

        public TokenDetector()
        {
            _validTokens = new Dictionary<string, ETokenType>
            {
                {"=", ETokenType.Operator },
                {"+", ETokenType.Operator },
                {"-", ETokenType.Operator },
                {"*", ETokenType.Operator },
                {"/", ETokenType.Operator },

                {";", ETokenType.LineEnd },


            };
        }

        #endregion

        #region public methods

        public bool IsToken(string probe)
        {
            return _validTokens.ContainsKey(probe);
        }

        public Token GetFixedToken(string value)
        {
            if (_validTokens.TryGetValue(value, out var type))
            {
                return new Token(type, value);
            }
            return null;
        }

        public Token GetFreeToken(string value)
        {
            return new Token(ETokenType.)
        }

        #endregion

    }
}
