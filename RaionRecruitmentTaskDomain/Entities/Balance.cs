using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaionRecruitmentTaskDomain.Entities
{
    public class Balance
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public AccountOwner? Owner { get; set; }
        [Timestamp]
        public byte[]? RowVersion { get; set; }
    }
}
