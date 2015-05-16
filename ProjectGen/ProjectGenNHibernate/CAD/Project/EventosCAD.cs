
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
public partial class EventosCAD : BasicCAD, IEventosCAD
{
public EventosCAD() : base ()
{
}

public EventosCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventosEN ReadOIDDefault (int Id)
{
        EventosEN eventosEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventosEN = (EventosEN)session.Get (typeof(EventosEN), Id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventosEN;
}


public int New_ (EventosEN eventos)
{
        try
        {
                SessionInitializeTransaction ();
                if (eventos.Usuario != null) {
                        for (int i = 0; i < eventos.Usuario.Count; i++) {
                                eventos.Usuario [i] = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), eventos.Usuario [i].Nickname);
                                eventos.Usuario [i].Events.Add (eventos);
                        }
                }

                session.Save (eventos);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventos.Id;
}

public void Modify (EventosEN eventos)
{
        try
        {
                SessionInitializeTransaction ();
                EventosEN eventosEN = (EventosEN)session.Load (typeof(EventosEN), eventos.Id);

                eventosEN.Name = eventos.Name;


                eventosEN.Description = eventos.Description;


                eventosEN.State = eventos.State;


                eventosEN.DateStart = eventos.DateStart;


                eventosEN.DateEnd = eventos.DateEnd;


                eventosEN.Place = eventos.Place;

                session.Update (eventosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Destroy (int Id)
{
        try
        {
                SessionInitializeTransaction ();
                EventosEN eventosEN = (EventosEN)session.Load (typeof(EventosEN), Id);
                session.Delete (eventosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> GetAll ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventosEN self where FROM EventosEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventosENgetAllHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.EventosEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void DeleteHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.EventosEN eventosEN = null;
                eventosEN = (EventosEN)session.Load (typeof(EventosEN), p_Eventos_OID);

                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (eventosEN.Hobby != null) {
                        foreach (string item in p_hobby_OIDs) {
                                hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                                if (eventosEN.Hobby.Contains (hobbyENAux) == true) {
                                        eventosEN.Hobby.Remove (hobbyENAux);
                                        hobbyENAux.Events.Remove (eventosEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_hobby_OIDs you are trying to unrelationer, doesn't exist in EventosEN");
                        }
                }

                session.Update (eventosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        ProjectGenNHibernate.EN.Project.EventosEN eventosEN = null;
        try
        {
                SessionInitializeTransaction ();
                eventosEN = (EventosEN)session.Load (typeof(EventosEN), p_Eventos_OID);
                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (eventosEN.Hobby == null) {
                        eventosEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
                }

                foreach (string item in p_hobby_OIDs) {
                        hobbyENAux = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                        hobbyENAux.Events.Add (eventosEN);

                        eventosEN.Hobby.Add (hobbyENAux);
                }


                session.Update (eventosEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventosCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
