
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPostCAD
{
PostEN ReadOIDDefault (int id
                       );

void ModifyDefault (PostEN post);

System.Collections.Generic.IList<PostEN> ReadAllDefault (int first, int size);




void ModifyPost (PostEN post);


void DeletePost (int id
                 );


PostEN GetPostById (int id
                    );


System.Collections.Generic.IList<PostEN> GetAllPosts (int first, int size);




int NewPost (PostEN post);

System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> FindPostsByTipster (int id, int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetByResult (PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum ? p_postResult);




System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPostsBetweenDate (Nullable<DateTime> initialDate, Nullable<DateTime> finalDate);
}
}
