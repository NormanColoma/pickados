
using System;
// Definición clase SportEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class SportEN
    {
        /**
         *	Atributo competition
         */
        private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition;



        /**
         *	Atributo id
         */
        private int id;



        /**
         *	Atributo name
         */
        private string name;






        public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> Competition
        {
            get { return competition; }
            set { competition = value; }
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





        public SportEN()
        {
            competition = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.CompetitionEN>();
        }



        public SportEN(int id, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition, string name
                       )
        {
            this.init(Id, competition, name);
        }


        public SportEN(SportEN sport)
        {
            this.init(Id, sport.Competition, sport.Name);
        }

        private void init(int id
                           , System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.CompetitionEN> competition, string name)
        {
            this.Id = id;


            this.Competition = competition;

            this.Name = name;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            SportEN t = obj as SportEN;
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
