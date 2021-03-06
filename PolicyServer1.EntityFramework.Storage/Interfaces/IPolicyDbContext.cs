﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using PolicyServer1.EntityFramework.Storage.Entities;

namespace PolicyServer1.EntityFramework.Storage.Interfaces {
    public interface IPolicyDbContext : IDisposable {

        DbSet<Client> Clients { get; set; }
        DbSet<Policy> Policies { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<Role> Roles { get; set; }

        Int32 SaveChanges();
        Task<Int32> SaveChangesAsync();

        IDbContextTransaction BeginTransaction();
        Task<IDbContextTransaction> BeginTransactionAsync();
    }
}
