using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Friends;

namespace APIlaba.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : ControllerBase
    {

        private readonly ILogger<FriendController> _logger;

        public FriendController(ILogger<FriendController> logger)
        {
            _logger = logger;
        }

        static List<Friend> friends = new List<Friend>();

        // GET: api/Friend
        [HttpGet]
        public List<Friend> Get()
        {
            /*friends.Add(new Friend(0, "Ivan", "Ivanov", "Moscow", DateTime.Now));
            friends.Add(new Friend(1, "Oleander", "Yuba", "Nigeria", DateTime.Now));
            friends.Add(new Friend(2, "Saffron", "Lawrence", "Lagos", DateTime.Now));
            friends.Add(new Friend(3, "Jadon", "Munonye", "Asaba", DateTime.Now));
            friends.Add(new Friend(4, "Solace", "Okeke", "Oko", DateTime.Now));
            */
            return friends;
        }

        // GET: api/Friend/5
        [HttpGet("{id}", Name = "Get")]
        public Friend Get(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            return friend;
        }

        // POST: api/Friend
        [HttpPost]
        public List<Friend> Post([FromBody] Friend friend)
        {
            friends.Add(friend);
            return friends;
        }

        // PUT: api/Friend/5
        [HttpPut("{id}")]
        public List<Friend> Put(int id, [FromBody] Friend friend)
        {
            Friend friendToUpdate = friends.Find(f => f.id == id);
            int index = friends.IndexOf(friendToUpdate);

            friends[index].firstname = friend.firstname;
            friends[index].lastname = friend.lastname;
            friends[index].location = friend.location;
            friends[index].dateOfHire = friend.dateOfHire;
            return friends;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Friend> Delete(int id)
        {
            Friend friend = friends.Find(f => f.id == id);
            friends.Remove(friend);
            return friends;
        }
    }
}
