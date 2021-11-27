using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SumanChoraria_Sprint1.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumanChoraria_Sprint1.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<UserModel>
    {
        private readonly Context _context;

 
        public UserController(Context context) :base(context)
        {
            _context = context;

            if (_context.Users.Count() == 0)
            {
                _context.Users.Add(new UserModel
                {
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john.doe@test.com",
                    Password = "Password1"
                });

                _context.SaveChanges();

                _context.Users.Add(new UserModel
                {
                    FirstName = "John",
                    LastName = "Skeet",
                    Email = "john.skeet@test.com",
                    Password = "Password1"
                });

                _context.SaveChanges();

                _context.Users.Add(new UserModel
                {
                    FirstName = "Mark",
                    LastName = "Seeman",
                    Email = "mark.seeman@test.com",
                    Password = "Password1"
                });

                _context.SaveChanges();

                _context.Users.Add(new UserModel
                {
                    FirstName = "Bob",
                    LastName = "Martin",
                    Email = "bob.martin@test.com",
                    Password = "Password1"
                });

                _context.SaveChanges();
            }
        }
    }
}
