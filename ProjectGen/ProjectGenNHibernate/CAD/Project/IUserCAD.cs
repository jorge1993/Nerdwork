
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IUserCAD
{
UserEN ReadOIDDefault (string nickname);

string Create (UserEN user);

void Modify (UserEN user);


void Delete (string nickname);


UserEN Searchbynick (string nickname);
}
}
