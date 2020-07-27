using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordsThatIKnowWebAPI.Domain;
using WordsThatIKnowWebAPI.Services;

namespace WordsThatIKnowWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class WordsController : Controller
    {
        private readonly WordsService _wordsService;
        private readonly ILogger _logger;

        public WordsController(WordsService wordsService, ILogger<WordsController> logger)
        {
            _wordsService = wordsService;
            _logger = logger;

        }

        /// <summary>
        /// Get all words
        /// </summary>
        /// <returns>Return all words</returns>
        /// <response code="204">The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.</response> 
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get()
        {
            try
            {
                var response = _wordsService.GetCollections<Words>("Words");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Added a collection of new words
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Words
        ///     [
        ///       {
        ///         "word": "string",
        ///         "box": 0
        ///       },
        ///       {
        ///         "word": "string2",
        ///         "box": 0
        ///       }
        ///     ]
        /// </remarks>
        /// <returns>A newly created collection of Words</returns>
        /// <response code="201">The request has been fulfilled and has resulted in one or more new resources being created.</response>
        /// <response code="400">The server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).</response> 
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create(List<Words> collection)
        {
            try
            {
                _wordsService.InsertCollections("Words", collection);

                return Created(HttpContext.Request.GetDisplayUrl(), collection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }
    }
}
