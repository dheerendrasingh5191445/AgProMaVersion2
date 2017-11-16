using AgpromaWebAPI.model;
using AgpromaWebAPI.Repository;
using AgpromaWebAPI.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace UnitTestingAgProMa.Services
{
    public class ReleasePlanServiceTest
    {
        //First Test Case
        [Fact]
        public void Test_For_Checking_The_GetReleasePlan_Should_Be_NotNull()
        {
            //Arrange
            List<ReleasePlan> releasePlan = new List<ReleasePlan>();
            var releaseModel = new ReleasePlan()
            {
                ReleasePlanId = 1
            };
            releasePlan.Add(releaseModel);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(x => x.GetAllRelease(It.IsAny<int>())).Returns(releasePlan);
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);

            //Act
            List<ReleasePlan> result = service.GetAllReleasePlan(1);

            //Assert
            Assert.NotNull(result);
        }

        //Second Test Case
        [Fact]
        public void Test_For_Checking_The_GetReleasePlan_Is_Of_ReleasePlanMaster()
        {
            //Arrange
            List<ReleasePlan> releasePlan = new List<ReleasePlan>();
            var releaseModel = new ReleasePlan()
            {
                ReleasePlanId = 1
            };
            releasePlan.Add(releaseModel);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(x => x.GetAllRelease(It.IsAny<int>())).Returns(releasePlan);
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);

            //Act
            List<ReleasePlan> result = service.GetAllReleasePlan(1);

            //Assert
            Assert.IsType<List<ReleasePlan>>(result);
        }

        //Third Test Case
        [Fact]
        public void Test_For_Checking_The_GetReleasePlan_Is_Not_Of_Any_Other_Model()
        {
            //Arrange
            List<ReleasePlan> releasePlan = new List<ReleasePlan>();
            var releaseModel = new ReleasePlan()
            {
                ReleasePlanId = 1
            };
            releasePlan.Add(releaseModel);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(x => x.GetAllRelease(It.IsAny<int>())).Returns(releasePlan);
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);

            //Act
            List<ReleasePlan> result = service.GetAllReleasePlan(1);

            //Assert
            Assert.IsNotType<Sprint>(result);
            Assert.IsNotType<EpicMaster>(result);
            Assert.IsNotType<UserStory>(result);
            Assert.IsNotType<ChecklistBacklog>(result);
            Assert.IsNotType<TaskBacklog>(result);
            Assert.IsNotType<TeamMaster>(result);
        }

        //Fiourth Test Case
        [Fact]
        public void Test_For_SignalR_Should_Be_Not_Null()
        {
            //Arrange
            List<SignalRMaster> signal = new List<SignalRMaster>();
            var signalR = new SignalRMaster()
            {
                SignalId = 1
            };
            signal.Add(signalR);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(x => x.CreateGroup(It.IsAny<int>())).Returns(signal);
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);

            //Act
            List<SignalRMaster> result = service.CreateGroup(1);

            //Assert
            Assert.NotNull(result);
        }

        //Fifth Test Case
        [Fact]
        public void Test_For_SignalR_Should_Be_Of_SignalRMaster()
        {
            //Arrange
            List<SignalRMaster> signal = new List<SignalRMaster>();
            var signalR = new SignalRMaster()
            {
                SignalId = 1
            };
            signal.Add(signalR);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(x => x.CreateGroup(It.IsAny<int>())).Returns(signal);
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);

            //Act
            List<SignalRMaster> result = service.CreateGroup(1);

            //Assert
            Assert.IsType<List<SignalRMaster>>(result);
        }

        //Sixth Test Case
        [Fact]
        public void Test_for_Checking_AddRelease()
        {
            //arrange
            List<ReleasePlan> releasePlan = new List<ReleasePlan>();
            var releaseModel = new ReleasePlan()
            {
                ReleasePlanId = 1
            };
            releasePlan.Add(releaseModel);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            var mockSprintRepository = new Mock<ISprintRepository>();
            mockReleasePlanRepo.Setup(m => m.AddRelease(It.IsAny<ReleasePlan>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);
            //act
            var ex = Record.Exception(() => service.AddRelease(releaseModel));
            //assert
            Assert.IsType<NullReferenceException>(ex);
        }

        //Seventh Test Case
        [Fact]
        public void Test_for_Checking_AddRelease_Should_Be_NotNull()
        {
            //arrange
            List<ReleasePlan> releasePlan = new List<ReleasePlan>();
            var releaseModel = new ReleasePlan()
            {
                ReleasePlanId = 1
            };
            releasePlan.Add(releaseModel);
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(m => m.AddRelease(It.IsAny<ReleasePlan>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);
            //act
            var ex = Record.Exception(() => service.AddRelease(releaseModel));
            //assert
            Assert.NotNull(ex);
        }

        //Eigth Test Case
        [Fact]
        public void Test_for_Checking_UpdateConnectionId()
        {
            //arrange
            SignalRMaster signalR = new SignalRMaster()
            {
                SignalId = 1
            };
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(m => m.UpdateConnectionId(It.IsAny<string>(), It.IsAny<int>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);
            //act
            var ex = Record.Exception(() => service.UpdateConnectionId(It.IsAny<string>(), It.IsAny<int>()));
            //assert
            Assert.IsType<NullReferenceException>(ex);
        }

        //Tenth Test Case
        [Fact]
        public void Test_for_Checking_UpdateConnectionId_Should_Be_NotNull()
        {
            //arrange
            SignalRMaster signalR = new SignalRMaster()
            {
                SignalId = 1
            };
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(m => m.UpdateConnectionId(It.IsAny<string>(), It.IsAny<int>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);
            //act
            var ex = Record.Exception(() => service.UpdateConnectionId(It.IsAny<string>(), It.IsAny<int>()));
            //assert
            Assert.NotNull(ex);
        }

        //Eleventh Test Case
        [Fact]
        public void Test_for_Checking_UpdateReleaseInSprint_Should_Be_NotNull()
        {
            //arrange
            Sprint sprint = new Sprint()
            {
                SprintId = 1
            };
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(m => m.UpdateReleaseInSprint(It.IsAny<int>(), It.IsAny<int>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);           //act
            var ex = Record.Exception(() => service.UpdateReleaseInSprint(It.IsAny<Sprint>(), It.IsAny<int>()));
            //assert
            Assert.NotNull(ex);
        }
        //Twelfth Test Case
        [Fact]
        public void Test_for_Checking_UpdateReleaseInSprint()
        {
            //arrange
            Sprint sprint = new Sprint()
            {
                SprintId = 1
            };
            var mockReleasePlanRepo = new Mock<IReleasePlansRepo>();
            mockReleasePlanRepo.Setup(m => m.UpdateReleaseInSprint(It.IsAny<int>(), It.IsAny<int>())).Throws(new NullReferenceException());
            ReleasePlansService service = new ReleasePlansService(mockReleasePlanRepo.Object);
            //act
            var ex = Record.Exception(() => service.UpdateReleaseInSprint(It.IsAny<Sprint>(), It.IsAny<int>()));
            //assert
            Assert.IsType<NullReferenceException>(ex);
        }
    }
}