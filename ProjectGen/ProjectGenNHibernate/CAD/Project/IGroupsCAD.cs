
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IGroupsCAD
{
GroupsEN ReadOIDDefault (int Id);

GroupsEN ReadOID (int Id);


System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.GroupsEN> GetAllGroups ();



int New_ (GroupsEN groups);

void Modify (GroupsEN groups);


void Destroy (int Id);





void AddHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);

void DeleteHobbies (int p_Groups_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);
}
}
