using System;
using System.IO;
using System.Collections;
class Program
{
    static void Main(string[] args)
    {
        try
        {
            string path = 
                "C:/Users/dell/Desktop/Longest-English-word-chain/Longest-English-word-chain/TextFile1.txt";
            //string path = 
            //    "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt";
            // Console.WriteLine(path);
            WordListMaker maker = new WordListMaker();
            string article = maker.getArticleByPath(path);
            ArrayList wordList = maker.makeWordList(article);
            /*foreach (string word in wordList)
            {
                Console.WriteLine(word);
            }*/
            /*
            Num coreNum = new Num(wordList);
            ArrayList allWordChains = coreNum.getAllWordChains();
            Output output = new Output();
            output.printWordChains(allWordChains);
            */
            ZcxCore core = new ZcxCore(wordList, 0);
            ArrayList res = new ArrayList();
            // Console.WriteLine(core.getMaxAlphabetCountChain(res));
            // core.getAllWordChains('0', '0', true, res);
            // Output output = new Output();
            // output.printWordChains(res);
            Console.WriteLine(core.getMaxAlphabetCountChain('a', '0', true));
        }
        catch (Exception e)
        {
            Console.WriteLine("error");
        }
    }
}
