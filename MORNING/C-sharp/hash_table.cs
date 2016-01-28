using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication2
{
    class HashTable<TKey, TValue> {
        private List<Dictionary<TKey, TValue>> table;
        private int tableSize, count;

        public HashTable(int N) {
            tableSize = N * 3;
            table = new List<Dictionary<TKey, TValue>> (tableSize);
            for (int i = 0; i < tableSize; i++) {
                table.Add(null);
            }
            count = 0;
        }

        public void print() {
            foreach (var line in table) {
                if (line != null) {
                    foreach (var unit in line) {
                        Console.WriteLine(unit.Key + " " + unit.Value);
                    }
                }
            }
        }

        public TValue this[TKey key] {
            set
            {
                int hashCode = key.GetHashCode();
                int i = Math.Abs(hashCode) % tableSize;

                 if (table[i] == null) {
                    table[i] = new Dictionary<TKey, TValue>();
                    table[i][key] = value;
                }
                else {
                    table[i].Add(key, value);
                    ++count;
                }
            }

            get
            {
                int hashCode = key.GetHashCode();
                int i = Math.Abs(hashCode) % tableSize;

                if (table[i] != null && table[i].ContainsKey(key)) {
                    return table[i][key];
                }
                throw new IndexOutOfRangeException("In HashTable, get: there's not the key in hash table!");
            }
        }

        public void delete(TKey key) {
            int hashCode = key.GetHashCode();
            int i = Math.Abs(hashCode) % tableSize;
            if (table[i] != null && table[i].ContainsKey(key)) {
                table[i].Remove(key);
                --count;
            }
            else
                throw new ArgumentNullException("In HashTable, delete: there's no such key in the hashtable!");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            HashTable<string, string> hash = new HashTable<string, string>(10);

            hash["Вася"] = "Иванов";
            hash["Дмитрий"] = "Сорокин";
            hash["Екатерина"] = "Карпова";
            hash["Мария"] = "Довгаль";

            hash.print();
            Console.WriteLine(" ");

            hash.delete("Екатерина");
            hash.print();

            Console.ReadKey();
        }
    }
}
