﻿using BeitragRdr.Models;
using BeitragRdrDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public class BeitragRepo : IBeitragRepo
    {
        private readonly AppDbContext context;

        public BeitragRepo(AppDbContext context)
        {
            this.context = context;
        }

        public IEnumerable<Beitrag> GetAllBeitragsAsync()
        {
            try
            {
                var output = context.Beitrags
                .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                .Include(t => t.tags).ThenInclude(x => x.Tags);

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Beitrag> GetBeitragById(int id)
        {
            try
            {
                var output = context.Beitrags
                .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                .Include(t => t.tags).ThenInclude(x => x.Tags).FirstOrDefaultAsync();

                return await output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateBeitrag(Beitrag beitrag)
        {
            context.Beitrags.Add(beitrag);
            context.SaveChangesAsync();
        }

        public void DeleteBeitrag(int id)
        {
            Beitrag beigtrag = new Beitrag() { Id = id };
            context.Beitrags.Attach(beigtrag);
            context.Beitrags.Remove(beigtrag);
            context.SaveChangesAsync();
        }

        public void UpdateBeitrag(int id)
        {
            context.Update(id);
            context.SaveChangesAsync();
        }

    }
}
