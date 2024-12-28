using API.RequestHelpers;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected async Task<IActionResult> CreatePagedResultAsync<T>(IGenericRepository<T> repo,ISpecification<T> spec
            ,int pageIndex, int pageSize) where T : BaseEntity
            {
                //get entities with psecific specs
                var items = await repo.ListWithSpecAsync(spec);

                //get their count
                var count = await repo.CountAsync(spec);

                //create pagination collection with the given specs
                var pagination = new Pagination<T>(pageIndex,pageSize,count,items);

                return Ok(pagination);
            }
    }
}
