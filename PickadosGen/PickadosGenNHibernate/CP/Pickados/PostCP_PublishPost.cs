
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



/*PROTECTED REGION ID(usingPickadosGenNHibernate.CP.Pickados_Post_publishPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CP.Pickados
{
public partial class PostCP : BasicCP
{
public int PublishPost (Nullable<DateTime> p_created_at, Nullable<DateTime> p_modified_at, double p_stake, string p_description, bool p_private, System.Collections.Generic.IList<int> p_pick, int p_tipster, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult)
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CP.Pickados_Post_publishPost) ENABLED START*/

        IPostCAD postCAD = null;
        PostCEN postCEN = null;
        IPickCAD pickCAD = null;
        PickCEN pickCEN = null;

        int postId = 0;


        try
        {
                SessionInitializeTransaction ();
                postCAD = new PostCAD (session);
                postCEN = new  PostCEN (postCAD);
                pickCAD = new PickCAD(session);
                pickCEN = new PickCEN(pickCAD);

                List<int> picks_id = new List<int>();
                foreach (int id_pick in p_pick)
                {
                    PickEN pick = pickCEN.GetPickById(id_pick);
                    if (DateTime.Now <= pick.Event_rel.Date)
                    {
                        picks_id.Add(id_pick);
                    }
                }

                if (picks_id.Count > 0)
                {
                    postId = postCEN.NewPost(p_created_at, p_modified_at, p_stake, p_description, p_private, picks_id, p_tipster, 0, p_postResult);
                    double totalOdd = postCEN.GetTotalOdd(postId);
                    PostEN post = postCEN.GetPostById(postId);
                    postCAD.ModifyPost(post);
                    post.TotalOdd = totalOdd;
                }

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
        return postId;


        /*PROTECTED REGION END*/
}
}
}
