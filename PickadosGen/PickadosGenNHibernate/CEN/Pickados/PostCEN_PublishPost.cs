
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


/*PROTECTED REGION ID(usingPickadosGenNHibernate.CEN.Pickados_Post_publishPost) ENABLED START*/
//  references to other libraries
/*PROTECTED REGION END*/

namespace PickadosGenNHibernate.CEN.Pickados
{
public partial class PostCEN
{
        /*PROTECTED REGION ID(PickadosGenNHibernate.CEN.Pickados_Post_publishPost) ENABLED START*/
        public PickadosGenNHibernate.EN.Pickados.PostEN PublishPost (DateTime p_created_at, DateTime p_modified_at, double p_stake, string p_description, bool p_private, System.Collections.Generic.IList<int> p_pick, int p_tipster, double p_totalOdd, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum p_postResult, PickCEN pickCEN)
        {
                // Write here your custom code...

                PostEN post = null;

                List<int> picks_id = new List<int>();
                foreach (int id_pick in p_pick) {
                        PickEN pick = pickCEN.GetPickById (id_pick);
                        if (DateTime.Now <= pick.Event_rel.Date) {
                                picks_id.Add (id_pick);
                        }
                }

                if (picks_id.Count > 0) {
                        int post_id = NewPost (p_created_at, p_modified_at, p_stake, p_description, p_private, picks_id, p_tipster, p_totalOdd, p_postResult);
                        post = GetPostById (post_id);
                }

                return post;
        }
        /*PROTECTED REGION END*/
}
}
