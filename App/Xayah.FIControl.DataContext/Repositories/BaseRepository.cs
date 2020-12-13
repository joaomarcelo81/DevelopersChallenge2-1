using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xayah.FIControl.Domain.Domain.Interfaces.Repositories;

namespace Xayah.FIControl.DataContext.Repositories
{
    public class BaseRepository<TEntity> : IDisposable, IBaseRepository<TEntity> where TEntity : class
    {

        protected XayahFIControlDataContext Db;
        public XayahFIControlDataContext Context;

        //   private System.Data.Entity.DbContextTransaction dbTran;
        //http://www.entityframeworktutorial.net/entityframework6/transaction-in-entity-framework.aspx


        public BaseRepository(XayahFIControlDataContext _context)
        {
            Context = _context;
            this.Db = _context;
        }

        public virtual void Add(TEntity obj)
        {
            Db.Set<TEntity>().Add(obj);
        }

        public virtual void Update(Guid id, TEntity obj)
        {
            if (Db.Set<TEntity>().Find(id) != null)
            {
                Db.Entry(obj).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }
            else
            {
                Add(obj);
            }
        }

        public virtual void Remove(TEntity obj)
        {
            Db.Set<TEntity>().Remove(obj);
        }

        public virtual TEntity Get(Guid id)
        {
            return Db.Set<TEntity>().Find(id);
        }

        public virtual IEnumerable<TEntity> GetAll()
        {
            return Db.Set<TEntity>().ToList();
        }
        public virtual TEntity GetByParams(Func<TEntity, bool> lambda)
        {
            return Db.Set<TEntity>().Where<TEntity>(lambda).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FinByParams(Func<TEntity, bool> lambda)
        {
            return Db.Set<TEntity>().Where<TEntity>(lambda);
        }


        public virtual void SaveAndUpdate(TEntity obj)
        {

            //    bool saveFailed;
            //    do
            //    {
            //        saveFailed = false;

            //        try
            //        {
            //            Db.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            saveFailed = true;

            //            // Update the values of the entity that failed to save from the store 
            //            ex.Entries.Single().Reload();
            //        } 

            //    } while (saveFailed); 



            Db.Set<TEntity>().Update(obj);
        }


        public virtual void Save()
        {

            //    bool saveFailed;
            //    do
            //    {
            //        saveFailed = false;

            //        try
            //        {
            //            Db.SaveChanges();
            //        }
            //        catch (DbUpdateConcurrencyException ex)
            //        {
            //            saveFailed = true;

            //            // Update the values of the entity that failed to save from the store 
            //            ex.Entries.Single().Reload();
            //        } 

            //    } while (saveFailed); 


            var saida = Db.SaveChanges();
        }

        public void BeginTransaction()
        {
            // dbTran = Context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            //  dbTran.Commit();
        }

        public void RollbackTransaction()
        {
            //  dbTran.Rollback();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    Db.Dispose();
                }
            }
            this.disposed = true;
        }

        public virtual void Dispose()
        {

            //if (dbTran != null)
            //    dbTran.Dispose();

            Dispose(true);
            GC.SuppressFinalize(this);

        }

        /*

                #region Dispose
        private IntPtr nativeResource = Marshal.AllocHGlobal(100);
        public void Dispose()
        {
            if (nativeResource != IntPtr.Zero)
            {
                Marshal.FreeHGlobal(nativeResource);
                nativeResource = IntPtr.Zero;
            }
            GC.SuppressFinalize(this);
        }
        #endregion

          */
    }
}
