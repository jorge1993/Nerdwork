
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IHobbyCAD
{
HobbyEN ReadOIDDefault (string name);

string Create (HobbyEN hobby);

HobbyEN Search (string name);
}
}
