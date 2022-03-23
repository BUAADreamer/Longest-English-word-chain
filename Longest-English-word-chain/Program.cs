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
                "C:/Users/fzc/source/repos/Longest-English-word-chain/Longest-English-word-chain/TextFile2.txt";
            Console.WriteLine(path);
            WordListMaker maker = new WordListMaker();
            string article = maker.getArticleByPath(path);
            ArrayList wordList = maker.makeWordList(article);
            /*foreach (string word in wordList)
            {
                Console.WriteLine(word);
            }*/
            Num coreNum = new Num(wordList);
            ArrayList allWordChains = coreNum.getAllWordChains();
            Output output = new Output();
            output.printWordChains(allWordChains);
        }
        catch (Exception e)
        {
            Console.WriteLine("error");
        }
    }
}
