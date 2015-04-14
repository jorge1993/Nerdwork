
using System;
using System.Text;
using ProjectGenNHibernate.CEN.Project;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;
using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.Exceptions;

namespace ProjectGenNHibernate.CAD.Project
{
public partial class HobbyCAD : BasicCAD, IHobbyCAD
{
public HobbyCAD() : base ()
{
}

public HobbyCAD(ISession sessionAux) : base (sessionAux)
{
}



public HobbyEN ReadOIDDefault (string name)
{
        HobbyEN hobbyEN = null;

        try
        {
                SessionInitializeTransaction ();
                hobbyEN = (HobbyEN)session.Get (typeof(HobbyEN), name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in HobbyCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return hobbyEN;
}


public string Create (HobbyEN hobby)
{
        try
        {
                SessionInitializeTransaction ();

                session.Save (hobby);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in HobbyCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return hobby.Name;
}

public HobbyEN Search (string name)
{
        HobbyEN hobbyEN = null;

        try
        {
                SessionInitializeTransaction ();
                hobbyEN = (HobbyEN)session.Get (typeof(HobbyEN), name);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in HobbyCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return hobbyEN;
}
}
}
