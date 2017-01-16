
using System;
// Definición clase PickEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class PickEN
    {
        /**
         *	Atributo id
         */
        private int id;



        /**
         *	Atributo odd
         */
        private double odd;



        /**
         *	Atributo description
         */
        private string description;



        /**
         *	Atributo pickResult
         */
        private PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult;



        /**
         *	Atributo bookie
         */
        private string bookie;



        /**
         *	Atributo post
         */
        private System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post;



        /**
         *	Atributo event_rel
         */
        private PickadosGenNHibernate.EN.Pickados.Event_EN event_rel;






        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }



        public virtual double Odd
        {
            get { return odd; }
            set { odd = value; }
        }



        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }



        public virtual PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum PickResult
        {
            get { return pickResult; }
            set { pickResult = value; }
        }



        public virtual string Bookie
        {
            get { return bookie; }
            set { bookie = value; }
        }



        public virtual System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> Post
        {
            get { return post; }
            set { post = value; }
        }



        public virtual PickadosGenNHibernate.EN.Pickados.Event_EN Event_rel
        {
            get { return event_rel; }
            set { event_rel = value; }
        }





        public PickEN()
        {
            post = new System.Collections.Generic.List<PickadosGenNHibernate.EN.Pickados.PostEN>();
        }



        public PickEN(int id, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                      )
        {
            this.init(Id, odd, description, pickResult, bookie, post, event_rel);
        }


        public PickEN(PickEN pick)
        {
            this.init(Id, pick.Odd, pick.Description, pick.PickResult, pick.Bookie, pick.Post, pick.Event_rel);
        }

        private void init(int id
                           , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
        {
            this.Id = id;


            this.Odd = odd;

            this.Description = description;

            this.PickResult = pickResult;

            this.Bookie = bookie;

            this.Post = post;

            this.Event_rel = event_rel;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            PickEN t = obj as PickEN;
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
