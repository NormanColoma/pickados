
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IAdminCAD
{
AdminEN ReadOIDDefault (int id
                        );

void ModifyDefault (AdminEN admin);



int NewAdmin (AdminEN admin);

void ModifyAdmin (AdminEN admin);


void DeleteAdmin (int id
                  );
}
}
