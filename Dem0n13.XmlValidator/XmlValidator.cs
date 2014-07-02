using System;
using System.Collections.Generic;

namespace Dem0n13.XmlValidator
{
    public class XmlValidator
    {
        public void Validate(IEnumerable<Tag> tags)
        {
            var openingTags = new Stack<Tag>();
            foreach (var tag in tags)
            {
                switch (tag.Type)
                {
                    case TagType.Opening:
                        openingTags.Push(tag);
                        break;
                    case TagType.Closing:
                        var top = openingTags.Pop();
                        if (!string.Equals(top.Name, tag.Name, StringComparison.OrdinalIgnoreCase))
                            throw new Exception("Пересекающиеся теги: " + top + " и " + tag);
                        break;
                }
            }
            if (openingTags.Count != 0)
                throw new Exception("Следующие теги не закрыты: " + string.Join(", ", openingTags));
        }
    }
}