using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.cli.handlers
{
    class InputHandler
    {
        // For an array of inputs with a given message,
        // prompt and parse user for all inputs and return array of strings;
        public static string[] GetInputs(string[] inputs, string command = "\n")
        {
            Console.WriteLine(command);
            string[] outputs = new string[inputs.Length];

            int i = 0;
            foreach (string inputLabel in inputs)
            {
                Console.Write($"{inputLabel}:");
                outputs[i] = Console.ReadLine();
                i++;
            }

            return outputs;
        }
    }
}
