using Business.Interfaces;
using System;
using System.Collections.Generic;
using Domain.Entities;
using Repository;
using Exception;
using System.Linq;

namespace Business
{
    public class PoupancaBusiness : IPoupancaBusiness
    {

        private IUnitOfWork _uow = null;
        
        public PoupancaBusiness()
        {
            _uow = new UnitOfWork();
        }

        public PoupancaBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Poupanca GetById(int id)
        {
            try
            {
                return _uow.PoupancaRepository.Get(id);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public Poupanca Insert(Poupanca entity)
        {
            try
            {
                var entityReturn = _uow.PoupancaRepository.Add(entity);
                _uow.Commit();
                return entityReturn;
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }

        }

        public IList<Poupanca> ListAll()
        {
            try
            {
                return _uow.PoupancaRepository.ListAll().ToList();
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Poupanca> ListByPredicate(Func<Poupanca, bool> predicate)
        {
            try
            {
                return _uow.PoupancaRepository.Find(predicate);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public bool Update(Poupanca entity)
        {
            try
            {
                _uow.PoupancaRepository.Update(entity);
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
        // ~PoupancaBusiness() {
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
