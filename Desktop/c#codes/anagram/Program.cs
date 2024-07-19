int count =0;
string [] firstword= new string [4]{"p" ,"o" ,"o","l" };
string [] secondword = new string [4] {"p","o","l","o"};

if (secondword.Length != firstword.Length)
{
    //check=false;
    Console.WriteLine("They are not anegram.");
}
else
{
    
    for(int i = 0; i < firstword.Length; i ++)
    {
        if (firstword[i].Contains(secondword[i]))
        {
            firstword[i] = "";
            count ++;
            
        }
        if(firstword[i] != "")
        {
            count = 0;
        }
        if(firstword[i] == "")
        {
            count ++;
        }
        else
        {
            //check = false;
            count = 0;
            break;

        }

        }
}
if (count == firstword.Length) Console.WriteLine("They are anagram.");
else if(count < firstword.Length)
{
    Console.WriteLine("They are not anagram.");
}
Console.WriteLine(count);