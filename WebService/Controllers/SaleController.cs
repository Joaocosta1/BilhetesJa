using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels.Sale;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/sales")]
    public class SaleController : Controller
    {
        private readonly ISaleService _saleService;
        private readonly IMapper _mapper;
        
        public SaleController(ISaleService saleService, IMapper mapper)
        {
            _saleService = saleService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateSaleViewModel vm)
        {
            var mappedSale = _mapper.Map<Sale>(vm);
            await _saleService.SaveAsync(mappedSale);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Create(UpdateSaleViewModel vm)
        {
            var mappedSale = _mapper.Map<Sale>(vm);
            await _saleService.SaveAsync(mappedSale);
            return Ok();
        }
    }
}