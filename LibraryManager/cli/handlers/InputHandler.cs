using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryManager.cli.handlers
{
    class InputHandler
    {
        /// <summary>
        /// Prompt and parse user for all inputs.
        /// </summary>
        /// <param name="inputs">Input labels</param>
        /// <param name="command">Line to display before inputs</param>
        /// <returns></returns>
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

        // Overload method for a single input.
        public static string GetInputs(string inputs, string command = "\n")
        {
            Console.WriteLine(command);
            Console.Write($"{inputs}:");
            string input = Console.ReadLine();
            return input;
        }
    }
}
