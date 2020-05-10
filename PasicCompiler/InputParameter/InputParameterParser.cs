using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using PasicCompiler.InputParameter.Enums;
using PasicCompiler.InputParameter.Exceptions;
using PasicCompiler.InputParameter.SettingProvider;

namespace PasicCompiler.InputParameter
{
    internal class InputParameterParser
    {

        private Dictionary<EInputParameter, BaseSettingProvider> _parameters;

        public InputParameterParser(string[] args)
        {
            CreateDictionary(args);
        }

        private void CreateDictionary(string[] args)
        {
            _parameters = new Dictionary<EInputParameter, BaseSettingProvider>();
            try
            {
                for (int i = 0; i < args.Length; i += 2)
                {
                    var key = GetKey(args[i]);
                    var value = GetProvider(key, args[i + 1]);
                    if (_parameters.ContainsKey(key)) { continue; }
                    _parameters.Add(key, value);
                }
            }
            catch (Exception ex)
            {
                throw new InputParserException("Invalid Arguments", ex);
            }
        }

        public BaseSettingProvider GetProvider(EInputParameter key)
        {
            return _parameters.TryGetValue(key, out var value) ? value : null;
        }

        private EInputParameter GetKey(string parameter)
        {
            return parameter switch
            {
                var s when s == "-s" || s == "s" => EInputParameter.SourceFile,
                var e when e == "-e" || e == "e" => EInputParameter.Execute,
            };
        }

        private BaseSettingProvider GetProvider(EInputParameter key, string value)
        {
            return key switch
            {
                EInputParameter.SourceFile => new StringSettingProvider(value),
                EInputParameter.Execute => new BoolSettingProvider(value),
            };
        }

    }
}
