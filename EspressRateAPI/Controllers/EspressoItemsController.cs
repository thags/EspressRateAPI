#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EspressRateAPI.Models;

namespace EspressRateAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EspressoItemsController : ControllerBase
    {

        private IEspressoRepository _repository;

        public EspressoItemsController(IEspressoRepository repository)
        {
            _repository = repository;
        }

        // GET: api/EspressoItems
        [HttpGet]
        public IEnumerable<EspressoItem> GetEspressoItems()
        {
            return _repository.GetAll();
        }

        // GET: api/EspressoItems/5
        [HttpGet("{id}")]
        public EspressoItem GetEspressoItem(int id)
        {
            return _repository.Get(id);
        }

        // PUT: api/EspressoItems/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEspressoItem(EspressoItem espressoItem)
        {
            _repository.Update(espressoItem);

            return NoContent();
        }

        // POST: api/EspressoItems
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EspressoItem>> PostEspressoItem(EspressoItem espressoItem)
        {
            _repository.Add(espressoItem);

            return CreatedAtAction(nameof(GetEspressoItem), new { id = espressoItem.Id }, espressoItem);
        }

        // DELETE: api/EspressoItems/5
        [HttpDelete("{id}")]
        public void DeleteEspressoItem(int id)
        {
            _repository.Remove(id);
        }
    }
}
