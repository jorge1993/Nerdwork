
using System;
using ProjectGenNHibernate.EN.Project;

namespace ProjectGenNHibernate.CAD.Project
{
public partial interface IMessagesCAD
{
MessagesEN ReadOIDDefault (int id);

int Create (MessagesEN messages);

void Delete (int id);
}
}
