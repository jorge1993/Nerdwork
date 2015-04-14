
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class MessagesEN
{
/**
 *
 */

private int id;

/**
 *
 */

private string subject;

/**
 *
 */

private string description;

/**
 *
 */

private ProjectGenNHibernate.EN.Project.UserEN userreceive;

/**
 *
 */

private ProjectGenNHibernate.EN.Project.UserEN usersend;





public virtual int Id {
        get { return id; } set { id = value;  }
}


public virtual string Subject {
        get { return subject; } set { subject = value;  }
}


public virtual string Description {
        get { return description; } set { description = value;  }
}


public virtual ProjectGenNHibernate.EN.Project.UserEN Userreceive {
        get { return userreceive; } set { userreceive = value;  }
}


public virtual ProjectGenNHibernate.EN.Project.UserEN Usersend {
        get { return usersend; } set { usersend = value;  }
}





public MessagesEN()
{
}



public MessagesEN(int id, string subject, string description, ProjectGenNHibernate.EN.Project.UserEN userreceive, ProjectGenNHibernate.EN.Project.UserEN usersend)
{
        this.init (id, subject, description, userreceive, usersend);
}


public MessagesEN(MessagesEN messages)
{
        this.init (messages.Id, messages.Subject, messages.Description, messages.Userreceive, messages.Usersend);
}

private void init (int id, string subject, string description, ProjectGenNHibernate.EN.Project.UserEN userreceive, ProjectGenNHibernate.EN.Project.UserEN usersend)
{
        this.Id = id;


        this.Subject = subject;

        this.Description = description;

        this.Userreceive = userreceive;

        this.Usersend = usersend;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        MessagesEN t = obj as MessagesEN;
        if (t == null)
                return false;
        if (Id.Equals (t.Id))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Id.GetHashCode ();
        return hash;
}
}
}
