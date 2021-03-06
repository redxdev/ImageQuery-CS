﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using ImageQuery.Environment;
using ImageQuery.Query;
using ImageQuery.Query.Statements;
using ImageQuery.Query.Value;

namespace ImageQuery.Language
{
    public static class LanguageUtilities
    {
        public static IQueryStatement[] ParseString(string input)
        {
            return Parse(new AntlrInputStream(input));
        }

        public static IQueryStatement[] ParseFile(string filename)
        {
            return Parse(new AntlrFileStream(filename));
        }

        public static IQueryStatement[] Parse(ICharStream input)
        {
            IQLangLexer lexer = new IQLangLexer(input);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(LexerErrorListener.Instance);

            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            IQLangParser parser = new IQLangParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(ParserErrorListener.Instance);

            return parser.compileUnit().list.ToArray();
        }

        public static IQueryValue ParseValueFromString(IEnvironment env, string input)
        {
            return ParseValue(env, new AntlrInputStream(input));
        }

        public static IQueryValue ParseValue(IEnvironment env, ICharStream input)
        {
            IQLangLexer lexer = new IQLangLexer(input);
            lexer.RemoveErrorListeners();
            lexer.AddErrorListener(LexerErrorListener.Instance);

            CommonTokenStream tokenStream = new CommonTokenStream(lexer);

            IQLangParser parser = new IQLangParser(tokenStream);
            parser.RemoveErrorListeners();
            parser.AddErrorListener(ParserErrorListener.Instance);

            return parser.value().expr.Evaluate(env);
        }
    }
}
