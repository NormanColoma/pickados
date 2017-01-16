
using System;
// Definición clase DoubleChanceEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class DoubleChanceEN : PickadosGenNHibernate.EN.Pickados.ResultEN


    {
        /**
         *	Atributo result_b
         */
        private PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result_b;






        public virtual PickadosGenNHibernate.Enumerated.Pickados.ResultEnum Result_b
        {
            get { return result_b; }
            set { result_b = value; }
        }





        public DoubleChanceEN() : base()
        {
        }



        public DoubleChanceEN(int id, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result_b
                              , PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime
                              , double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel
                              )
        {
            this.init(Id, result_b, result, matchtime, odd, description, pickResult, bookie, post, event_rel);
        }


        public DoubleChanceEN(DoubleChanceEN doubleChance)
        {
            this.init(Id, doubleChance.Result_b, doubleChance.Result, doubleChance.Matchtime, doubleChance.Odd, doubleChance.Description, doubleChance.PickResult, doubleChance.Bookie, doubleChance.Post, doubleChance.Event_rel);
        }

        private void init(int id
                           , PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result_b, PickadosGenNHibernate.Enumerated.Pickados.ResultEnum result, PickadosGenNHibernate.Enumerated.Pickados.TimeEnum matchtime, double odd, string description, PickadosGenNHibernate.Enumerated.Pickados.PickResultEnum pickResult, string bookie, System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.PostEN> post, PickadosGenNHibernate.EN.Pickados.Event_EN event_rel)
        {
            this.Id = id;


            this.Result_b = result_b;

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
            DoubleChanceEN t = obj as DoubleChanceEN;
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
