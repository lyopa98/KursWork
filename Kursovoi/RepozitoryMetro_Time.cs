using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryMetro_Time:IRepository<Metro_Time>
    {
        private KursWorkEntities db;

        public RepozitoryMetro_Time(KursWorkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Metro_Time> GetAll()
        {
            return db.Metro_Time;
        }
        public void Add(Metro_Time metro)
        {
            db.Metro_Time.Add(metro);
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
