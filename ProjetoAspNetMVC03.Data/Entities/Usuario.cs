using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAspNetMVC03.Data.Entities
{
    public class Usuario
    {
        //prop + 2x TAB
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataCadastro { get; set; }

        //Relacionamento de Associação (TER - MUITOS)
        public List<Tarefa> Tarefas { get; set; }
        
    }
}
