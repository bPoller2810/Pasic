using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PasicCompiler.Lexers.Helper;
using PasicCompiler.Lexers.Tokens;
using PasicCompiler.SourceLoader;

namespace PasicCompiler.Lexers
{
    internal class Lexer
    {

        #region private member

        private readonly ISourceLoader _sourceLoader;

        #endregion

        #region ctor

        public Lexer(ISourceLoader sourceLoader)
        {
            this._sourceLoader = sourceLoader;
        }

        #endregion

        #region public methods

        public List<Token> GetTokenChain()
        {
            var fileData = _sourceLoader.Source;

            var sanitizer = new SourceSanitizer(fileData);
            var source = sanitizer.GetSanitized();

            var chain = new List<Token>();

            foreach (var line in source)
            {

            }


            return chain;
        }

        #endregion

    }
}
