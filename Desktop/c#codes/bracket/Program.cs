Console.Write("Enter lenght of array: ");
//bool check = true;
int len =int.Parse( Console.ReadLine());
string[]brackets = new string[len];
for (int i = 0; i <len;i++)
{
    Console.Write("Enter the brackets one by one: ");
    Console.ReadLine();

}
for(int i = 0;i < len;i++)
{
    if (brackets[i] == "{")
    {
        if(brackets[i + 1] == "}")
        {
            //check = true;
            continue;
        }
        else
        {
            Console.WriteLine("They are not equal.");
            break;
        }

    }
    if (brackets[i] == "(")
    {
        if(brackets[i + 1] == ")")
        {
            //check = true;
            continue;
        }
        else
        {
            Console.WriteLine("They are not equal.");
            break;
        }

    }
    if (brackets[i] == "[")
    {
        if(brackets[i + 1] == "]")
        {
            // check = true;
            continue;
        }
        else
        {
            Console.WriteLine("They are not equal.");
            break;
        }

    }

}
//Console.WriteLine(check);