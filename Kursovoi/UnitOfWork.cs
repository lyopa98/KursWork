using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursovoi
{
    public class UnitOfWork:IDisposable
    {
        private KursWorkEntities db = new KursWorkEntities();
        private Repozitory_Time Repozitory_Time;
        private RepozitoryMetro RepozitoryMetro;
        private RepozitoryMetro_Branch RepozitoryMetro_Branch;
        private RepozitoryMetro_Time RepozitoryMetro_Time;
        private RepozitoryRoute RepozitoryRoute;
        private RepozitoryStop RepozitoryStop;
        private RepozitoryUser RepozitoryUser;

        public Repozitory_Time times
        {
            get
                {
                if (Repozitory_Time == null)
                    Repozitory_Time = new Repozitory_Time(db);
                return Repozitory_Time;
            }
        }
        public RepozitoryMetro metro
        {
            get
            {
                if (RepozitoryMetro == null)
                    RepozitoryMetro = new RepozitoryMetro(db);
                return RepozitoryMetro;
            }
        }
        public RepozitoryMetro_Branch metroBranch
        {
            get
            {
                if (RepozitoryMetro_Branch == null)
                    RepozitoryMetro_Branch = new RepozitoryMetro_Branch(db);
                return RepozitoryMetro_Branch;
            }
        }
        public RepozitoryMetro_Time metroTime
        {
            get
            {
                if (RepozitoryMetro_Time == null)
                    RepozitoryMetro_Time = new RepozitoryMetro_Time(db);
                return RepozitoryMetro_Time;
            }
        }
        public RepozitoryRoute route
        {
            get
            {
                if (RepozitoryRoute == null)
                    RepozitoryRoute = new RepozitoryRoute(db);
                return RepozitoryRoute;
            }
        }
        public RepozitoryStop stop
        {
            get
            {
                if (RepozitoryStop == null)
                    RepozitoryStop = new RepozitoryStop(db);
                return RepozitoryStop;
            }
        }
        public RepozitoryUser user
        {
            get
            {
                if (RepozitoryUser == null)
                    RepozitoryUser = new RepozitoryUser(db);
                return RepozitoryUser;
            }
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
