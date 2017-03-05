
using System;
using System.Text;
using System.Collections.Generic;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_deletingFollower) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public bool DeletingFollower (int idTipster, int idUnfollower)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_deletingFollower) ENABLED START*/

        // Write here your custom code...

        if (idTipster == idUnfollower) {
                return false;
        }

        TipsterCEN tipster = new TipsterCEN ();
        List<int> tipsters = new List<int>();
        Boolean exists = false;
        IList<TipsterEN> followers = tipster.GetFollowers (idTipster);

        foreach (var p in followers) {
                if (idUnfollower == p.Id) {
                        exists = true;
                    tipsters.Add(idUnfollower);
                }
                //tipsters.Add (p.Id);
        }

        if (exists) {
                //tipsters.Remove(idUnfollower);
                tipster.DeleteFollow (idTipster, tipsters);
        }

        return exists;

        //throw new NotImplementedException ("Method DeletingFollower() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
