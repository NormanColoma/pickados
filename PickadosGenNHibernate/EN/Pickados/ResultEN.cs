
using System;
// Definición clase ResultEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class ResultEN : PickadosGenNHibernate.EN.Pickados.PickEN


    {
        /**
         *	Atributo result
         */
        private PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result;



        /**
         *	Atributo matchtime
         */
        private PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime;






        public virtual PickadosGenNHibernate.Enumerated.Pickados.ResultEnum Result
        {
            get { return result; }
            set { result = value; }
        }



        public virtual PickadosGenNHibernate.Enumerated.Pickados.TimeEnum Matchtime
        {
            get { return matchtime; }
            set { matchtime = value; }
        }





        public ResultEN() : base()
        {
        }



        public ResultEN(int id, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime
                        , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                        )
        {
            this.init(Id, result, matchtime, odd, description, pickResult, bookie, post, event_rel);
        }


        public ResultEN(ResultEN result)
        {
            this.init(Id, result.Result, result.Matchtime, result.Odd, result.Description, result.PickResult, result.Bookie, result.Post, result.Event_rel);
        }

        private void init(int id
                           , PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
        {
            this.Id = id;


            this.Result = result;

            this.Matchtime = matchtime;

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
            ResultEN t = obj as ResultEN;
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
