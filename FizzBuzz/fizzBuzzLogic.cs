using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class fizzBuzzLogic
    {
        public void FizzBuzz(ConfigArray CA, int maxI)
        {
            //create new ordered integerIndexList
            var orderedList = CA.IntegerIndex.OrderBy(v => v).ToList();

            for(int i = 1; i <= maxI; i++)
            {
                string output = "";
                foreach(int val in orderedList)
                {
                    int index = CA.IntegerIndex.IndexOf(val);
                    var conf = CA.Configs[index];

                    if(i % conf.Factor == 0)
                    {
                        output += conf.KeyWord;
                    }

                }
                if (output.Length == 0)
                    output = i.ToString();
                Console.WriteLine(output);
            }

        }
    }
}
