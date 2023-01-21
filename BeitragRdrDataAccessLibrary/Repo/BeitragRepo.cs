using BeitragRdr.Models;
using BeitragRdrDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
                .Include(t => t.tags);

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public Task<Beitrag> GetBeitragById(int id)
        {
            context.ChangeTracker.Clear();

            try
            {
                var output = context.Beitrags.Where(i => i.Id == id)
                .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                .Include(t => t.tags).FirstOrDefaultAsync();

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Beitrag>> GetBeitragByUserId(int id)
        {
            try
            {
                var output = context.Beitrags.Where(i => i.CompanyId == id)
                    .Include(c => c.company).ThenInclude(a => a.addresses)
                    .Include(c => c.company).ThenInclude(p => p.phoneNumbers)
                    .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                    .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                    .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                    .Include(t => t.tags).ToList();

                return output;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void CreateBeitrag(Beitrag beitrag)
        {
            if(beitrag == null)
            {
                throw new ArgumentNullException(nameof(beitrag));
            }

            context.Beitrags.Add(beitrag);
            context.SaveChangesAsync();

            //return context.Beitrags.OrderByDescending(s => s.Id).FirstOrDefault().Id;
        }

        public void DeleteBeitrag(int id)
        {
            context.ChangeTracker.Clear();

            Beitrag beigtrag = new Beitrag() { Id = id };
            context.Beitrags.Attach(beigtrag);
            context.Beitrags.Remove(beigtrag);
            context.SaveChangesAsync();
        }

        public void UpdateBeitrag(Beitrag beitrag)
        {
            context.ChangeTracker.Clear();

            context.Update(beitrag);
            context.SaveChangesAsync();
        }

    }
}
