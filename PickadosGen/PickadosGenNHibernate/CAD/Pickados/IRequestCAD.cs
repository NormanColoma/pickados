
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface IRequestCAD
{
RequestEN ReadOIDDefault (int id
                          );

void ModifyDefault (RequestEN request);

System.Collections.Generic.IList<RequestEN> ReadAllDefault (int first, int size);



int New_ (RequestEN request);

void Modify (RequestEN request);


void Delete (int id
             );


RequestEN GetById (int id
                   );


System.Collections.Generic.IList<RequestEN> GetAll (int first, int size);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RequestEN> GetByState (PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum ? p_state);
}
}
