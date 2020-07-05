using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CronDemo.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CronDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        List<Person> people = new List<Person>();

        public PeopleController()
        {
            people.Add(new Person { FirstName = "Tim", LastName = "Corey", Id = 1 });
            people.Add(new Person { FirstName = "Sue", LastName = "Storm", Id = 2});
            people.Add(new Person { FirstName = "Bilbo", LastName = "Baggins", Id = 3 });

        }

        [HttpGet("getfirstnames/{id}/{age}")]
        public List<string> GetFirstNames(string id, string age)
        {
            List<string> output = new List<string>();

            foreach(var item in people)
            {
                output.Add(item.FirstName);
            }

            return output;
        }

        // GET: api/<PeopleController>
        [HttpGet]
        public List<Person> Get()
        {
            return people;
        }

        // GET api/<PeopleController>/5
        [HttpGet("{id}")]
        public Person Get(int id)
        {
            return people.Where(x => x.Id == id).FirstOrDefault();
        }

        // POST api/<PeopleController>
        [HttpPost]
        public void Post(Person value)
        {
            people.Add(value);
        }

        // PUT api/<PeopleController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PeopleController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
