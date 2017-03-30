
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (int id
                          );

void ModifyDefault (UsuarioEN usuario);

System.Collections.Generic.IList<UsuarioEN> ReadAllDefault (int first, int size);



int NewUser (UsuarioEN usuario);

void ModifyUser (UsuarioEN usuario);


void DeleteUser (int id
                 );


UsuarioEN GetUserById (int id
                       );


System.Collections.Generic.IList<UsuarioEN> GetAllUsers (int first, int size);



PickadosGenNHibernate.EN.Pickados.UsuarioEN FindByUser (string name);
}
}
