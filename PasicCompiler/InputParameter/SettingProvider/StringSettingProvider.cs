using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.InputParameter.SettingProvider
{
    internal class StringSettingProvider : BaseSettingProvider<string>
    {

        #region private member

        private readonly string _parameter;

        #endregion

        #region ctor

        public StringSettingProvider(string parameter)
        {
            _parameter = parameter;
        }

        #endregion

        #region BaseSettingProvider<string>

        internal override string GetValue()
        {
            return _parameter;
        }

        #endregion

    }
}
