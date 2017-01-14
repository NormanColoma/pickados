
using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;
using PickadosGenNHibernate.CEN.Pickados;



/*PROTECTED REGION ID(usingPickadosGenNHibernate.CP.Pickados_Post_publishPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CP.Pickados
{
public partial class PostCP : BasicCP
{
public PickadosGenNHibernate.EN.Pickados.PostEN PublishPost (TimeSpan p_created_at, TimeSpan p_modified_at, double p_stake, string p_description, bool p_private, System.Collections.Generic.IList<int> p_pick, int p_tipster, double p_totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CP.Pickados_Post_publishPost) ENABLED START*/

        IPostCAD postCAD = null;
        PostCEN postCEN = null;

        PickadosGenNHibernate.EN.Pickados.PostEN result = null;


        try
        {
                SessionInitializeTransaction ();
                postCAD = new PostCAD (session);
                postCEN = new  PostCEN (postCAD);




                int oid;
                //Initialized PostEN
                PostEN postEN;
                postEN = new PostEN ();
                postEN.Created_at = p_created_at;

                postEN.Modified_at = p_modified_at;

                postEN.Stake = p_stake;

                postEN.Description = p_description;

                postEN.Private_ = p_private;


                postEN.Pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                if (p_pick != null) {
                        for (int item : p_pick) {
                                PickadosGenNHibernate.EN.Pickados.PickEN en = new PickadosGenNHibernate.EN.Pickados.PickEN ();
                                en.Id = item;
                                postEN.Pick ().Add (en);
                        }
                }

                else{
                        postEN.Pick = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
                }


                if (p_tipster != -1) {
                        postEN.Tipster = new PickadosGenNHibernate.EN.Pickados.TipsterEN ();
                        postEN.Tipster.Id = p_tipster;
                }

                postEN.TotalOdd = p_totalOdd;

                postEN.PostResult = p_postResult;

                //Call to PostCAD

                oid = postCAD.PublishPost (postEN);
                result = postCAD.ReadOIDDefault (oid);



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
        return result;


        /*PROTECTED REGION END*/
}
}
}
