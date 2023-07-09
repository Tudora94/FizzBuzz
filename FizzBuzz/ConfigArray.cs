using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class ConfigArray
    {
        private List<ConfigModel> configs = new List<ConfigModel>();
        private List<int> integerIndex = new List<int>();

        public List<int> IntegerIndex { get => integerIndex; set => integerIndex = value; }
        public List<ConfigModel> Configs { get => configs; set => configs = value; }

        public bool addConfig(string factor, string keyword)
        {
            int factorInt = 0;
            if(int.TryParse(factor, out factorInt))
            {
                ConfigModel CM = new ConfigModel(factorInt, keyword);

                if (IntegerIndex.Contains(factorInt))
                {
                    var IntegerPos = IntegerIndex.IndexOf(factorInt);
                    Configs[IntegerPos] = CM;
                }
                else
                {
                    Configs.Add(CM);
                    IntegerIndex.Add(factorInt);
                }
                return true;
            }
            return false;

        }
        public void displayList()
        {
            foreach(ConfigModel CM in Configs)
            {
                Console.WriteLine($"Factor {CM.Factor} has keyword {CM.KeyWord}");
            }
        }

        public bool addConfigLoop()
        {
            bool ret = true;
            Console.WriteLine("Please enter a Number");
            var factor = Console.ReadLine();
            Console.WriteLine("Please enter a Keyword");
            var keyword = Console.ReadLine();
            Console.Clear();

            if (addConfig(factor, keyword))
            {
                Console.WriteLine($"{factor} and {keyword} have been added successfully, would you like to add another? [Y]");
                String response = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.Clear();

                if (response != "Y")
                    ret = false;

            }
            else
            {
                Console.WriteLine("incorrect syntax, unable to add, please try again");
            }
            return ret;
        }

        public bool deleteConfigLoop()
        {
            bool ret = true; ;

            Console.WriteLine("Enter number to Delete, this cannot be undone.");
            var value = Console.ReadLine();

            if (deleteConfig(value))
            {
                Console.WriteLine("Value has been deleted, would you like to delete another. [Y]");
            }
            else
            {
                Console.WriteLine("value not found, try again? [Y]");
            }

            String response = Console.ReadKey().KeyChar.ToString().ToUpper();
            Console.Clear();

            if (response != "Y")
                ret = false;

            if (IntegerIndex.Count == 0)
                ret = false;


            return ret;

        }

        private bool deleteConfig(string valueStr)
        {
            bool ret = false;
            int value = 0;
            if (int.TryParse(valueStr, out value))
            {
                if (IntegerIndex.Contains(value))
                {
                    //delete the indexed location in both lists.
                    int index = IntegerIndex.IndexOf(value);
                    IntegerIndex.RemoveAt(index);
                    Configs.RemoveAt(index);
                    ret = true;
                }
            }
            return ret;

        }
    }
}
