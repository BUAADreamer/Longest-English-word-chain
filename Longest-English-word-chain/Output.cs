using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
namespace Library
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
            if (outputMode == 1 && wordChains.Count < 2)
            {
                return outputStr;
            }
            for (int i = 0; i < wordChains.Count; i++)
            {
                string wordChain = wordChains[i];
                outputStr += wordChain + "\n";
            }
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
            string filePath = Path.GetFullPath("me.txt");
            StreamWriter sw = new StreamWriter(filePath, false);
            sw.Write(outputStr);
            sw.Flush();
            sw.Close();
        }
    }
}
