
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
public partial class EventsCAD : BasicCAD, IEventsCAD
{
public EventsCAD() : base ()
{
}

public EventsCAD(ISession sessionAux) : base (sessionAux)
{
}



public EventsEN ReadOIDDefault (int Id)
{
        EventsEN eventsEN = null;

        try
        {
                SessionInitializeTransaction ();
                eventsEN = (EventsEN)session.Get (typeof(EventsEN), Id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return eventsEN;
}


public int New_ (EventsEN events)
{
        try
        {
                SessionInitializeTransaction ();
                if (events.Usuario != null) {
                        for (int i = 0; i < events.Usuario.Count; i++) {
                                events.Usuario [i] = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), events.Usuario [i].Nickname);
                                events.Usuario [i].Events.Add (events);
                        }
                }

                session.Save (events);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return events.Id;
}

public void Modify (EventsEN events)
{
        try
        {
                SessionInitializeTransaction ();
                EventsEN eventsEN = (EventsEN)session.Load (typeof(EventsEN), events.Id);

                eventsEN.Name = events.Name;


                eventsEN.Description = events.Description;


                eventsEN.State = events.State;


                eventsEN.DateStart = events.DateStart;


                eventsEN.DateEnd = events.DateEnd;


                eventsEN.Place = events.Place;

                session.Update (eventsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
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
                EventsEN eventsEN = (EventsEN)session.Load (typeof(EventsEN), Id);
                session.Delete (eventsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> GetAll ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM EventsEN self where FROM EventsEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("EventsENgetAllHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.EventsEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        ProjectGenNHibernate.EN.Project.EventsEN eventsEN = null;
        try
        {
                SessionInitializeTransaction ();
                eventsEN = (EventsEN)session.Load (typeof(EventsEN), p_Events_OID);
                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (eventsEN.Hobby == null) {
                        eventsEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
                }

                foreach (string item in p_hobby_OIDs) {
                        hobbyENAux = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                        hobbyENAux.Events.Add (eventsEN);

                        eventsEN.Hobby.Add (hobbyENAux);
                }


                session.Update (eventsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.EventsEN eventsEN = null;
                eventsEN = (EventsEN)session.Load (typeof(EventsEN), p_Events_OID);

                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (eventsEN.Hobby != null) {
                        foreach (string item in p_hobby_OIDs) {
                                hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                                if (eventsEN.Hobby.Contains (hobbyENAux) == true) {
                                        eventsEN.Hobby.Remove (hobbyENAux);
                                        hobbyENAux.Events.Remove (eventsEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_hobby_OIDs you are trying to unrelationer, doesn't exist in EventsEN");
                        }
                }

                session.Update (eventsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in EventsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
