using IP_BusinessLayer.MockBackEnd;
using System;
using System.Collections.Generic;
using System.Text;

namespace IP_BusinessLayer.ExampleDBModel
{
    public class User
    {
        public int UserId { get; set; }
        public string UserName { get; set; }

        public override string ToString()
        {
            return $"{UserId} {UserName}";
        }
    }
}
