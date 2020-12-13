using System;
using System.Collections.Generic;
using System.Text;
using Xayah.FIControl.Domain.Domain.Interfaces.Business;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;

namespace Xayah.FIControl.Business
{
    public class BaseBusiness<TEntity> : IDisposable, IBaseBusiness<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _serviceBase;

        public BaseBusiness(IBaseRepository<TEntity> serviceBase)
        {
            _serviceBase = serviceBase;
        }

        public void Add(TEntity obj)
        {
            _serviceBase.Add(obj);
        }

        public void Update(Guid id, TEntity obj)
        {
            _serviceBase.Update(id, obj);
        }

        public void Remove(TEntity obj)
        {
            _serviceBase.Remove(obj);
        }

        public TEntity Get(Guid id)
        {
            return _serviceBase.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _serviceBase.GetAll();
        }

        public IEnumerable<TEntity> FinByParams(Func<TEntity, bool> lambda)
        {
            return _serviceBase.FinByParams(lambda);
        }

        public virtual void SaveAndUpdate(TEntity obj)
        {
            _serviceBase.SaveAndUpdate(obj);
        }
        public virtual void Save()
        {
            _serviceBase.Save();
        }

        public void Dispose()
        {
            _serviceBase.Dispose();
        }
    }
}

