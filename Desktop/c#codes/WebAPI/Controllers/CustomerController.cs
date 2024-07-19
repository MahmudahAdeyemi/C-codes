using Microsoft.AspNetCore.Mvc;
using WebAPI;
using WebAPI.bin;
using WebAPI.Entities;
namespace WEBAPI.Controllers
{


    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        PostService _postService;

        public CustomerController(PostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("profile")]
        public IActionResult GetPersons(){

           var profile = Profile.Profiles;
           return Ok(profile);

        }
        [HttpPost]
        public IActionResult Post([FromBody]Profile profile)
        {
            Profile.Profiles.Add(profile);
            return CreatedAtAction(nameof(Post),new {id = profile.Id});
        }
        [HttpPut("{id}")]
        public IActionResult Put(Guid id,[FromBody] string email)
        {
            var profile = Profile.Profiles.Where(x => x.Id == id).FirstOrDefault();
            if (profile == null)
            {
                return NotFound();                
            }
            profile.Email = email;
            return Ok(profile);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var profile = Profile.Profiles.Where(x => x.Id == id).FirstOrDefault();
            if (profile == null)
            {
                return NotFound();                
            }
            Profile.Profiles.Remove(profile);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetProfie (Guid id)
        {
            var profile = Profile.Profiles.Where(x => x.Id == id).FirstOrDefault();
            if (profile == null)
            {
                return NotFound();                
            }
            return Ok(profile);
        }
        [HttpGet]
        [Route("persons/{id}")]
        public IActionResult GetPersons([FromRoute]int id){

           var persons = GetPeople().Where(p=>p.Id == id);
           if (persons.Count() == 0)
           {
             return NotFound();
           }
           else
           {
                return Ok(persons.First());
           }
           

        }
        [HttpGet]
        [Route("persons/search")]
        public IActionResult SearchByName([FromQuery] string searchkey)
        {
            // var token = HttpContext.Session.GetString("token");
            // if(token != "123456789")
            // {
            //     return Unauthorized();
            // }
            var perons = GetPeople().Where(x => x.Name.Contains(searchkey));
            if(perons.Count() != 0)
            {
                return Ok(perons);
            }
            return NotFound();
        }
        [HttpGet]
        [Route("posts")]
        public async Task<IActionResult> ViewPost()
        {
            try
            {
                var post = await _postService.GetPosts();
                return Ok(post);
            }
            catch(Exception ex)
            {
                return new JsonResult("Sorry, unexpexted error occured")
                {
                    StatusCode = 500
                };
            }

        }
        [HttpPost]
        [Route("posts")]
        public async Task<IActionResult> AddPost([FromBody]PostRequestModel post)
        {
            try
            {
                await _postService.AddPost(post);
                return Ok();
            }
            catch(Exception ex)
            {
                return new JsonResult("Sorry, unexpexted error occured")
                {
                    StatusCode = 500
                };
            }
            
        }
        [HttpPut]
        [Route("update")]
        public async Task<IActionResult> Update(int id,[FromBody]string Title,string Body)
        {
            try
            {
                    var posts = await _postService.GetPosts();
                var post = posts.FirstOrDefault(x => x.Id == id);
                if (post == null)
                {
                    return NotFound("PostNotFound");
                }
                post.Title = Title;
                post.Body = Body;
                return Ok();
            }
            catch(Exception ex)
            {
                return new JsonResult("Sorry, unexpexted error occured")
                {
                    StatusCode = 500
                };
            }
        }


        private static IEnumerable<Person> GetPeople(){
            var perons = new List<Person>{
               new Person(){ Name="adeola", Id=2},
               new Person(){ Name="bimbo", Id=1}
            };

            return perons;
        }


    }

    public record Person{
        public string Name{ get; set;}
        public int Id {get; set;} 
    }

}
