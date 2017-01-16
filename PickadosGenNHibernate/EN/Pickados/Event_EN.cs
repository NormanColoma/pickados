
using System;
// Definición clase Event_EN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class Event_EN
    {
        /**
         *	Atributo id
         */
        private int id;



        /**
         *	Atributo competition
         */
        private PickadosGenNHibernate.EN.Pickados.CompetitionEN competition;



        /**
         *	Atributo pick_rel
         */
        private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel;



        /**
         *	Atributo date
         */
        private Nullable<DateTime> date;






        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }



        public virtual PickadosGenNHibernate.EN.Pickados.CompetitionEN Competition
        {
            get { return competition; }
            set { competition = value; }
        }



        public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> Pick_rel
        {
            get { return pick_rel; }
            set { pick_rel = value; }
        }



        public virtual Nullable<DateTime> Date
        {
            get { return date; }
            set { date = value; }
        }





        public Event_EN()
        {
            pick_rel = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PickEN>();
        }



        public Event_EN(int id, PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, Nullable<DateTime> date
                        )
        {
            this.init(Id, competition, pick_rel, date);
        }


        public Event_EN(Event_EN event_)
        {
            this.init(Id, event_.Competition, event_.Pick_rel, event_.Date);
        }

        private void init(int id
                           , PickadosGenNHibernate.EN.Pickados.CompetitionEN competition, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PickEN> pick_rel, Nullable<DateTime> date)
        {
            this.Id = id;


            this.Competition = competition;

            this.Pick_rel = pick_rel;

            this.Date = date;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            Event_EN t = obj as Event_EN;
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
