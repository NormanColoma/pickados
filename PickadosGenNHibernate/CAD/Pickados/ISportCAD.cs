
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface ISportCAD
    {
        SportEN ReadOIDDefault(int id
                                );

        void ModifyDefault(SportEN sport);



        int NewSport(SportEN sport);

        void ModifySport(SportEN sport);


        void DeleteSport(int id
                          );


        SportEN GetSportById(int id
                              );


        System.Collections.Generic.IList<SportEN> GetAllSports(int first, int size);
    }
}
