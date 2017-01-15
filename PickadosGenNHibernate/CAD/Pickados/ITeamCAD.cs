
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface ITeamCAD
    {
        TeamEN ReadOIDDefault(int id
                               );

        void ModifyDefault(TeamEN team);



        int NewTeam(TeamEN team);

        void ModifyTeam(TeamEN team);


        void DeleteTeam(int id
                         );


        TeamEN GetByID(int id
                        );


        System.Collections.Generic.IList<TeamEN> GetAll(int first, int size);
    }
}
