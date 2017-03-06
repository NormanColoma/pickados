

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using PickadosGenNHibernate.Exceptions;

using PickadosGenNHibernate.EN.Pickados;
using PickadosGenNHibernate.CAD.Pickados;


namespace PickadosGenNHibernate.CEN.Pickados
{
/*
 *      Definition of the class RequestCEN
 *
 */
public partial class RequestCEN
{
private IRequestCAD _IRequestCAD;

public RequestCEN()
{
        this._IRequestCAD = new RequestCAD ();
}

public RequestCEN(IRequestCAD _IRequestCAD)
{
        this._IRequestCAD = _IRequestCAD;
}

public IRequestCAD get_IRequestCAD ()
{
        return this._IRequestCAD;
}

public int New_ (int p_post, PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum p_type, string p_reason, PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum p_state, Nullable<DateTime> p_date)
{
        RequestEN requestEN = null;
        int oid;

        //Initialized RequestEN
        requestEN = new RequestEN ();

        if (p_post != -1) {
                // El argumento p_post -> Property post es oid = false
                // Lista de oids id
                requestEN.Post = new PickadosGenNHibernate.EN.Pickados.PostEN ();
                requestEN.Post.Id = p_post;
        }

        requestEN.Type = p_type;

        requestEN.Reason = p_reason;

        requestEN.State = p_state;

        requestEN.Date = p_date;

        //Call to RequestCAD

        oid = _IRequestCAD.New_ (requestEN);
        return oid;
}

public void Modify (int p_Request_OID, PickadosGenNHibernate.Enumerated.Pickados.RequestTypeEnum p_type, string p_reason, PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum p_state, Nullable<DateTime> p_date)
{
        RequestEN requestEN = null;

        //Initialized RequestEN
        requestEN = new RequestEN ();
        requestEN.Id = p_Request_OID;
        requestEN.Type = p_type;
        requestEN.Reason = p_reason;
        requestEN.State = p_state;
        requestEN.Date = p_date;
        //Call to RequestCAD

        _IRequestCAD.Modify (requestEN);
}

public void Delete (int id
                    )
{
        _IRequestCAD.Delete (id);
}

public RequestEN GetById (int id
                          )
{
        RequestEN requestEN = null;

        requestEN = _IRequestCAD.GetById (id);
        return requestEN;
}

public System.Collections.Generic.IList<RequestEN> GetAll (int first, int size)
{
        System.Collections.Generic.IList<RequestEN> list = null;

        list = _IRequestCAD.GetAll (first, size);
        return list;
}
public System.Collections.Generic.IList<PickadosGenNHibernate.EN.Pickados.RequestEN> GetByState (PickadosGenNHibernate.Enumerated.Pickados.RequestStateEnum ? p_state)
{
        return _IRequestCAD.GetByState (p_state);
}
}
}
