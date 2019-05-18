using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TutorPrototype.EF;

namespace TutorPrototype.Repos
{
    public class BaseRepo : IDisposable
    {
        protected readonly TPContext _db;
        private bool _disposed = false;

        readonly log4net.ILog logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseRepo()
        {
            _db = new TPContext();
        }

        public BaseRepo(DbContextOptions options)
        {
            _db = new TPContext(options);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (_disposed) return;
            if (disposing)
            {
                //Free any other managed objects here
            }
            _db.Dispose();
            _disposed = true;
        }

        public int SaveChanges()
        {
            try
            {
                return _db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                //A concurrency error occurred
                logger.Error("Database cannot be updated.", ex);
                throw;
            }
            catch (RetryLimitExceededException ex)
            {
                //_dbResiliency retry limit exceeded
                logger.Error("Maximum retry limit reached.", ex);
                throw;
            }
            catch (Exception ex)
            {
                logger.Error("Error occurred.", ex);
                throw;
            }
        }
    }
}
