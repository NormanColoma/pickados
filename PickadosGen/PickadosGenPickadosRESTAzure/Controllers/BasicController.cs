using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using NHibernate;
using PickadosGenNHibernate.CAD.Pickados;

namespace PickadosGenPickadosRESTAzure.Controllers
{
public class BasicController : ApiController
{
#region NHibernate Session

protected ISession session;

protected bool sessionStarted;
protected bool transaccionStarted;

protected ITransaction tx;

protected BasicController()
{
        session = null; tx = null;
        sessionStarted = true;
        transaccionStarted = false;
}

protected BasicController(ISession sessionAux)
{
        session = sessionAux;
        sessionStarted = false;
        transaccionStarted = false;
}

protected void SessionInitializeWithoutTransaction ()
{
        if (session == null && sessionStarted == true) {
                session = NHibernateHelper.OpenSession ();
        }
}

protected void SessionInitializeTransaction ()
{
        if (session == null && tx == null && sessionStarted == true && transaccionStarted == false) {
                session = NHibernateHelper.OpenSession ();
                tx = session.BeginTransaction ();
                transaccionStarted = true;
        }
}

protected void SessionCommit ()
{
        if (transaccionStarted && tx != null && session.IsOpen) {
                tx.Commit ();
                transaccionStarted = false;
        }
}
protected void SessionRollBack ()
{
        if (transaccionStarted && tx != null && session.IsOpen) {
                tx.Rollback ();
                transaccionStarted = false;
        }
}

protected void SessionClose ()
{
        if (sessionStarted && session != null && session.IsOpen) {
                session.Close ();
                session.Dispose ();
                session = null;
                tx = null;
        }
}

#endregion


#region Individual Security

protected bool IsLoginID (string id)
{
        return(User.Identity.Name == id);
}

protected void Security (string id)
{
        if (User.Identity.Name == id) throw new HttpResponseException (HttpStatusCode.Unauthorized);
}

#endregion
}
}
