using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contracts;
using System.ComponentModel.Composition;

namespace ExportMultiplyLib
{
    [Export(typeof(IComponent))]
    [ExportMetadata("Symbol", '*')]
    public class MultiplyOfNumberComponent : IComponent
    {
        public string Description
        {
            get { return "Multiplication of components"; }
        }

        public string ManipulateOperation(params double[] args)
        {
            string result = "";
            double count = 0;
            bool first = true;

            foreach (double d in args)
            {
                if (first)
                {
                    count = d;
                    first = false;
                }
                else
                    count *= d;
                result += d.ToString() + " * ";
            }

            return result.Trim('*', ' ') + " = " + count.ToString();
        }
    }
}
