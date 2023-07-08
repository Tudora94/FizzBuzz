using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace FizzBuzz
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigArray CA = new ConfigArray();
            //Identify if file already exists for fizzBuzz config
            string FilePath = Environment.ExpandEnvironmentVariables("%USERPROFILE%\\Documents\\FizzBuzzConfig.JSON");

            bool AddNewValue = false;

            if (File.Exists(FilePath)
)
            {
                string JsonContent = File.ReadAllText(FilePath);
                if (JsonContent.Length > 0)
                {
                    CA = JsonSerializer.Deserialize<ConfigArray>(JsonContent);
                }
                    
            }

            if (CA.Configs.Count > 0)
            {
                //print each object as a line
                CA.displayList();

                Console.WriteLine("press \'y\' to add/ edit lines");
                String res = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.Clear();

                if (res == "Y")
                    AddNewValue = true;
            }
            else
            {
                Console.WriteLine("There is currently no Config, please add some...");
                AddNewValue = true;
            }

            if(AddNewValue)
            {
                while (AddNewValue)
                {
                    Console.WriteLine("Please enter a Number");
                    var factor = Console.ReadLine();
                    Console.WriteLine("Please enter a Keyword");
                    var keyword = Console.ReadLine();
                    Console.Clear();

                    if(CA.addConfig(factor, keyword))
                    {
                        Console.WriteLine($"{factor} and {keyword} have been added successfully, would you like to add another? [Y]");
                        String response = Console.ReadKey().KeyChar.ToString().ToUpper();
                        Console.Clear();
                        
                        if (response != "Y")
                            AddNewValue = false;

                    }
                    else
                    {
                        Console.WriteLine("incorrect syntax, unable to add, please try again");
                    }
                }

            }
            //write object to Json to save.
            var jsonInput = JsonSerializer.Serialize(CA);
            File.WriteAllText(FilePath, jsonInput);

            Console.ReadLine();
        }
    }
}
