﻿using AgpromaWebAPI.model;
using AgpromaWebAPI.Repository;
using AgpromaWebAPI.Service;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestingAgProMa.Services
{
    public class StoryServiceTest
    {
        [Fact]
        public void Story_Service_GetAll_Method_To_GetAll_Request_Should_Be_NotNull()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.GetAll(1)).Returns(requests); //mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.GetAll(1);
            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void Story_Service_GetAll_Method_To_GetAll_Request_Should_Compare_Values()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.GetAll(1)).Returns(requests); //mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.GetAll(1);
            //Assert
            Assert.Equal(requests, res);
        }
        [Fact]
        public void Story_Service_GetAll_Method_should_return_productbacklog_type_object()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.GetAll(1)).Returns(requests); //mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.GetAll(1);
            //Assert
            Assert.IsType<List<UserStory>>(res);
        }
        [Fact]
        public void Story_Service_Update_Method_To_Update_userStory_Should_Be_NotNull()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Update(request)).Returns(request);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.Update(request);
            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void Story_Service_Update_Method_To_Update_userStory_Should_Compare_Values()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Update(request)).Returns(request);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.Update(request);
            //Assert
            Assert.Equal(request, res);
        }
        [Fact]
        public void Story_Service_Update_Method_To_Update_userStory_Should_Be_Of_UserStory_type()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Update(request)).Returns(request);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.Update(request);
            //Assert
            Assert.Equal(request, res);
            Assert.IsType<UserStory>(res);
        }
        [Fact]
        public void Story_Service_Update_Method_should_return_ProductBacklog_Type_object()
        {
            //Arrange
            List<UserStory> requests = new List<UserStory>();
            var request = new UserStory();
            request.StoryId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.Update(request)).Returns(request);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.Update(request);
            //Assert
            Assert.IsType<UserStory>(res);
        }
        [Fact]
        public void Story_Service_JoinGroup_Method_Should_Be_NotNull()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.JoinGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.JoinGroup(It.IsAny<int>());
            //Assert
            Assert.NotNull(res);
        }
        [Fact]
        public void Story_Service_JoinGroup_Method_Should_Compare_Values()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.JoinGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.JoinGroup(It.IsAny<int>());
            //Assert
            Assert.Equal(requests, res);
        }
        [Fact]
        public void Story_Service_JoinGroup_Method_should_return_SignalIRMaster_type_object()
        {
            //Arrange
            List<SignalRMaster> requests = new List<SignalRMaster>();
            var request = new SignalRMaster();
            request.MemberId = 1;
            requests.Add(request);
            var mockRepoReq = new Mock<IStoryRepository>(); //mocking RequestRepository
            mockRepoReq.Setup(x => x.JoinGroup(It.IsAny<int>())).Returns(requests);//mocking GetAll() of RequestRepository
            StoryService obj = new StoryService(mockRepoReq.Object);
            //Act
            var res = obj.JoinGroup(It.IsAny<int>());
            //Assert
            Assert.IsType<List<SignalRMaster>>(res);
        }
        [Fact]
        public void Story_service_Add_method_throw_exception_with_invalid_value_type()
        {
            //Arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            UserStory backlog2 = new UserStory();
            backlog.StoryId = 2;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Add(backlog)).Throws(new FormatException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Add(backlog));
            //Assert
            Assert.IsType<FormatException>(exception);
        }
        [Fact]
        public void Story_service_Add_method_throw_nullrefrence_Exception()
        {
            //Arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Add(backlog)).Throws(new NullReferenceException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Add(backlog));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Story_service_Delete_method_throw_exception_with_invalid_value_type()
        {
            //Arrange
            UserStory backlog = new UserStory();
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Delete(It.IsAny<int>())).Throws(new FormatException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Delete(It.IsAny<int>()));
            //Assert
            Assert.IsType<FormatException>(exception);
        }
        [Fact]
        public void Story_service_Delete_method_throw_nullReferenceException()
        {
            //Arrange
            UserStory backlog = new UserStory();
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Delete(It.IsAny<int>())).Throws(new NullReferenceException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Delete(It.IsAny<int>()));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Story_service_update_method_throw_nullrefrence_Exception()
        {
            //arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Update(backlog)).Throws(new NullReferenceException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Update(backlog));
            //Assert
            Assert.IsType<NullReferenceException>(exception);
        }
        [Fact]
        public void Story_service_update_method_throw_Format_Exception_with_invalid_input()
        {
            //Arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.Update(backlog)).Throws(new FormatException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.Update(backlog));
            //Assert
            Assert.IsType<FormatException>(exception);
        }
        [Fact]
        public void Story_service_setConnection_method_should_throw_Format_Exception_with_invalid_input()
        {
            //Arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.setConnectionId(It.IsAny<string>(), It.IsAny<int>())).Throws(new FormatException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.setConnectionId(It.IsAny<string>(), It.IsAny<int>()));
            //Assert
            Assert.IsType<FormatException>(exception);
        }
        [Fact]
        public void Story_service_setConnection_method_should_throw_Argument_Null_Exception_with_invalid_input()
        {
            //Arrange
            UserStory backlog = new UserStory();
            backlog.StoryId = 1;
            var mockrepo = new Mock<IStoryRepository>();
            mockrepo.Setup(x => x.setConnectionId(It.IsAny<string>(), It.IsAny<int>())).Throws(new ArgumentNullException());
            StoryService obj = new StoryService(mockrepo.Object);
            //Act
            var exception = Record.Exception(() => obj.setConnectionId(It.IsAny<string>(), It.IsAny<int>()));
            //Assert
            Assert.IsType<ArgumentNullException>(exception);
        }
    }
}