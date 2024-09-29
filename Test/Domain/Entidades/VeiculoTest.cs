using minimal_api.Dominio.Entidades;
using minimal_api.Migrations;
using MinimalAPI.Dominio.Entidades;

namespace Test.Domain.Entidades;

[TestClass]
public class VeiculoTest
{
    [TestMethod]
    public void TestGetSetPropriedades()
    {
        //Arrange
        var veiculo = new Veiculo();

        //Act
        veiculo.Id = 1;
        veiculo.Nome = "Tempra";
        veiculo.Marca = "Fiat";
        veiculo.Ano = 2000;

        //Assert
        Assert.AreEqual(1, veiculo.Id);
        Assert.AreEqual("Tempra", veiculo.Nome);
        Assert.AreEqual("Fiat", veiculo.Marca);
        Assert.AreEqual(2000, veiculo.Ano);        
    }
}