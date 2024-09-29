using Microsoft.EntityFrameworkCore;
using minimal_api.Dominio.Entidades;
using MinimalAPI.Dominio.Entidades;

namespace MinimalAPI.Infraestrutura.Db;
public class DbContexto : DbContext
{
    private readonly IConfiguration _configuracaoAppSettings;
    public DbContexto(IConfiguration configuracaoAppSettings)
    {
        this._configuracaoAppSettings = configuracaoAppSettings;
    }
    public DbSet<Administrador> administradores {get; set;} = default!;
    public DbSet<Veiculo> veiculos {get; set;} = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administrador>().HasData(
            new Administrador{  
                Id = 1,              
                Email = "administrador@teste.com",
                Senha = "123456",
                Perfil = "Adm"
            }
        );
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured){
            var stringConexao = _configuracaoAppSettings.GetConnectionString("mysql")?.ToString();
            if (!string.IsNullOrEmpty(stringConexao)){
                optionsBuilder.UseMySql(stringConexao,ServerVersion.AutoDetect(stringConexao));
            }   
        }
    }
}