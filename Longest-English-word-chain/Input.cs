using System.Collections;
using System.IO;
using System;
using System.Collections.Generic;

public class WordListMaker
{
    public WordListMaker()
    {

    }

    public string getArticleByPath(string path)
    {
        string res = "";
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
            Console.WriteLine(e.Message);
        }
        return res;
    }

    public ArrayList makeWordList(string article)
    {
        
        ArrayList wordList = new ArrayList();
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
            if (currentWord != "" && currentWord.Length>1)
            {
                wordList.Add(currentWord.ToLower());
            }
        }
        return wordList;
    }
}

public class CommandParser
{
    //mode checkLoop start end
    int mode = 0; //最长的模式 0表示单词数量 1表示字母个数
    bool checkLoop = false;
    char start;
    char end;
    string output_path = "";
    bool nFlag = false;
    bool wFlag = false;
    bool mFlag = false;
    bool cFlag = false;
    bool hflag = false;
    bool tflag = false;
    bool rflag = false;
    ArrayList validCmdChars = new ArrayList(){ 'n', 'w', 'm', 'c', 'h', 't', 'r' };
    Hashtable char2ap = new Hashtable();
    Hashtable validCharPair = new Hashtable(); //validCharPair['n']['w']=false;
    public CommandParser(string[] args)
    {
        parseCommand(args);
    }

    private void init()
    {
        foreach(char c1 in validCmdChars)
        {
            validCharPair.Add(c1, new Hashtable());
            foreach(char c2 in validCmdChars)
            {
                if (c1 == c2)
                {
                    ((Hashtable)validCharPair[c1]).Add(c2, false);
                }
                if (c1 == 'n')
                {
                    if(c2=='h' || c2=='t' || c2 == 'r')
                    {
                        ((Hashtable)validCharPair[c1]).Add(c2, true);
                    }
                    else
                    {
                        ((Hashtable)validCharPair[c1]).Add(c2, false);
                    }
                }
                if (c1 == 'w')
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
                if (c1 == 'm')
                {
                    ((Hashtable)validCharPair[c1]).Add(c2, false);
                }
                if (c1 == 'c')
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
                if (c1 == 'h')
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
                if (c1 == 't')
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
                if (c1 == 'r')
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
        while (pos < args.Length)
        {
            if (args[pos].Length>=1 && args[pos][0] == '-')
            {
                if(args[pos].Length!=2 || !validCmdChars.Contains(args[pos][1]))
                {
                    throw new CommandInvalidException("invalid arg at pos " + pos);
                }
                char c = args[pos][1];
                if (char2ap.ContainsKey(c))
                {
                    throw new CommandComplexException(string.Format("{0} and {1}", c, c));
                }
                char2ap.Add(c, 1);
                if (c == 'h' || c == 't')
                {
                    if (pos + 1 >= args.Length || args[pos + 1].Length != 1 || Char.IsLetter(args[pos + 1][0]))
                    {
                        throw new CommandInvalidException("invalid arg behind pos " + pos);
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
                }
                if (c == 'r')
                {
                    checkLoop = true;
                }
                if (c == 'w' || c == 'm' || c == 'c')
                {
                    mode = 0;
                }
                else
                {
                    mode = 1;
                }
            }
            else
            {
                if (pos != args.Length - 1)
                {
                    throw new CommandInvalidException("invalid arg at pos " + pos);
                }
                output_path = args[pos];
            }
        }
        foreach(char c1 in char2ap.Keys)
        {
            foreach (char c2 in char2ap.Keys)
            {
                if ((bool)((Hashtable)validCharPair[c1])[c2]==false)
                {
                    throw new CommandComplexException(string.Format("{0} and {1}", c1, c2));
                }
            }
        }
    }
    
}
