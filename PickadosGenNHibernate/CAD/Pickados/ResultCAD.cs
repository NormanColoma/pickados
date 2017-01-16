
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
 * Clase Result:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class ResultCAD : BasicCAD, IResultCAD
    {
        public ResultCAD() : base()
        {
        }

        public ResultCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public ResultEN ReadOIDDefault(int id
                                        )
        {
            ResultEN resultEN = null;

            try
            {
                SessionInitializeTransaction();
                resultEN = (ResultEN)session.Get(typeof(ResultEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return resultEN;
        }

        public System.Collections.Generic.IList<ResultEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<ResultEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(ResultEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<ResultEN>();
                    else
                        result = session.CreateCriteria(typeof(ResultEN)).List<ResultEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(ResultEN result)
        {
            try
            {
                SessionInitializeTransaction();
                ResultEN resultEN = (ResultEN)session.Load(typeof(ResultEN), result.Id);

                resultEN.Result = result.Result;


                resultEN.Matchtime = result.Matchtime;

                session.Update(resultEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewResult(ResultEN result)
        {
            try
            {
                SessionInitializeTransaction();
                if (result.Event_rel != null)
                {
                    // Argumento OID y no colección.
                    result.Event_rel = (PickadosGenNHibernate.EN.Pickados.Event_EN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.Event_EN), result.Event_rel.Id);

                    result.Event_rel.Pick_rel
                    .Add(result);
                }

                session.Save(result);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result.Id;
        }

        public void ModifyResult(ResultEN result)
        {
            try
            {
                SessionInitializeTransaction();
                ResultEN resultEN = (ResultEN)session.Load(typeof(ResultEN), result.Id);

                resultEN.Odd = result.Odd;


                resultEN.Description = result.Description;


                resultEN.PickResult = result.PickResult;


                resultEN.Bookie = result.Bookie;


                resultEN.Result = result.Result;


                resultEN.Matchtime = result.Matchtime;

                session.Update(resultEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeleteResult(int id
                                  )
        {
            try
            {
                SessionInitializeTransaction();
                ResultEN resultEN = (ResultEN)session.Load(typeof(ResultEN), id);
                session.Delete(resultEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in ResultCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
    }
}
