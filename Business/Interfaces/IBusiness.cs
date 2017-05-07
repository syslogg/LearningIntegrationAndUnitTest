using System;
using System.Collections.Generic;

namespace Business.Interfaces
{
    public interface IBusiness<T> : IDisposable
    {
        
        /// <summary>
        /// Inserir no banco
        /// </summary>
        /// <param name="entity"></param>
        T Insert(T entity);

        /// <summary>
        /// Pegar dado pelo Id
        /// </summary>
        /// <returns></returns>
        T GetById(int id);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity"></param>
        bool Update(T entity);

        /// <summary>
        /// Listar todos
        /// </summary>
        IList<T> ListAll();

        /// <summary>
        /// Listar por predicado, Evitar utilizar essa função.
        /// </summary>
        [Obsolete]
        IList<T> ListByPredicate(Func<T,bool> predicate);

    }
}
