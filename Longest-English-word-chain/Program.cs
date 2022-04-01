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
            try
            {
                //string path = 
                //"C:/Users/dell/Desktop/Longest-English-word-chain/Longest-English-word-chain/TextFile5.txt";
                //string path = 
                //    "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt";
                // Console.WriteLine(path);
                //args = new String[] { "-n", "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile1.txt" };
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
