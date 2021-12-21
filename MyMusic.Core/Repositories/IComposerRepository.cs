﻿using MyMusic.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMusic.Core.Repositories
{
    public  interface IComposerRepository
    {
        Task<IEnumerable<Composer>> GetAllComposers();
        Task<Composer> GetComposerById(string id);
        Task<Composer> Create(Composer composer);
        Task<bool> Delete(string id);
        void Update(string id, Composer composer);
    }
}
