
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ILoginCAD
{
LoginEN ReadOIDDefault (int id
                        );

void ModifyDefault (LoginEN login);

System.Collections.Generic.IList<LoginEN> ReadAllDefault (int first, int size);



int NewLogin (LoginEN login);

System.Collections.Generic.IList<LoginEN> GetAllLogins (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.LoginEN> GetLoginBetweenDate (Nullable<DateTime> initialDate, Nullable<DateTime> finalDate);
}
}
