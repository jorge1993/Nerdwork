
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
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUsers (int arg0)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Groups_getAllUsers) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> lista = new System.Collections.Generic.List<UsuarioEN>();
        try
        {
                SessionInitializeTransaction ();
                UsuarioCAD usuariocad = new UsuarioCAD (session);
                GroupsCAD groupcad = new GroupsCAD (session);
                GroupsEN groupen = groupcad.ReadOIDDefault (arg0);

                foreach (UsuarioEN us in groupen.Usuario) {
                        lista.Add (us);
                }
                SessionCommit ();
        }
        catch (Exception ex)
        {
                SessionRollBack ();
        }
        return lista;


        /*PROTECTED REGION END*/
}
}
}
