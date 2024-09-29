using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPI.Dominio.Entidades;

public class Administrador
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id {get;set;} = default;
    [Required]
    [StringLength(50)]
    public string Email {get;set;} = default!;
    [Required]
    [StringLength(10)]
    public string Senha {get;set;} = default!;
    public string Perfil {get;set;} = default!;
}