using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Entidades;
using minimal_api.Dominio.Interfaces;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.DTOs;

namespace Test.Mocks
{
    public class VeiculoServicoMock : IVeiculoServico
    {
        private static List<Veiculo> veiculos = new List<Veiculo>();

        public void Apagar(Veiculo veiculo)
        {
            veiculos.Remove(veiculo);
        }

        public void Atualizar(Veiculo veiculo)
        {
            var v = veiculos.Find(x => x.Id == veiculo.Id);
            if(v!=null){
                v.Marca = veiculo.Marca;
                v.Ano = veiculo.Ano;
                v.Nome = veiculo.Nome;
                
                veiculos.Remove(veiculo);
                veiculos.Add(v);
            }
        
        }

        public Veiculo? BuscaPorId(int id)
        {
             return veiculos.Find(x => x.Id == id);
        }

        public void Incluir(Veiculo veiculo)
        {
            veiculo.Id = veiculos.Count()+1;
            veiculos.Add(veiculo);            
        }

        public List<Veiculo> Todos(int? pagina = 1, string? nome = null, string? marca = null)
        {
            return veiculos;
        }
    }
}