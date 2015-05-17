
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IPostCAD
{
PostEN ReadOIDDefault (int id);

int Create (PostEN post);

void Delete (int id);


void AddHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);

void DeleteHobbies (int p_Post_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);



System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> GetAllPost ();



void Modify (PostEN post);


void AddGroup (int p_Post_OID, int p_groups_OID);

void DeleteGroup (int p_Post_OID, int p_groups_OID);


PostEN GetByID (int id);
}
}
