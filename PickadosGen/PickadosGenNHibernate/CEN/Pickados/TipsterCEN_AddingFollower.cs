
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Tipster_addingFollower) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class TipsterCEN
{
public bool AddingFollower (int idTipster, int idNewFollower)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Tipster_addingFollower) ENABLED START*/

        // Write here your custom code...

        if (idTipster == idNewFollower) {
                return false;
        }

        TipsterCEN tipster = new TipsterCEN ();

        List<int> tipsters = new List<int>();
        IList<TipsterEN> followers = tipster.GetFollowers (idTipster);

        foreach (var p in followers) {
                if (idNewFollower == p.Id) {
                        return false;
                }
                //tipsters.Add (p.Id);
        }
        tipsters.Add (idNewFollower);
        tipster.AddFollower (idTipster, tipsters);
        return true;

        //throw new NotImplementedException ("Method AddingFollower() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
