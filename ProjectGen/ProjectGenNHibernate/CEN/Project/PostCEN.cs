

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

public int Create (int p_id, string p_description, string p_user)
{
        PostEN postEN = null;
        int oid;

        //Initialized PostEN
        postEN = new PostEN ();
        postEN.Id = p_id;

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
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetMax ()
{
        return _IPostCAD.GetMax ();
}
}
}
