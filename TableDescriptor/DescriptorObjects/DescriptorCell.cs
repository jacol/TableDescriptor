using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    internal class DescriptorCell
    {
        internal string Value { get; private set; }
        internal bool IsNullOrWhitespace { get { return string.IsNullOrWhiteSpace(Value); } }
        internal object BoxValue { get { return (object)Value; } }
        internal bool ShouldIgnore { get { return string.Equals(Value, TagsHelper.IgnoreTagValue, StringComparison.InvariantCulture); } }

        internal DescriptorCell(string value)
        {
            Value = value;
        }
    }
}
