using PassengerApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using BookingDetailsApi.Models;
namespace PassengerApi.Repository
{
    public class Passenger : IPassenger
    {
        private readonly TICKET_BOOKINGContext _context;

        public Passenger()
        {

        }
        public Passenger(TICKET_BOOKINGContext context)
        {
            _context = context;
        }


        public IEnumerable<PassengerDetail> GetPassengerDetail()
        {
            return _context.PassengerDetails.ToList();
        }
        public PassengerDetail GetPassengerById(int sno)
        {
            PassengerDetail item = _context.PassengerDetails.Find(sno);

            return item;
        }
        public async Task<PassengerDetail> AddPassenger(PassengerDetail item)
        {
            PassengerDetail pass = null;
            /*  if (item == null)
              {
                  throw new NullReferenceException();
              }
              else
              {*/
            //    var noseats = _context.BookingDetails.Where(tr => tr.TrainNo == item.TrainNo).Select(tr => tr.NoOfSeats);
            //    int var1 = Convert.ToInt32(noseats);
            //    for (int i = 0; i < var1; i++)
            //    {


            //}
            pass = new PassengerDetail()
            {
                TrainNo = item.TrainNo,
                PassengerName = item.PassengerName,
                Gender = item.Gender,
                Age = item.Age,
                EmailId = item.EmailId,
            };
            await _context.PassengerDetails.AddAsync(pass);
            await _context.SaveChangesAsync();


            return pass;
        }
        public async Task<PassengerDetail> UpdatePassengerDetail(PassengerDetail item, int sno)
        {
            //var passenger = _context.PassengerDetails.Where(s => s.SerialNo == item.SerialNo).FirstOrDefault<PassengerDetail>();
            PassengerDetail passenger = await _context.PassengerDetails.FindAsync(sno);

            passenger.PassengerName = item.PassengerName;
            passenger.Gender = item.Gender;
            passenger.Age = item.Age;
            passenger.EmailId = item.EmailId;
            await _context.SaveChangesAsync();



            return passenger;
        }
    }





}




