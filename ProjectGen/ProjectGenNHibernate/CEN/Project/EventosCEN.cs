

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
public partial class EventosCEN
{
private IEventosCAD _IEventosCAD;

public EventosCEN()
{
        this._IEventosCAD = new EventosCAD ();
}

public EventosCEN(IEventosCAD _IEventosCAD)
{
        this._IEventosCAD = _IEventosCAD;
}

public IEventosCAD get_IEventosCAD ()
{
        return this._IEventosCAD;
}

public int New_ (string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State, TimeSpan p_DateStart, TimeSpan p_DateEnd, string p_Place, System.Collections.Generic.IList<string> p_usuario)
{
        EventosEN eventosEN = null;
        int oid;

        //Initialized EventosEN
        eventosEN = new EventosEN ();
        eventosEN.Name = p_Name;

        eventosEN.Description = p_Description;

        eventosEN.State = p_State;

        eventosEN.DateStart = p_DateStart;

        eventosEN.DateEnd = p_DateEnd;

        eventosEN.Place = p_Place;


        eventosEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        ProjectGenNHibernate.EN.Project.UsuarioEN en = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                        en.Nickname = item;
                        eventosEN.Usuario.Add (en);
                }
        }

        else{
                eventosEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        }

        //Call to EventosCAD

        oid = _IEventosCAD.New_ (eventosEN);
        return oid;
}

public void Modify (int p_Eventos_OID, string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State, TimeSpan p_DateStart, TimeSpan p_DateEnd, string p_Place)
{
        EventosEN eventosEN = null;

        //Initialized EventosEN
        eventosEN = new EventosEN ();
        eventosEN.Id = p_Eventos_OID;
        eventosEN.Name = p_Name;
        eventosEN.Description = p_Description;
        eventosEN.State = p_State;
        eventosEN.DateStart = p_DateStart;
        eventosEN.DateEnd = p_DateEnd;
        eventosEN.Place = p_Place;
        //Call to EventosCAD

        _IEventosCAD.Modify (eventosEN);
}

public void Destroy (int Id)
{
        _IEventosCAD.Destroy (Id);
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> GetAllEventos ()
{
        return _IEventosCAD.GetAllEventos ();
}
public void DeleteHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobbyEvent_OIDs)
{
        //Call to EventosCAD

        _IEventosCAD.DeleteHobbies (p_Eventos_OID, p_hobbyEvent_OIDs);
}
public void AddHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobbyEvent_OIDs)
{
        //Call to EventosCAD

        _IEventosCAD.AddHobbies (p_Eventos_OID, p_hobbyEvent_OIDs);
}
}
}
