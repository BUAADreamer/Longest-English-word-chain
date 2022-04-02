using System;
using System.Collections;

namespace Core
{
    public class PairTestInterface
    {
        public PairTestInterface()
        {
        }

        public static string Solve(string[] args)
        {
            try
            {
                CommandParser parser = new CommandParser(args);
                ParseRes parseRes = parser.getParseRes();
                WordListMaker maker = new WordListMaker();
                string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
                ArrayList wordList = maker.makeWordList(article);
                CalcuCore core = new CalcuCore(wordList, parseRes);
                return core.runByArgs();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return "";
        }
    }
}
