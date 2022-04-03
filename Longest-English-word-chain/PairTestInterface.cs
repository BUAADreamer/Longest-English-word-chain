using System;
using System.Collections;
using System.Collections.Generic;

namespace Core
{
    public class PairTestInterface
    {
        public PairTestInterface()
        {
        }

        private static void checkResultLength(List<string> result)
        {
            int len = 0;
            const int MAXLEN = 20000;
            foreach (string str in result)
            {
                len += str.Length;
            }
            if (len > MAXLEN)
            {
                throw new ResultTooLongException("The result length is " + len);
            }
        }

        public static int gen_chain_word(List<string> words, List<string> result,
            char head, char tail, bool enable_loop)
        {
            CalcuCore core = new CalcuCore(words, head, tail, enable_loop, 0);
            core.getMaxAlphabetCountChain(head, tail, enable_loop, result);
            try 
            {
                checkResultLength(result);
            }
            catch (ResultTooLongException e)
            {
                result.Clear();
                Console.WriteLine(e.Message);
            }
            return result.Count;
        }

        public static int gen_chains_all(List<string> words, List<string> result)
        {
            CalcuCore core = new CalcuCore(words, '0', '0', false, 0);
            core.getAllWordChains('0', '0', false, result);
            try 
            {
                checkResultLength(result);
            }
            catch (ResultTooLongException e)
            {
                result.Clear();
                Console.WriteLine(e.Message);
            }
            return result.Count;
        }

        public static int gen_chain_word_unique(List<string> words, List<string> result)
        {
            CalcuCore core = new CalcuCore(words, '0', '0', false, 0);
            core.getMaxWordCountChainWithDifferentHead(result);
            try 
            {
                checkResultLength(result);
            }
            catch (ResultTooLongException e)
            {
                result.Clear();
                Console.WriteLine(e.Message);
            }
            return result.Count;
        }

        public static int gen_chain_char(
            List<string> words, List<string> result, char head, char tail, bool enable_loop)
        {
            CalcuCore core = new CalcuCore(words, head, tail, enable_loop, 1);
            core.getMaxAlphabetCountChain(head, tail, enable_loop, result);
            try 
            {
                checkResultLength(result);
            }
            catch (ResultTooLongException e)
            {
                result.Clear();
                Console.WriteLine(e.Message);
            }
            return result.Count;
        }

        public static string Solve(string[] args)
        {
            try
            {
                CommandParser parser = new CommandParser(args);
                ParseRes parseRes = parser.getParseRes();
                WordListMaker maker = new WordListMaker();
                string article = maker.getArticleByPath(parseRes.absolutePathOfWordList);
                List<string> wordList = maker.makeWordList(article);
                List<string> result = new List<string>();
                gen_chain_word(wordList, result, parseRes.start, parseRes.end, parseRes.enableLoop);
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
