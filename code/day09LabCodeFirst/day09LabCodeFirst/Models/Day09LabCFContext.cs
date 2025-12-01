using Microsoft.EntityFrameworkCore;
using System.Data.Common;

namespace day09LabCodeFirst.Models
{
    public class Day09LabCFContext: DbContext
    {
        public Day09LabCFContext(DbContextOptions<Day09LabCFContext> options): base(options) { }

        public DbSet<LttLoaiSanPham> LttLoaiSanPhams { get; set; }
        public DbSet<LttSanPham> LttSanPhams { get; set; }
    }
}
