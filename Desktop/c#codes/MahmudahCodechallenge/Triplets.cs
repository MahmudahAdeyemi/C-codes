using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MahmudahCodechallenge
{
    public class Triplets
    {
        public void Answer()
        {
            
            int [] array = new int [] {1,1,2,2,3};
            int a=0;
            int b = 0; 
            int c = 1;
            
            var list = new List<Array> ();
            
            
            for(int k = array.Length-1; k >= 2; k --)
            {
                for (int j =array.Length-2; j >= 1; j -- )
                {
                    for (int i = array.Length-3; i >=0; i--)
                    {
                        int d = array[i] - array[j];
                        int e = array[j] - array[k];
                        int f = array [i] - array[k];
                        if (d <  0)
                        {
                            d = -1 * d;
                        }
                        if (e <  0)
                        {
                            e = -1 * e;
                        }
                        if (f <  0)
                        {
                            f = -1 * f;
                        }
                        if(d <= a && f <= b && e <= c && 0<=i &&i<j && j<k )
                        {
                            //Console.WriteLine($"{array[i]} , {array[j]} , {array[k]}\n");
                            var newarray =  new int [] {array[i],array[j],array[k]};
                            list.Add(newarray);
                        }

                    }
                }
            }
            Console.WriteLine(list.Count());
        }
    }
}