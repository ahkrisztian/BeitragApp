﻿using BeitragRdr.Models;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public interface IBeitragRepo
    {
        void CreateBeitrag(Beitrag beitrag);
        void DeleteBeitrag(int id);
        IEnumerable<Beitrag> GetAllBeitragsAsync();
        Task<Beitrag> GetBeitragById(int id);

        Task<List<Beitrag>> GetBeitragByUserId(int id);
        void UpdateBeitrag(Beitrag beitrag);
    }
}