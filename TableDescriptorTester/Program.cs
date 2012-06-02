using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TableDescriptorTester
{
    class Program
    {
        static void Main(string[] args)
        {
            string t1 = File.ReadAllText(@"Examples\Table1.txt");


            TableDescriptor.DescriptorObjects.DescriptorTable table = new TableDescriptor.DescriptorObjects.DescriptorTable(t1);
            table.ParseTable();

            string test = table.Rows.First().Values.First().Value;
        }
    }
}
