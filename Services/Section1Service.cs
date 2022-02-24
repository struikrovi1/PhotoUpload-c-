using DataAccess;
using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class Section1Service
    {
        private readonly AgencyContext _context;

        public Section1Service(AgencyContext context)
        {
            _context = context;
        }
        public async Task<List<Section1>> GetAll()
        {
            return await _context.Section1s.ToListAsync();
        }
        public async Task<Section1?> GetById(int? id)
        {
            return await _context.Section1s.FindAsync(id);
        }

        public async Task Add(Section1 sec)
        {
            _context.Section1s.Add(sec);
           await _context.SaveChangesAsync();
        }
        public async Task Update(Section1 sec)
        {
            _context.Section1s.Update(sec);
           await _context.SaveChangesAsync();
        }

        public async Task Remove(int? id)
        {
           var selectedSection= await GetById(id);
            _context.Remove(selectedSection);
            await _context.SaveChangesAsync();
        }

    }
}
