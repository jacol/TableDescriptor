using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TableDescriptor.DescriptorObjects
{
    internal class DescriptorTable
    {
        private readonly string [] ColumnSeparators =  { "|" };
        private readonly string[] LineSeparators = { Environment.NewLine };

        internal IEnumerable<DescriptorRow> Rows { get; private set; }
        internal IEnumerable<string> ColumnNames { get; private set; }

        internal bool AreDefinedColumnNames { get { return ColumnNames != null && ColumnNames.Count() > 0; } }
        internal bool AreDefinedRows { get { return Rows != null && Rows.Count() > 0; } }

        private string tableString;

        internal DescriptorTable(string tableString)
        {
            if (string.IsNullOrWhiteSpace(tableString))
            {
                throw new ArgumentNullException("tableString cannot be null or empty");
            }

            this.tableString = tableString;
        }

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
    }
}
