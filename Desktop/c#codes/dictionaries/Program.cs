        using System.Collections.Generic;
        Dictionary <char,int> mydictionary = new Dictionary<char, int> ();
        Console.Write("Enter the word: ");
        string arr =Console.ReadLine();
        foreach (var item in arr)
        {
            if(mydictionary.ContainsKey(item))
            {
                mydictionary[item] = (int)mydictionary[item] + 1;
            }
            else
            {
                mydictionary[item] = 1;
            }
        }
        
