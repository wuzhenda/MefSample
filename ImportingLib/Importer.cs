﻿using System;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using Contracts;

namespace ImportingLib
{
    public class Importer
    {
        [ImportMany]
        private IEnumerable<Lazy<IComponent, IMetadata>> operations;

        public void DoImport()
        {
            //An aggregate catalog that combines multiple catalogs
            var catalog = new AggregateCatalog();

            //Add all the parts found in all assemblies in
            //the same directory as the executing program
            catalog.Catalogs.Add(
                new DirectoryCatalog(
                    Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location
                    )
                )
            );

            //Create the CompositionContainer with the parts in the catalog.
            CompositionContainer container = new CompositionContainer(catalog);

            //Fill the imports of this object
            container.ComposeParts(this);
        }

        public int AvailableNumberOfOperation
        {
            get { return operations != null ? operations.Count() : 0; }
        }

        public List<string> CallAllComponents(params double[] args)
        {
            var result = new List<string>();

            foreach (Lazy<IComponent, IMetadata> com in operations)
            {
                Console.WriteLine(com.Value.Description);
                Console.WriteLine(com.Metadata.Symbol);
                result.Add(com.Value.ManipulateOperation(args));
            }

            return result;
        }
    }
}
