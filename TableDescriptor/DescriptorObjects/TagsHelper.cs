using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    /// <summary>
    /// TagsHelper defines constant values for tags that can be placed inside table string representation
    /// </summary>
    internal static class TagsHelper
    {
        /// <summary>
        /// Ingnore tag is used to set DescriptorCell.ShouldIgnore value to true
        /// </summary>
        internal static string IgnoreTagValue = "[IGNORE]";
    }
}
