using System.Collections.Generic;
using ProjetoEplayers.Models;

namespace ProjetoEplayers.Interfaces
{
    public interface IJogador
    {
        void Criar(Jogador j);
        List<Jogador> LerTodos();
        void Alterar(Jogador j);
        void Deletar(int id);
    }
}