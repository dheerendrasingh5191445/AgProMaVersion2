using AgProMa.Services;
using AgpromaWebAPI.model;
using AgpromaWebAPI.Service;
using AgpromaWebAPI.Viewmodel;
using ForgetPassword.Controllers;
using Moq;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace UnitTestingAgProMa.Controllers
{
    public class InviteMemberControllerTest
    {
        [Fact]
        public void Test_Case_To_Check_Return_All_Details_in_Get_Function()
        {
            //Arrange
            List<User> user = new List<User>();
            User master = new User();
            master.Email = "sdsd@gmail.com";
            master.Id = 1;
            master.Password = "2332";

            user.Add(master);
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockanotherobj.Setup(x => x.GetAllDetails()).Returns(user);
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (ObjectResult)obj.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public void Test_Case_To_Check_Returns_Null_in_Get_Function()
        {
            //Arrange
            List<User> user = new List<User>();
            User master = new User();

            user.Add(null);
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockanotherobj.Setup(x => x.GetAllDetails()).Returns(user);
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (ObjectResult)obj.Get();
            //Assert
            Assert.IsType<OkObjectResult>(result);
        }
        [Fact]
        public void Test_Case_To_Check_exception_in_Get_Function()
        {
            //Arrange
            List<User> user = new List<User>();
            User master = new User();

            user.Add(null);
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockanotherobj.Setup(x => x.GetAllDetails()).Throws(new Exception());
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (StatusCodeResult)obj.Get();
            //Assert
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void Should__Return_Already_Exist_ok_objectResult()
        {
            //Arrange
            InvitePeople ppl = new InvitePeople();
            ppl.Email = "abc";
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockobj.Setup(x => x.EmailForInvitation(It.IsAny<InvitePeople>())).Returns(0);
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (ObjectResult)obj.post(It.IsAny<InvitePeople>());
            //Assert
            Assert.Equal("Already Exist", result.Value);
        }
        [Fact]
        public void Should_Return_Mail_Sent()
        {
            //Arrange
            InvitePeople ppl = new InvitePeople();
            ppl.Email = "abc";
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockobj.Setup(x => x.EmailForInvitation(It.IsAny<InvitePeople>())).Returns(1);
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (ObjectResult)obj.post(It.IsAny<InvitePeople>());
            //Assert
            Assert.Equal("Mail Sent", result.Value);
        }
        [Fact]
        public void Should_return_internal_server_error()
        {
            //Arrange
            InvitePeople ppl = new InvitePeople();
            ppl.Email = "abc";
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockobj.Setup(x => x.EmailForInvitation(It.IsAny<InvitePeople>())).Throws(new Exception());
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (StatusCodeResult)obj.post(It.IsAny<InvitePeople>());
            //Assert
            Assert.Equal(500, result.StatusCode);
        }
        [Fact]
        public void Should_throw_ArgumentnullException()
        {
            //Arrange
            InvitePeople ppl = new InvitePeople();
            ppl.Email = "abc";
            var mockobj = new Mock<IinviteMembersService>();
            var mockanotherobj = new Mock<ISignUpService>();
            mockobj.Setup(x => x.EmailForInvitation(It.IsAny<InvitePeople>())).Throws(new ArgumentNullException());
            InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
            //Act
            var result = (StatusCodeResult)obj.post(It.IsAny<InvitePeople>());
            //Assert
            Assert.Equal(400, result.StatusCode);
        }
        //[Fact]
        //public void Test_To_Check_Get_Member_Name_Should_Return_OkObjectResult()
        //{
        //    //Arrange
        //    List<InviteExistingMember> list = new List<InviteExistingMember>();
        //    InviteExistingMember member = new InviteExistingMember();
        //    member.Email = "fsa";
        //    list.Add(member);
        //    var mockobj = new Mock<IinviteMembersService>();
        //    var mockanotherobj = new Mock<ISignUpService>();
        //    mockobj.Setup(x => x.GetMemberName(It.IsAny<int>())).Returns(list);
        //    InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
        //    //Act
        //    var res = (ObjectResult)obj.GetMemberName(1);

        //    //Assert
        //    Assert.Equal(200, res.StatusCode);
        //}

        //[Fact]
        //public void Test_To_Check_Get_Member_Name_Should_return_Bad_Request()
        //{
        //    //Arrange
        //    List<InviteExistingMember> list = new List<InviteExistingMember>();
        //    InviteExistingMember member = new InviteExistingMember();
        //    member.Email = "tripathiishu16@gmail.com";
        //    list.Add(member);
        //    var mockobj = new Mock<IinviteMembersService>();
        //    var mockanotherobj = new Mock<ISignUpService>();
        //    mockobj.Setup(x => x.GetMemberName(It.IsAny<int>())).Throws(new Exception());
        //    InviteMembersController obj = new InviteMembersController(mockobj.Object, mockanotherobj.Object);
        //    //Act
        //    var res = (StatusCodeResult)obj.GetMemberName(1);

        //    //Assert
        //    Assert.Equal(400, res.StatusCode);
        //}
    }
}
