using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels.Receipt;
using WebService.ViewModels.Transfer;

namespace WebService.ControllersGH
{
    [ApiController]
    [Route("api/transfers")]
    public class TransferController : Controller
    {
        private readonly ITransferService _transferService;
        private readonly IMapper _mapper;
        
        public TransferController(ITransferService transferService, IMapper mapper)
        {
            _transferService = transferService;
            _mapper = mapper;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTransferViewModel vm)
        {
            var transfer = _mapper.Map<Transfer>(vm);
            await _transferService.SaveAsync(transfer);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateTransferViewModel vm)
        {
            var transfer = _mapper.Map<Transfer>(vm);
            await _transferService.SaveAsync(transfer);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int? transferId, [FromQuery] int eventId, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            if (transferId != null)
            {
                var transfer = await _transferService.FindByIdAsync(transferId ?? 0);
                var mappedTransfer = _mapper.Map<DetailTransferViewModel>(transfer);
                return Ok(mappedTransfer);
            }
                
            var transfers = await _transferService.GetAsync(eventId, limit, page);
            var mappedTransfers = _mapper.Map<List<PreviewTransferViewModel>>(transfers);
            var pages = await _transferService.CountPagesAsync(limit);
            var count = await _transferService.CountAsync();
            return Ok(new {data = mappedTransfers, page, limit, pages, count});
        }
        
        [HttpPost]
        [Route("process")]
        public async Task<IActionResult> Process([FromBody] ProcessTransferViewModel vm)
        {
            await _transferService.Process(vm.TransferId);
            return Ok();
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> Cancel([FromBody] CancelTransferViewModel vm)
        {
            await _transferService.Cancel(vm.TransferId);
            return Ok();
        }
    }
}