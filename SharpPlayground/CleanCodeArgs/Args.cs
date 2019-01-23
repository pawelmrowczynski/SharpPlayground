using System;
using System.Collections.Generic;
using System.Text;

namespace CleanCodeArgs
{
    public class Args
    {
        private string schema;
        private string[] args;
        private bool valid;
        private HashSet<char> unexpectedArguments = new HashSet<char>();
        private Dictionary<char, bool> boolArgs = new Dictionary<char, bool>();
        private int numberOfArgs = 0;

        public Args(string schema, string[] args)
        {
            this.schema = schema;
            this.args = args;
            valid = parse();
        }

        public string usage()
        {
            if (schema.Length > 0)
            {
                return "-[" + schema + "]";
            }
            else
            {
                return string.Empty;
            }
        }

        public string errorMessage()
        {
            if (unexpectedArguments.Count > 0)
            {
                return unexpectedArgumentCountMessage();
            }
            else return string.Empty;
        }

        public bool getBoolean(char arg)
        {
            return boolArgs[arg];
        }

        private string unexpectedArgumentCountMessage()
        {
            StringBuilder message = new StringBuilder("Argument(y) -");
            foreach (var c in unexpectedArguments)
            {
                message.Append(c);
            }
            message.Append(" nieoczekiwany");
            return message.ToString();
        }

        private bool parse()
        {
            if (schema.Length == 0 && args.Length == 0)
            {
                return true;
            }
            parseSchema();
            parseArgs();
            return unexpectedArguments.Count == 0;
        }

        private void parseArgs()
        {
            foreach (var arg in args)
            {
                parseArgument(arg);
            }
        }

        private void parseArgument(string arg)
        {
            if (arg.StartsWith('-'))
            {
                parseElements(arg);
            }
        }

        private void parseElements(string arg)
        {
            for (int i = 1; i < arg.Length; i++)
            {
                parseElement(arg[i]);
            }
        }

        private void parseElement(char argChar)
        {
            if (isBoolean(argChar))
            {
                numberOfArgs++;
                setBooleanArg(argChar, true);
            }
            else
            {
                unexpectedArguments.Add(argChar);
            }
        }

        private void setBooleanArg(char argChar, bool value)
        {
            if (boolArgs.ContainsKey(argChar))
            {
                boolArgs[argChar] = value;
            }
        }

        private bool isBoolean(char c)
        {
            return boolArgs.ContainsKey(c);
        }

        private bool parseSchema()
        {
            foreach (var element in schema.Split(','))
            {
                parseSchemaElement(element);
            }
            return true;
        }

        private void parseSchemaElement(string element)
        {
            if (element.Length == 1)
            {
                parseBooleanSchemaElement(element);
            }
        }

        private void parseBooleanSchemaElement(string element)
        {
            char c = element[0];
            if (char.IsLetter(c))
            {
                boolArgs.Add(c, false);
            }
        }
    }
}
