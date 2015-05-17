
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
public partial class UsuarioCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> SearchByHobbies (string p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Usuario_searchByHobbies) ENABLED START*/

        // Write here your custom code...
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> lista = new System.Collections.Generic.List<UsuarioEN>();
        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> listaux = new System.Collections.Generic.List<UsuarioEN>();
        try
        {
                SessionInitializeTransaction ();
                HobbyCAD hobbycad = new HobbyCAD (session);
                UsuarioEN usercad = new UsuarioEN ();
                UsuarioCEN us = new UsuarioCEN ();
                listaux = us.GetAllUsers ();

                foreach (UsuarioEN eve in listaux) {
                        foreach (HobbyEN ho in eve.Hobby) {
                                if (ho.Name.Contains (p_oid)) {
                                        lista.Add (eve);
                                        break;
                                }
                        }
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
