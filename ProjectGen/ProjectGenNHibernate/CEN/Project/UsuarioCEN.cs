

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
public partial class UsuarioCEN
{
private IUsuarioCAD _IUsuarioCAD;

public UsuarioCEN()
{
        this._IUsuarioCAD = new UsuarioCAD ();
}

public UsuarioCEN(IUsuarioCAD _IUsuarioCAD)
{
        this._IUsuarioCAD = _IUsuarioCAD;
}

public IUsuarioCAD get_IUsuarioCAD ()
{
        return this._IUsuarioCAD;
}

public string Create (string p_nickname, string p_email, string p_password, string p_name, string p_surname, string p_phone, string p_avatar, System.Collections.Generic.IList<string> p_hobby)
{
        UsuarioEN usuarioEN = null;
        string oid;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nickname = p_nickname;

        usuarioEN.Email = p_email;

        usuarioEN.Password = p_password;

        usuarioEN.Name = p_name;

        usuarioEN.Surname = p_surname;

        usuarioEN.Phone = p_phone;

        usuarioEN.Avatar = p_avatar;


        usuarioEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        if (p_hobby != null) {
                foreach (string item in p_hobby) {
                        ProjectGenNHibernate.EN.Project.HobbyEN en = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        en.Name = item;
                        usuarioEN.Hobby.Add (en);
                }
        }

        else{
                usuarioEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        }

        //Call to UsuarioCAD

        oid = _IUsuarioCAD.Create (usuarioEN);
        return oid;
}

public void Modify (string p_Usuario_OID, string p_email, string p_password, string p_name, string p_surname, string p_phone, string p_avatar)
{
        UsuarioEN usuarioEN = null;

        //Initialized UsuarioEN
        usuarioEN = new UsuarioEN ();
        usuarioEN.Nickname = p_Usuario_OID;
        usuarioEN.Email = p_email;
        usuarioEN.Password = p_password;
        usuarioEN.Name = p_name;
        usuarioEN.Surname = p_surname;
        usuarioEN.Phone = p_phone;
        usuarioEN.Avatar = p_avatar;
        //Call to UsuarioCAD

        _IUsuarioCAD.Modify (usuarioEN);
}

public void Delete (string nickname)
{
        _IUsuarioCAD.Delete (nickname);
}

public UsuarioEN Searchbynick (string nickname)
{
        UsuarioEN usuarioEN = null;

        usuarioEN = _IUsuarioCAD.Searchbynick (nickname);
        return usuarioEN;
}

public void AddHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddHobbies (p_Usuario_OID, p_hobby_OIDs);
}
public void DeleteHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteHobbies (p_Usuario_OID, p_hobby_OIDs);
}
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers ()
{
        return _IUsuarioCAD.GetAllUsers ();
}
public void AddEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddEvent (p_Usuario_OID, p_events_OIDs);
}
public void DeleteEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteEvent (p_Usuario_OID, p_events_OIDs);
}
public void AddGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_groups_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.AddGroup (p_Usuario_OID, p_groups_OIDs);
}
public void DeleteGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs)
{
        //Call to UsuarioCAD

        _IUsuarioCAD.DeleteGroup (p_Usuario_OID, p_events_OIDs);
}
}
}
