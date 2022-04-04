using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;
namespace Library
{
    public class WordListMaker
    {
        public WordListMaker()
        {

        }

        public string getArticleByPath(string path)
        {
            string res = "";
            if (!path.EndsWith(".txt"))
            {
                throw new FileInvalidException("file must be end with .txt!!");
            }
            try
            {
                StreamReader reader = new StreamReader(path);
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    res += line;
                    res += " ";
                }
            }
            catch (Exception e)
            {
                throw new FileInvalidException("[" + path + "]" + " is invalid!!");
            }
            return res;
        }

        public List<string> makeWordList(string article)
        {
            HashSet<string> wordSet = new HashSet<string>();
            List<string> wordList = new List<string>();
            int len = article.Length;
            int pos = 0;
            article = article.ToLower();
            while (pos < len)
            {
                while (pos < len)
                {
                    if (article[pos] < 'a' || article[pos] > 'z')
                    {
                        pos++;
                    }
                    else
                    {
                        break;
                    }
                }

                string currentWord = "";
                while (pos < len)
                {
                    if (article[pos] >= 'a' && article[pos] <= 'z')
                    {
                        currentWord += article[pos];
                        pos++;
                    }
                    else
                    {
                        break;
                    }
                }
                if (currentWord != "" && currentWord.Length > 1)
                {
                    wordSet.Add(currentWord.ToLower());
                }
            }
            foreach (string word in wordSet)
            {
                wordList.Add(word);
            }
            return wordList;
        }
    }

    public class CommandParser
    {
        //mode enableLoop start end
        int mode = 0; //最长的模式 0表示单词数量 1表示字母个数
        bool enableLoop = false;
        char start = '0';
        char end = '0';
        string absolutePathOfWordList = "";
        ParseRes parseRes;
        HashSet<char> cmdChars = new HashSet<char>();
        ArrayList validCmdChars = new ArrayList() { 'n', 'w', 'm', 'c', 'h', 't', 'r' };
        Hashtable char2ap = new Hashtable();
        Hashtable validCharPair = new Hashtable(); //validCharPair['n']['w']=false;
        public CommandParser(string[] args)
        {
            init();
            parseCommand(args);
            parseRes = new ParseRes(mode, enableLoop, start, end, absolutePathOfWordList, cmdChars);
        }

        public CommandParser()
        {
            init();
        }

        private void init()
        {
            foreach (char c1 in validCmdChars)
            {
                validCharPair.Add(c1, new Hashtable());
                foreach (char c2 in validCmdChars)
                {

                    if (c1 == c2)
                    {
                        ((Hashtable)validCharPair[c1]).Add(c2, false);
                    }
                    else if (c1 == 'n')
                    {
                        /*
                        if (c2 == 'h' || c2 == 't' || c2 == 'r')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }*/
                        ((Hashtable)validCharPair[c1]).Add(c2, false);
                    }
                    else if (c1 == 'w')
                    {
                        if (c2 == 'h' || c2 == 't' || c2 == 'r')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }
                    }
                    else if (c1 == 'm')
                    {
                        ((Hashtable)validCharPair[c1]).Add(c2, false);
                    }
                    else if (c1 == 'c')
                    {
                        if (c2 == 'h' || c2 == 't' || c2 == 'r')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }
                    }
                    else if (c1 == 'h')
                    {
                        if (c2 == 'm' || c2 == 'h')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                    }
                    else if (c1 == 't')
                    {
                        if (c2 == 'm' || c2 == 't')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                    }
                    else if (c1 == 'r')
                    {
                        if (c2 == 'm' || c2 == 'r')
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, false);
                        }
                        else
                        {
                            ((Hashtable)validCharPair[c1]).Add(c2, true);
                        }
                    }
                }
            }
        }

        public void parseCommand(string[] args)
        {
            int pos = 0;
            bool hasMainCmdChar = false;
            while (pos < args.Length)
            {
                if (args[pos].Length >= 1 && args[pos][0] == '-')
                {
                    if (args[pos].Length != 2 || !validCmdChars.Contains(args[pos][1]))
                    {
                        throw new CommandInvalidException("invalid arg at pos " + pos + ", should be like: -n");
                    }
                    char c = args[pos][1];
                    if (char2ap.ContainsKey(c))
                    {
                        throw new CommandComplexException(string.Format("{0} and {1} command is complex!!", c, c));
                    }
                    char2ap.Add(c, 1);
                    if (c == 'h' || c == 't')
                    {
                        if (pos + 1 >= args.Length || args[pos + 1].Length != 1 || !Char.IsLetter(args[pos + 1][0]))
                        {
                            throw new CommandInvalidException("invalid arg behind cmd " + c + " at pos " + pos + ", need to add a lower letter");
                        }
                        char beginOrEnd = Char.ToLower(args[pos + 1][0]);
                        if (c == 'h')
                        {
                            start = beginOrEnd;
                        }
                        else
                        {
                            end = beginOrEnd;
                        }
                        pos += 1;
                    }
                    if (c == 'r')
                    {
                        enableLoop = true;
                    }
                    if (c == 'w' || c == 'm' || c == 'c')
                    {
                        hasMainCmdChar = true;
                        mode = 0;
                    }
                    else
                    {
                        hasMainCmdChar = true;
                        mode = 1;
                    }
                    pos += 1;
                }
                else
                {
                    if (pos != args.Length - 1)
                    {
                        throw new CommandInvalidException("invalid arg at pos " + pos + ",file path should be at the end!!");
                    }
                    absolutePathOfWordList = args[pos];
                    pos += 1;
                }
            }
            if (!hasMainCmdChar)
            {
                throw new CommandInvalidException("lack main cmd char : n/w/m/c");
            }
            foreach (char c1 in char2ap.Keys)
            {
                cmdChars.Add(c1);
                foreach (char c2 in char2ap.Keys)
                {
                    if ((bool)((Hashtable)validCharPair[c1])[c2] == false && c1 != c2)
                    {
                        throw new CommandComplexException(string.Format("{0} and {1} command is conflict!!!", c1, c2));
                    }
                }
            }
        }

        public ParseRes getParseRes()
        {
            return parseRes;
        }

        public Hashtable getValidCharPair()
        {
            return validCharPair;
        }

    }

    public class ParseRes
    {
        public bool enableLoop = false;
        public char start;
        public char end;
        public string absolutePathOfWordList = "";
        public int mode = 0; //最长的模式 0表示单词数量 1表示字母个数
        public HashSet<char> cmdChars;
        public ParseRes(int mode, bool enableLoop, char start, char end, string absolutePathOfWordList, HashSet<char> cmdChars)
        {
            this.enableLoop = enableLoop;
            this.mode = mode;
            this.start = start;
            this.end = end;
            this.absolutePathOfWordList = absolutePathOfWordList;
            this.cmdChars = cmdChars;
        }
    }
}
