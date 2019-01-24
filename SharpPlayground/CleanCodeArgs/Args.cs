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
        private Dictionary<char, string> stringArgs = new Dictionary<char, string>();
        private HashSet<char> argsFound = new HashSet<char>();
        private int currentArgument = 0;

        public Args(string schema, string[] args)
        {
            this.schema = schema;
            this.args = args;
            valid = parse();
        }

        #region API
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

        public string getString(char arg)
        {
            return stringArgs[arg];
        }
        #endregion


        #region Error Handling
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
        #endregion

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


        #region PARSING ARGUMENTS


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
            if (TrySetArgument(argChar))
            {
                argsFound.Add(argChar);
            }
            else
            {
                unexpectedArguments.Add(argChar);
            }


            
        }

        private bool TrySetArgument(char argChar)
        {
            if (isBooleanArgument(argChar))
            {
                setBooleanArg(argChar, true);
                return true;
            }
            else if (IsStringArgument(argChar))
            {
                setStringArg(argChar, "");
                return true;
            }
            else
            {
                unexpectedArguments.Add(argChar);
                return true;
            }
        }

        private void setStringArg(char argChar, string v)
        {
            currentArgument++;
            try
            {
                stringArgs.Add(argChar, args[currentArgument]);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private bool IsStringArgument(char argChar)
        {
            return stringArgs.ContainsKey(argChar);
        }

        private void setBooleanArg(char argChar, bool value)
        {
            if (boolArgs.ContainsKey(argChar))
            {
                boolArgs[argChar] = value;
            }
        }

        private bool isBooleanArgument(char c)
        {
            return boolArgs.ContainsKey(c);
        }
        #endregion


        #region PARSING SCHEMA
        private bool parseSchema()
        {
            foreach (var element in schema.Split(','))
            {
                if (element.Length > 0)
                {
                    var trimmedSchemaElement = element.Trim();
                    parseSchemaElement(trimmedSchemaElement);
                }
            }
            return true;
        }

        private void parseSchemaElement(string schemaElement)
        {
            var schemaElementCharId = schemaElement[0];
            var schemaElementTail = schemaElement.Substring(1);
            if (!char.IsLetter(schemaElementCharId))
            {
                throw new Exception("Bad argument char passed (please use letters)");
            }
            if (IsSchemaElementBool(schemaElementTail))
            {
                parseBooleanSchemaElement(schemaElementCharId);
            }
            else if (IsSchemaElementString(schemaElementTail))
            {
                parseStringSchemaElement(schemaElementCharId);
            }
        }

        private bool IsSchemaElementString(string elementTail)
        {
            return elementTail == "*";
        }

        private static bool IsSchemaElementBool(string elementTail)
        {
            return elementTail.Length == 0;
        }

        private void parseBooleanSchemaElement(char elementCharId)
        {
            boolArgs.Add(elementCharId, false);
        }

        private void parseStringSchemaElement(char elementCharId)
        {
            stringArgs.Add(elementCharId, "");
        }
        #endregion
    }
}
