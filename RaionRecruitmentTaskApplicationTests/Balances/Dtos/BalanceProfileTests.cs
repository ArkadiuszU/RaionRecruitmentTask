using Xunit;
using RaionRecruitmentTaskApplication.Balances.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RaionRecruitmentTaskApplication.Balances.Commands.Withdraw;
using AutoMapper;
using RaionRecruitmentTaskDomain.Entities;
using FluentAssertions;

namespace RaionRecruitmentTaskApplication.Balances.Dtos.Tests
{
    public class BalanceProfileTests
    {
        //TestMethod_Scenario_ExpectResult

        [Fact()]

        public void CreateMap_FromBalanceToBalanceDto_MapsCorrectly()
        {
            // arrange

            var configuration = new MapperConfiguration(cfg =>
                                cfg.AddProfile<BalanceProfile>());

            var mapper = configuration.CreateMapper();

            var balance = new Balance()
            {
                Id = 1,
                Owner = new AccountOwner()
                {
                    Id = 1,
                    Name = "TestName",
                    Surname = "TestSurname"
                },
                Value = 1
            };

            // act
            var balanceDto = mapper.Map<BalanceDto>(balance);

            // assert

            balanceDto.Should().NotBeNull();
            balanceDto.Id.Should().Be(balance.Id);
            balanceDto.Value.Should().Be(balance.Value);
            balanceDto.Owner.Should().Be($"{balance.Owner.Name} {balance.Owner.Surname}");
        }
    }
}