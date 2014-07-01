using System;
using System.Collections.Generic;

namespace Dem0n13.XmlValidator
{
    public class XmlValidator
    {
        public void Validate(IEnumerable<Tag> tags)
        {
            var stack = new Stack<Tag>();
            foreach (var tag in tags)
            {
                switch (tag.Type)
                {
                    case TagType.Opening:
                        stack.Push(tag);
                        break;
                    case TagType.Closing:
                        var top = stack.Pop();
                        if (top.Type != TagType.Opening ||
                            !string.Equals(top.Name, tag.Name, StringComparison.OrdinalIgnoreCase))
                            throw new Exception("Пересекающиеся теги: " + top + " и " + tag);
                        break;
                }
            }
            if (stack.Count != 0)
                throw new Exception("Следующие теги не закрыты: " + string.Join(", ", stack));
        }
    }
}