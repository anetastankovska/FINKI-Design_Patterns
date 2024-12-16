﻿using source.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace source.Serrvices
{
    public class PackageManager
    {
        private Dictionary<string, PackagePrototype> _packagePrototypes;

        public PackageManager()
        {
            _packagePrototypes = new Dictionary<string, PackagePrototype>();
        }

        public void RegisterPackage(string name, PackagePrototype prototype)
        {
            _packagePrototypes[name] = prototype;
        }

        public PackagePrototype CreatePackage(string name)
        {
            if (_packagePrototypes.ContainsKey(name))
            {
                return (PackagePrototype)_packagePrototypes[name].Clone();
            }
            throw new ArgumentException($"Package '{name}' not found.");
        }

        public PackagePrototype CreateCustomPackage(string baseName)
        {
            var basePackage = CreatePackage(baseName);
            basePackage.Name += " (Custom)";
            return basePackage;
        }
    }

}
