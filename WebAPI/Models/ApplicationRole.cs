﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Models
{
    /// Роль пользователя 
    public class ApplicationRole : IdentityRole
    {
        /// Описание роли
        public string Description { get; set; }
    }
}
