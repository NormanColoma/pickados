
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface IHandicapCAD
    {
        HandicapEN ReadOIDDefault(int id
                                   );

        void ModifyDefault(HandicapEN handicap);



        int NewHandicap(HandicapEN handicap);

        void ModifyHandicap(HandicapEN handicap);


        void DeleteHandicap(int id
                             );
    }
}
