using System.Collections.Generic;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Interfaces
{
    public interface IEquipe
    {
          void Criar(Equipe e);
          List<Equipe> LerTodas();
          void Alterar(Equipe e);
          void Deletar(int id);
          
    }
}