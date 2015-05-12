

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
public partial class GroupsCEN
{
private IGroupsCAD _IGroupsCAD;

public GroupsCEN()
{
        this._IGroupsCAD = new GroupsCAD ();
}

public GroupsCEN(IGroupsCAD _IGroupsCAD)
{
        this._IGroupsCAD = _IGroupsCAD;
}

public IGroupsCAD get_IGroupsCAD ()
{
        return this._IGroupsCAD;
}

public GroupsEN ReadOID (int Id)
{
        GroupsEN groupsEN = null;

        groupsEN = _IGroupsCAD.ReadOID (Id);
        return groupsEN;
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> GetAllGroups ()
{
        return _IGroupsCAD.GetAllGroups ();
}
public int New_ (string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State, int p_post, System.Collections.Generic.IList<string> p_usuario)
{
        GroupsEN groupsEN = null;
        int oid;

        //Initialized GroupsEN
        groupsEN = new GroupsEN ();
        groupsEN.Name = p_Name;

        groupsEN.Description = p_Description;

        groupsEN.State = p_State;


        if (p_post != -1) {
                groupsEN.Post = new ProjectGenNHibernate.EN.Project.PostEN ();
                groupsEN.Post.Id = p_post;
        }


        groupsEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        ProjectGenNHibernate.EN.Project.UsuarioEN en = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                        en.Nickname = item;
                        groupsEN.Usuario.Add (en);
                }
        }

        else{
                groupsEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        }

        //Call to GroupsCAD

        oid = _IGroupsCAD.New_ (groupsEN);
        return oid;
}

public void Modify (int p_Groups_OID, string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State)
{
        GroupsEN groupsEN = null;

        //Initialized GroupsEN
        groupsEN = new GroupsEN ();
        groupsEN.Id = p_Groups_OID;
        groupsEN.Name = p_Name;
        groupsEN.Description = p_Description;
        groupsEN.State = p_State;
        //Call to GroupsCAD

        _IGroupsCAD.Modify (groupsEN);
}

public void Destroy (int Id)
{
        _IGroupsCAD.Destroy (Id);
}

public void AddHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to GroupsCAD

        _IGroupsCAD.AddHobbies (p_Groups_OID, p_hobby_OIDs);
}
public void DeleteHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to GroupsCAD

        _IGroupsCAD.DeleteHobbies (p_Groups_OID, p_hobby_OIDs);
}
}
}
