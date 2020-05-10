using System;
using System.Collections.Generic;
using System.Text;

namespace PasicCompiler.InputParameter.SettingProvider
{
    internal abstract class BaseSettingProvider
    {
    }

    internal abstract class BaseSettingProvider<TValue> : BaseSettingProvider
    {

        internal abstract TValue GetValue();

    }

}
