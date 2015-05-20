
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IEventsCAD
{
EventsEN ReadOIDDefault (int Id);


int New_ (EventsEN events);

void Modify (EventsEN events);


void Destroy (int Id);




System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventsEN> GetAll ();



void DeleteHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);

void AddHobbies (int p_Events_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);
}
}
