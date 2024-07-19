public class DelegateExample{
    public delegate int Add(int a, int b);

    public  static int Sum(int x, int y){
    return x+y;
   }
}