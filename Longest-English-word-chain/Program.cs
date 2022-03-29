using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string path = 
                "C:/Users/dell/Desktop/Longest-English-word-chain/Longest-English-word-chain/TextFile5.txt";
            //string path = 
            //    "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt";
            // Console.WriteLine(path);
            CommandParser parser = new CommandParser(args);
            ParseRes parseRes = parser.getParseRes();
            WordListMaker maker = new WordListMaker();
            string article = maker.getArticleByPath(path);
            ArrayList wordList = maker.makeWordList(article);
            ArrayList res = new ArrayList();
            HashSet<char> parameters = parseRes.cmdChars;
            ZcxCore core = new ZcxCore(wordList, parseRes.mode);
            if (parameters.Contains('n'))
            {   
                core.getAllWordChains(parseRes.start, parseRes.end, parseRes.enableLoop, res);
            }
            else if (parameters.Contains('w')) 
            {
                core.getMaxWordCountChain(
                    parseRes.start, parseRes.end, parseRes.enableLoop, res);
            }
            else if (parameters.Contains('m'))
            {
                core.getMaxWordCountChainWithDifferentHead(res);
            }
            else if (parameters.Contains('c'))
            {
                core.getMaxAlphabetCountChain(
                    parseRes.start, parseRes.end, parseRes.enableLoop, res);
            }
            else 
            {
                Console.WriteLine("Invalid parameter!");
            }
            Output output = new Output();
            int outputMode = 1;
            if (parameters.Contains('n'))
            {
                outputMode = 0;
            }
            output.printWordChains(res, outputMode);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.ToString());
            Console.WriteLine("error");
        }
    }
}
