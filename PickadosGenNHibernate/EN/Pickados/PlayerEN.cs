
using System;
// Definición clase PlayerEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class PlayerEN
    {
        /**
         *	Atributo club_team
         */
        private PickadosGenNHibernate.EN.Pickados.TeamEN club_team;



        /**
         *	Atributo national_team
         */
        private PickadosGenNHibernate.EN.Pickados.TeamEN national_team;



        /**
         *	Atributo id
         */
        private int id;



        /**
         *	Atributo name
         */
        private string name;



        /**
         *	Atributo scorer
         */
        private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.ScorerEN> scorer;






        public virtual PickadosGenNHibernate.EN.Pickados.TeamEN Club_team
        {
            get { return club_team; }
            set { club_team = value; }
        }



        public virtual PickadosGenNHibernate.EN.Pickados.TeamEN National_team
        {
            get { return national_team; }
            set { national_team = value; }
        }



        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }



        public virtual string Name
        {
            get { return name; }
            set { name = value; }
        }



        public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.ScorerEN> Scorer
        {
            get { return scorer; }
            set { scorer = value; }
        }





        public PlayerEN()
        {
            scorer = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.ScorerEN>();
        }



        public PlayerEN(int id, PickadosGenNHibernate.EN.Pickados.TeamEN club_team, PickadosGenNHibernate.EN.Pickados.TeamEN national_team, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.ScorerEN> scorer
                        )
        {
            this.init(Id, club_team, national_team, name, scorer);
        }


        public PlayerEN(PlayerEN player)
        {
            this.init(Id, player.Club_team, player.National_team, player.Name, player.Scorer);
        }

        private void init(int id
                           , PickadosGenNHibernate.EN.Pickados.TeamEN club_team, PickadosGenNHibernate.EN.Pickados.TeamEN national_team, string name, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.ScorerEN> scorer)
        {
            this.Id = id;


            this.Club_team = club_team;

            this.National_team = national_team;

            this.Name = name;

            this.Scorer = scorer;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            PlayerEN t = obj as PlayerEN;
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
