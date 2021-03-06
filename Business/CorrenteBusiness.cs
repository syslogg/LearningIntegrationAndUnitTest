﻿using System;
using System.Collections.Generic;
using Business.Interfaces;
using Domain.Entities;
using Repository;
using Exception;
using System.Linq;

namespace Business
{
    public class CorrenteBusiness : ICorrenteBusiness
    {

        private IUnitOfWork _uow = null;

        public CorrenteBusiness()
        {
            _uow = new UnitOfWork();
        }

        public CorrenteBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Corrente GetById(int id)
        {
            try
            {
                return _uow.CorrenteRepository.Get(id);
            }
            catch(System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public Corrente Insert(Corrente entity)
        {
            try
            {
                var entityReturn = _uow.CorrenteRepository.Add(entity);
                _uow.Commit();
                return entityReturn;
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Corrente> ListAll()
        {
            try
            {
                return _uow.CorrenteRepository.ListAll().ToList();
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Corrente> ListByPredicate(Func<Corrente, bool> predicate)
        {
            try
            {
                return _uow.CorrenteRepository.Find(predicate);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public bool Update(Corrente entity)
        {
            try
            {
                _uow.CorrenteRepository.Update(entity);
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
        // ~CorrenteBusiness() {
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
