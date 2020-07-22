using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
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
        public ContentsController(ContentsService contentsService)
        {
            _contentsService = contentsService;
        }

        /// <summary>
        /// Get all words
        /// </summary>
        /// <returns>Return all content</returns>
        /// <response code="400">If the item is null</response> 
        /// <response code="500">Something went wrong on the server</response> 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public List<Boxes> Get()
        {
            return _contentsService.LoadRecords<Boxes>("Contents");
        }

        /// <summary>
        /// Get word collection by ID
        /// </summary>
        /// <param name="id">Used to get a word collection.</param>
        /// <returns>Return a word collection</returns>
        /// <response code="204">The server has successfully fulfilled the request and that there is no additional content to send in the response payload body.</response> 
        /// <response code="404">If the item is null</response> 
        /// <response code="500">Something went wrong on the server</response> 
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public Boxes Get(Guid id)
        {
            return _contentsService.GetRecordByID<Boxes>("Contents", id);
        }

        /// <summary>
        /// Added new word
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
        /// <response code="201">Returns the newly created item</response>
        /// <response code="400">If the item is null or the request json format is wrong</response> 
        /// <response code="500">Something went wrong on the server</response> 
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult Create(Boxes collection)
        {
            try
            {
                _contentsService.InsertRecord("Contents", collection);

                return Created(HttpContext.Request.GetDisplayUrl() + "/" + collection.Id, collection);
            }
            catch
            {
                return Problem();
            }
        }
    }
}
