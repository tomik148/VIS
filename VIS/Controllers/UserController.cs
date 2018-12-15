using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VIS.Models;

namespace VIS
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<User> Get()
        {
            return Model1.Context.Users;
        }

        // GET api/<controller>/5
        public User Get(int id)
        {
            return Model1.Context.Users.FirstOrDefault(u => u.id == id);
        }

        // POST api/<controller>
        public void Post([FromBody]User value)
        {
            Model1.Context.Users.Add(value);
            Model1.Context.SaveChanges();
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]User value)
        {
            var change = Model1.Context.Users.FirstOrDefault(u => u.id == id);
            change.Email = value.Email;
            change.Name = value.Name;
            change.Phone = value.Phone;
            change.Surname = value.Surname;
            change.Lives = value.Lives;
            Model1.Context.SaveChanges();
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
            Model1.Context.Users.Remove(Model1.Context.Users.FirstOrDefault(u => u.id == id));
            Model1.Context.SaveChanges();
        }
    }
}