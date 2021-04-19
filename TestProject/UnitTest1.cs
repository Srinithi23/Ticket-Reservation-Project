using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using TrainDetailsAPI.Models;
using TrainDetailsAPI.Repository;

namespace TestProject
{
    public class Tests
    {
        
            List<TrainDetail> train = new List<TrainDetail>();
            IQueryable<TrainDetail> traindata;

            Mock<DbSet<TrainDetail>> mockSet;
            Mock<TICKET_BOOKINGContext> contextmock;


            [SetUp]
            public void Setup()
            {
                train = new List<TrainDetail>()
            {
                new TrainDetail{TrainNo=100,TrainName="Amaravathi Express"},
                new TrainDetail{TrainNo=101,TrainName="Ganga Express"},

            };
                traindata = train.AsQueryable();
                mockSet = new Mock<DbSet<TrainDetail>>();
                mockSet.As<IQueryable<TrainDetail>>().Setup(m => m.Provider).Returns(traindata.Provider);
                mockSet.As<IQueryable<TrainDetail>>().Setup(m => m.Expression).Returns(traindata.Expression);
                mockSet.As<IQueryable<TrainDetail>>().Setup(m => m.ElementType).Returns(traindata.ElementType);
                mockSet.As<IQueryable<TrainDetail>>().Setup(m => m.GetEnumerator()).Returns(traindata.GetEnumerator());
                var p = new DbContextOptions<TICKET_BOOKINGContext>();
                contextmock = new Mock<TICKET_BOOKINGContext>(p);
                contextmock.Setup(x => x.TrainDetails).Returns(mockSet.Object);
            }

            [Test]
            public void GetTrain()
            {

                var searchrepo = new Search(contextmock.Object);
                var searchlist = searchrepo.GetAllTrainDetail();

                Assert.AreEqual(2, searchlist.Count());
            }


        }

    }
