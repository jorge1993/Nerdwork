
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IMessagesCAD
{
MessagesEN ReadOIDDefault (int id);

int Create (MessagesEN messages);

void Delete (int id);


System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetSend (string usuario);


System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetMax ();


System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> GetReceive (string arg0);
}
}
