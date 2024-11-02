using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.InterfaceRepository;
using KoiFarmShop.Services.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IPermissionReposirory _permissionReposirory;
        public PermissionService(IPermissionReposirory permissionReposiror)
        {
            _permissionReposirory = permissionReposiror;
        }
        public bool AddPermission(Permission permission)
        {
            return _permissionReposirory.AddPermission(permission);
        }

        public bool DeletePermission(int id)
        {
            return _permissionReposirory.DeletePermission(id);
        }

        public bool DeletePermission(Permission permission)
        {
            return _permissionReposirory.DeletePermission(permission);
        }

        public Task<List<Permission>> GetAllPermission()
        {
            return _permissionReposirory.GetAllPermission();
        }

        public Task<Permission> GetPermissionById(int id)
        {
            return _permissionReposirory.GetPermissionById(id);
        }

        public bool UpdatePermission(Permission permission)
        {
            return _permissionReposirory.UpdatePermission(permission);
        }
    }
}
