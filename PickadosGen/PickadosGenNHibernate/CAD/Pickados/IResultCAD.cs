
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface IResultCAD
    {
        ResultEN ReadOIDDefault(int id
                                 );

        void ModifyDefault(ResultEN result);



        int NewResult(ResultEN result);

        void ModifyResult(ResultEN result);


        void DeleteResult(int id
                           );
    }
}
