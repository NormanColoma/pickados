
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IPostCAD
{
PostEN ReadOIDDefault (int id
                       );

void ModifyDefault (PostEN post);



int PublishPost (PostEN post);

void ModifyPost (PostEN post);


void DeletePost (int id
                 );


PostEN GetByID (int id
                );


System.Collections.Generic.IList<PostEN> GetAll (int first, int size);
}
}
