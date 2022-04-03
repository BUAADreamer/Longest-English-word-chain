using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using Library;
using Core;
class Program
{
    static void Main(string[] args)
    {
        //CoreType:0 使用我们的Core
        //CoreType:1 使用交换的Core
        int CoreType = 0;
        if (CoreType == 0)
        {
            Solve(args, "");
        }
        else
        {
            
        }
    }
    public static string Solve(string[] args, string inputArticle)
    {
        try
        {
            CommandParser parser = new CommandParser(args);
            ParseRes parseRes = parser.getParseRes();
            WordListMaker maker = new WordListMaker();
            string article = inputArticle;
            if (article == "")
            {
                article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
            }
            List<string> wordList = maker.makeWordList(article);
            List<string> result = new List<string>();
            PairTestInterface.gen_chain_word(wordList, result, parseRes.start, parseRes.end, parseRes.enableLoop);
            Output output = new Output();
            return output.printWordChains(result, 1);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return "";
    }
}

