using de.bp.pasic.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace de.bp.pasic
{
    public class PSolution
    {

        #region private memeber

        private string _executionPath;

        #endregion

        #region properties

        public string Entry { get; set; }

        public Dictionary<string, string> SourcePaths { get; set; }

        #endregion


        #region ctor

        public PSolution()
        {

        }

        #endregion

        #region init

        /// <summary>
        /// Init the source path for the fileloader
        /// </summary>
        /// <param name="executionPath">The initial path for our solution file</param>
        public void InitPath(string executionPath)
        {
            try
            {
                _executionPath = executionPath.Substring(0, executionPath.LastIndexOf("/"));
            }
            catch
            {
                throw new PasicInitException(nameof(InitPath));
            }
        }

        #endregion

        #region checking and validation

        /// <summary>
        /// Checks if all sources are existent. At this step there is no code validation
        /// <para>- Throws a PasicInitException if any file was not found</para>
        /// <para>- Returns silent if all is fine</para>
        /// </summary>
        public void CheckSourcesForExistence()
        {
            foreach (var sourcePath in SourcePaths.Values)
            {
                if (!File.Exists(Path.Combine(_executionPath, sourcePath)))
                {
                    throw new FileNotFoundException("Source file not found", sourcePath);
                }
            }
        }

        /// <summary>
        /// Checks if the entry file is existens. At this step there is no code validation
        /// <para>- Throws a PasicInitException if the entry file was not found</para>
        /// <para>- Returns silent if all is fine</para>
        /// </summary>
        public void CheckForValidEntryPath()
        {
            if (!SourcePaths.ContainsKey(Entry))
            {
                throw new PasicInitException(nameof(CheckForValidEntryPath));
            }
        }

        #endregion


        /// <summary>
        /// Returns the propper path to a source file
        /// <para>Should never throw cause the existance of the files is checked</para>
        /// </summary>
        /// <param name="filename">The class name</param>
        public string GetPath(string filename)
        {
            return Path.Combine(_executionPath, filename);
        }


    }
}
