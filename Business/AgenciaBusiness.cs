using System;
using System.Collections.Generic;
using Business.Interfaces;
using Domain.Entities;
using Exception;
using Repository;
using System.Linq;

namespace Business
{
    public class AgenciaBusiness : IAgenciaBusiness
    {

        private IUnitOfWork _uow = null;

        public AgenciaBusiness()
        {
            _uow = new UnitOfWork();
        }

        public AgenciaBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Agencia GetById(int id)
        {
            try
            {
                return _uow.AgenciaRepository.Get(id);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public Agencia Insert(Agencia entity)
        {
            try
            {
                var entityReturn = _uow.AgenciaRepository.Add(entity);
                _uow.Commit();
                return entityReturn;
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Agencia> ListAll()
        {
            try
            {
                return _uow.AgenciaRepository.ListAll().ToList();
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Agencia> ListByPredicate(Func<Agencia, bool> predicate)
        {
            try
            {
                return _uow.AgenciaRepository.Find(predicate);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public bool Update(Agencia entity)
        {
            try
            {
                _uow.AgenciaRepository.Update(entity);
                _uow.Commit();
                return true;
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        #region IDisposable Support
        private bool disposedValue = false; // Para detectar chamadas redundantes

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _uow.Dispose();
                    _uow = null;
                }

                // TODO: liberar recursos não gerenciados (objetos não gerenciados) e substituir um finalizador abaixo.
                // TODO: definir campos grandes como nulos.

                disposedValue = true;
            }
        }

        // TODO: substituir um finalizador somente se Dispose(bool disposing) acima tiver o código para liberar recursos não gerenciados.
        // ~AgenciaBusiness() {
        //   // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
        //   Dispose(false);
        // }

        // Código adicionado para implementar corretamente o padrão descartável.
        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
