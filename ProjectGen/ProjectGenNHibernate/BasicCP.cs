using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using ProjectGenNHibernate.CAD.Project;
using ProjectGenNHibernate.Exceptions;

namespace ProjectGenNHibernate
{
public class BasicCP
{
public ISession session;

public bool sessionInside;

public ITransaction tx;

public BasicCP()
{
        sessionInside = true;
}

public BasicCP(ISession sessionAux)
{
        session = sessionAux;
        sessionInside = false;
}

public void SessionInitializeTransaction ()
{
        if (session == null) {
                session = NHibernateHelper.OpenSession ();
                tx = session.BeginTransaction ();
        }
}

public void SessionCommit ()
{
        if (sessionInside && session != null)
                tx.Commit ();
}

public void SessionRollBack ()
{
        if (sessionInside && session != null && session.IsOpen)
                tx.Rollback ();
}

public void SessionClose ()
{
        if (sessionInside && session != null && session.IsOpen) {
                session.Close ();
                session.Dispose ();
                session = null;
        }
}
}
}
