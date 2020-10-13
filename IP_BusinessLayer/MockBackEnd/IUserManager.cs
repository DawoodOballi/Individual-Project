using IP_BusinessLayer.ExampleDBModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer.MockBackEnd
{
    interface IUserManager
    {
        void AddUser(User item);
        User FindUser(string name);
        void RemoveUser(string name);
        void CreateUsers(List<User> items);
    }
}
