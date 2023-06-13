using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Routes.Account;

namespace UnitTests;

public class LoginRouteTests
{
    [Fact]
    public void GetTest()
    {
        // Arrange
        // await using var context = new MockDb().CreateDbContext();
        //
        // context.Todos.Add(new Todo
        // {
        //     Id = 1,
        //     Title = "Test title",
        //     Description = "Test description",
        //     IsDone = false
        // });
        //
        // await context.SaveChangesAsync();

        // Act
        // var result = LoginRoute.GetTest();
        
        //Assert
        // Assert.IsType<Results<Ok<Coords>, BadRequest>>(result);

        // var okResult = (Ok)result;

        // Assert.NotNull(okResult.Value);
        // Assert.Equal(1, okResult.Value.Id);
    }
}

// using System;
// using System.Threading.Tasks;
// using Application.Services.Login.Queries;
// using FluentAssertions;
// using LanguageExt;
// using MediatR;
// using Microsoft.AspNetCore.Http;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Mvc.Abstractions;
// using Microsoft.AspNetCore.Mvc.ModelBinding;
// using Microsoft.AspNetCore.Routing;
// using Moq;
// using NUnit.Framework;
// using WebApi.Routes.Account;
//
// namespace TestProject.Routes.Account
// {
//     [TestFixture]
//     public class LoginRouteTests
//     {
//         private Mock<IMediator> _mediatorMock;
//         private DefaultHttpContext _httpContext;
//         private ActionContext _actionContext;
//
//         [SetUp]
//         public void SetUp()
//         {
//             _mediatorMock = new Mock<IMediator>();
//             _httpContext = new DefaultHttpContext();
//             _actionContext = new ActionContext(
//                 _httpContext,
//                 new Mock<RouteData>().Object,
//                 new Mock<ActionDescriptor>().Object,
//                 new ModelStateDictionary());
//         }

        // [Test]
        // public async Task MapLoginRoute_LoginWithPhone_ReturnsOk()
        // {
        //     // Arrange
        //     var request = new UserByPhoneNumberQuery { Phone = "1234567890" };
        //     var expectedResult = new UserByPhoneNumberResult { IsValid = true };
        //     _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResult);
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "loginWithPhone");
        //     // var controller = new LoginRouteController(_mediatorMock.Object)
        //     // {
        //     //     ControllerContext = new ControllerContext(_actionContext)
        //     //     {
        //     //         HttpContext = _httpContext
        //     //     }
        //     // };
        //
        //     // Act
        //     var result = await controller.LoginWithPhone(request);
        //
        //     // Assert
        //     result.Should().BeOfType<OkObjectResult>();
        //     var okResult = (OkObjectResult)result;
        //     okResult.Value.Should().BeEquivalentTo(new
        //     {
        //         Valid = true,
        //         Message = "Otp sent"
        //     });
        // }

        // [Test]
        // public async Task MapLoginRoute_LoginWithPhone_ThrowsException_ReturnsBadRequest()
        // {
        //     // Arrange
        //     var request = new UserByPhoneNumberQuery { Phone = "1234567890" };
        //     var exception = new Exception("Something went wrong");
        //     _mediatorMock.Setup(x => x.Send(request, default)).ThrowsAsync(exception);
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "loginWithPhone");
        //     var controller = new LoginRouteController(_mediatorMock.Object)
        //     {
        //         ControllerContext = new ControllerContext(_actionContext)
        //         {
        //             HttpContext = _httpContext
        //         }
        //     };
        //
        //     // Act
        //     var result = await controller.LoginWithPhone(request);
        //
        //     // Assert
        //     result.Should().BeOfType<BadRequestObjectResult>();
        //     var badRequestResult = (BadRequestObjectResult)result;
        //     badRequestResult.Value.Should().BeEquivalentTo(new
        //     {
        //         Valid = false,
        //         Message = exception.Message,
        //         exception.StackTrace
        //     });
        // }

        // [Test]
        // public async Task MapLoginRoute_LoginWithEmail_ReturnsOk()
        // {
        //     // Arrange
        //     var request = new UserByEmailAddressQuery { Email = "test@example.com", Password = "password" };
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "loginWithEmail");
        //     var controller = new LoginRouteController(_mediatorMock.Object)
        //     {
        //         ControllerContext = new ControllerContext(_actionContext)
        //         {
        //             HttpContext = _httpContext
        //         }
        //     };
        //
        //     // Act
        //     var result = await controller.LoginWithEmail(request);
        //
        //     // Assert
        //     result.Should().BeOfType<OkObjectResult>();
        //     var okResult = (OkObjectResult)result;
        //     okResult.Value.Should().Be("Login with phone test@example.com Password: password");
        // }

        // [Test]
        // public async Task MapLoginRoute_LoginWithPhoneAndPass_ReturnsOk()
        // {
        //     // Arrange
        //     var request = new UserByPhoneAndPasswordQuery { Phone = "1234567890", Password = "password" };
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "loginWithPhoneAndPass");
        //     var controller = new LoginRouteController(_mediatorMock.Object)
        //     {
        //         ControllerContext = new ControllerContext(_actionContext)
        //         {
        //             HttpContext = _httpContext
        //         }
        //     };
        //
        //     // Act
        //     var result = await controller.LoginWithPhoneAndPass(request);
        //
        //     // Assert
        //     result.Should().BeOfType<OkObjectResult>();
        //     var okResult = (OkObjectResult)result;
        //     okResult.Value.Should().Be("Login with phone: 1234567890 Password: password");
        // }

        // [Test]
        // public async Task MapLoginRoute_VerifyPhone_ReturnsOk()
        // {
        //     // Arrange
        //     var request = new VerifyCodeQuery { Phone = "1234567890", Code = "1234" };
        //     var expectedResult = new VerifyCodeResult { IsValid = true };
        //     _mediatorMock.Setup(x => x.Send(request, default)).ReturnsAsync(expectedResult);
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "verifyPhone");
        //     var controller = new LoginRouteController(_mediatorMock.Object)
        //     {
        //         ControllerContext = new ControllerContext(_actionContext)
        //         {
        //             HttpContext = _httpContext
        //         }
        //     };
        //
        //     // Act
        //     var result = await controller.VerifyPhone(request);
        //
        //     // Assert
        //     result.Should().BeOfType<OkObjectResult>();
        //     var okResult = (OkObjectResult)result;
        //     okResult.Value.Should().BeEquivalentTo(new
        //     {
        //         Valid = true,
        //         Message = "Verify code success",
        //         Data = expectedResult
        //     });
        // }

        // [Test]
        // public async Task MapLoginRoute_VerifyPhone_ThrowsException_ReturnsBadRequest()
        // {
        //     // Arrange
        //     var request = new VerifyCodeQuery { Phone = "1234567890", Code = "1234" };
        //     var exception = new Exception("Something went wrong");
        //     _mediatorMock.Setup(x => x.Send(request, default)).ThrowsAsync(exception);
        //     var routeBuilder = new Mock<IEndpointRouteBuilder>();
        //     LoginRoute.MapLoginRoute(routeBuilder.Object);
        //     var routeContext = new RouteContext(_httpContext) { RouteData = new RouteData() };
        //     routeContext.RouteData.Values.Add("action", "verifyPhone");
        //     var controller = new LoginRouteController(_mediatorMock.Object)
        //     {
        //         ControllerContext = new ControllerContext(_actionContext)
        //         {
        //             HttpContext = _httpContext
        //         }
        //     };
        //
        //     // Act
        //     var result = await controller.VerifyPhone(request);
        //
        //     // Assert
        //     result.Should().BeOfType<BadRequestObjectResult>();
        //     var badRequestResult = (BadRequestObjectResult)result;
        //     badRequestResult.Value.Should().BeEquivalentTo(new
        //     {
        //         Valid = false,
        //         Message = exception.Message,
        //         exception.StackTrace
        //     });
        // }
    // }

    // public class LoginRouteController : ControllerBase
    // {
    //     private readonly IMediator _mediator;
    //
    //     public LoginRouteController(IMediator mediator)
    //     {
    //         _mediator = mediator;
    //     }
    //
    //     public async Task<IActionResult> LoginWithPhone(UserByPhoneNumberQuery request)
    //     {
    //         return await LoginRoute.LoginWithPhone(request, _mediator);
    //     }
    //
    //     public async Task<IActionResult> LoginWithEmail(UserByEmailAddressQuery request)
    //     {
    //         return await LoginRoute.LoginWithEmail(request);
    //     }
    //
    //     public async Task<IActionResult> LoginWithPhoneAndPass(UserByPhoneAndPasswordQuery request)
    //     {
    //         return await LoginRoute.LoginWithPhoneAndPass(request);
    //     }
    //
    //     public async Task<IActionResult> VerifyPhone(VerifyCodeQuery request)
    //     {
    //         return await LoginRoute.VerifyPhone(request, _mediator);
    //     }
    // }
// }