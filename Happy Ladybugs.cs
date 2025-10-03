using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

class Result
{

    /*
     * Complete the 'happyLadybugs' function below.
     *
     * The function is expected to return a STRING.
     * The function accepts STRING b as parameter.
     */

    public static string happyLadybugs(string b)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        bool hasEmpty = false;

        foreach (char ch in b)
        {
            if (ch == '_')
            {
                hasEmpty = true;
            }
            else
            {
                if (!freq.ContainsKey(ch))
                    freq[ch] = 0;
                freq[ch]++;
            }
        }


        if (!hasEmpty)
        {
            for (int i = 0; i < b.Length; i++)
            {
                bool leftSame = (i > 0 && b[i] == b[i - 1]);
                bool rightSame = (i < b.Length - 1 && b[i] == b[i + 1]);

                if (!leftSame && !rightSame)
                    return "NO";
            }
            return "YES";
        }


        foreach (var kvp in freq)
        {
            if (kvp.Value == 1)
                return "NO";
        }

        return "YES";

    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int g = Convert.ToInt32(Console.ReadLine().Trim());

        for (int gItr = 0; gItr < g; gItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            string b = Console.ReadLine();

            string result = Result.happyLadybugs(b);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
