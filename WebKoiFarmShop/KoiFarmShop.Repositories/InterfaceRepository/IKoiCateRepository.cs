﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Repositories.InterfaceRepository
{
    public interface IKoiCateRepository
    {
        Task<List<KoiCategory>> GetAllKoiCate();
        Boolean DeleteKoiCate(int id);
        Boolean DeleteKoiCate(KoiCategory koiCategory);
        Boolean UpdateKoiCate(KoiCategory koiCategory);
        Boolean AddKoiCate(KoiCategory koiCategory);
        Task<KoiCategory> GetKoiCateById(int id);
    }
}