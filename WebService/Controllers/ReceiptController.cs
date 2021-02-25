using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using Repository.Interface;
using WebService.ViewModels;
using WebService.ViewModels.Receipt;

namespace WebService.Controllers
{
    [ApiController]
    [Route("api/receipts")]
    public class ReceiptController : Controller
    {
        private readonly IReceiptService _receiptService;
        private readonly IMapper _mapper;

        public ReceiptController(IReceiptService receiptService, IMapper mapper)
        {
            _receiptService = receiptService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReceiptViewModel vm)
        {
            var receipt = _mapper.Map<Receipt>(vm);
            await _receiptService.SaveAsync(receipt);
            return Ok();
        }
        
        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReceiptViewModel vm)
        {
            var receipt = _mapper.Map<Receipt>(vm);
            await _receiptService.SaveAsync(receipt);
            return Ok();
        }
        
        [HttpGet]
        public async Task<IActionResult> List([FromQuery] int? receiptId, [FromQuery] int eventId, [FromQuery] int limit = 10, [FromQuery] int page = 0)
        {
            if (receiptId != null)
            {
                var receipt = await _receiptService.FindByIdAsync(receiptId ?? 0);
                var mappedReceipt = _mapper.Map<PreviewReceiptViewModel>(receipt);
                return Ok(mappedReceipt);
            }
                
            var receipts = await _receiptService.GetAsync(eventId, limit, page);
            var mappedReceipts = _mapper.Map<List<PreviewReceiptViewModel>>(receipts); 
            return Ok(mappedReceipts);
        }
        
        [HttpPost]
        [Route("process")]
        public async Task<IActionResult> Process([FromBody] ProcessReceiptViewModel vm)
        {
            await _receiptService.ProcessAsync(vm.ReceiptId);
            return Ok();
        }
        
        [HttpPost]
        [Route("cancel")]
        public async Task<IActionResult> Cancel([FromBody] CancelReceiptViewModel vm)
        {
            await _receiptService.CancelAsync(vm.ReceiptId);
            return Ok();
        }
    }
}