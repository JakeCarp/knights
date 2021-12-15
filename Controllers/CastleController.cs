using Microsoft.AspNetCore.Mvc;
using knights.Services;
using System.Collections.Generic;
using knights.Models;

namespace knights.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CastleController : ControllerBase
    {
        private readonly CastleService _cs;

        public CastleController(CastleService cs)
        {
            _cs = cs;
        }

        [HttpGet]

        public ActionResult<IEnumerable<Castle>> Get()
        {
            try
            {
                List<Castle> castles = _cs.Get();
                return Ok(castles);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]

        public ActionResult<Castle> Get(int id)
        {
            try
            {
                Castle castle = _cs.Get(id);
                return Ok(castle);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpPost]

        public ActionResult<Castle> Create([FromBody] Castle newCastle)
        {
            try
            {
                //Would put this here if I had remembered creator IDs
                // newCastle.creatorId = await HttpContext.GetUserInfoAsync<Account>();
                Castle castle = _cs.Create(newCastle);
                return Ok(castle);
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]

        public ActionResult<Castle> Create([FromBody] Castle updatedCastle, int id)
        {
            try
            {
                updatedCastle.Id = id;
                Castle castle = _cs.Update(updatedCastle);
                return Ok(castle);
            }
            catch (System.Exception e)
            {

                return BadRequest(e.Message);
            }
        }

        [HttpDelete]

        public ActionResult<string> Remove(int id)
        {
            try
            {
                _cs.Remove(id);
                return Ok("Castle Removed");
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}