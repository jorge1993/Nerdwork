
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IUsuarioCAD
{
UsuarioEN ReadOIDDefault (string nickname);

string Create (UsuarioEN usuario);

void Modify (UsuarioEN usuario);


void Delete (string nickname);


UsuarioEN Searchbynick (string nickname);


void AddHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);

void DeleteHobbies (string p_Usuario_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);


System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers ();



void AddEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs);

void DeleteEvent (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs);

void AddGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_groups_OIDs);

void DeleteGroup (string p_Usuario_OID, System.Collections.Generic.IList<int> p_events_OIDs);
}
}
