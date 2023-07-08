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
    }
}
