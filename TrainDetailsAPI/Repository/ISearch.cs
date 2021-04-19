using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDetailsAPI.Models;

namespace TrainDetailsAPI.Repository
{
    public interface ISearch
    {

        IEnumerable<TrainDetail> GetAllTrainDetail();

        List<TrainDetail> SearchTrain(string from, string to);
       
    }
}
