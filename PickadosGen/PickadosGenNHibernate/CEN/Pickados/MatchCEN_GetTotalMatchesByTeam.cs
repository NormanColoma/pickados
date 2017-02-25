
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Match_getTotalMatchesByTeam) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class MatchCEN
{
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.MatchEN> GetTotalMatchesByTeam (int id)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Match_getTotalMatchesByTeam) ENABLED START*/

        // Write here your custom code...

        MatchCEN matches = new MatchCEN ();

        IList<MatchEN> total = matches.GetMatchByLocalTeam (id);
        IList<MatchEN> visitants = matches.GetMatchByVisistantTeam (id);

        ((List<MatchEN>)total).AddRange (visitants);

        return total;
        //throw new NotImplementedException ("Method GetTotalMatchesByTeam() not yet implemented.");

        /*PROTECTED REGION END*/
}
}
}
