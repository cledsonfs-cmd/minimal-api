using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Servicos;
using minimal_api.Migrations;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.Dominio.Servicos;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace Test.Domain.Servicos;

[TestClass]
public class VeiculoServicoTest
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
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        var veiculo = new Veiculo();        
        veiculo.Id = 1;
        veiculo.Nome = "Tempra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2000;

        
        var servico = new VeiculoServico(context);

        //Act
        servico.Incluir(veiculo);

        //Assert
        Assert.AreEqual(1, servico.Todos(1, null, null).Count());      
    }

     [TestMethod]
    public void TestBuscarPorId()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

       
        var veiculo = new Veiculo();        
        veiculo.Id = 1;
        veiculo.Nome = "Tempra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2000;

        
        var servico = new VeiculoServico(context);

        //Act
        servico.Incluir(veiculo);
        var vTest = servico.BuscaPorId(veiculo.Id);

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Tempra", veiculo.Nome);
        Assert.AreEqual("Fiat", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);        
    }

     [TestMethod]
    public void TestBuscarTodos()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        
        var veiculo = new Veiculo();        
        veiculo.Id = 1;
        veiculo.Nome = "Tempra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2000;

       
        var veiculo1 = new Veiculo();        
        veiculo1.Id = 2;
        veiculo1.Nome = "ford ka";
        veiculo1.Marca = "Fprd";
        veiculo1.Ano = 2010;


        
        var servico = new VeiculoServico(context);

        //Act
        servico.Incluir(veiculo);
        servico.Incluir(veiculo1);
        var vTest = servico.Todos(1, null, null);

        //Assert
        Assert.AreEqual(2, vTest.Count());             
    }

     [TestMethod]
    public void TestDelete()
    {
        //Arrange
        var context = CriarContextoDeTeste();    
        context.Database.ExecuteSqlRaw("TRUNCATE TABLE Veiculos");

        
        var veiculo = new Veiculo();        
        veiculo.Id = 1;
        veiculo.Nome = "Tempra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2000;

       
        var veiculo1 = new Veiculo();        
        veiculo1.Id = 2;
        veiculo1.Nome = "ford ka";
        veiculo1.Marca = "Fprd";
        veiculo1.Ano = 2010;


        
        var servico = new VeiculoServico(context);

        //Act
        servico.Incluir(veiculo);
        servico.Incluir(veiculo1);
        servico.Apagar(veiculo);

        var vTest = servico.Todos(1, null, null);

        //Assert
        Assert.AreEqual(1, vTest.Count());             
    }

  
}