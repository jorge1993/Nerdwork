
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
                UsuarioCAD usercad = new UsuarioCAD (session);

                listaux = usercad.GetAllUsers ();

                foreach (UsuarioEN eve in listaux) {
                        System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> listaux2 = new System.Collections.Generic.List<HobbyEN>();
                        listaux2 = eve.Hobby;
                        foreach (HobbyEN ho in listaux2) {
                                if (ho.Name.IndexOf (p_oid) >= 0) {
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
