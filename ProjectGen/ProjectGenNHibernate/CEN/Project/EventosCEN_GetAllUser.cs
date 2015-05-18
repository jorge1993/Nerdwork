
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
public partial class EventosCEN : BasicCAD
{
public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> GetAllUser (int p_oid)
{
        /*PROTECTED REGION ID(ProjectGenNHibernate.CEN.Project_Eventos_getAllUser) ENABLED START*/

        // Write here your custom code...
    System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.UsuarioEN> lista = new System.Collections.Generic.List<UsuarioEN>();
    try
    {
        SessionInitializeTransaction();
        UsuarioCAD usuariocad = new UsuarioCAD(session);
        EventosCAD groupcad = new EventosCAD(session);
        EventosEN groupen = groupcad.ReadOIDDefault(p_oid);

        foreach (UsuarioEN us in groupen.Usuario)
        {
            lista.Add(us);
        }
        SessionCommit();
    }
    catch (Exception ex)
    {
        SessionRollBack();
    }
    return lista;
        /*PROTECTED REGION END*/
}
}
}
