
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial interface ITipsterCAD
    {
        TipsterEN ReadOIDDefault(int id
                                  );

        void ModifyDefault(TipsterEN tipster);



        int NewTipster(TipsterEN tipster);

        void ModifyTipster(TipsterEN tipster);


        void DeleteTipster(int id
                            );


        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollowers(int oid);


        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPosts();


        void AddFollower(int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs);

        TipsterEN GetTipsterById(int id
                                  );


        System.Collections.Generic.IList<TipsterEN> GetAllTipsters(int first, int size);


        void AddFollow(int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs);

        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollows(int oid);


        void DeleteFollow(int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs);


        System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersWithBenefit();
    }
}
