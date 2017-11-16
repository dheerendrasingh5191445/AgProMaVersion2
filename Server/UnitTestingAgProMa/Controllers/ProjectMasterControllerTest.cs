using AgpromaWebAPI.Controllers;
using AgpromaWebAPI.model;
using AgpromaWebAPI.Service;
using AgpromaWebAPI.Viewmodel;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
namespace UnitTestingAgProMa.Controllers
{
    public class ProjectMasterControllerTest
    {
        [Fact]
        public void Test_Case_To_Check_Return_Ok_of_Get_by_id()
        {
            //Arrange
            List<ProjectDetailView> pros = new List<ProjectDetailView>();
            ProjectDetailView pro = new ProjectDetailView() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.GetProjectById(It.IsAny<int>())).Returns(pros);
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Get(It.IsAny<int>());
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Test_Case_To_Check_Return_500_StatusCode_of_Get_by_id()
        {
            List<ProjectDetailView> pros = new List<ProjectDetailView>();
            ProjectDetailView pro = new ProjectDetailView() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.GetProjectById(It.IsAny<int>())).Throws(new Exception());
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Get(It.IsAny<int>());
            var result1 = (StatusCodeResult)result;
            //Assert
            Assert.Equal(500, result1.StatusCode);
        }
        [Fact]
        public void Get_Method_Should_Return_Null()
        {
            //Arrange
            var mockService = new Mock<IProjectMasterService>();
            var controller = new ProjectMasterController(mockService.Object);
            // Act
            IActionResult actionResult = controller.Get(1);
            var contentResult = actionResult as OkObjectResult;
            // Assert

            Assert.Null(contentResult);
        }
        [Fact]
        public void Test_Case_To_Check_Return_StatusCode_of_500_in_method_Post()
        {
            //Arrange
            List<Projectmembers> pros = new List<Projectmembers>();
            Projectmembers pro = new Projectmembers() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.AddProjectmembersL(It.IsAny<ProjectMaster>())).Throws(new Exception());
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Post(It.IsAny<ProjectMaster>());
            var result1 = (StatusCodeResult)result;
            //Assert
            Assert.Equal(500, result1.StatusCode);
        }
        [Fact]
        public void Test_Case_To_Check_Return_NotNull()
        {
            //Arrange
            List<Projectmembers> pros = new List<Projectmembers>();
            Projectmembers pro = new Projectmembers() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.AddProjectmembersL(It.IsAny<ProjectMaster>()));
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Post(It.IsAny<ProjectMaster>());
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Post_Method_When_Return_Null()
        {
            //Arrange
            var mockService = new Mock<IProjectMasterService>();
            var controller = new ProjectMasterController(mockService.Object);
            // Act
            IActionResult actionResult = controller.Post(It.IsAny<ProjectMaster>());
            var contentResult = actionResult as OkObjectResult;
            // Assert
            Assert.Null(contentResult);
        }
        [Fact]
        public void Test_Case_To_Check_Return_StatusCode_of_500_in_method_delete()
        {
            //Arrange
            List<Projectmembers> pros = new List<Projectmembers>();
            Projectmembers pro = new Projectmembers() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.DeleteProject(1)).Throws(new Exception());
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Delete(1);
            var result1 = (StatusCodeResult)result;
            //Assert
            Assert.Equal(500, result1.StatusCode);
        }
        [Fact]
        public void Delete_Method_When_Return_Null()
        {
            //Arrange
            var mockService = new Mock<IProjectMasterService>();
            var controller = new ProjectMasterController(mockService.Object);
            // Act
            IActionResult actionResult = controller.Delete(1);
            var contentResult = actionResult as OkObjectResult;
            // Assert
            Assert.Null(contentResult);
        }
        [Fact]
        public void Delete_Method_When_Return_NotNull()
        {
            //Arrange
            List<Projectmembers> pros = new List<Projectmembers>();
            Projectmembers pro = new Projectmembers() { ProjectId = 1 };
            pros.Add(pro);
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.DeleteProject(1));
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Delete(It.IsAny<int>());
            //Assert
            Assert.NotNull(result);
        }
        [Fact]
        public void Test_Case_To_Check_Return_StatusCode_of_500_in_method_Put()
        {
            //Arrange
            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.UpdateProject(1, It.IsAny<ProjectMaster>())).Throws(new Exception());
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Put(1, It.IsAny<ProjectMaster>());
            var result1 = (StatusCodeResult)result;
            //Assert
            Assert.Equal(500, result1.StatusCode);
        }
        [Fact]
        public void Put_Method_When_Return_NotNull()
        {
            //Arrange

            var mockObj = new Mock<IProjectMasterService>();
            mockObj.Setup(x => x.UpdateProject(1, It.IsAny<ProjectMaster>()));
            ProjectMasterController obj1 = new ProjectMasterController(mockObj.Object);
            //Act
            var result = obj1.Put(1, It.IsAny<ProjectMaster>());
            //Assert
            Assert.NotNull(result);
        }
    }
}