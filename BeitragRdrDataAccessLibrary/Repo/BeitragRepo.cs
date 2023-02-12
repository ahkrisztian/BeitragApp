using BeitragRdr.DTOs.CompanyDTOs;
using BeitragRdr.Models;
using BeitragRdr.Models.CompanyModel;
using BeitragRdr.Models.SubModels;
using BeitragRdrDataAccessLibrary.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BeitragRdrDataAccessLibrary.Repo
{
    public class BeitragRepo : IBeitragRepo
    {
        private readonly AppDbContext context;

        public BeitragRepo(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Beitrag>> GetAllBeitragsAsync()
        {
            try
            {
                var output = await context.Beitrags
                .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                .Include(t => t.tags).ToListAsync();

                return output;
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        public async Task<Beitrag> GetBeitragById(int id)
        {
            context.ChangeTracker.Clear();

            try
            {
                var output = await context.Beitrags.Where(i => i.Id == id)
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
                var output = await context.Beitrags.Where(i => i.CompanyId == id)
                    .Include(c => c.company).ThenInclude(a => a.addresses)
                    .Include(c => c.company).ThenInclude(p => p.phoneNumbers)
                    .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                    .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                    .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                    .Include(t => t.tags).ToListAsync();

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

        public async void UpdateBeitrag(Beitrag beitrag)
        {
            context.ChangeTracker.Clear();

            var output = await context.Beitrags.Where(i => i.Id== beitrag.Id)
                .Include(f => f.beitragFace).ThenInclude(i => i.Image)
                .Include(p => p.beitragPintr).ThenInclude(i => i.Image)
                .Include(inst => inst.beitragInsta).ThenInclude(i => i.Image)
                .Include(t => t.tags).FirstOrDefaultAsync();

            foreach (var tag in output.tags)
            {
                context.ChangeTracker.Clear();

                Tags tags = new Tags() { Id = tag.Id };
                context.Tags.Attach(tags);
                context.Tags.Remove(tags);

                await context.SaveChangesAsync();
            }

            if (beitrag.beitragFace is null)
            {
                //context.ChangeTracker.Clear();

                if (context.beitragFaces.Where(i => i.Id == beitrag.Id).FirstOrDefault() is not null)
                {
                    BeitragFace face = new BeitragFace() { Id = beitrag.Id };

                    context.ChangeTracker.Clear();

                    context.beitragFaces.Attach(face);
                    context.beitragFaces.Remove(face);

                    await context.SaveChangesAsync();
                }
            }

            if (beitrag.beitragInsta is null)
            {
                //context.ChangeTracker.Clear();

                if (context.beitragInstas.Where(i => i.Id == beitrag.Id).FirstOrDefault() is not null)
                {
                    BeitragInsta insta = new BeitragInsta() { Id = beitrag.Id };

                    context.ChangeTracker.Clear();

                    context.beitragInstas.Attach(insta);
                    context.beitragInstas.Remove(insta);

                    await context.SaveChangesAsync();
                }

            }

            if (beitrag.beitragPintr is null)
            {
                if (context.beitragPintrs.Where(i => i.Id == beitrag.Id).FirstOrDefault() is not null)
                {
                    //context.ChangeTracker.Clear();

                    BeitragPintr pintr = new BeitragPintr() { Id = beitrag.Id };

                    context.ChangeTracker.Clear();

                    context.beitragPintrs.Attach(pintr);
                    context.beitragPintrs.Remove(pintr);

                    await context.SaveChangesAsync();
                }
            }

            beitrag.LastModifiedDate= DateTime.UtcNow;

            context.ChangeTracker.Clear();

            context.Beitrags.Update(beitrag);

            await context.SaveChangesAsync();
        }

        public async Task<List<Company>> Companies()
        {
            return await context.companies
                .Include(a => a.addresses)
                .Include(p => p.phoneNumbers).ToListAsync();
        }

    }
}
