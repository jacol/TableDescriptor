using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace TableDescriptor
{
    public class Program
    {
        public static void Main(string [] args)
        {
            string t1 = File.ReadAllText(@"Examples\Table1.txt");


            DescriptorObjects.DescriptorTable table = new DescriptorObjects.DescriptorTable(t1);
            table.ParseTable();

            string test = table.Rows.First().Values.First().Value;
        }
    }
}
