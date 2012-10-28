using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Rumorphology.DictionaryReader;

namespace SampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var v = new DictionaryReader();
            v.LoadDictionary(@"d:\dict.xml");
        }
    }
}
