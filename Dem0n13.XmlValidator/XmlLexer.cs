using System;
using System.Collections.Generic;
using System.Text;

namespace Dem0n13.XmlValidator
{
    public class XmlLexer
    {
        public IEnumerable<Token> Tokenize(string text)
        {
            if (text == null)
                throw new ArgumentNullException("text");

            for (var index = 0; index < text.Length; index++)
            {
                switch (text[index])
                {
                    case ' ':
                    case '\t':
                    case '\r':
                    case '\n':
                        break;
                    case '<':
                        yield return new OpeningBraketToken();
                        break;
                    case '/':
                        yield return new SlashToken();
                        break;
                    case '>':
                        yield return new ClosingBraketToken();
                        break;
                    default:
                        yield return TokenizeTagName(text, ref index);
                        index--; // переставляем на предыдущий символ
                        break;
                }
            }
        }

        private TagNameToken TokenizeTagName(string chars, ref int index)
        {
            var builder = new StringBuilder();
            for (; index < chars.Length; index++)
            {
                switch (chars[index])
                {
                    case '<':
                    case '/':
                    case '>':
                        if (builder.Length == 0)
                            throw new Exception("Empty tag name");
                        return new TagNameToken(builder.ToString());
                    default:
                        builder.Append(chars[index]);
                        break;
                }
            }
            return new TagNameToken(builder.ToString());
        }
    }
}