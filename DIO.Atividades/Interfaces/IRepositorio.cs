using System.Collections.Generic;

namespace DIO.Atividades.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> Lista();
        T RetornaPorId(int id);        
        void Insere(T entidade);        
        void Conclui(int id);        
        void Atualiza(int id, T entidade);
        int ProximoId();
    }
}