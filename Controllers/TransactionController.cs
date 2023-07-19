using KANOKO.Dto;
using KANOKO.Interface.IService;

using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace KANOKO.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class TransactionController: ControllerBase
    {
        private readonly ITransactionService _transactionService;
        private readonly IAppUserService _appUserService;
        private readonly IHttpContextAccessor _contextAccessor;

        public TransactionController(ITransactionService transactionService, IAppUserService appUserService, IHttpContextAccessor contextAccessor)
        {
            _transactionService = transactionService;
            _appUserService = appUserService;
            _contextAccessor = contextAccessor;
        }



        [HttpPost("CreateTransaction")]
        public async Task<IActionResult> CreateTransaction([FromBody] CreateTransactionDto createTransactionDto)
        {
            var get = User.FindFirst(ClaimTypes.Name)?.Value;
            //createTransactionDto.DriverId = get; //buyer ID
            var result = await _transactionService.CreateTransaction(createTransactionDto);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }

        [HttpGet ("GetTransaction")]
        public async Task<IActionResult> GetTransaction(int transactionId)
        {
            var result = await _transactionService.GetTransaction(transactionId);
            if (result == null)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpGet ("GetAllTransaction")]

        public async Task<IActionResult> GetAllTransaction()
        {
            var result = await _transactionService.GetAllTransaction();
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }


        [HttpGet("GetTransactionByReferenceNumber")]
        public async Task<IActionResult> GetTransactionByReferenceNumber(string referenceId)
        {
            var result = await _transactionService.GetTransactionByReferenceNumber(referenceId);
            if (result.IsSuccess == false)
            {
                return BadRequest(result.Message);
            }
            return Ok(result);
        }
         
    }
}
