using System;
using System.Collections.Generic;
using System.Linq;

namespace Dem0n13.XmlValidator
{
    public class XmlParser
    {
        public IEnumerable<Tag> Parse(IEnumerable<Token> tokens)
        {
            if (tokens == null)
                throw new ArgumentNullException("tokens");

            var array = tokens.ToArray();
            for (var index = 0; index < array.Length;)
            {
                yield return ParseTag(array, ref index);
            }
        }

        private Tag ParseTag(Token[] tokens, ref int index)
        {
            if (tokens[index] is OpeningBraketToken)
            {
                index++;
            }
            else
            {
                throw new Exception(index + ": ожидался токен открывающей угловой скобки");
            }

            var type = TagType.Opening;
            if (tokens[index] is SlashToken)
            {
                index++;
                type = TagType.Closing;
            }

            string name;
            if (tokens[index] is TagNameToken)
            {
                name = tokens[index].OriginalString;
                index++;
            }
            else
            {
                throw new Exception(index + ": ожидался токен имени тега");
            }

            if (tokens[index] is ClosingBraketToken)
            {
                index++;
                return new Tag(name, type);
            }
            else
            {
                throw new Exception(index + ": ожидался токен закрывающей угловой скобки");
            }
        }
    }
}