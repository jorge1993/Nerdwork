
using System;

namespace ProjectGenNHibernate.EN.Project
{
public partial class UserEN
{
/**
 *
 */

private string nickname;

/**
 *
 */

private string email;

/**
 *
 */

private string password;

/**
 *
 */

private string name;

/**
 *
 */

private string surname;

/**
 *
 */

private string phone;

/**
 *
 */

private string avatar;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend;

/**
 *
 */

private System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby;





public virtual string Nickname {
        get { return nickname; } set { nickname = value;  }
}


public virtual string Email {
        get { return email; } set { email = value;  }
}


public virtual string Password {
        get { return password; } set { password = value;  }
}


public virtual string Name {
        get { return name; } set { name = value;  }
}


public virtual string Surname {
        get { return surname; } set { surname = value;  }
}


public virtual string Phone {
        get { return phone; } set { phone = value;  }
}


public virtual string Avatar {
        get { return avatar; } set { avatar = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> Messagesreceive {
        get { return messagesreceive; } set { messagesreceive = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> Post {
        get { return post; } set { post = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> Messagessend {
        get { return messagessend; } set { messagessend = value;  }
}


public virtual System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> Hobby {
        get { return hobby; } set { hobby = value;  }
}





public UserEN()
{
        messagesreceive = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
        post = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.PostEN>();
        messagessend = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.MessagesEN>();
        hobby = new System.Collections.Generic.List<ProjectGenNHibernate.EN.Project.HobbyEN>();
}



public UserEN(string nickname, string email, string password, string name, string surname, string phone, string avatar, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby)
{
        this.init (nickname, email, password, name, surname, phone, avatar, messagesreceive, post, messagessend, hobby);
}


public UserEN(UserEN user)
{
        this.init (user.Nickname, user.Email, user.Password, user.Name, user.Surname, user.Phone, user.Avatar, user.Messagesreceive, user.Post, user.Messagessend, user.Hobby);
}

private void init (string nickname, string email, string password, string name, string surname, string phone, string avatar, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagesreceive, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.PostEN> post, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.MessagesEN> messagessend, System.Collections.Generic.IList<ProjectGenNHibernate.EN.Project.HobbyEN> hobby)
{
        this.Nickname = nickname;


        this.Email = email;

        this.Password = password;

        this.Name = name;

        this.Surname = surname;

        this.Phone = phone;

        this.Avatar = avatar;

        this.Messagesreceive = messagesreceive;

        this.Post = post;

        this.Messagessend = messagessend;

        this.Hobby = hobby;
}

public override bool Equals (object obj)
{
        if (obj == null)
                return false;
        UserEN t = obj as UserEN;
        if (t == null)
                return false;
        if (Nickname.Equals (t.Nickname))
                return true;
        else
                return false;
}

public override int GetHashCode ()
{
        int hash = 13;

        hash += this.Nickname.GetHashCode ();
        return hash;
}
}
}
