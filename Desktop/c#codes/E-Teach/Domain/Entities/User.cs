namespace E_Teach.Domain.Entities
{
    public class User
    {
        public Guid Id{get; set;}
        public string FirstName{get; set;} = default!;
        public string LastName{get; set;}= default!;
        public string Email{get; set;}= default!;
        public string UserName{get; set;} = default!;
        public string Password{get; set;} = default!;
        public string Country {get; set;} = default!;
    }
}