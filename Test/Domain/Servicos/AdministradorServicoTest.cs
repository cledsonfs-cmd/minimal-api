using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Migrations;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.Dominio.Servicos;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class AdministradorServicoTest
{

    private DbContexto CriarContextoDeTeste()
    {
        var assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location); 
        var path = Path.GetFullPath(Path.Combine(assemblyPath ?? "", "..", "..", "..")); 

        var build = new ConfigurationBuilder()
        //.SetBasePath(path ?? Directory.GetCurrentDirectory())
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json", optional: false, reloadOnChange:true)   
        .AddEnvironmentVariables();

        var configuration = build.Build();

        return new DbContexto(configuration);
    }

    [TestMethod]
    public void TestIncluir()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        
        var admServico = new AdministradorServico(context);

        //Act
        admServico.Incluir(adm);

        //Assert
        Assert.AreEqual(1, admServico.Todos(1).Count());      
    }

     [TestMethod]
    public void TestBuscarPorId()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        
        var admServico = new AdministradorServico(context);

        //Act
        admServico.Incluir(adm);
        var admTest = admServico.BuscaPorId(adm.Id);

        //Assert
        Assert.AreEqual(1, admTest.Id);
        Assert.AreEqual("teste@teste.com", admTest.Email);
        Assert.AreEqual("teste", admTest.Senha);
        Assert.AreEqual("Adm", admTest.Perfil);        
    }

     [TestMethod]
    public void TestBuscarTodos()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        var adm2 = new Administrador();
        adm2.Id = 2;
        adm2.Email = "teste2@teste.com";
        adm2.Senha = "teste3";
        adm2.Perfil = "Adm";


        
        var admServico = new AdministradorServico(context);

        //Act
        admServico.Incluir(adm);
        admServico.Incluir(adm2);
        var admsTest = admServico.Todos(1);

        //Assert
        Assert.AreEqual(2, admsTest.Count());             
    }

      [TestMethod]
    public void TestLogin()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Administradores");

        var adm = new Administrador();
        adm.Id = 1;
        adm.Email = "teste@teste.com";
        adm.Senha = "teste";
        adm.Perfil = "Adm";

        
        var admServico = new AdministradorServico(context);

        //Act
        admServico.Incluir(adm);
        var admTest = admServico.Login(new LoginDTO{
            Email = "teste@teste.com",
            Senha = "teste"
        });

        //Assert        
        Assert.AreEqual("teste@teste.com", admTest.Email);
        
    }
}