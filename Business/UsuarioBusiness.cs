using System;
using System.Collections.Generic;
using Business.Interfaces;
using Domain.Entities;
using Repository;
using Exception;
using System.Linq;

namespace Business
{
    public class UsuarioBusiness : IUsuarioBusiness, IDisposable
    {

        private IUnitOfWork _uow = null;

        public UsuarioBusiness()
        {
            _uow = new UnitOfWork();
        }

        public UsuarioBusiness(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public Usuario GetById(int id)
        {
            try
            {
                return _uow.UsuarioRepository.Get(id);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public Usuario Insert(Usuario entity)
        {
            try
            {
                Usuario objectReturn = _uow.UsuarioRepository.Add(entity);
                _uow.Commit();
                return objectReturn;
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public IList<Usuario> ListAll()
        {
            try
            {
                return _uow.UsuarioRepository.ListAll().ToList();
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        [Obsolete]
        public IList<Usuario> ListByPredicate(Func<Usuario, bool> predicate)
        {
            try
            {
                return _uow.UsuarioRepository.Find(predicate);
            }
            catch (System.Exception ex)
            {
                throw new BusinessException(ex);
            }
        }

        public bool Update(Usuario entity)
        {
            try
            {
                _uow.UsuarioRepository.Update(entity);
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
                    if(_uow != null)
                    {
                        this._uow.Dispose();
                        this._uow = null;
                    }
                }
                
                disposedValue = true;
            }
        }

        // TODO: substituir um finalizador somente se Dispose(bool disposing) acima tiver o código para liberar recursos não gerenciados.
        // ~UsuarioBusiness() {
        //   // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
        //   Dispose(false);
        // }

        // Código adicionado para implementar corretamente o padrão descartável.
        public void Dispose()
        {
            // Não altere este código. Coloque o código de limpeza em Dispose(bool disposing) acima.
            Dispose(true);
            GC.SuppressFinalize(this);
            // TODO: remover marca de comentário da linha a seguir se o finalizador for substituído acima.
            // GC.SuppressFinalize(this);
        }
        #endregion

    }
}
