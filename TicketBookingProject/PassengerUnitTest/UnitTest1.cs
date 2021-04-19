//using Microsoft.EntityFrameworkCore;
//using Moq;
//using NUnit.Framework;
//using PassengerApi.Models;
//using PassengerApi.Repository;
//using System.Collections.Generic;
//using System.Linq;

//namespace PassengerUnitTest
//{
//    public class Tests
//    {
       
//            List<PassengerDetail> train = new List<PassengerDetail>();
//            IQueryable<PassengerDetail> passdata;
//            Mock<DbSet<PassengerDetail>> mockSet;
//            Mock<TICKET_BOOKINGContext> contextmock;


//            [SetUp]
//            public void Setup()
//            {
//            train = new List<PassengerDetail>()
//            {
//               new PassengerDetail{ SerialNo=1,PassengerName="Nisha"},
//               new PassengerDetail{ SerialNo=2,PassengerName="Sri"},


//            };
//                passdata = train.AsQueryable();
//                mockSet = new Mock<DbSet<PassengerDetail>>();
//                mockSet.As<IQueryable<PassengerDetail>>().Setup(m => m.Provider).Returns(passdata.Provider);
//                mockSet.As<IQueryable<PassengerDetail>>().Setup(m => m.Expression).Returns(passdata.Expression);
//                mockSet.As<IQueryable<PassengerDetail>>().Setup(m => m.ElementType).Returns(passdata.ElementType);
//                mockSet.As<IQueryable<PassengerDetail>>().Setup(m => m.GetEnumerator()).Returns(passdata.GetEnumerator());
//                var p = new DbContextOptions<TICKET_BOOKINGContext>();
//                contextmock = new Mock<TICKET_BOOKINGContext>(p);
//                contextmock.Setup(x => x.PassengerDetails).Returns(mockSet.Object);
//            }

//            [Test]
//            public void GetTrain()
//            {

//                var passrepo = new Passenger(contextmock.Object);
//                var searchlist = passrepo.GetPassengerById(1);
//            string pname = searchlist.PassengerName;
//            Assert.AreEqual("Nisha", pname);
//        }


//    }

//    }
