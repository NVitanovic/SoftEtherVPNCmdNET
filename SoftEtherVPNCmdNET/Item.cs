using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoftEtherVPNCmdNET
{
    public sealed class ItemClassMap : CsvClassMap<Item>
    {
        public ItemClassMap()
        {
            Map(m => m.Key).Name("Key");
            Map(m => m.Value).Name("Value");
        }
    }
    public class Item
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
