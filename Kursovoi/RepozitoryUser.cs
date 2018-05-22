using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class RepozitoryUser:IRepository<Users>
    {
        private KursWorkEntities db;

        public RepozitoryUser(KursWorkEntities context)
        {
            this.db = context;
        }

        public IEnumerable<Users> GetAll()
        {
            return db.Users;
        }
        public void Add(Users users)
        {
            db.Users.Add(users);
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
