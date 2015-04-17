
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
}
}
