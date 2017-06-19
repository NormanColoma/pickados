
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using System.Collections.Generic;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;



/*PROTECTED REGION ID(usingPickadosGenNHibernate.CP.Pickados_Post_addLike) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CP.Pickados
{
public partial class PostCP : BasicCP
{
public void AddLike (int p_oid)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CP.Pickados_Post_addLike) ENABLED START*/

        IPostCAD postCAD = null;
        PostCEN postCEN = null;



        try
        {
                SessionInitializeTransaction ();
                postCAD = new PostCAD (session);
                postCEN = new  PostCEN (postCAD);





                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
                throw ex;
        }
        finally
        {
                SessionClose ();
        }


        /*PROTECTED REGION END*/
}
}
}
