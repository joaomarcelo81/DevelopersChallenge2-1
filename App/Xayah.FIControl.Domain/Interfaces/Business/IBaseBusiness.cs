using System;
using System.Collections.Generic;
using System.Text;


namespace Xayah.FIControl.Domain.Domain.Interfaces.Business
{
    public interface IBaseBusiness<TEntity> where TEntity : class
    {
        void Add(TEntity obj);
        void Update(Guid id, TEntity obj);
        void Remove(TEntity obj);
        TEntity Get(Guid id);
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> FinByParams(Func<TEntity, bool> lambda);
        
        void Save();
        void SaveAndUpdate(TEntity obj);
        void Dispose();
    }
}
