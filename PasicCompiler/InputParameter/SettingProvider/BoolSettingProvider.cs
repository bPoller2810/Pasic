using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.InputParameter.SettingProvider
{
    internal class BoolSettingProvider : BaseSettingProvider<bool>
    {

        #region private member

        private readonly string _parameter;

        #endregion

        #region ctor

        public BoolSettingProvider(string parameter)
        {
            _parameter = parameter;
        }

        #endregion

        #region BaseSettingProvider<string>

        internal override bool GetValue()
        {
            return bool.TryParse(_parameter, out var result) ? result : false;
        }

        #endregion

    }
}
