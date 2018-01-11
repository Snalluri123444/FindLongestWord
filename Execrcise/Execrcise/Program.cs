using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using System.Linq;

public class Program
{
    static List<string> trie = new List<string>();
    public static void Main(string[] args)
    {
        string data = File.ReadAllText("wordlist.txt");
        string[] stringrray = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
        List<string> tempList = new List<string>(stringrray);
        List<string> Finallist = new List<string>();
        char[] smallstrchar = String.Join("", tempList.Where(x => x.Length <= 4)).ToCharArray();
        char[] bigstrchar = String.Join("", tempList.Where(x => x.Length > 4)).ToCharArray();
        char[] modchar = bigstrchar.Except(smallstrchar).ToArray();

        foreach (string bigstr in tempList)
        {
            if (!(bigstr.IndexOfAny(modchar) != -1))
            {
                Finallist.Add(bigstr);
            }
        }
        Finallist = Finallist.OrderByDescending(x => x.Length).Take(2).ToList();
        foreach (string word in Finallist)
        {
            Console.WriteLine(word + " at "+ word.Length+ " letters");
        }

      
    }

}