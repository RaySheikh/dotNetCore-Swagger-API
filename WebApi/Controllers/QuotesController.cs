using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using WebApi.Filters;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [ApiKeyAuth]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class QuotesController : ControllerBase
    {
        private readonly IQuotesRepo _ctx;

        public QuotesController(IQuotesRepo ctx)
        {
            _ctx = ctx;
        }
        // GET: api/<QuotesController>


        [HttpGet("AllQuotes")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Quote>), 200)]
        public async Task<IActionResult> GetAllQuotes()
        {
            try
            {
                var quotes = await _ctx.GetAllQuotes();
                return Ok(quotes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpGet("QuoteByAuthor/{name}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(List<Quote>), 200)]
        public async Task<IActionResult> QuoteByAuthor(string name)
        {
            try
            {
                var quotes = await _ctx.GetQuoteByAuthor(name);
                return Ok(quotes);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }
        [HttpGet("RandomQuote")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Quote), 200)]
        public async Task<IActionResult> GetRandomQuote()
        {
            try
            {
                
                var quote = await _ctx.GetRandomQuote();
                if (quote != null)
                {
                    return Ok(quote);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

        }

        // GET api/<QuotesController>/5
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Quote), 200)]
        public async Task<IActionResult> GetQuoteById(string id)
        {
            try
            {
                var mongoId = ObjectId.Parse(id);
                var quote = await _ctx.GetQuoteById(id);
                if(quote != null)
                {
                    return Ok(quote);
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // POST api/<QuotesController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(Quote), 200)]
        public async Task<IActionResult> CreateQuote(Quote quote)
        {
            try
            {
                var created = await _ctx.CreateQuote(quote);
                return Ok(created);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }

            
        }


        // PUT api/<QuotesController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> PutQuote(string id, [FromBody] Quote quote)
        {
            try
            {
                var mongoId = ObjectId.Parse(id);
                await _ctx.UpdateQuote(id, quote);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }

        // DELETE api/<QuotesController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteQuote(string id)
        {
            try
            {
                var mongoId = ObjectId.Parse(id);
                await _ctx.DeleteQuoteById(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
            
        }
    }
}
