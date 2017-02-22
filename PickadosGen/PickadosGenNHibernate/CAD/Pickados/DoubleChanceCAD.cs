
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
 * Clase DoubleChance:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class DoubleChanceCAD : BasicCAD, IDoubleChanceCAD
    {
        public DoubleChanceCAD() : base()
        {
        }

        public DoubleChanceCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public DoubleChanceEN ReadOIDDefault(int id
                                              )
        {
            DoubleChanceEN doubleChanceEN = null;

            try
            {
                SessionInitializeTransaction();
                doubleChanceEN = (DoubleChanceEN)session.Get(typeof(DoubleChanceEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return doubleChanceEN;
        }

        public System.Collections.Generic.IList<DoubleChanceEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<DoubleChanceEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(DoubleChanceEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<DoubleChanceEN>();
                    else
                        result = session.CreateCriteria(typeof(DoubleChanceEN)).List<DoubleChanceEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(DoubleChanceEN doubleChance)
        {
            try
            {
                SessionInitializeTransaction();
                DoubleChanceEN doubleChanceEN = (DoubleChanceEN)session.Load(typeof(DoubleChanceEN), doubleChance.Id);

                doubleChanceEN.Result_b = doubleChance.Result_b;

                session.Update(doubleChanceEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewDobleChance(DoubleChanceEN doubleChance)
        {
            try
            {
                SessionInitializeTransaction();
                if (doubleChance.Event_rel != null)
                {
                    // Argumento OID y no colección.
                    doubleChance.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), doubleChance.Event_rel.Id);

                    doubleChance.Event_rel.Pick_rel
                    .Add(doubleChance);
                }

                session.Save(doubleChance);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return doubleChance.Id;
        }

        public void ModifyDobleChance(DoubleChanceEN doubleChance)
        {
            try
            {
                SessionInitializeTransaction();
                DoubleChanceEN doubleChanceEN = (DoubleChanceEN)session.Load(typeof(DoubleChanceEN), doubleChance.Id);

                doubleChanceEN.Odd = doubleChance.Odd;


                doubleChanceEN.Description = doubleChance.Description;


                doubleChanceEN.PickResult = doubleChance.PickResult;


                doubleChanceEN.Bookie = doubleChance.Bookie;


                doubleChanceEN.Result = doubleChance.Result;


                doubleChanceEN.Matchtime = doubleChance.Matchtime;


                doubleChanceEN.Result_b = doubleChance.Result_b;

                session.Update(doubleChanceEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeleteDobleChance(int id
                                       )
        {
            try
            {
                SessionInitializeTransaction();
                DoubleChanceEN doubleChanceEN = (DoubleChanceEN)session.Load(typeof(DoubleChanceEN), id);
                session.Delete(doubleChanceEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in DoubleChanceCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
    }
}
