﻿using System;
using InventoryManagment.Models.Domains;
using Microsoft.EntityFrameworkCore;

namespace InventoryManagment.DataTypes.Repositories
{
    public class BrandRepository : Repository<Brand>, IBrandRepository
    {
        public BrandRepository(DbContext context) : base(context)
        {

        }
    }
}