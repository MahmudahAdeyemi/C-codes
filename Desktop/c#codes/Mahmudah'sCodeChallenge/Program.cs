// Question 1
List<int>mylist = new List<int>(){1,1,1};
int [] myarray = new int[mylist.Count()];
mylist.Sort();

for (int i = 0; i < mylist.Count() ; i++)
{   
    for (int j = i+1; j < mylist.Count(); j++)
    {
        mylist[j] = mylist[j] - mylist[i];
    }
    mylist[i] += mylist[i] * mylist.Count-i - 1;
}
foreach (var item in mylist)
{
    Console.WriteLine(item);
}

// //Question 2
// List<int>mylist = new List<int>(){1,8,6,2,5,4,8,3,7};
// List<int>multiple = new List<int>();
// int count = 0;
// for (int i = 0; i < mylist.Count(); i++)
// {
//     for (int j = 0; j < mylist.Count; j++)
//     {
//         if (mylist[i] > mylist[j])
//         {
//             if (i > j)
//             {
//                 var c =  mylist[j] * (i - j);
//                 multiple.Add(c);
//             }
//             else
//             {
//                 var c = mylist[j] * (j - i);
//                 multiple.Add(c);
//             }
//         }
//         else
//         {
//             if (i > j)
//             {
//                 var c = mylist[i] * (i - j);
//                 multiple.Add(c);
//             }
//             else
//             {
//                 var c = mylist[i] * (j - i);
//                 multiple.Add(c);
//             }
//         }

//     }
// }
// int answer = multiple.Max();
// Console.WriteLine(answer);