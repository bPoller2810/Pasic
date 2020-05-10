using System;
using PasicCompiler.InputParameter;
using PasicCompiler.InputParameter.Enums;
using PasicCompiler.InputParameter.Exceptions;
using PasicCompiler.InputParameter.SettingProvider;
using PasicCompiler.Lexers;
using PasicCompiler.SourceLoader;

namespace PasicCompiler
{
    class Program
    {

        private static InputParameterParser _parameterParser;

        static void Main(string[] args)
        {
            var _parameterParser = new InputParameterParser(args);

            ISourceLoader sourceLoader = GetSourceLoader() ?? throw new InputParameterException("Could not load FileSourceLoader");
            var lexer = new Lexer(sourceLoader);


            //test
            var token = lexer.GetTokenChain();


        }

        private static ISourceLoader GetSourceLoader()
        {
            var provider = _parameterParser.GetProvider(EInputParameter.SourceFile);
            if (provider is StringSettingProvider stringProvider)
            {
                return new FileSourceLoader(stringProvider.GetValue());
            }


            return null;
        }


    }
}
