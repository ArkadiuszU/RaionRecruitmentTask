using MediatR;
using Microsoft.AspNetCore.Mvc;
using RaionRecruitmentTaskApplication.Balances.Commands.Deposit;
using RaionRecruitmentTaskApplication.Balances.Commands.Withdraw;
using RaionRecruitmentTaskApplication.Balances.Queries.GetBalanceStatus;

namespace RaionRecruitmentTaskAPI.Controllers
{
    [ApiController]
    [Route("api/balance")]
    public class BalanceController(IMediator mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBalance([FromRoute] int id)
        {
            var balance = await mediator.Send(new GetBalanceStatusQuery(id));
            return Ok(balance);
        }

        [HttpPost("deposit")]
        public async Task<IActionResult> Deposit( [FromBody] DepositCommand command )
        {
            await mediator.Send(command);
            
            return NoContent();
        }

        [HttpPost("withdraw")]
        public async Task<IActionResult> Withdraw([FromBody] WithdrawCommand command)
        {
            await mediator.Send(command);

            return NoContent();
        }


    }
}
