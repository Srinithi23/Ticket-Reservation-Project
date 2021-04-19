using System;
using System.Collections.Generic;

#nullable disable

namespace PassengerApi.Models
{
    public partial class PassengerDetail
    {
        public int SerialNo { get; set; }
        public int? TrainNo { get; set; }
        public string PassengerName { get; set; }
        public string Gender { get; set; }
        public int? Age { get; set; }
        public string EmailId { get; set; }

        public virtual Register Email { get; set; }
        public virtual TrainDetail TrainNoNavigation { get; set; }
        //public PassengerDetail(int serialno, int TNo, string pname, string gender, int age, string email)
        //{

        //    SerialNo = serialno;
        //    TrainNo = TNo;
        //    PassengerName = pname;
        //    Gender = gender;
        //    Age = age;
        //    EmailId = email;
        //}
    }
}
