using System.Collections.Generic;
using knights.Models;
using knights.Services;
using Microsoft.AspNetCore.Mvc;

namespace knights.Controllers
{
    [ApiController]
    [Route("api/[controller")]
    public class KnightController : ControllerBase
    {
        private readonly KnightService _ks;

        public KnightController(KnightService ks)
        {
            _ks = ks;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Knight>> Get()
        {
            try
            {
                List<Knight> knights = _ks.Get();
                return Ok(knights);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }

        }

        [HttpGet("{id}")]

        public ActionResult<Knight> Get(int id)
        {
            try
            {
                Knight knight = _ks.Get(id);
                return Ok(knight);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        //Used to apply Auth
        //[Authorize]

        public ActionResult<Knight> Create([FromBody] Knight newKnight)
        {
            try
            {
                Knight knight = _ks.Create(newKnight);
                return Ok(knight);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Knight> Create([FromBody] Knight updatedKnight, int id)
        {
            try
            {
                updatedKnight.Id = id;
                Knight knight = _ks.Update(updatedKnight);
                return Ok(knight);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]

        public ActionResult<string> Remove(int id)
        {
            try
            {
                _ks.Remove(id);
                return Ok("Deleted");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}