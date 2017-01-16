

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
    /*
     *      Definition of the class SportCEN
     *
     */
    public partial class SportCEN
    {
        private ISportCAD _ISportCAD;

        public SportCEN()
        {
            this._ISportCAD = new SportCAD();
        }

        public SportCEN(ISportCAD _ISportCAD)
        {
            this._ISportCAD = _ISportCAD;
        }

        public ISportCAD get_ISportCAD()
        {
            return this._ISportCAD;
        }

        public int NewSport(string p_name)
        {
            SportEN sportEN = null;
            int oid;

            //Initialized SportEN
            sportEN = new SportEN();
            sportEN.Name = p_name;

            //Call to SportCAD

            oid = _ISportCAD.NewSport(sportEN);
            return oid;
        }

        public void ModifySport(int p_Sport_OID, string p_name)
        {
            SportEN sportEN = null;

            //Initialized SportEN
            sportEN = new SportEN();
            sportEN.Id = p_Sport_OID;
            sportEN.Name = p_name;
            //Call to SportCAD

            _ISportCAD.ModifySport(sportEN);
        }

        public void DeleteSport(int id
                                 )
        {
            _ISportCAD.DeleteSport(id);
        }

        public SportEN GetSportById(int id
                                     )
        {
            SportEN sportEN = null;

            sportEN = _ISportCAD.GetSportById(id);
            return sportEN;
        }

        public System.Collections.Generic.IList<SportEN> GetAllSports(int first, int size)
        {
            System.Collections.Generic.IList<SportEN> list = null;

            list = _ISportCAD.GetAllSports(first, size);
            return list;
        }
    }
}
