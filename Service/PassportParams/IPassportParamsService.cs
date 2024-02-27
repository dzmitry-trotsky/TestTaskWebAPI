using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.PassportParams
{
    public interface IPassportParamsService
    {
        public List<long> GetIssuedToMillPassportParam();
    }
}
