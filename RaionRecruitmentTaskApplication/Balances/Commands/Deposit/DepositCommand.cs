using MediatR;
using RaionRecruitmentTaskApplication.Balances.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaionRecruitmentTaskApplication.Balances.Commands.Deposit
{
    public class DepositCommand : IRequest
    {
        public int? BalanceId { get; set; }
        public decimal DepositValue { get; set; }
    }

}
