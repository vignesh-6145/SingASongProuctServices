using CatalogueService.Catalogue;
using CatalogueService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogueService.Controllers
{
    

    [Route("api/[Controller]")]
    [ApiController]
    public class CatalogueController : Controller
    {
        CatalogueClient client;

        public CatalogueController()
        {
            this.client = new CatalogueClient();
        }
    
        [HttpGet]
        public IActionResult GetCatalogue()
        {
            return Ok(client.GetCatalogueItems());
        }
        [HttpGet]
        [Route("{TrackId}")]
        public IActionResult GetCatalogItem(int TrackId) {
            CatalogueItem item = client.GetCatalogueItem(TrackId);
            if(item == null)
            {
                return NotFound($"No Item found with ID : {TrackId}");
            }
            return Ok(item);
        }
    }
}
