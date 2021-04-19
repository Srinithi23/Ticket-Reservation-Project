using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainDetailsAPI.Models;

namespace TrainDetailsAPI.Repository
{
    public class Search : ISearch
    {
        private readonly TICKET_BOOKINGContext _context;
        public Search(TICKET_BOOKINGContext context)
        {
            _context = context;
        }
        public IEnumerable<TrainDetail> GetAllTrainDetail()
        {
          
                return _context.TrainDetails.ToList();

        }

        public List<TrainDetail> SearchTrain(string from, string to)
        {
            List<TrainDetail> searchtrain = _context.TrainDetails.Where(tr => tr.FromStation == from && tr.ToStation == to).Select(tr=>tr).ToList<TrainDetail>();


            return searchtrain;
            //TrainDetail item = _context.TrainDetails.Find(from, to);

            //return item;
            
                        //TrainDetail train = _context.TrainDetails.Select(from, to);

            //if ((!String.IsNullOrEmpty(from)&& !String.IsNullOrEmpty(to)))
            //{
            //    train = train.Where(s => s.FromStation.Contains(from)&& s.FromStation.Contains(to));
            //}


        }



    }
}
