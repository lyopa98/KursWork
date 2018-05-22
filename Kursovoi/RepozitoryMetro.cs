using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryMetro : IRepository<Metro>
    {
        private KursWorkEntities db;

        public RepozitoryMetro(KursWorkEntities context)
        {
            this.db = context;
        }


        public IEnumerable<Metro> GetAll()
        {
            return db.Metro;
        }
        public void Add(Metro metro)
        {
            db.Metro.Add(metro);
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
