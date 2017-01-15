
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Post_getTotalOdd) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PostCEN
{
public double GetTotalOdd (int p_oid)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_getTotalOdd) ENABLED START*/

        // Write here your custom code...

        PostEN post = GetByID(p_oid);
        double total_odd= 0;
        if (!post.Equals(null)) {
                IList<PickEN> picks = post.Pick;
                foreach(PickEN pick in picks)
                {
                    total_odd += pick.Odd;
                }
        }
       
        return total_odd;

        /*PROTECTED REGION END*/
}
}
}
