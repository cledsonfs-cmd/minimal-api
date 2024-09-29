using minimal_api.Dominio.Interfaces;
using MinimalAPI.Dominio.Entidades;
using MinimalAPI.DTOs;
using MinimalAPI.Infraestrutura.Db;

namespace MinimalAPI.Dominio.Servicos;

public class AdministradorServico : IAdministradorServico
{
    private readonly DbContexto _contexto;

    public AdministradorServico(DbContexto db)
    {
        _contexto = db;
    }

    public Administrador? BuscaPorId(int id)
    {
         return _contexto.administradores.Where(x => x.Id == id).FirstOrDefault();
    }

    public Administrador Incluir(Administrador administrador)
    {
        _contexto.administradores.Add(administrador);
        _contexto.SaveChanges();
        return administrador;
    }

    public Administrador? Login(LoginDTO loginDTO)
    {
        return _contexto.administradores.Where(a => a.Email == loginDTO.Email && a.Senha == loginDTO.Senha).FirstOrDefault();

    }

    public List<Administrador> Todos(int? pagina)
    {
        var query =_contexto.administradores.AsQueryable();
            
        int itensPorPagina = 10;
        if(pagina != null)
            query = query.Skip(((int)pagina-1)*itensPorPagina).Take(itensPorPagina);

        return query.ToList();  
    }

}