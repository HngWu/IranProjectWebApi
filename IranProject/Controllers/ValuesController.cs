using IranProject.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IranProject.Controllers
{





    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        public class tempUser
        {
            public string UserName { get; set; }
            public string Password { get; set; }
        }






        [HttpPost("Login")]
        public IActionResult Login(tempUser tempUser)
        {
            using (IranProjectContext context = new IranProjectContext())
            {
                try
                {
                    // Assuming Users is a DbSet<User> within your context
                    var user = context.Users.FirstOrDefault(x => x.UserName == tempUser.UserName && x.Password == tempUser.Password);
                    if (user != null)
                    {
                        // Assuming you have logic here to validate the user further or perform actions after successful login
                        return Ok(user);

                    }
                    else
                    {
                        // Return false if the user is not found or other validation fails
                        return NotFound();
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine($"An error occurred during login: {ex.Message}");
                    return NotFound(); // Indicate failure due to an exception
                }
            }
        }

        public partial class NewWorkshopRequest
        {
            public int WorkshopRequestedId { get; set; }

            public int UserId { get; set; }

            public int SaloonId { get; set; }

            public int CategoryId { get; set; }

            public int WorkshopTimeId { get; set; }

            public DateTime WorkshopDate { get; set; }
            public string Status { get; set; } = null!;


        }


        [HttpPost("Request")]
        public IActionResult WorkshopRequest(NewWorkshopRequest newWorkshopRequest)
        {
            using (IranProjectContext context = new IranProjectContext())
            {
                try
                {
                    var request = new WorkshopRequest()
                    {
                        Category = context.Categories.Where(x => x.CategoryId == newWorkshopRequest.CategoryId).FirstOrDefault(),
                        Saloon = context.Saloons.Where(x => x.SaloonId == newWorkshopRequest.SaloonId).FirstOrDefault(),
                        User = context.Users.Where(x => x.UserId == newWorkshopRequest.UserId).FirstOrDefault(),
                        WorkshopTime = context.WorkshopTimes.Where(x => x.WorkshopTimeId == newWorkshopRequest.WorkshopTimeId).FirstOrDefault(),
                        //UserId = newWorkshopRequest.UserId,
                        //SaloonId = newWorkshopRequest.SaloonId,
                        //// CategoryId = newWorkshopRequest.CategoryId,
                        //WorkshopTimeId = newWorkshopRequest.WorkshopTimeId,
                        Date = DateOnly.FromDateTime(newWorkshopRequest.WorkshopDate),
                        Status = newWorkshopRequest.Status,

                    };
                    // Assuming Users is a DbSet<User> within your context
                    context.Add(request);
                    int successRows = context.SaveChanges();

                    if (successRows >= 1)
                    {
                        // Assuming you have logic here to validate the user further or perform actions after successful login
                        return Ok("Success");

                    }
                    else
                    {
                        // Return false if the user is not found or other validation fails
                        return StatusCode(499);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception or handle it as needed
                    Console.WriteLine($"An error occurred during login: {ex.Message}");
                    Console.WriteLine(ex.InnerException.ToString());
                    return StatusCode(499, ex.Message); // Indicate failure due to an exception
                }
            }
        }



        // GET api/<ValuesController>/5
        [HttpGet("WorkshopRequest/{userId}")]
        public IActionResult Get(int userId)
        {
            using (IranProjectContext context = new IranProjectContext())
            {
                try
                {
                    var getWorkshopRequest = context.WorkshopRequests
                        .Where(x => x.UserId == userId)
                        .OrderBy(x => x.Status == "Pending" ? 0 : x.Status == "Accepted" ? 1 : 2) // Sort by status (Pending: 0, Accepted: 1, Rejected: 2)
                        .ThenByDescending(x => x.WorkshopTimeId) // Then sort by time in descending order
                        .ToList();
                    return Ok(getWorkshopRequest);



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return NotFound();
                }
            }

        }


        [HttpGet("WorkshopRequest")]
        public IActionResult GetAllWorkshopRequest()
        {
            using (IranProjectContext context = new IranProjectContext())
            {
                try
                {
                    var getWorkshopRequest = context.WorkshopRequests.ToList();
                    return Ok(getWorkshopRequest);



                }
                catch (Exception ex)
                {
                    Console.WriteLine("Exception: " + ex.Message);
                    return NotFound();
                }
            }

        }





        // POST api/<ValuesController>

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
