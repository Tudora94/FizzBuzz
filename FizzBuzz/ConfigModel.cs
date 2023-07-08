using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FizzBuzz
{
    class ConfigModel
    {

        public ConfigModel()
        {
        }
        public ConfigModel(int factor, string keyWord)
        {
            this.factor = factor;
            this.keyWord = keyWord;
        }

        private int factor;
        private string keyWord;

        public int Factor { get => factor; set => factor = value; }
        public string KeyWord { get => keyWord; set => keyWord = value; }
    }
}
