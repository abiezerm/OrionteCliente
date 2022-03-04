using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using BusinessLayer.Repository;
using DataLayer.DBModels.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Authorize]
    public class CoreController<TService, TModel, TRequestViewModel, TResponseModel> : ControllerBase
        where TModel : CoreModel
        where TRequestViewModel : class
        where TResponseModel : class
        where TService : IGenericRepository<TModel, TRequestViewModel, TResponseModel>

    {
        private readonly TService _service;
        private readonly IMapper _mapper;

        public CoreController(TService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        [HttpGet("[controller]s")]
        public async Task<IActionResult> GetAllAsync()
        {
            var list = await _service.GetAllAsync();
            var response = _mapper.Map<IEnumerable<TModel>, IEnumerable<TResponseModel>>(list);
            if (!response.Any())
            {
                return NoContent();
            }
            return Ok(response);
        }

        [HttpGet("[controller]/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var unMappedResponse = await _service.GetByIdAsync(id);
            if (unMappedResponse is null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<TModel, TResponseModel>(unMappedResponse));
        }

        [HttpPost("[controller]")]
        public async Task<IActionResult> PostAsync(TRequestViewModel request)
        {
            var response = await _service.AddAsync(request);
            return Created("", response);
        }

        [HttpPut("[controller]")]
        public async Task<IActionResult> PutAsync(TRequestViewModel request)
        {
            var unMappedResponse = await _service.UpdateAsync(request);

            return Ok(unMappedResponse);
        }
        [HttpDelete("[controller]/{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await _service.DeleteAsync(id);
            return Ok();
        }




    }
}
