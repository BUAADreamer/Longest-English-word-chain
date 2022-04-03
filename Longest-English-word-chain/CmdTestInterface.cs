using System;
using System.Collections.Generic;
using Core;
using Library;
namespace Cmd
{
	public class CmdTestInterface
	{
		public CmdTestInterface()
		{
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
}

