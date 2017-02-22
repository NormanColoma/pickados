
using System;
using System.Text;
using PickadosGenNHibernate.CEN.Pickados;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.Exceptions;


/*
 * Clase Sport:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class SportCAD : BasicCAD, ISportCAD
    {
        public SportCAD() : base()
        {
        }

        public SportCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public SportEN ReadOIDDefault(int id
                                       )
        {
            SportEN sportEN = null;

            try
            {
                SessionInitializeTransaction();
                sportEN = (SportEN)session.Get(typeof(SportEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return sportEN;
        }

        public System.Collections.Generic.IList<SportEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<SportEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(SportEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<SportEN>();
                    else
                        result = session.CreateCriteria(typeof(SportEN)).List<SportEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(SportEN sport)
        {
            try
            {
                SessionInitializeTransaction();
                SportEN sportEN = (SportEN)session.Load(typeof(SportEN), sport.Id);


                sportEN.Name = sport.Name;

                session.Update(sportEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewSport(SportEN sport)
        {
            try
            {
                SessionInitializeTransaction();

                session.Save(sport);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return sport.Id;
        }

        public void ModifySport(SportEN sport)
        {
            try
            {
                SessionInitializeTransaction();
                SportEN sportEN = (SportEN)session.Load(typeof(SportEN), sport.Id);

                sportEN.Name = sport.Name;

                session.Update(sportEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeleteSport(int id
                                 )
        {
            try
            {
                SessionInitializeTransaction();
                SportEN sportEN = (SportEN)session.Load(typeof(SportEN), id);
                session.Delete(sportEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        //Sin e: GetSportById
        //Con e: SportEN
        public SportEN GetSportById(int id
                                     )
        {
            SportEN sportEN = null;

            try
            {
                SessionInitializeTransaction();
                sportEN = (SportEN)session.Get(typeof(SportEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return sportEN;
        }

        public System.Collections.Generic.IList<SportEN> GetAllSports(int first, int size)
        {
            System.Collections.Generic.IList<SportEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(SportEN)).
                             SetFirstResult(first).SetMaxResults(size).List<SportEN>();
                else
                    result = session.CreateCriteria(typeof(SportEN)).List<SportEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in SportCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
