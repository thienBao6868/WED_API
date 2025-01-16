using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using Web_API.Data;

namespace Web_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly AppApiDbContext _appApiContext;

        public RegionsController(AppApiDbContext appApiContext)
        {
            this._appApiContext = appApiContext;
        }

        [HttpGet]
        public IActionResult getAll() {

            var regions = _appApiContext.Regions.ToList();
            return Ok(regions);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public IActionResult getRegionById([FromRoute]Guid id) {
            //var region = _appApiContext.Regions.Find(id);
            var region = _appApiContext.Regions.FirstOrDefault(x => x.Id == id);
            if (region == null) {
                return NotFound();
            }
            return Ok(region);

        }
    }
}