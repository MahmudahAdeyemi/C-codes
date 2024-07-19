namespace ExtensionMethod
{
    static class Extension 
    {
       public static int Double(this int num)
        {
            return num * 2;
        }
        public static string Fullname(this Student student)
        {
            return $"{student.FirstName} {student.LastName}" ;
        }
        public static string PrintAge(this Student student,int age)
        {
            return $"{student.LastName} is {age}";
        }

        public static string UpA(this string name)
        {
            name = name.ToLower();
            string new_name = "";
            for(int i =0; i< name.Length;i ++)
            {
                if(name[i] == 'a')
                {
                    new_name += 'A';
                }
                else new_name += name[i];
                
            }
            return  new_name;
        }
    }
}