using System;
using System.Collections;
public class Output
{
	public Output()
	{
	}

    public void printWordChains(ArrayList wordChains, int outputMode)
    {
        if (outputMode == 0)
        {
            Console.WriteLine(wordChains.Count);
        } 
        for (int i = 0; i < wordChains.Count; i++)
        {
            string wordChain = (string) wordChains[i];
            Console.WriteLine(wordChain);
        }
    }
}
