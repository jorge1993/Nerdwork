

using System;
using System.Text;

using NHibernate;
using NHibernate.Cfg;
using NHibernate.Criterion;
using NHibernate.Exceptions;

using ProjectGenNHibernate.EN.Project;
using ProjectGenNHibernate.CAD.Project;

namespace ProjectGenNHibernate.CEN.Project
{
public partial class PostCEN
{
private IPostCAD _IPostCAD;

public PostCEN()
{
        this._IPostCAD = new PostCAD ();
}

public PostCEN(IPostCAD _IPostCAD)
{
        this._IPostCAD = _IPostCAD;
}

public IPostCAD get_IPostCAD ()
{
        return this._IPostCAD;
}

public int Create (string p_description, string p_user)
{
        PostEN postEN = null;
        int oid;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Description = p_description;


        if (p_user != null) {
                postEN.User = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                postEN.User.Nickname = p_user;
        }

        //Call to PostCAD

        oid = _IPostCAD.Create (postEN);
        return oid;
}

public void Delete (int id)
{
        _IPostCAD.Delete (id);
}

public void AddHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to PostCAD

        _IPostCAD.AddHobbies (p_Post_OID, p_hobby_OIDs);
}
public void DeleteHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to PostCAD

        _IPostCAD.DeleteHobbies (p_Post_OID, p_hobby_OIDs);
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetAllPost ()
{
        return _IPostCAD.GetAllPost ();
}
public void Modify (int p_Post_OID, string p_description)
{
        PostEN postEN = null;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Id = p_Post_OID;
        postEN.Description = p_description;
        //Call to PostCAD

        _IPostCAD.Modify (postEN);
}

public void AddGroup (int p_Post_OID, int p_groups_OID)
{
        //Call to PostCAD

        _IPostCAD.AddGroup (p_Post_OID, p_groups_OID);
}
public void DeleteGroup (int p_Post_OID, int p_groups_OID)
{
        //Call to PostCAD

        _IPostCAD.DeleteGroup (p_Post_OID, p_groups_OID);
}
public PostEN GetByID (int id)
{
        PostEN postEN = null;

        postEN = _IPostCAD.GetByID (id);
        return postEN;
}
}
}
