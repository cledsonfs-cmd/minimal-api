using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using minimal_api.Dominio.Interfaces;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.DTOs;

namespace Test.Mocks
{
    public class AdministradorServicoMock : IAdministradorServico
    {
        private static List<Administrador> administradores = new List<Administrador>(){
            new Administrador{
                Id = 1,
                Email = "adm@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            },
            new Administrador{
                Id = 2,
                Email = "usuario@teste.com",
                Senha = "123456",
                Perfil = "Usuario"
            }
        };
        public Administrador? BuscaPorId(int id)
        {
            return administradores.Find(x => x.Id == id);
        }

        public Administrador Incluir(Administrador administrador)
        {
            administrador.Id = administradores.Count()+1;
            administradores.Add(administrador);
            return administrador;
        }

        public Administrador? Login(LoginDTO loginDTO)
        {
            return administradores.Find(x => x.Email == loginDTO.Email && x.Senha == loginDTO.Senha);
        }

        public List<Administrador> Todos(int? pagina)
        {
            return administradores;
        }
    }
}