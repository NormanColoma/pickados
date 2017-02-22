
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface IScorerCAD
    {
        ScorerEN ReadOIDDefault(int id
                                 );

        void ModifyDefault(ScorerEN scorer);



        int NewScorer(ScorerEN scorer);

        void ModifyScorer(ScorerEN scorer);


        void DeleteScorer(int id
                           );
    }
}
