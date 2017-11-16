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
    public class SprintServiceTest
    {

        [Fact]
        public void Sprint_Service_Getall_Method_should_return_sprintBacklog_type_object()
        {
            //Arrange
            List<Sprint> requests = new List<Sprint>();
            var request = new Sprint();
            request.SprintId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.GetAll(1)).Returns(requests); //mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.GetAll(1);

            //Assert
            Assert.IsType<List<Sprint>>(res);
        }
        [Fact]
        public void Sprint_Service_GetAll_Method_should_return_allsprints()
        {
            //Arrange

            var request = new Sprint();
            request.SprintId = 1;

            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Get(1)).Returns(request); //mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.Get(1);

            //Assert
            Assert.Equal(res, request);
        }

        [Fact]
        public void Sprint_Service_Get_Method_should_return_particular_particualr_sprint()
        {
            //Arrange
            var request = new Sprint();
            request.SprintId = 1;
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Get(1)).Returns(request); //mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.Get(1);

            //Assert
            Assert.Equal(res, request);
        }

        [Fact]
        public void Sprint_Service_Get_Method_should_return_sprintBacklog_type_object()
        {
            //Arrange
            List<Sprint> requests = new List<Sprint>();
            var request = new Sprint();
            request.SprintId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.GetAll(1)).Returns(requests); //mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.GetAll(1);

            //Assert
            Assert.Equal(res, requests);
        }
        [Fact]
        public void Sprint_Service_CreateGroup_Method_Should_Be_NotNull()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.CreateGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.CreateGroup(It.IsAny<int>());

            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void Sprint_Service_CreateGroup_Method_Should_Compare_Values()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.CreateGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.CreateGroup(It.IsAny<int>());

            //Assert
            Assert.Equal(requests, res);
        }

        [Fact]
        public void Sprint_Service_CreateGroup_Method_should_return()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<ISprintRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.CreateGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            SprintService obj = new SprintService(mockRepoReq.Object);
            //Act
            var res = obj.CreateGroup(It.IsAny<int>());

            //Assert
            Assert.IsType<List<SignalRMaster>>(res);
        }
        [Fact]
        public void Sprint_service_Add_method_should_throw_null_exception_with_empty_input_object()
        {
            //Arrange
            Sprint bk = new Sprint();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Add(bk));
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Add(bk));
            //Assert
            Assert.Equal(null, exception);
        }
        [Fact]
        public void Sprint_service_Add_method_should_throw_nullReferenceException()
        {
            //Arrange
            Sprint bk = new Sprint();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Add(bk)).Throws(new NullReferenceException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Add(bk));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Sprint_service_Add_method_should_throw_FormatException()
        {
            //Arrange
            Sprint bk = new Sprint();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Add(bk)).Throws(new FormatException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Add(bk));
            //Assert
            Assert.IsType<FormatException>(exception);
        }

        [Fact]
        public void Sprint_service_Delete_method_should_throw_null_exception_with_empty_input_object()
        {
            //Arrange
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Delete(It.IsAny<int>()));
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Delete(It.IsAny<int>()));
            //Assert
            Assert.Equal(null, exception);
        }
        [Fact]
        public void Sprint_service_Delete_method_should_throw_nullReferenceException()
        {
            //Arrange
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Delete(It.IsAny<int>())).Throws(new NullReferenceException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Delete(It.IsAny<int>()));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Sprint_service_Delete_method_should_throw_FormatException()
        {
            //Arrange
            Sprint bk = new Sprint();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Delete(It.IsAny<int>())).Throws(new FormatException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Delete(It.IsAny<int>()));
            //Assert
            Assert.IsType<FormatException>(exception);
        }

        [Fact]
        public void Sprint_service_Update_method_should_throw_null_exception_with_empty_input_object()
        {
            //Arrange
            UserStory bk = new UserStory();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Update(It.IsAny<int>(), bk));
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Update(It.IsAny<int>(), bk));
            //Assert
            Assert.Equal(null, exception);
        }
        [Fact]
        public void Sprint_service_Update_method_should_throw_nullReferenceException()
        {
            //Arrange
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<UserStory>())).Throws(new NullReferenceException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Update(It.IsAny<int>(), It.IsAny<UserStory>()));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Sprint_service_Update_method_should_throw_FormatException()
        {
            //Arrange
            Sprint bk = new Sprint();
            var mockRepo = new Mock<ISprintRepository>();
            mockRepo.Setup(x => x.Update(It.IsAny<int>(), It.IsAny<UserStory>())).Throws(new FormatException());
            SprintService obj = new SprintService(mockRepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Update(It.IsAny<int>(), It.IsAny<UserStory>()));
            //Assert
            Assert.IsType<FormatException>(exception);
        }
    }
}