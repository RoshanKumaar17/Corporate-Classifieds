using System;
using System.Collections;
using System.Collections.Generic;
using AuthorizeModule.Models;

namespace AuthorizeModule.Repository
{
    public interface IAuthRepo
    {
        public List<User> Users();
    }
}
