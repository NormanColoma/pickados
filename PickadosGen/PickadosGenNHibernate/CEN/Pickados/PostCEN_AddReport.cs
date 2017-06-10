
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Post_addReport) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PostCEN
{
public void AddReport (int p_oid)
{
            /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_addReport) ENABLED START*/

            PostCEN postCEN = new PostCEN();
            PostEN postEN = postCEN.GetPostById(p_oid);

            postEN.Report += 1;

            postCEN.ModifyPost(postEN.Id, postEN.Created_at, postEN.Modified_at, postEN.Stake, postEN.Description, postEN.Private_, postEN.TotalOdd, postEN.PostResult, postEN.Likeit, postEN.Report);

            /*PROTECTED REGION END*/
        }
}
}
