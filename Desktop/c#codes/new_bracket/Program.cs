bool check = true;
string [] bracket = new string[6]{"[","]","(",")","{","}" };
char [] char_bracket = new char[6];
for (int i = 0; i < 6; i ++)
{
    char_bracket[i] = char.Parse(bracket[i]);
}



Console.Write("Enter lenght of string: ");
int len =int.Parse( Console.ReadLine());
//string[]brackets = new string[len];

//for (int i = 0; i <len;i++)
//{



if(len % 2 == 0)
{
    Console.Write("Enter the brackets: ");
    string brackets = Console.ReadLine();
    int index1 = brackets.IndexOf('[');
    int index2 = brackets.IndexOf(']');
    int index3 = brackets.IndexOf('(');
    int index4 = brackets.IndexOf(')');
    int index5 = brackets.IndexOf('{');
    int index6 = brackets.IndexOf('}');
    for (int i = 0; i < len; i ++)
    {
        if (brackets.Contains(char_bracket[0]))
        {
            if(brackets .Contains(char_bracket[1]))
            {
                if (index1 < index2)
                {
                    brackets.Replace(brackets.Substring(index1),string.Empty);
                    brackets.Replace(brackets.Substring(index2),string.Empty);
                }

                else check = false;
            }
            else check = false;
        }
        if (brackets.Contains(char_bracket[4]))
        {
            if(brackets.Contains(char_bracket[5]))
            {
                if (index5 < index6)
                {
                    brackets.Replace(brackets.Substring(index5),string.Empty);
                    brackets.Replace(brackets.Substring(index6),string.Empty);
                }
                else check = false;


            }
            else check = false;
        }
        if (brackets.Contains(char_bracket[2]))
        {
            if(brackets.Contains(char_bracket[3]))
            {
                if (index1 < index2)
                {
                    brackets.Replace(brackets.Substring(index3),string.Empty);
                    brackets.Replace(brackets.Substring(index4),string.Empty);
                }
                else check = false;
            }
            else check = false;
        }
        else 
        {
        check = false;
        }
    }
}
else 
{
    check = false;
}

Console.WriteLine(check);