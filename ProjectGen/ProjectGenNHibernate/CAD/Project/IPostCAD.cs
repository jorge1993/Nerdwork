
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IPostCAD
{
PostEN ReadOIDDefault (int id);

int Create (PostEN post);

void Delete (int id);
}
}
