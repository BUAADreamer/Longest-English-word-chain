using System.Collections;
using System.IO;
using System;

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
