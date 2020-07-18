using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WordsThatIKnowWebAPI.DataAccess;
using WordsThatIKnowWebAPI.Domain;

namespace WordsThatIKnowWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContentsController : Controller
    {
        MongoDBContext db = new MongoDBContext("WordsThatIKnowMongoDB");

        [HttpGet]
        public List<Boxes> Get()
        {
            return db.LoadRecords<Boxes>("Contents");
        }

        [HttpPost]
        public ActionResult Create(Boxes collection)
        {
            try
            {
                db.InsertRecord("Contents", collection);

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
