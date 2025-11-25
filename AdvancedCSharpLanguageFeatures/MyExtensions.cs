using System;
using System.Collections;

namespace AdvancedCSharpLanguageFeatures;

static class MyExtensions
{
    // now all string types has access to this method
    public static void PrintUpper(this string str)
    {
        Console.WriteLine(str.ToUpper());
    }
    
    // now all int type has this member
    public static int ReverseDigits(this int num)
    {
        char[] chars = num.ToString().ToCharArray();
        char[] reversedChars = new char[chars.Length];
        for(int i = chars.Length; i>0; i--)
        {
            reversedChars[chars.Length-i]=chars[i-1];
        }
        // or use Array.Reverse(chars);
        string reversed = new(reversedChars);
        int result = int.Parse(reversed);
        return result;
    }

    // extending types that implement certain interface
    public static void PrintDataAndBeep(this IEnumerable iterator)
    {
        foreach(var item in iterator)
        {
            Console.WriteLine(item);
            Console.WriteLine("BEEP");
        }
    }
}
