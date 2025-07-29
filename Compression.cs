using System;
using System.Text;

public class Compression
{
    public static string Compress(string input)
    {
        if (string.IsNullOrEmpty(input))
            return string.Empty;

        StringBuilder compressed = new StringBuilder();
        char currentChar = input[0];
        int count = 1;

        for (int i = 1; i < input.Length; i++)
        {
            if (input[i] == currentChar)
            {
                count++;
            }
            else
            {
                compressed.Append(currentChar);
                if (count > 1)
                    compressed.Append(count);
                currentChar = input[i];
                count = 1;
            }
        }

        compressed.Append(currentChar);
        if (count > 1)
            compressed.Append(count);

        return compressed.ToString();
    }

    public static string Decompress(string compressed)
    {
        if (string.IsNullOrEmpty(compressed))
            return string.Empty;

        StringBuilder output = new StringBuilder();
        int index = 0;

        while (index < compressed.Length)
        {
            char c = compressed[index++];
            if (index < compressed.Length && char.IsDigit(compressed[index]))
            {
                int numStart = index;
                while (index < compressed.Length && char.IsDigit(compressed[index]))
                    index++;

                int count = int.Parse(compressed.Substring(numStart, index - numStart));
                output.Append(c, count);
            }
            else
            {
                output.Append(c);
            }
        }

        return output.ToString();
    }
}