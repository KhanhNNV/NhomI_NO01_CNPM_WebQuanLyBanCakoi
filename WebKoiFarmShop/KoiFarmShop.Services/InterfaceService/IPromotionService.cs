﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface IPromotionService
    {
        Task<List<Promotion>> GetAllPromotion();
        Boolean DeletePromotion(int id);
        Boolean DeletePromotion(Promotion promotion);
        Boolean UpdatePromotion(Promotion promotion);
        Boolean AddPromotion(Promotion promotion);
        Task<Promotion> GetPromotionById(int id);
    }
}
