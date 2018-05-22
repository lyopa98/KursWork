using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class Repozitory_Time:IRepository<Time>
    {
        private KursWorkEntities db;

        public Repozitory_Time(KursWorkEntities context)
        { this.db = context; }

        public IEnumerable<Time> GetAll()
        {
            return db.Time;
        }
        public void Add(Time time)
        {
            db.Time.Add(time);
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
