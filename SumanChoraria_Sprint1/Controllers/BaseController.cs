using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SumanChoraria_Sprint1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SumanChoraria_Sprint1.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme)]
    public class BaseController<T> : ControllerBase where T : BaseModel
    {
        private readonly Context _context;

        public BaseController(Context context)
        {
            _context = context;
        }


        [HttpPost]
        public virtual IActionResult Create(T entity)
        {
            try
            {
                if (entity == null)
                    return BadRequest();

                _context.Set<T>().Add(entity);
                _context.SaveChanges();

                return Ok(new
                {
                    message = "entity created"
                });
            }
            catch (Exception)
            {

            }
            return BadRequest();
        }


        [HttpPut]
        public virtual IActionResult Update(int id,T entity)
        {
            try
            {
                if (id != entity.Id)
                    return BadRequest();

                if (!(_context.Set<T>().Any(e => e.Id == id)))
                {
                    return NotFound();
                }
                _context.Entry(entity).State = EntityState.Modified;
                _context.SaveChanges();

                return Ok(new
                {
                    message = "entity updated succesfully"
                });
            }
            catch(Exception)
            {

            }
            return BadRequest();
        }


        [HttpGet]
        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _context.Set<T>().ToList();
            }
            catch(Exception)
            {

            }
            return null;
        }


        [HttpGet]
        [Route("{id}")]
        public virtual IActionResult GetById(int id)
        {
            try
            {
                var entity = _context.Set<T>().FirstOrDefault(i => i.Id == id);
                if (entity == null)
                    return NotFound();

                return Ok(entity);
            }
            catch(Exception)
            {

            }
            return BadRequest();
        }
    }
}
