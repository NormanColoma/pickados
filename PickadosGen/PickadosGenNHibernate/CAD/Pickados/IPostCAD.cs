
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
}
}
