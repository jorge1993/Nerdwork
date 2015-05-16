
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IEventosCAD
{
EventosEN ReadOIDDefault (int Id);


int New_ (EventosEN eventos);

void Modify (EventosEN eventos);


void Destroy (int Id);




System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.EventosEN> GetAll ();



void DeleteHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);

void AddHobbies (int p_Eventos_OID, System.Collections.Generic.IList<string> p_hobby_OIDs);
}
}
