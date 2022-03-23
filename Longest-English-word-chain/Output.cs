using System;
using System.Collections;
public class Output
{
	public Output()
	{
	}

    public void printWordChains(ArrayList wordChains)
    {
        Console.WriteLine(wordChains.Count);
        for (int i = 0; i < wordChains.Count; i++)
        {
            string wordChain = (string) wordChains[i];
            Console.WriteLine(wordChain);
        }
    }
}
