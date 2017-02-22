
using System;
// Definición clase MatchEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class MatchEN : PickadosGenNHibernate.EN.Pickados.Event_EN


    {
        /**
         *	Atributo away
         */
        private PickadosGenNHibernate.EN.Pickados.TeamEN away;



        /**
         *	Atributo home
         */
        private PickadosGenNHibernate.EN.Pickados.TeamEN home;



        /**
         *	Atributo stadium
         */
        private string stadium;






        public virtual PickadosGenNHibernate.EN.Pickados.TeamEN Away
        {
            get { return away; }
            set { away = value; }
        }



        public virtual PickadosGenNHibernate.EN.Pickados.TeamEN Home
        {
            get { return home; }
            set { home = value; }
        }



        public virtual string Stadium
        {
            get { return stadium; }
            set { stadium = value; }
        }





        public MatchEN() : base()
        {
        }



        public MatchEN(int id, PickadosGenNHibernate.EN.Pickados.TeamEN away, PickadosGenNHibernate.EN.Pickados.TeamEN home, string stadium
                       , PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, Nullable<DateTime> date
                       )
        {
            this.init(Id, away, home, stadium, competition, pick_rel, date);
        }


        public MatchEN(MatchEN match)
        {
            this.init(Id, match.Away, match.Home, match.Stadium, match.Competition, match.Pick_rel, match.Date);
        }

        private void init(int id
                           , PickadosGenNHibernate.EN.Pickados.TeamEN away, PickadosGenNHibernate.EN.Pickados.TeamEN home, string stadium, PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, Nullable<DateTime> date)
        {
            this.Id = id;


            this.Away = away;

            this.Home = home;

            this.Stadium = stadium;

            this.Competition = competition;

            this.Pick_rel = pick_rel;

            this.Date = date;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            MatchEN t = obj as MatchEN;
            if (t == null)
                return false;
            if (Id.Equals(t.Id))
                return true;
            else
                return false;
        }

        public override int GetHashCode()
        {
            int hash = 13;

            hash += this.Id.GetHashCode();
            return hash;
        }
    }
}
