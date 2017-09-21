﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MEFApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            var t = new ImportingLib.Importer();
            t.DoImport();
            Console.WriteLine("{0} component(s) are imported successfully.", t.AvailableNumberOfOperation);
            var result = t.CallAllComponents(125, 5, 10, 27, 45, 19, 10);
            foreach (string s in result)
            {
                Console.WriteLine(s);
            }
            Console.Read();
        }
    }
}
