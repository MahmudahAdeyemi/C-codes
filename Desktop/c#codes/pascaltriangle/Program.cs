// // // // // int rows = 5, val = 1, blank, i, j;
// // // // // Console.WriteLine("Pascal's triangle");
// // // // // for (i = 0; i < rows; i++)
// // // // // {
// // // // //     for (blank = 1; blank <= rows - i; blank++)
// // // // //         Console.Write(" ");
// // // // //     for (j = 0; j <= i; j++)
// // // // //     {
// // // // //         if (j == 0 || i == 0)
// // // // //             val = 1;
// // // // //         else
// // // // //             val = val * (i - j + 1) / j;
// // // // //         Console.Write(val + " ");
// // // // //     }
// // // // //     Console.WriteLine();
// // // // // }
// // // // namespace Method
// // // // {
// // // //     class Program
// // // //     {
// // // //         static void Main(string[] args)
// // // //         {
// // // //             int[]sequence = new int[6]{1,1,2,3,4,4};
// // // //             Console.WriteLine(solution(sequence));
// // // //         }
// // // //         static bool solution(int[] sequence)
// // // //         {
// // // //             bool check = true;
// // // //             List<int> newList = new List<int>();
// // // //             newList = sequence.Select(x => x).ToList();
// // // //             int firstnum = newList[0];
// // // //             newList.Remove(newList[0]);
// // // //             Array.Sort(sequence);
// // // //             for (int i = 0; i < newList.Count(); i ++)
// // // //             {
// // // //                 if (newList[i] == sequence[i])
// // // //                 {
// // // //                     if (i ==newList.Count() - 1 && check != false)
// // // //                     {
// // // //                         check = true;
// // // //                         for (int j = 1; j < newList.Count(); j++)
// // // //                         {
// // // //                             if (newList[j] <= newList[j-1])
// // // //                             {
// // // //                                 newList.Remove(newList[j]);
// // // //                                 if (j > 1)
// // // //                                 {
// // // //                                     j = j-2;
// // // //                                 }
// // // //                                 else j --;
// // // //                             }
// // // //                         }
// // // //                         if (newList.Count()  == sequence.Length || newList.Count()  == (sequence.Length - 1))
// // // //                         {
// // // //                             return true;
// // // //                         }
// // // //                     }
// // // //                 }
// // // //                 else
// // // //                 {
// // // //                     check = false;
// // // //                     break;
// // // //                 }
// // // //             }
// // // //             newList.Clear();
// // // //             newList = sequence.Select(x => x).ToList();
// // // //             for (int j = 1; j < newList.Count(); j++)
// // // //             {
// // // //                 if (newList[j] <= newList[j-1])
// // // //                 {
// // // //                     newList.Remove(newList[j]);
// // // //                     if (j > 1)
// // // //                     {
// // // //                         j = j-2;
// // // //                     }
// // // //                     else j --;
// // // //                 }
// // // //             }
// // // //             if (newList.Count() == sequence.Length || newList.Count() == (sequence.Length - 1))
// // // //             {
// // // //                 check = true;
// // // //             }
// // // //             else check = false;
// // // //             return check;

// // // //         }

// // // //     }
// // // // }

// // // int target = 6;
// // // int [] nums = new int [] {3,3};
// // //         List<int>myList = nums.Where(x => true).ToList();
// // //         int[] myarray = new int[2];
// // //         for (int i = 0; i < myList.Count(); i++)
// // //         {
// // //             for (int j = 1; j < myList.Count(); j++)
// // //             {
// // //                 if (myList[i] + myList[j] == target)
// // //                 {
// // //                     myarray[0] = i;
// // //                     myarray[1] = j;
// // //                     break;
// // //                 }
// // //             }
// // //         }

// // using System.Text;
// // int num = 5;
// // string[] symbol = { "MMM", "MM", "M", "CM", "DCCC", "DCC", "DC", "D", "CD", "CCC", "CC", "C", "XC", "LXXX", "LXX", "LX", "L", "XL", "XXX", "XX", "X", "IX", "VIII", "VII", "VI", "V", "IV", "III", "II", "I" };
// // int[] value = { 3000, 2000, 1000, 900, 800, 700, 600, 500, 400, 300, 200, 100, 90, 80, 70, 60, 50, 40, 30, 20, 10, 9, 8, 7, 6, 5, 4, 3, 2, 1 };
// // StringBuilder result = new StringBuilder();
// // var index = 0;
// // while (num != 0)
// // {
// //     if (num >= value[index])
// //     {
// //         num -= value[index];
// //         result.Append(symbol[index]);
// //     }
// //     else
// //     {
// //         index++;
// //     }
// // }

// // Console.WriteLine(result.ToString());#
// // int x =9;
// // if (x < 1) { return x; }

// // double last = 0.0, result = 1.0;
// // while (last != result)
// // {
// //     last = result;
// //     result = (result + x / result) / 2;
// // }

// // return (int)last;
// // string s =  "abbcbba";
// // int sum = s.Distinct().Count();
// string s = "pwwkew";
// if (string.IsNullOrEmpty(s)) return 0;

// var map = new Dictionary<int, int>();
// var maxLen = 0;
// var lastRepeatPos = -1;
// for (int i = 0; i < s.Length; i++)
// {
//     if (map.ContainsKey(s[i]) && lastRepeatPos < map[s[i]])
//         lastRepeatPos = map[s[i]];
//     if (maxLen < i - lastRepeatPos)
//         maxLen = i - lastRepeatPos;
//     map[s[i]] = i;
// }

// return maxLen;
using System.Collections.Generic;
LinkedListNode<int> l1 = new LinkedListNode<int>(3);