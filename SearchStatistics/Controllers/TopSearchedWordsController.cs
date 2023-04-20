using Microsoft.AspNetCore.Mvc;
using SearchStatistics.Models;
using SearchStatistics.Services.Implementations;

namespace SearchStatistics.Controllers
{
    [ApiController]
    [Route("words")]
    public class TopSearchedWordsController : ControllerBase
    {
        TopSearchedWords tsw = new TopSearchedWords(Program.db);

        [HttpGet("all")]
        public List<SearchWord> GetAll()
        {
            return tsw.GetAll();
        }

        [HttpGet]
        public List<SearchWord> Get([FromBody] GetModel getModel)
        {
            return tsw.Get(getModel.Amount, getModel.Order);
        }

        [HttpPost]
        public void Post([FromBody] PostModel postModel)
        {
            tsw.Post(postModel.Query);
        }
    }
}
