using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    /// <summary>
    /// Class represents Cell and its value
    /// </summary>
    internal class DescriptorCell
    {
        /// <summary>
        /// Fetch cell value
        /// </summary>
        internal string Value
        {
            get;
            private set;
        }
        
        /// <summary>
        /// Indicates if cell value is null or empty
        /// </summary>
        internal bool IsNullOrWhitespace
        {
            get
            { 
                return string.IsNullOrWhiteSpace(Value); 
            }
        }

        /// <summary>
        /// Property indicates if value should be ignored while Assert table rows
        /// </summary>
        internal bool ShouldIgnore
        {
            get;
            private set;
        }

        /// <summary>
        /// Constructor take as a paramter value to store and sets ShouldIgnore property
        /// </summary>
        /// <param name="value">Value to store as Cell value</param>
        internal DescriptorCell(string value)
        {
            Value = value;
            ShouldIgnore = string.Equals(Value, TagsHelper.IgnoreTagValue, StringComparison.InvariantCulture);
        }
    }
}
