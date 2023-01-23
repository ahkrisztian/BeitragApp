﻿using BeitragRdr.DTOs;

namespace BeitragRdrBlazorServerApp.Data
{
    public interface IHttpDataAccess
    {
        Task<IEnumerable<BeitragDTO>> Beitrags();

        Task<BeitragDTO> BeitragById(int id);

        Task<BeitragDTO> CreateBeitrag(CreateBeitragDTO createBeitragDTO);
    }
}