
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
public partial class GroupsCAD : BasicCAD, IGroupsCAD
{
public GroupsCAD() : base ()
{
}

public GroupsCAD(ISession sessionAux) : base (sessionAux)
{
}



public GroupsEN ReadOIDDefault (int Id)
{
        GroupsEN groupsEN = null;

        try
        {
                SessionInitializeTransaction ();
                groupsEN = (GroupsEN)session.Get (typeof(GroupsEN), Id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return groupsEN;
}


public GroupsEN ReadOID (int Id)
{
        GroupsEN groupsEN = null;

        try
        {
                SessionInitializeTransaction ();
                groupsEN = (GroupsEN)session.Get (typeof(GroupsEN), Id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return groupsEN;
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> GetAllGroups ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM GroupsEN self where FROM GroupsEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("GroupsENgetAllGroupsHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.GroupsEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public int New_ (GroupsEN groups)
{
        try
        {
                SessionInitializeTransaction ();
                if (groups.Usuario != null) {
                        for (int i = 0; i < groups.Usuario.Count; i++) {
                                groups.Usuario [i] = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), groups.Usuario [i].Nickname);
                                groups.Usuario [i].Groups.Add (groups);
                        }
                }

                session.Save (groups);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return groups.Id;
}

public void Modify (GroupsEN groups)
{
        try
        {
                SessionInitializeTransaction ();
                GroupsEN groupsEN = (GroupsEN)session.Load (typeof(GroupsEN), groups.Id);

                groupsEN.Name = groups.Name;


                groupsEN.Description = groups.Description;


                groupsEN.State = groups.State;

                session.Update (groupsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
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
                GroupsEN groupsEN = (GroupsEN)session.Load (typeof(GroupsEN), Id);
                session.Delete (groupsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        ProjectGenNHibernate.EN.Project.GroupsEN groupsEN = null;
        try
        {
                SessionInitializeTransaction ();
                groupsEN = (GroupsEN)session.Load (typeof(GroupsEN), p_Groups_OID);
                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (groupsEN.Hobby == null) {
                        groupsEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
                }

                foreach (string item in p_hobby_OIDs) {
                        hobbyENAux = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                        hobbyENAux.Groups.Add (groupsEN);

                        groupsEN.Hobby.Add (hobbyENAux);
                }


                session.Update (groupsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.GroupsEN groupsEN = null;
                groupsEN = (GroupsEN)session.Load (typeof(GroupsEN), p_Groups_OID);

                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (groupsEN.Hobby != null) {
                        foreach (string item in p_hobby_OIDs) {
                                hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                                if (groupsEN.Hobby.Contains (hobbyENAux) == true) {
                                        groupsEN.Hobby.Remove (hobbyENAux);
                                        hobbyENAux.Groups.Remove (groupsEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_hobby_OIDs you are trying to unrelationer, doesn't exist in GroupsEN");
                        }
                }

                session.Update (groupsEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in GroupsCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
}
}
