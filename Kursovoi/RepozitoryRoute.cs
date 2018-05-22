using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryRoute:IRepository<Route> 
    {
        private KursWorkEntities db;

        public RepozitoryRoute(KursWorkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Route> GetAll()
        {
            return db.Route;
        }
        public void Add(Route route)
        {
            db.Route.Add(route);
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
