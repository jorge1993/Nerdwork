
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
public partial class UsuarioCAD : BasicCAD, IUsuarioCAD
{
public UsuarioCAD() : base ()
{
}

public UsuarioCAD(ISession sessionAux) : base (sessionAux)
{
}



public UsuarioEN ReadOIDDefault (string nickname)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}


public string Create (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                if (usuario.Hobby != null) {
                        for (int i = 0; i < usuario.Hobby.Count; i++) {
                                usuario.Hobby [i] = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), usuario.Hobby [i].Name);
                                usuario.Hobby [i].User.Add (usuario);
                        }
                }

                session.Save (usuario);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuario.Nickname;
}

public void Modify (UsuarioEN usuario)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), usuario.Nickname);

                usuarioEN.Email = usuario.Email;


                usuarioEN.Password = usuario.Password;


                usuarioEN.Name = usuario.Name;


                usuarioEN.Surname = usuario.Surname;


                usuarioEN.Phone = usuario.Phone;


                usuarioEN.Avatar = usuario.Avatar;

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void Delete (string nickname)
{
        try
        {
                SessionInitializeTransaction ();
                UsuarioEN usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), nickname);
                session.Delete (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public UsuarioEN Searchbynick (string nickname)
{
        UsuarioEN usuarioEN = null;

        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Get (typeof(UsuarioEN), nickname);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return usuarioEN;
}

public void AddHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (usuarioEN.Hobby == null) {
                        usuarioEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
                }

                foreach (string item in p_hobby_OIDs) {
                        hobbyENAux = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                        hobbyENAux.User.Add (usuarioEN);

                        usuarioEN.Hobby.Add (hobbyENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (usuarioEN.Hobby != null) {
                        foreach (string item in p_hobby_OIDs) {
                                hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                                if (usuarioEN.Hobby.Contains (hobbyENAux) == true) {
                                        usuarioEN.Hobby.Remove (hobbyENAux);
                                        hobbyENAux.User.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_hobby_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM UsuarioEN self where FROM UsuarioEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("UsuarioENgetAllUsersHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void AddEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_eventos_OIDs)
{
        ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ProjectGenNHibernate.EN.Project.EventosEN eventosENAux = null;
                if (usuarioEN.Eventos == null) {
                        usuarioEN.Eventos = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.EventosEN>();
                }

                foreach (int item in p_eventos_OIDs) {
                        eventosENAux = new ProjectGenNHibernate.EN.Project.EventosEN ();
                        eventosENAux = (ProjectGenNHibernate.EN.Project.EventosEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.EventosEN), item);
                        eventosENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Eventos.Add (eventosENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_eventos_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ProjectGenNHibernate.EN.Project.EventosEN eventosENAux = null;
                if (usuarioEN.Eventos != null) {
                        foreach (int item in p_eventos_OIDs) {
                                eventosENAux = (ProjectGenNHibernate.EN.Project.EventosEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.EventosEN), item);
                                if (usuarioEN.Eventos.Contains (eventosENAux) == true) {
                                        usuarioEN.Eventos.Remove (eventosENAux);
                                        eventosENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_eventos_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_groups_OIDs)
{
        ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
        try
        {
                SessionInitializeTransaction ();
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);
                ProjectGenNHibernate.EN.Project.GroupsEN groupsENAux = null;
                if (usuarioEN.Groups == null) {
                        usuarioEN.Groups = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
                }

                foreach (int item in p_groups_OIDs) {
                        groupsENAux = new ProjectGenNHibernate.EN.Project.GroupsEN ();
                        groupsENAux = (ProjectGenNHibernate.EN.Project.GroupsEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.GroupsEN), item);
                        groupsENAux.Usuario.Add (usuarioEN);

                        usuarioEN.Groups.Add (groupsENAux);
                }


                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_groups_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.UsuarioEN usuarioEN = null;
                usuarioEN = (UsuarioEN)session.Load (typeof(UsuarioEN), p_Usuario_OID);

                ProjectGenNHibernate.EN.Project.GroupsEN groupsENAux = null;
                if (usuarioEN.Groups != null) {
                        foreach (int item in p_groups_OIDs) {
                                groupsENAux = (ProjectGenNHibernate.EN.Project.GroupsEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.GroupsEN), item);
                                if (usuarioEN.Groups.Contains (groupsENAux) == true) {
                                        usuarioEN.Groups.Remove (groupsENAux);
                                        groupsENAux.Usuario.Remove (usuarioEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_groups_OIDs you are trying to unrelationer, doesn't exist in UsuarioEN");
                        }
                }

                session.Update (usuarioEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in UsuarioCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
