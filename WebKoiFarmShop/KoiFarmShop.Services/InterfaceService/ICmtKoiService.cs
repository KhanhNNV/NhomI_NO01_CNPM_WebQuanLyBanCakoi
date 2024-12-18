﻿using KoiFarmShop.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.InterfaceService
{
    public interface ICmtKoiService
    {
        Task<List<CommentKoi>> GetAllCmtKoi();
        Boolean DelCmtKoi(int Id);
        Boolean DelCmtKoi(CommentKoi cmtKoi);
        Boolean AddCmtKoi(CommentKoi cmtKoi);
        Boolean UpCmtKoi(CommentKoi cmtKoi);
        Task<CommentKoi> GetCmtKoiById(int Id);
    }
}
