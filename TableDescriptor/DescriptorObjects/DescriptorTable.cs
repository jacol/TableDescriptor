using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    /// <summary>
    /// Class that takes table description as string and parse it to simple Descriptor classes - column names, rows and cells
    /// </summary>
    internal class DescriptorTable
    {
        #region Private Fields

        private readonly string [] ColumnSeparators =  { "|" };
        private readonly string[] LineSeparators = { Environment.NewLine };

        private string tableString;

        #endregion

        #region Internal Properties

        /// <summary>
        /// Collection that represents each row as separate DescriptorRow class
        /// </summary>
        internal IEnumerable<DescriptorRow> Rows { get; private set; }

        /// <summary>
        /// Collection that represents column names as strings
        /// </summary>
        internal IEnumerable<string> ColumnNames { get; private set; }

        /// <summary>
        /// Property indicates if there are any columns defined
        /// </summary>
        internal bool AreDefinedColumnNames { get { return ColumnNames != null && ColumnNames.Count() > 0; } }

        /// <summary>
        /// Property indicates if there are any rows defined
        /// </summary>
        internal bool AreDefinedRows { get { return Rows != null && Rows.Count() > 0; } }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor take string which is table representation
        /// </summary>
        /// <param name="tableString"></param>
        internal DescriptorTable(string tableString)
        {
            if (string.IsNullOrWhiteSpace(tableString))
            {
                throw new ArgumentNullException("tableString cannot be null or empty");
            }

            this.tableString = tableString;
        }

        #endregion

        #region Internal Methods

        /// <summary>
        /// Method use private field tableString passed to ctor and parse it to DescriptorRows and DescriptorCells
        /// </summary>
        internal void ParseTable()
        {
            string[] lines = tableString.Split(LineSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (lines.Length < 1)
            {
                throw new ArgumentException(string.Format("Provided tableString does not contain table data separated line breaks '{0}'", LineSeparators));
            }

            this.ColumnNames = ParseColumnNames(lines[0]);
            this.Rows = ParseRows(lines.Skip(1));
        }

        #endregion

        #region Private Methods

        private IEnumerable<string> ParseColumnNames(string firstLine)
        {
            string[] columnNames = firstLine.Split(ColumnSeparators, StringSplitOptions.RemoveEmptyEntries);
            if (columnNames == null || columnNames.Length == 0)
            {
                throw new ArgumentException(string.Format("Provided tableString does not contain any columns separated '{0}'", ColumnSeparators));
            }

            return columnNames.Select(l => l.Trim());
        }

        private IEnumerable<DescriptorRow> ParseRows(IEnumerable<string> tableLines)
        {
            foreach (string line in tableLines)
            {
                string[] values = line.Split(ColumnSeparators, StringSplitOptions.RemoveEmptyEntries);
                if (values.Length != ColumnNames.Count())
                {
                    throw new ApplicationException("Number of columns does not match");
                }

                yield return new DescriptorRow(values.Select(v => v.Trim()));
            }
        }

        #endregion
    }
}
