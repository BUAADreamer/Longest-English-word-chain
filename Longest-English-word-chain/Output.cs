using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace Core
{
    public class Output
    {
        public Output()
        {
        }

        public string getOutputStr(List<string> wordChains, int outputMode)
        {
            string outputStr = "";
            if (outputMode == 0)
            {
                outputStr += wordChains.Count + "\n";
            }
            for (int i = 0; i < wordChains.Count; i++)
            {
                string wordChain = wordChains[i];
                outputStr += wordChain + "\n";
            }
            Console.WriteLine(outputStr);
            return outputStr;
        }

        public String printWordChains(List<string> wordChains, int outputMode)
        {
            string outputStr = getOutputStr(wordChains, outputMode);
            writeStrToFile(outputStr);
            return outputStr;
        }

        public void writeStrToFile(string outputStr)
        {
            string filePath = Path.GetFullPath("solution.txt");
            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(outputStr);
            sw.Flush();
            sw.Close();
        }
    }
}
