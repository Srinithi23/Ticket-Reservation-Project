using PassengerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PassengerApi.Repository
{
    public interface IPassenger
    {
        IEnumerable<PassengerDetail> GetPassengerDetail();
        PassengerDetail GetPassengerById(int sno);
        Task<PassengerDetail> AddPassenger(PassengerDetail passenger);
        Task<PassengerDetail> UpdatePassengerDetail(PassengerDetail passenger,int sno);
      

    }
}
