using System;
using System.Collections.Generic;

public class TextToNumber
{
    // این دیکشنری شامل حروف و علائم خاص است
    private static readonly Dictionary<char, int> charToNumber = new Dictionary<char, int>
    {
        {'a', 1}, {'b', 2}, {'c', 3}, {'d', 4}, {'e', 5}, {'f', 6}, {'g', 7}, {'h', 8}, {'i', 9},
        {'j', 10}, {'k', 11}, {'l', 12}, {'m', 13}, {'n', 14}, {'o', 15}, {'p', 16}, {'q', 17},
        {'r', 18}, {'s', 19}, {'t', 20}, {'u', 21}, {'v', 22}, {'w', 23}, {'x', 24}, {'y', 25},
        {'z', 26},
        {' ', 27}, 
        {'.', 28}, 
        {',', 29}, 
        {'!', 30}, 
        {'?', 31}, 
        {'"', 32}, 
        {'-', 33},
       
    };

    // تبدیل متن به لیستی از اعداد
    public static int[] ConvertTextToNumbers(string text)
    {
        text = text.ToLower(); // تبدیل متن به حروف کوچک
        List<int> numbers = new List<int>();

        foreach (char c in text)
        {
            if (charToNumber.ContainsKey(c))
            {
                numbers.Add(charToNumber[c]);
            }
        }

        return numbers.ToArray();
    }

    // تبدیل اعداد به متن
    public static string ConvertNumbersToText(IEnumerable<int> numbers)
    {
        Dictionary<int, char> numberToChar = charToNumber.ToDictionary(x => x.Value, x => x.Key);
        return string.Concat(numbers.Select(n => numberToChar.ContainsKey(n) ? numberToChar[n].ToString() : ""));
    }
}