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
            bool DeleteValue = false;

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
                CA.displayList();

                Console.WriteLine("press [A] to add/ edit lines or [D] to delete, any other button to continue");
                String res = Console.ReadKey().KeyChar.ToString().ToUpper();
                Console.Clear();

                if (res == "A")
                {
                    AddNewValue = true;
                }
                else if (res == "D")
                {
                    DeleteValue = true;
                }

            }
            else
            {
                Console.WriteLine("There is currently no Config, please add some...");
                AddNewValue = true;
            }

            if (DeleteValue)
            {
                while (DeleteValue)
                {
                    //Method for deleting value.
                    DeleteValue = CA.deleteConfigLoop();
                }
                //check if they now want to add a value, if the list is empty force them to
                if(CA.Configs.Count == 0)
                {
                    Console.WriteLine("the list is empty, you must now add values");
                    AddNewValue = true;
                }
                else
                {
                    Console.WriteLine("would you like to add values [Y]");
                    String response = Console.ReadKey().KeyChar.ToString().ToUpper();
                    Console.Clear();

                    if (response == "Y")
                        AddNewValue = true;
                }

            }

            if(AddNewValue)
            {
                while (AddNewValue)
                {
                    AddNewValue = CA.addConfigLoop();
                }

            }

            var jsonInput = JsonSerializer.Serialize(CA);
            File.WriteAllText(FilePath, jsonInput);
            Console.WriteLine("Object written to Json");
            Console.ReadLine();

            //do the fizzBuzz
            Console.Clear();
            Console.WriteLine("Enter Max value to count to");
            bool validValue = false;
            var maxi = 0;

            while (!validValue)
            {
                if (int.TryParse(Console.ReadLine(), out maxi))
                    validValue = true;
            }
            Console.Clear();
            fizzBuzzLogic fb = new fizzBuzzLogic();
            fb.FizzBuzz(CA, maxi);
            Console.ReadLine();
        }
    }
}
