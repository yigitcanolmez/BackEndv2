﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Entity.Concrete
{
    public class User : IEntity
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Email { get; set; }
        public bool  status { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
    }
}