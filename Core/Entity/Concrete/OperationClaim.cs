﻿using Core.Entity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entity.Concrete
{
    public class OperationClaim  : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
