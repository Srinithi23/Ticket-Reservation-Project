using GetTrainAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetTrainAPI.Repository
{
    public interface ITrainDetailManager
    {
        IEnumerable<TrainDetail> GetAllTrainDetail();
        TrainDetail GetAllTrainById(int id);
        Task<TrainDetail> AddTrainDetail(TrainDetail item);
        Task<TrainDetail> UpdateTraindetail(TrainDetail item, int id);
        Task<TrainDetail> RemoveTraindetail(int id);
    }
}
