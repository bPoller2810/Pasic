using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PasicCompiler.SourceLoader
{
    internal class FileSourceLoader : ISourceLoader
    {

        #region private member

        private string[] _sourceData;

        #endregion

        #region ctor

        public FileSourceLoader(string filepath)
        {
            LoadSourceFromFile(filepath);
        }

        #endregion

        #region private methods

        private void LoadSourceFromFile(string filepath)
        {
            if (!File.Exists(filepath)) { return; }
            _sourceData = File.ReadAllLines(filepath);
        }

        #endregion

        #region ISourceLoader

        public string[] Source => _sourceData;

        #endregion

    }
}
