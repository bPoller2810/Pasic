using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PasicCompiler.Lexers.Helper
{
    internal class SourceSanitizer
    {

        #region private member

        private readonly string[] _source;

        #endregion

        #region ctor

        public SourceSanitizer(string[] source)
        {
            this._source = source;
        }

        #endregion

        #region public methods

        public string[] GetSanitized()
        {
            return _source.Where(s =>
                !s.StartsWith("//") ||
                !string.IsNullOrWhiteSpace(s)
            )
                .ToArray();
        }

        #endregion
    }
}
