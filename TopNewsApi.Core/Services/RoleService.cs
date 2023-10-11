using Ardalis.Specification;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopNewsApi.Core.Interfaces;

namespace TopNewsApi.Core.Services
{
    public class RoleService
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<IdentityRole>> GetAll()
        {
            List<IdentityRole> roles = await _roleManager.Roles.ToListAsync();
            return roles;
        }

        public async Task Insert(IdentityRole entity)
        {
            throw new NotImplementedException();
        }

        public async Task Save()
        {
            throw new NotImplementedException();
        }

        public async Task Update(IdentityRole ententityToUpdate)
        {
            throw new NotImplementedException();
        }
    }
}
