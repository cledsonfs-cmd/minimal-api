using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace minimal_api.Dominio.ModelViews
{
    public class AdministradorLogado
    {
        public string Email {get;set;} = default!;        
        public String Perfil {get;set;} = default!;
        public String Token {get;set;} = default!;
    }
}