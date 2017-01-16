
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
 * Clase Player:
 *
 */

namespace PickadosGenNHibernate.CAD.Pickados
{
    public partial class PlayerCAD : BasicCAD, IPlayerCAD
    {
        public PlayerCAD() : base()
        {
        }

        public PlayerCAD(ISession sessionAux) : base(sessionAux)
        {
        }



        public PlayerEN ReadOIDDefault(int id
                                        )
        {
            PlayerEN playerEN = null;

            try
            {
                SessionInitializeTransaction();
                playerEN = (PlayerEN)session.Get(typeof(PlayerEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return playerEN;
        }

        public System.Collections.Generic.IList<PlayerEN> ReadAllDefault(int first, int size)
        {
            System.Collections.Generic.IList<PlayerEN> result = null;
            try
            {
                using (ITransaction tx = session.BeginTransaction())
                {
                    if (size > 0)
                        result = session.CreateCriteria(typeof(PlayerEN)).
                                 SetFirstResult(first).SetMaxResults(size).List<PlayerEN>();
                    else
                        result = session.CreateCriteria(typeof(PlayerEN)).List<PlayerEN>();
                }
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }

            return result;
        }

        // Modify default (Update all attributes of the class)

        public void ModifyDefault(PlayerEN player)
        {
            try
            {
                SessionInitializeTransaction();
                PlayerEN playerEN = (PlayerEN)session.Load(typeof(PlayerEN), player.Id);



                playerEN.Name = player.Name;


                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }


        public int NewPlayer(PlayerEN player)
        {
            try
            {
                SessionInitializeTransaction();

                session.Save(player);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return player.Id;
        }

        public void ModifyPlayer(PlayerEN player)
        {
            try
            {
                SessionInitializeTransaction();
                PlayerEN playerEN = (PlayerEN)session.Load(typeof(PlayerEN), player.Id);

                playerEN.Name = player.Name;

                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void DeletePlayer(int id
                                  )
        {
            try
            {
                SessionInitializeTransaction();
                PlayerEN playerEN = (PlayerEN)session.Load(typeof(PlayerEN), id);
                session.Delete(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        public void JoinClubTeam(int p_Player_OID, int p_club_team_OID)
        {
            PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
            try
            {
                SessionInitializeTransaction();
                playerEN = (PlayerEN)session.Load(typeof(PlayerEN), p_Player_OID);
                playerEN.Club_team = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_club_team_OID);

                playerEN.Club_team.Club_player.Add(playerEN);



                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        public void JoinNationalTeam(int p_Player_OID, int p_national_team_OID)
        {
            PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
            try
            {
                SessionInitializeTransaction();
                playerEN = (PlayerEN)session.Load(typeof(PlayerEN), p_Player_OID);
                playerEN.National_team = (PickadosGenNHibernate.EN.Pickados.TeamEN)session.Load(typeof(PickadosGenNHibernate.EN.Pickados.TeamEN), p_national_team_OID);

                playerEN.National_team.National_player.Add(playerEN);



                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }

        public void UnlinkClubTeam(int p_Player_OID, int p_club_team_OID)
        {
            try
            {
                SessionInitializeTransaction();
                PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
                playerEN = (PlayerEN)session.Load(typeof(PlayerEN), p_Player_OID);

                if (playerEN.Club_team.Id == p_club_team_OID)
                {
                    playerEN.Club_team = null;
                }
                else
                    throw new ModelException("The identifier " + p_club_team_OID + " in p_club_team_OID you are trying to unrelationer, doesn't exist in PlayerEN");

                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        public void UnlinkNationalTeam(int p_Player_OID, int p_national_team_OID)
        {
            try
            {
                SessionInitializeTransaction();
                PickadosGenNHibernate.EN.Pickados.PlayerEN playerEN = null;
                playerEN = (PlayerEN)session.Load(typeof(PlayerEN), p_Player_OID);

                if (playerEN.National_team.Id == p_national_team_OID)
                {
                    playerEN.National_team = null;
                }
                else
                    throw new ModelException("The identifier " + p_national_team_OID + " in p_national_team_OID you are trying to unrelationer, doesn't exist in PlayerEN");

                session.Update(playerEN);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }
        }
        //Sin e: GetPlayerById
        //Con e: PlayerEN
        public PlayerEN GetPlayerById(int id
                                       )
        {
            PlayerEN playerEN = null;

            try
            {
                SessionInitializeTransaction();
                playerEN = (PlayerEN)session.Get(typeof(PlayerEN), id);
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return playerEN;
        }

        public System.Collections.Generic.IList<PlayerEN> GetAllPlayers(int first, int size)
        {
            System.Collections.Generic.IList<PlayerEN> result = null;
            try
            {
                SessionInitializeTransaction();
                if (size > 0)
                    result = session.CreateCriteria(typeof(PlayerEN)).
                             SetFirstResult(first).SetMaxResults(size).List<PlayerEN>();
                else
                    result = session.CreateCriteria(typeof(PlayerEN)).List<PlayerEN>();
                SessionCommit();
            }

            catch (Exception ex)
            {
                SessionRollBack();
                if (ex is PickadosGenNHibernate.Exceptions.ModelException)
                    throw ex;
                throw new PickadosGenNHibernate.Exceptions.DataLayerException("Error in PlayerCAD.", ex);
            }


            finally
            {
                SessionClose();
            }

            return result;
        }
    }
}
