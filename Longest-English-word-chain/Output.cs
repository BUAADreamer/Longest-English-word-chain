using System;
using System.Collections;
using System.IO;
namespace Core
{
    public class Output
    {
        public Output()
        {
        }

        public void printWordChains(ArrayList wordChains, int outputMode)
        {
            string outputStr = "";
            if (outputMode == 0)
            {
                Console.WriteLine(wordChains.Count);
                outputStr += wordChains.Count + "\n";
            }
            for (int i = 0; i < wordChains.Count; i++)
            {
                string wordChain = (string)wordChains[i];
                Console.WriteLine(wordChain);
                outputStr += wordChain + "\n";
            }
            string filePath = Path.GetFullPath("solution.txt");
            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(outputStr);
            sw.Flush();
            sw.Close();
        }
    }
}
