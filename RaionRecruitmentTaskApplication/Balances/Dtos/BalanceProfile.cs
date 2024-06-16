

using AutoMapper;
using RaionRecruitmentTaskDomain.Entities;

namespace RaionRecruitmentTaskApplication.Balances.Dtos
{
    public class BalanceProfile : Profile
    {
        public BalanceProfile()
        {
            CreateMap<Balance, BalanceDto>()
                .ForMember(b => b.Owner, opt => opt.MapFrom(scr => scr.Owner == null ? null : $"{scr.Owner.Name} {scr.Owner.Surname}"));
        }
    }
}
