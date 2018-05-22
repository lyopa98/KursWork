using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryMetro_Branch:IRepository<Metro_Branch>
    {
        private KursWorkEntities db;

        public RepozitoryMetro_Branch(KursWorkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Metro_Branch> GetAll()
        {
            return db.Metro_Branch;
        }
        public void Add(Metro_Branch metro)
        {
            db.Metro_Branch.Add(metro);
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
