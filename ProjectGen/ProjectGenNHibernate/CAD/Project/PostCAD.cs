
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
public partial class PostCAD : BasicCAD, IPostCAD
{
public PostCAD() : base ()
{
}

public PostCAD(ISession sessionAux) : base (sessionAux)
{
}



public PostEN ReadOIDDefault (int id)
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}


public int Create (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                if (post.User != null) {
                        post.User = (ProjectGenNHibernate.EN.Project.UsuarioEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.UsuarioEN), post.User.Nickname);

                        post.User.Post.Add (post);
                }

                session.Save (post);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return post.Id;
}

public void Delete (int id)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), id);
                session.Delete (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void AddHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        ProjectGenNHibernate.EN.Project.PostEN postEN = null;
        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);
                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (postEN.Hobby == null) {
                        postEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
                }

                foreach (string item in p_hobby_OIDs) {
                        hobbyENAux = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                        hobbyENAux.Post.Add (postEN);

                        postEN.Hobby.Add (hobbyENAux);
                }


                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.PostEN postEN = null;
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);

                ProjectGenNHibernate.EN.Project.HobbyEN hobbyENAux = null;
                if (postEN.Hobby != null) {
                        foreach (string item in p_hobby_OIDs) {
                                hobbyENAux = (ProjectGenNHibernate.EN.Project.HobbyEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.HobbyEN), item);
                                if (postEN.Hobby.Contains (hobbyENAux) == true) {
                                        postEN.Hobby.Remove (hobbyENAux);
                                        hobbyENAux.Post.Remove (postEN);
                                }
                                else
                                        throw new ModelException ("The identifier " + item + " in p_hobby_OIDs you are trying to unrelationer, doesn't exist in PostEN");
                        }
                }

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetAllPost ()
{
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> result;
        try
        {
                SessionInitializeTransaction ();
                //String sql = @"FROM PostEN self where FROM PostEN";
                //IQuery query = session.CreateQuery(sql);
                IQuery query = (IQuery)session.GetNamedQuery ("PostENgetAllPostHQL");

                result = query.List<ProjectGenNHibernate.EN.Project.PostEN>();
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return result;
}
public void Modify (PostEN post)
{
        try
        {
                SessionInitializeTransaction ();
                PostEN postEN = (PostEN)session.Load (typeof(PostEN), post.Id);

                postEN.Description = post.Description;

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public void AddGroup (int p_Post_OID, int p_groups_OID)
{
        ProjectGenNHibernate.EN.Project.PostEN postEN = null;
        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);
                postEN.Groups = (ProjectGenNHibernate.EN.Project.GroupsEN)session.Load (typeof(ProjectGenNHibernate.EN.Project.GroupsEN), p_groups_OID);

                postEN.Groups.Post.Add (postEN);



                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}

public void DeleteGroup (int p_Post_OID, int p_groups_OID)
{
        try
        {
                SessionInitializeTransaction ();
                ProjectGenNHibernate.EN.Project.PostEN postEN = null;
                postEN = (PostEN)session.Load (typeof(PostEN), p_Post_OID);

                if (postEN.Groups.Id == p_groups_OID) {
                        postEN.Groups = null;
                }
                else
                        throw new ModelException ("The identifier " + p_groups_OID + " in p_groups_OID you are trying to unrelationer, doesn't exist in PostEN");

                session.Update (postEN);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }
}
public PostEN GetByID (int id)
{
        PostEN postEN = null;

        try
        {
                SessionInitializeTransaction ();
                postEN = (PostEN)session.Get (typeof(PostEN), id);
                SessionCommit ();
        }

        catch (Exception ex) {
                SessionRollBack ();
                if (ex is ProjectGenNHibernate.Exceptions.ModelException)
                        throw ex;
                throw new ProjectGenNHibernate.Exceptions.DataLayerException ("Error in PostCAD.", ex);
        }


        finally
        {
                SessionClose ();
        }

        return postEN;
}
}
}
