namespace LINQDemo
{     static class  Program 
     {
        static void Main(string[] args)
        {
            List<int>myList = new List<int> () {5,7,13,24,6,9,8,7};
            // Console.Write("Enter the sentence: ");
            // string word = Console.ReadLine();
            //int num = int.Parse(Console.ReadLine());
           // Console.Write("Enter number of element: ");
            //int element = int.Parse (Console.ReadLine());
            List<string> mystring = new List<string> (){"Job", "Comb", "hour"};
            // for (int i = 0; i < element; i++)
            // {
            //     Console.Write($"Enter element at {i}: ") ;
            //     string said = Console.ReadLine();
            //     mystring.Add(said);            
            // }
            Eleven.Extensions();

            IEnumerable<int> nums = Enumerable.Range(50, 50).Where(s =>s < 101 && s % 2 == 1);
            IEnumerable<string>work = Enumerable.Repeat("Work,Hard",5);
            var wor = Enumerable.Repeat("CodeLearnersHub",50000).ToList();
            var counters = Enumerable.Range(1, 50000).ToList();
         
            for(int i = 0; i < counters.Count; i++) 
            {
                Console.WriteLine($"{counters[i]} {wor[i]}");           
            }
        }
     }
}


                
//             List<Student> studentList = new List<Student>()
//             {
//                 new Student(){ID =1 ,FirstName = "Mahmudah",LastName = "Adeyemi",Weight=10,Age = 18,Gender = "Female"},
//                 new Student(){ID =2,FirstName = "Farhaan",LastName = "Balogun",Weight=67  ,Age =23 ,Gender = "Male"},
//                 new Student(){ID = 3,FirstName = "Amirah",LastName = "Ashimi",Weight=43 ,Age =21 ,Gender = "Female"},
//                 new Student(){ID =4 ,FirstName = "Yusrat",LastName = "Taiwo",Weight=47 ,Age =19 ,Gender = "Female"},
//                 new Student(){ID = 5,FirstName = "Imaan",LastName = "Salaam",Weight=57 ,Age =13 ,Gender = "Male"},
//                 new Student(){ID = 6,FirstName = "Aliyah",LastName = "Akamo",Weight=23 ,Age =22 ,Gender = "Male"},
//                 new Student(){ID = 7,FirstName = "Toluwaani",LastName = "Alao",Weight=49 ,Age =16 ,Gender = "Male"},
//                 new Student(){ID = 8,FirstName = "AbdulLateef",LastName = "Shittu",Weight=71,Age =20 ,Gender = "Male"},
//             };
//             //var element = studentList.LastOrDefault(s => s.LastName.ToLower() == "erinosho");
//            // Console.WriteLine($"{element.FirstName} {element.LastName} {element.Weight} {element.NoOfDaysPresent} {element.Age} {element.Gender}");
//             // Console.WriteLine(element.FirstName);
//             //var groups =studentList.GroupBy(d => d.Gender = "Male");
//             // foreach(var grp in groups)
//             // {
//             //    // Console.WriteLine($"{grp.Key} : {grp.Count()}");

//             //     foreach(var student in grp){
//             //        // Console.WriteLine($"{student.FirstName} {student.LastName} {student.Age}");
//             //     }
//             //    // Console.WriteLine( );
//             // }

//             List<string> words = new List<string>(){"Java", "c#", "JavaScript", "Html", "CSS"}; //"Java,c#,JavaScript,Html,CSS"
//             List<int> numbers = new List<int>(){4, 7, 1, 9, 7, 3};
            
//             // List<int>numlist = new List<int> ();
//             // foreach (var item in studentList)
//             // {
//             //     numlist.Add(item.Weight);
//             // }
//             var weights = studentList.Select(s => s.Weight).ToList();
//             var sum1 = weights.Aggregate((n1,n2) => n1 + n2)/(weights.Count());
//            // Console.WriteLine(sum1);
//             bool wok2 = studentList.Any(s => s.Age < 10 && s.Gender == "Male");
//          //   Console.WriteLine(wok2);
            
//             bool wok = studentList.All(s => s.Age > 18 && s.Gender == "Female");
//          //   Console.WriteLine(wok);
            
//            // Console.WriteLine(check);
//             var sum = numbers.Aggregate((n1, n2) => n1 * n2);
//            // Console.WriteLine(sum);


//             var output = words.Aggregate((s1, s2) => s1 + s2);
//                 //Console.WriteLine(output);

//             // string result = string.Empty;
//             // foreach(string word in words){
//             //     result = result + word + ",";
//             // }

//             // var lastIndex = result.LastIndexOf(',');
//             // result = result.Remove(lastIndex);
//             // Console.WriteLine(result);


//             // var  selectedStudent = from imp in studentList
//             //                         select new StudentInfo(){
//             //                             FullName = imp.FirstName + imp.LastName,
//             //                             ID = imp.ID
//             //                         };

//             // var mywork = from imp in studentList
//             //              where imp.Gender =="Male" && imp.Age >19
//             //              select new StudentInfo(){
//             //                  FullName = imp.FirstName +"  "+imp.LastName,
//             //                  Weight = imp.Weight + "kg",
//             //                  AttendanceRate =(imp.NoOfDaysPresent * 100)/30,
//             //                  ID = imp.ID
//             //              };
//             // var c = studentList.Where(s => s.Gender == "Male" && s.Age > 19).Select(s => new StudentInfo (){
//             //     FullName = s.FirstName + "  "+s.LastName,
//             //     Weight = s.Weight + "kg",
//             //      AttendanceRate =(s.NoOfDaysPresent * 100)/30,
//             //      ID = s.ID
//             // }) ;

//             // foreach (var item in mywork)
//             // {
//             //     Console.WriteLine($"{item.FullName} {item.ID} {item.AttendanceRate}");
//             // }  
//             var course = studentList.SelectMany(s => s.Courses).Distinct();
//             List<int> num1 = new List<int>(){1,2,3,4,5};
//             List<int> num2 = new List<int>(){1,2,3,5,4};
//             num1.Sort();
//             num2.Sort();
//             var newon = num1.Append(5).ToList();
//             //Console.WriteLine(num1.SequenceEqual(num2));
            
//             var exceopt = num1.Concat(num2);
//             List<string> alphabets = new List<string> () {"boy","girl","male","female"};
            // IEnumerable<int> nums = Enumerable.Range(50, 50).Where(s =>s < 101 && s % 2 == 1);
            // IEnumerable<string>work = Enumerable.Repeat("Work,Hard",5);
            // var wor = Enumerable.Repeat("CodeLearnersHub",50000).ToList();
            // var counters = Enumerable.Range(1, 50000).ToList();
         
            // for(int i = 0; i < counters.Count; i++) 
            // {           
            //    Console.WriteLine($"{counters[i]} {wor[i]}");
            // }
//             foreach (var item in work)
//             {
//               //  Console.WriteLine(item +" ");
//             }
            
//             var characters = alphabets.SelectMany(s => s);
//             foreach (var item in exceopt)
//             {
//                // Console.WriteLine(item);
//             }

//             int [] num = new int [] {1,4,6,21,8};
//             var c = num.Where(s => s % 3 == 0 && s % 7 == 0).ToList();
//             foreach (var item in c)
//             {
//                 //Console.WriteLine(item);
//             }
//             string statement = "i love you";
//             // Console.WriteLine(statement.Capital());
            

//             List<StuMy_Student>my_Students = new List<StuMy_Student> ()
//             {
//                 new StuMy_Student(){FirstName = "Mahmudah",LastName = "Adeyemi",Age = 43},
//                 new StuMy_Student(){LastName = "Taiwwo",FirstName = "Yusrat",Age = 24},
//                 new StuMy_Student(){LastName = "Ashimi",FirstName = "Amirah",Age = 65},
//                 new StuMy_Student(){LastName = "Balogun",FirstName = "Farhaan",Age = 92},
//                 new StuMy_Student(){LastName = "Salaam",FirstName = "Imaan",Age = 76},
//                 new StuMy_Student(){LastName = "Akamo",FirstName = "Aliyah",Age = 42},
//                 new StuMy_Student(){FirstName = "Toluwani",LastName = "Alao",Age = 54}
//             };

//             var mycheck = my_Students.Where(s => s.FirstName.ElementAt(0) < s.LastName.ElementAt(0));
//             foreach(var item in mycheck)
//             {
//              // Console.WriteLine($"{item.FirstName} {item.LastName}");
//             }
//             var age = my_Students.Where(s => s.Age < 25 && s.Age > 18);
            
            

//                // var mywork = from imp in studentList
//             //              where imp.Gender =="Male" && imp.Age >19
//             //              select new StudentInfo(){
//             //                  FullName = imp.FirstName +"  "+imp.LastName,
//             //                  Weight = imp.Weight + "kg",
//             //                  AttendanceRate =(imp.NoOfDaysPresent * 100)/30,
//             //                  ID = imp.ID
//             //              };


//             var mywork = my_Students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName);
//             foreach(var item in mywork)
//             {
//               //  Console.WriteLine($"{item.FirstName} {item.LastName}");
//             }
            
//         //   Question 1 
//             // List<int> exer1 = new List<int> (){1,2,3,4,5,6,7,8,9};
//             // var work1= exer1.Where(s => s % 2 == 0);

//             // Question 2;
//             // List<int> exer1 = new List<int> (){1,2,3,4,5,6,7,8,9};
//             // var work2 = exer1.Where(s => s > 0);

//             // Question 3
//             // List<int> exer1 = new List<int> (){1,2,3,4,5,6,7,8,9};
//             // var work3 = exer1.Select(s => s * s);
//             // var new_sum = work3.Aggregate((s1,s2) => s1 + s2);
//             // Console.WriteLine(new_sum);


//             // Question 5
//             Dictionary <char,int> mydictionary = new Dictionary<char, int> ();
//             Console.Write("Enter the word: ");
//             string arr =Console.ReadLine();
//             foreach (var item in arr)
//             {
//                 if(mydictionary.ContainsKey(item))
//                 {
//                     mydictionary[item] = (int)mydictionary[item] + 1;
//                 }
//                 else
//                 {
//                     mydictionary[item] = 1;
//                 }
//             }
//             foreach(KeyValuePair<char,int> item in mydictionary )
//             {
//                 Console.WriteLine(item.Key + " "+ item.Value);
//             }


//             // Question 8
//             // List<string>mylist = new List<string>(){"ROME","LONDON","nAIROBI","CALIFORNIA","ZURICH","AMSTERDAM"};
//             // Console.Write("Enter the starting character");
//             // char fc  = char.Parse(Console.ReadLine());
//             // Console.Write("Enter the last character");
//             // char ec = char.Parse(Console.ReadLine());
//             // var work1 = mylist.Where(s => s[0] == fc && s[s.Length -1] == ec).Select(s => s);
//             // foreach (var item in work1)
//             // {
//             //     Console.WriteLine(item);
//             // }


//             // Question 9
//             // List<int> exer1 = new List<int> (){1,2,65,76,43,9340};
//             // var s = exer1.Select(s => s > 80);

//         //     Question 10
//         //     Console.WriteLine("Enter the number 0f member: ");
//         //     int n = int.Parse (Console.ReadLine());
//         //     List<int> exer1 = new List<int> ();
//         //     for (int i = 0; i < n; i++)
//         //     {
//         //         Console.Write($"Enter member {i} : ");
//         //         int said =int.Parse(Console.ReadLine());
//         //         exer1.Add(said);
//         //     }
//         //     Console.WriteLine("Enter the input you want to display above");
//         //     int x = int.Parse(Console.ReadLine());
//         //     var work1 = exer1.Select(s => s>x);


//             // Question 11
//             //     List<int> exer1 = new List<int> (){1,2,3,4,5,6,7,8,9};
//             //     var x = exer1.Max();
//             //     exer1.Remove(x);
//             //     var y = exer1.Max();
//             //     exer1.Remove(y);
//             //     var z = exer1.Max();
//             //     exer1.Remove(z);
//             //     Console.WriteLine($"{x} \n {y} \n {z}");
            
   
//             // Question 13
            // Console.Write("Enter number of element: ");
            // int element = int.Parse (Console.ReadLine());
            // List<string> mystring = new List<string> ();
            // for (int i = 0; i < element; i++)
            // {
            //     Console.Write($"Enter element at {i}: ") ;
            //     string said = Console.ReadLine();
            //     mystring.Add(said);            
            // }
            // string word1 = "";
            // foreach(var item in mystring)
            // {
            //     word1 = word1 + item + ", ";
            // }


//             // List<string>file = new List<string> (){"aaa.frx","bbb.txt","xyz.dbf","abc.pdf","aaaa.pdf","xyz.frt","abc.xml","ccc.txt","zzz.txt"};
//             // List<string>extensions  = new List<string> ();
//             // foreach (var item in file)
//             // {
//             //     var x = item.Split('.');
//             //     extensions.Add(x[1]);
//             // }
//             // var r = extensions.Distinct();
//             // var v = extensions.GroupBy(s => r);
//             // foreach (var item in v)
//             // {
//             //     Console.WriteLine(item.Key );
//             // }

//             // Qoestion 17 to 21
//             // Console.Write("Enter the word: ");
//             // string worda = Console.ReadLine();
//             // Console.Write("Enter the letter you want to remove: ");
//             // char remover =char.Parse(Console.ReadLine());
//             // int index = worda.IndexOf(remover);
//             // var removers = worda.Remove(index);

//             // Question 22
//             // List<string>mylist = new List<string> ();
//             // Console.WriteLine("Enter number of element you want to enter");
//             // int entry =int.Parse(Console.ReadLine());
//             // Console.Write("Enter the mininmum lenght you want: ");
//             // int len = int.Parse(Console.ReadLine());
//             // for (int i = 0; i < entry; i++)
//             // {
//             //     Console.Write($"Enter element {i}");
//             //     string inputa = Console.ReadLine();
//             // }
//             // var wgtv  = mylist.Select(s => s.Length >= len );

//             // Question 30
//             // List<string>mylist = new List<string> (){"biscuit","bread","bread","biscuit","butter"};
//             // var wgtv = mylist.OrderBy(s => s).Distinct();



//             List<int>mylist = new List<int>(){5,1,9,2,3,7,4,5,6,8,7,6,3,4,5,2};
//             List<int>cont = new List<int> ();
//             List<int>count = new List<int> ();
//             var k = mylist.Distinct().ToList();
//             for (int i = 0; i < mylist.Count(); i++)
//             {
//                if (!(cont.Contains(mylist[i])))
//                {
//                 cont.Add(mylist[i]);
//                    var r = mylist.Where(s => s==mylist[i]).Count();
//                    count.Add(r);

//                } 
//             }
//             //for (int i = 0; i < k.Count(); i++)
//             // {
//             // Console.WriteLine($"{k[i]}  {k[i] * count[i]}  {count[i]}");
//             // } 
//         // static string Capital(this string statement)
//         // {
//         //     string mywords = "";
//         //     //List<string> mylist = new List<string>();
//         //     var spilt = statement.Split(' ');
//         //     // foreach(string item in spilt)
//         //     // {
//         //     //     mylist.Add(item);
//         //     // }
//         //     for(int i = 0; i < spilt.Length; i++)
//         //     {
//         //         char r = Convert.ToChar(spilt[i].ElementAt(0).ToString().ToUpper());
//         //         spilt[i] = spilt[i].Replace(spilt[i][0], r);
                
//         //     }
//         //     foreach (var item in spilt)
//         //     {
//         //         mywords =mywords + item + " ";
//         //     }
//         //     return mywords;

//         // }

//     }
    
// }
// }