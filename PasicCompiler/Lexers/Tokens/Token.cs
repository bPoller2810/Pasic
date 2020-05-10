using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.Lexers.Tokens
{
    internal class Token
    {

        #region private member

        private ETokenType _type;
        private string _value;

        #endregion

        #region ctor

        public Token(ETokenType type, string value)
        {
            this._type = type;
            this._value = value;
        }

        #endregion

    }
}
