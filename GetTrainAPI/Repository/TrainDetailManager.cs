using GetTrainAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GetTrainAPI.Repository
{
    public class TrainDetailManager :ITrainDetailManager
    {
        private readonly TICKET_BOOKINGContext _context;

        public TrainDetailManager()
        {

        }
       public TrainDetailManager(TICKET_BOOKINGContext trainDetailManager)
        {
            _context = trainDetailManager;
        }

        public Task<TrainDetail> AddTrainDetail(TrainDetail item)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<TrainDetail> GetAllTrainDetail()
        //{
        //    throw new NotImplementedException();
        //}
        public async Task<ActionResult<IEnumerable<TrainDetail>>> GetAllTrainDetail()
        {
            return await _context.TrainDetails.ToListAsync();
        }
        //public IEnumerable<TrainDetail> GetAllTrainDetail()
        //{

        //    return _context.TrainDetails.ToList();

        //}
        public TrainDetail GetAllTrainById(int id)
        {
            TrainDetail item = _context.TrainDetails.Find(id);
            return item;
        }

        public Task<TrainDetail> RemoveTraindetail(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TrainDetail> UpdateTraindetail(TrainDetail item, int id)
        {
            throw new NotImplementedException();
        }

        IEnumerable<TrainDetail> ITrainDetailManager.GetAllTrainDetail()
        {
            throw new NotImplementedException();
        }
    }
}
