namespace LINQDemo
{
    public class FileSpliter
    {
        public FileSpliter(string name, string extensions)
        {
            Name = name;
            Extensions = extensions;
        }

        public string Name{get;set;}
        public string Extensions{get;set;}
    }
}