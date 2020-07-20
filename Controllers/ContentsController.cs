using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordsThatIKnowWebAPI.DataAccess;
using WordsThatIKnowWebAPI.Domain;
using WordsThatIKnowWebAPI.Services;

namespace WordsThatIKnowWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentsController : Controller
    {
        private readonly ContentsService _contentsService;
        public ContentsController(ContentsService contentsService)
        {
            _contentsService = contentsService;
        }

        [HttpGet]
        public List<Boxes> Get()
        {
            return _contentsService.LoadRecords<Boxes>("Contents");
        }

        [HttpPost]
        public ActionResult Create(Boxes collection)
        {
            try
            {
                _contentsService.InsertRecord("Contents", collection);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return Problem();
            }
        }
    }
}
