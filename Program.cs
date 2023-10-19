using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace World_Word
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Please enter a sentence: ");
            string sentence = Console.ReadLine().ToLower();
            
            for (int i = 0; i < sentence.Length; i++)
            {
                char puncCheck = sentence[i];
                if (char.IsPunctuation(puncCheck))
                {
                    sentence = sentence.Replace(puncCheck, ' '); 
                }
                else if (puncCheck == '$' || puncCheck == '^' || puncCheck == '+' || puncCheck == '=' || puncCheck == '>' || puncCheck == '<' || puncCheck == '|' || puncCheck == '~' || puncCheck == '`')
                {
                    sentence = sentence.Replace(puncCheck, ' ');
                } 
            }
            sentence = sentence.Replace("  ", " ");
            sentence = sentence.Trim();
            string[] words = sentence.Split(' ');
            string temp = null;
            for (int i = 0; i < words.Length; i++)
            {
                int counter = 0;
                temp = words[i];
                for (int j = 0; j < words.Length; j++)
                {
                    if (words[j] == temp)
                    {
                        counter++;
                    }
                    if (counter > 1)
                    {
                        words[i] = null;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine("Plaese enter a pattern");
            string pattern = Console.ReadLine().ToLower();
            bool flag = false;
            while (!flag)
            {
                if (!(pattern.Contains('*') || pattern.Contains('-')))
                {
                    flag = true;
                    Console.WriteLine("The pattern should contain one of - or * symbols!!");
                }
                else if (pattern.Contains('*') && pattern.Contains('-'))
                {
                    flag = true;
                    Console.WriteLine("The pattern can't contain both of - or * symbols!!");
                }
                int starCount = 0;
                for (int i = 0; i < pattern.Length; i++)
                {
                    if (pattern[i] == '*')
                    {
                        starCount++;
                    }
                }
                if (pattern.Length == starCount && pattern.Length > 1)
                {
                    flag = true;
                    Console.WriteLine("All of the pattern characters can't be * !!!");
                }
                if (flag)
                {
                    flag = false;
                    pattern = Console.ReadLine().ToLower();
                }
                else
                {
                    break;
                }
            }
            Console.WriteLine();
            if (pattern.Contains('*'))
            {
                if (pattern.Length == 1)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != null)
                        {
                            Console.WriteLine(words[i]);
                        }
                    }
                }
                else
                {
                    string starPatternletters = null;
                    bool check2 = false;
                    char[] patLetters = pattern.ToCharArray();
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if(patLetters[i] != '*')
                        {
                            starPatternletters += patLetters[i];
                        }
                    }

                    for (int i = 0; i < words.Length; i++)
                    {
                        int count2 = 0;
                        if (words[i] != null)
                        {
                            string tempstr = words[i];
                            for (int j = 0; j < starPatternletters.Length; j++)
                            {
                                if (tempstr.Contains(starPatternletters[j]))
                                {
                                    count2++;
                                }
                            }
                            if (count2 == starPatternletters.Length)
                            {
                                Console.WriteLine(tempstr);
                                check2 = true;
                            }
                        }
                    }
                    if (!check2)
                    {
                        Console.WriteLine("There isn't any suitable word for the pattern you have entered");
                    }
                }   
            }
            else
            {
                char[] characters = pattern.ToCharArray();
                int count = 0;
                bool check = true;
                for (int i = 0; i < characters.Length; i++)
                {
                    if (characters[i] == '-')
                    {
                        count++;
                    } 
                }
                if (pattern.Length == count)
                {
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (words[i] != null && words[i].Length == pattern.Length)
                        {
                            Console.WriteLine(words[i]);
                            check = false;
                        }
                    }
                    if (check)
                    {
                        Console.WriteLine("There isn't any suitable word for the pattern you have entered");
                    }
                }
                else
                {
                    string letters = null;
                    bool control = true;
                    bool control2 = true;
                    for (int i = 0; i < pattern.Length; i++)
                    {
                        if (pattern[i] != '-')
                        {
                            letters += pattern[i];
                        }
                    }
                    for (int i = 0; i < words.Length; i++)
                    {
                        string wordINArray = words[i];
                        string temp1 = null;
                        string temp2 = null;
                        control = true;
                        if (wordINArray != null && wordINArray.Length == pattern.Length)
                        {
                            control2 = false;
                            for (int j = 0; j < pattern.Length; j++)
                            {
                                if (pattern[j] != '-' && wordINArray[j] == pattern[j])
                                {
                                    temp1 += wordINArray[j]; 
                                    temp2 += pattern[j]; 
                                }
                            }
                            if (temp1 != null && temp1.Length == letters.Length && temp1 == temp2)
                            {
                                Console.WriteLine(wordINArray);
                            }
                            else
                            {
                                control = false;
                            }
                        }
                    }
                    if (!control)
                    {
                        Console.WriteLine("There isn't any suitable word for the pattern you have entered");
                    }
                    if (control2)
                    {
                        Console.WriteLine("There isn't any suitable word for the pattern you have entered");
                    }
                }
            }
            Console.ReadLine();
        }
    }
}
