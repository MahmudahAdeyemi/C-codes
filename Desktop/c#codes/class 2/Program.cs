namespace Method
{
    class Program
    {
        static void Main(string[] args)
        {
            Textbook textbook1 =new Textbook (20,"Math","red","Toyyib" ,"ColeHub","Js3");
            Notebook notebook1 = new Notebook(34,"English","blue","Soft",true);
            
            textbook1.Print_Details();
            notebook1.Print_Status();
        }
        
    }
}
