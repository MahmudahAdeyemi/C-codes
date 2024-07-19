using System.Collections;
Stack bracket = new Stack();

Console.Write("Enter the string: ");
string text = Console.ReadLine();

bool isValid = true;

foreach (var c in text)
{


    if (c == '(' || c == '[' || c == '{')
    {
        bracket.Push(c);
    }
    else
    {
        if (bracket.Count == 0)
        {
            isValid = false;
            break;
        }

        var opening = (char)bracket.Pop();
        if (c == ')' && opening != '(' || c == ']' && opening != '[' || c == '}' && opening != '{')
        {
            isValid = false;
            break;
        }

    }
}
Console.WriteLine(isValid && bracket.Count == 0);



