using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryStop : IRepository<Stop>
    {
        private KursWorkEntities db;

        public RepozitoryStop(KursWorkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Stop> GetAll()
        {
            return db.Stop;
        }
        public void Add(Stop stop)
        {
            db.Stop.Add(stop);
        }

        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
