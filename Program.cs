using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace D3ItemCodeAnalyzer
{
    class Program
    {
        static Regex ItemName = new Regex(@"\|h\[(.+)\]\|h");
        static Dictionary<string, string> Affixes = new Dictionary<string, string>();

        [STAThread]
        static void Main(string[] args)
        {
            if (!File.Exists("affixes.txt"))
            {
                Console.WriteLine("NO AFFIXES.TXT, GO GET.");
                Console.ReadLine();
                return;
            }
            var affixes = File.ReadAllLines("affixes.txt");
            foreach (var data in from line in affixes where !string.IsNullOrWhiteSpace(line) select line.Split(new[] { ' ' }, 2))
            {
                Affixes.Add(data[0], data[1]);
            }
            string[] items = new string[1];
            if (File.Exists("items.txt"))
                items = File.ReadAllLines("items.txt");
            else
            {
                if (args.Length == 0)
                    Console.WriteLine("Please enter the item ID.");
                items[0] = args.Length > 0 ? args[0] : Console.ReadLine();
            }
            foreach (var item in items.Where(item => !string.IsNullOrWhiteSpace(item)))
            {
                Analyse(item);
            }
            Console.Read();
        }

        static void Analyse(string raw)
        {
            var data = raw.Split(':');
            if (data.Length != 18)
            {
                Console.WriteLine("{0} is an invalid item code.");
                return;
            }
            var item = new Item();
            var affixes = data[3].Split(',');
            item.Affixes = new List<string>();
            foreach (var affix in affixes)
            {
                string aff = "";
                if(Affixes.TryGetValue(affix, out aff))
                    item.Affixes.Add(aff);
            }
            var match = ItemName.Match(data[17]);
            if (match.Success)
                item.Name = match.Groups[1].Value;
            item.MaxDurability = data[11];
            item.CurrentDurability = data[10];
            item.Stack = data[12];
            item.Rarity = (ItemRarity) int.Parse(data[14]);
            item.Identified = (int.Parse(data[9])%2) != 0;
            item.Print();
        }
    }

    class Item
    {
        public List<string> Affixes;
        public string Name;
        public bool Identified;
        public string MaxDurability;
        public string CurrentDurability;
        public ItemRarity Rarity;
        public string Stack;

        public void Print()
        {
            Console.WriteLine("-----{0}-----", Name);
            Console.WriteLine("Affixes: {0}", string.Join(", ", Affixes));
            Console.WriteLine("Identified: {0}", Identified);
            Console.WriteLine("Rarity: {0}", Rarity);
            Console.WriteLine("Durability: {0}/{1}", CurrentDurability, MaxDurability);
            Console.WriteLine("Stack: {0}", Stack);
        }
    }

    enum ItemRarity
    {
        Inferior = 0,
        White = 1,
        Superior = 2,
        Magic1 = 3,
        Magic2 = 4,
        Magic3 = 5,
        Rare4 = 6,
        Rare5 = 7,
        Rare6 = 8,
        LegendarySet1 = 9,
        LegendarySet2 = 10
    }
}
