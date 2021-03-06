using System.Threading.Tasks;
using BB.BLL.Interfaces;
using BB.Common.Dto.DepositDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;

namespace BB.API.Controllers
{
    [Authorize]
    [Route("[controller]")]
    [ApiController]
    public class DepositController : ControllerBase
    {
        private readonly IDepositBranchService _depositService;

        public DepositController(IDepositBranchService depositBranchService)
        {
            _depositService = depositBranchService;
        }
        
        [HttpPost]
        public async Task Deposit(DepositDto dep)
        {
            await _depositService.Deposit(dep);
        }

        [HttpPost("createDepositAccount")]
        public async Task CreateDepositAccount(int cardId)
        {
            await _depositService.CreateDepositAccount(cardId);
        }
        
        [HttpPost("deleteDepositAccount")]
        public async Task DeleteDepositAccount(int cardId)
        {
            await _depositService.DeleteDepositAccount(cardId);
        }
    }
}