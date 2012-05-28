using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    internal class DescriptorRow
    {
        internal IEnumerable<DescriptorCell> Values { get; private set; }

        internal DescriptorRow(IEnumerable<string> values)
        {
            if (values == null || values.Count() == 0)
            {
                throw new ArgumentException("Values are invalid");
            }

            Values = values.Select(v => new DescriptorCell(v));
        }
    }
}
