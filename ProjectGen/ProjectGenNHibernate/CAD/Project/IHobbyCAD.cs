
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IHobbyCAD
{
HobbyEN ReadOIDDefault (string name);

string Create (HobbyEN hobby);

HobbyEN Search (string name);





System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> GetAllHobby ();
}
}
