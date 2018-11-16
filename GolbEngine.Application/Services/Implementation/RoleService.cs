using GolbEngine.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using GolbEngine.Application.ViewModels.System;
using GolbEngine.Utilities.DTOs;
using System.Threading.Tasks;
using GolbEngine.Data.Entities;
using Microsoft.AspNetCore.Identity;
using GolbEngine.Infrastructure.Interfaces;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace GolbEngine.Application.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private RoleManager<AppRole> _roleManager;
        private IUnitOfWork _unitOfWork;

        public RoleService(RoleManager<AppRole> roleManager, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _roleManager = roleManager;
        }

        public Task<bool> AddAsync(AppRoleViewModel userVm)
        {
            throw new NotImplementedException();
        }

        public Task<bool> CheckPermission(string functionId, string action, string[] roles)
        {
            var query = from role in _roleManager.Roles
                        select role;

            return query.AnyAsync();
        }

        public Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppRoleViewModel>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public PagedResult<AppRoleViewModel> GetAllPagingAsync(string keyword, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public Task<AppRoleViewModel> GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<PermissionViewModel> GetListFunctionWithRole(Guid roleId)
        {
            throw new NotImplementedException();
        }

        public void SavePermission(List<PermissionViewModel> permissions, Guid roleId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(AppRoleViewModel userVm)
        {
            throw new NotImplementedException();
        }
    }
}
