

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
public partial class EventsCEN
{
private IEventsCAD _IEventsCAD;

public EventsCEN()
{
        this._IEventsCAD = new EventsCAD ();
}

public EventsCEN(IEventsCAD _IEventsCAD)
{
        this._IEventsCAD = _IEventsCAD;
}

public IEventsCAD get_IEventsCAD ()
{
        return this._IEventsCAD;
}

public int New_ (string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State, TimeSpan p_DateStart, TimeSpan p_DateEnd, string p_Place, System.Collections.Generic.IList<string> p_usuario)
{
        EventsEN eventsEN = null;
        int oid;

        //Initialized EventsEN
        eventsEN = new EventsEN ();
        eventsEN.Name = p_Name;

        eventsEN.Description = p_Description;

        eventsEN.State = p_State;

        eventsEN.DateStart = p_DateStart;

        eventsEN.DateEnd = p_DateEnd;

        eventsEN.Place = p_Place;


        eventsEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        if (p_usuario != null) {
                foreach (string item in p_usuario) {
                        ProjectGenNHibernate.EN.Project.UsuarioEN en = new ProjectGenNHibernate.EN.Project.UsuarioEN ();
                        en.Nickname = item;
                        eventsEN.Usuario.Add (en);
                }
        }

        else{
                eventsEN.Usuario = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.UsuarioEN>();
        }

        //Call to EventsCAD

        oid = _IEventsCAD.New_ (eventsEN);
        return oid;
}

public void Modify (int p_Events_OID, string p_Name, string p_Description, ProjectGenNHibernate.Enumerated.Project.EstadoEnum p_State, TimeSpan p_DateStart, TimeSpan p_DateEnd, string p_Place)
{
        EventsEN eventsEN = null;

        //Initialized EventsEN
        eventsEN = new EventsEN ();
        eventsEN.Id = p_Events_OID;
        eventsEN.Name = p_Name;
        eventsEN.Description = p_Description;
        eventsEN.State = p_State;
        eventsEN.DateStart = p_DateStart;
        eventsEN.DateEnd = p_DateEnd;
        eventsEN.Place = p_Place;
        //Call to EventsCAD

        _IEventsCAD.Modify (eventsEN);
}

public void Destroy (int Id)
{
        _IEventsCAD.Destroy (Id);
}

public System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> GetAll ()
{
        return _IEventsCAD.GetAll ();
}
public void DeleteHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to EventsCAD

        _IEventsCAD.DeleteHobbies (p_Events_OID, p_hobby_OIDs);
}
public void AddHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs)
{
        //Call to EventsCAD

        _IEventsCAD.AddHobbies (p_Events_OID, p_hobby_OIDs);
}
}
}
