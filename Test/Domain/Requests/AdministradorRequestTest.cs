using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MinimalAPI.DTOs;
using Test.Domain.Helpers;

namespace Test.Domain.Requests
{
    [TestClass]
    public class AdministradorRequestTest    
    {

        [ClassInitialize]
        public static void ClassInit(TestContext testContext){
            Helpers.Setup.ClassInit(testContext);
        }
    
    [TestMethod]
    public async void TestIncluir()
    {
        //Arrange
        var loginDTO = new LoginDTO{
            Email = "adm@teste.com",
            Senha = "123456"
        };

        var content = new StringContent(JsonSerializer.Serialize(loginDTO), Encoding.UTF8, "Application/json");
      
        //Act
        var response = await Setup.client.PostAsync("/administradores/login", content);
    

        //Assert
        Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
       
    }
    }
}