
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



System.Collections.Generic.IList<PostEN> GetAllPost (int first, int size);
}
}
