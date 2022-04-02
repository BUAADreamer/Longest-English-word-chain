using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
namespace Core
{
    class Program
    {
        static void Main(string[] args)
        {
            TestOneSample(args);
        }

        public static void TestOneSample(String[] args)
        {
            try
            {
                //string path = 
                //"C:/Users/dell/Desktop/Longest-English-word-chain/Longest-English-word-chain/TestFile5.txt";
                //string path = 
                //    "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile2.txt";
                // Console.WriteLine(path);
                //args = new String[] { "-n", "-r", "C:/Users/dell/Desktop/Longest-English-word-chain/Longest-English-word-chain/TestFile4.txt" };
                //args = new String[] { "-n","-r", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TestFile5.txt" };
                CommandParser parser = new CommandParser(args);
                ParseRes parseRes = parser.getParseRes();
                WordListMaker maker = new WordListMaker();
                string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
                ArrayList wordList = maker.makeWordList(article);
                CalcuCore core = new CalcuCore(wordList, parseRes);
                core.runByArgs();
            }
            catch (Exception e)
            {
                //Console.WriteLine(e.ToString());
                //Console.WriteLine("error");
                Console.WriteLine(e.Message);
            }
        }
    }
}
