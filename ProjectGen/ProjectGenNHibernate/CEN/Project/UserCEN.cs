

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
public partial class UserCEN
{
private IUserCAD _IUserCAD;

public UserCEN()
{
        this._IUserCAD = new UserCAD ();
}

public UserCEN(IUserCAD _IUserCAD)
{
        this._IUserCAD = _IUserCAD;
}

public IUserCAD get_IUserCAD ()
{
        return this._IUserCAD;
}

public string Create (string p_nickname, string p_email, string p_password, string p_name, string p_surname, string p_phone, string p_avatar, System.Collections.Generic.IList<string> p_hobby)
{
        UserEN userEN = null;
        string oid;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Nickname = p_nickname;

        userEN.Email = p_email;

        userEN.Password = p_password;

        userEN.Name = p_name;

        userEN.Surname = p_surname;

        userEN.Phone = p_phone;

        userEN.Avatar = p_avatar;


        userEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        if (p_hobby != null) {
                foreach (string item in p_hobby) {
                        ProjectGenNHibernate.EN.Project.HobbyEN en = new ProjectGenNHibernate.EN.Project.HobbyEN ();
                        en.Name = item;
                        userEN.Hobby.Add (en);
                }
        }

        else{
                userEN.Hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
        }

        //Call to UserCAD

        oid = _IUserCAD.Create (userEN);
        return oid;
}

public void Modify (string p_User_OID, string p_email, string p_password, string p_name, string p_surname, string p_phone, string p_avatar)
{
        UserEN userEN = null;

        //Initialized UserEN
        userEN = new UserEN ();
        userEN.Nickname = p_User_OID;
        userEN.Email = p_email;
        userEN.Password = p_password;
        userEN.Name = p_name;
        userEN.Surname = p_surname;
        userEN.Phone = p_phone;
        userEN.Avatar = p_avatar;
        //Call to UserCAD

        _IUserCAD.Modify (userEN);
}

public void Delete (string nickname)
{
        _IUserCAD.Delete (nickname);
}

public UserEN Searchbynick (string nickname)
{
        UserEN userEN = null;

        userEN = _IUserCAD.Searchbynick (nickname);
        return userEN;
}
}
}
