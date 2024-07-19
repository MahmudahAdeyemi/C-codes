namespace WebAPI.Entities
{
    public class Profile
    {
        public Guid Id{get; set;}
        public string FirstName{get; set;}
        public string LastName{get; set;}
        public string Email {get; set;}
        public DateOnly DateOfBirth{get; set;}

        public static List<Profile> Profiles = new List<Profile>
        {
            new Profile {Id = Guid.NewGuid(),FirstName = "Bolu",LastName = "Ade",Email="adeym@g.com"}
        };
    }
}