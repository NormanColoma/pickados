
using System;
// Definición clase UsuarioEN
namespace PickadosGenNHibernate.EN.Pickados
{
    public partial class UsuarioEN
    {
        /**
         *	Atributo id
         */
        private int id;



        /**
         *	Atributo createdAt
         */
        private TimeSpan createdAt;



        /**
         *	Atributo modifiedAt
         */
        private TimeSpan modifiedAt;



        /**
         *	Atributo alias
         */
        private string alias;



        /**
         *	Atributo email
         */
        private string email;



        /**
         *	Atributo password
         */
        private String password;






        public virtual int Id
        {
            get { return id; }
            set { id = value; }
        }



        public virtual TimeSpan CreatedAt
        {
            get { return createdAt; }
            set { createdAt = value; }
        }



        public virtual TimeSpan ModifiedAt
        {
            get { return modifiedAt; }
            set { modifiedAt = value; }
        }



        public virtual string Alias
        {
            get { return alias; }
            set { alias = value; }
        }



        public virtual string Email
        {
            get { return email; }
            set { email = value; }
        }



        public virtual String Password
        {
            get { return password; }
            set { password = value; }
        }





        public UsuarioEN()
        {
        }



        public UsuarioEN(int id, TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password
                         )
        {
            this.init(Id, createdAt, modifiedAt, alias, email, password);
        }


        public UsuarioEN(UsuarioEN usuario)
        {
            this.init(Id, usuario.CreatedAt, usuario.ModifiedAt, usuario.Alias, usuario.Email, usuario.Password);
        }

        private void init(int id
                           , TimeSpan createdAt, TimeSpan modifiedAt, string alias, string email, String password)
        {
            this.Id = id;


            this.CreatedAt = createdAt;

            this.ModifiedAt = modifiedAt;

            this.Alias = alias;

            this.Email = email;

            this.Password = password;
        }

        public override bool Equals(object obj)
        {
            if (obj == null)
                return false;
            UsuarioEN t = obj as UsuarioEN;
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
