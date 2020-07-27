using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WordsThatIKnowWebAPI.DataAccess;
using WordsThatIKnowWebAPI.Domain;
using WordsThatIKnowWebAPI.Services;

namespace WordsThatIKnowWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class ContentsController : Controller
    {
        private readonly ContentsService _contentsService;
        private readonly ILogger _logger;

        public ContentsController(ContentsService contentsService, ILogger<ContentsController> logger)
        {
            _contentsService = contentsService;
            _logger = logger;

        }

        /// <summary>
        /// Get all contents
        /// </summary>
        /// <returns>Return all content</returns>
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
                var response = _contentsService.GetCollections<Boxes>("Contents");

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Get content collection by ID
        /// </summary>
        /// <param name="id">Used to get a content collection.</param>
        /// <returns>Return a word collection</returns>
        /// <response code="204">The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.</response> 
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Get(Guid id)
        {
            try
            {
                var response = _contentsService.GetCollectionsByID<Boxes>("Contents", id);

                return Ok(response);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem(ex.Message);
            }
        }

        /// <summary>
        /// Added new content
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///     POST /Contents
        ///     {
        ///       "box": "Still Learning",
        ///       "languageTarget": "English",
        ///       "languageOrigen": "Portuguese",
        ///       "contents": [
        ///         {
        ///           "content": "Lurch",
        ///           "typeOfContent": 0,
        ///           "typeOfDefinition": 0,
        ///           "translations": [
        ///             {
        ///               "translation": "Apuro"
        ///             }
        ///           ],
        ///           "curiosities": [
        ///             {
        ///               "curiosity": "Name of one member of Addam's family"
        ///             }
        ///           ],
        ///           "definitions": [
        ///             {
        ///               "definition": "Leave an associate or friend abruptly and without assistance or support in a difficult situation.",
        ///               "exemple": "He left you in the lurch when you needed him most"
        ///             }
        ///           ],
        ///           "images": [
        ///             {
        ///               "src": "./lurch.jpg",
        ///               "description": "Lurch Cover"
        ///             }
        ///           ]
        ///         }
        ///       ]
        ///     }
        ///
        /// </remarks>
        /// <returns>A newly created Content</returns>
        /// <response code="201">The request has been fulfilled and has resulted in one or more new resources being created.</response>
        /// <response code="400">The server cannot or will not process the request due to something that is perceived to be a client error (e.g., malformed request syntax, invalid request message framing, or deceptive request routing).</response> 
        /// <response code="500">The server encountered an unexpected condition that prevented it from fulfilling the request.</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create(Boxes collection)
        {
            try
            {
                _contentsService.InsertCollection("Contents", collection);

                return Created(HttpContext.Request.GetDisplayUrl() + "/" + collection.Id, collection);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return Problem();
            }
        }
    }
}
