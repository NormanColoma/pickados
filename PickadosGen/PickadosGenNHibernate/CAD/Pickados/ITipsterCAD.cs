
using System;
using PickadosGenNHibernate.EN.Pickados;

namespace PickadosGenNHibernate.CAD.Pickados
{
public partial interface ITipsterCAD
{
TipsterEN ReadOIDDefault (int id
                          );

void ModifyDefault (TipsterEN tipster);

System.Collections.Generic.IList<TipsterEN> ReadAllDefault (int first, int size);



int NewTipster (TipsterEN tipster);

void ModifyTipster (TipsterEN tipster);


void DeleteTipster (int id
                    );


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollowers (int id);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> GetPosts ();


void AddFollower (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs);

TipsterEN GetTipsterById (int id
                          );


System.Collections.Generic.IList<TipsterEN> GetAllTipsters (int first, int size);


void AddFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_follow_to_OIDs);

System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetFollows (int ? id);


void DeleteFollow (int p_Tipster_OID, System.Collections.Generic.IList<int> p_followed_by_OIDs);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersWithBenefit ();



System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetStatsByMonth (Nullable<DateTime> p_date, int ? p_oid);


System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.TipsterEN> GetTipstersPremium ();


PickadosGenNHibernate.EN.Pickados.TipsterEN FindByUser (string alias);




PickadosGenNHibernate.EN.Pickados.TipsterEN FindByMail (string email);


PickadosGenNHibernate.EN.Pickados.TipsterEN FindByNIF (string nif);
}
}
