using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    /// <summary>
    /// Class represents row of table and all its Cells
    /// </summary>
    internal class DescriptorRow
    {
        /// <summary>
        /// Collection of DescriptionCell objects
        /// </summary>
        internal IEnumerable<DescriptorCell> Values { get; private set; }

        /// <summary>
        /// Constructor that take collection of string and place them into separate cells
        /// </summary>
        /// <param name="values">Collection of string representing cell values</param>
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
