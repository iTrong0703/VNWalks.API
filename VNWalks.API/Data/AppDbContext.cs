using Microsoft.EntityFrameworkCore;
using VNWalks.API.Models.Domain;

namespace VNWalks.API.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Difficulty> Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            var difficulties = new List<Difficulty>()
            {
                new Difficulty()
                {
                    Id = Guid.Parse("752498e4-2f26-43a0-a7ab-bb80786b656b"),
                    Name = "Easy"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("4267ac23-8ac0-4d8a-9a8c-50abd5e1b57b"),
                    Name = "Medium"
                },
                new Difficulty()
                {
                    Id = Guid.Parse("ff05d366-448d-4a90-8a63-4974055a1daf"),
                    Name = "Hard"
                }
            };
            var regions = new List<Region>()
            {
                new Region()
                {
                    Id = Guid.Parse("d5ee681a-5fd0-4d27-997b-635c62d615d8"),
                    Code = "HN",
                    Name = "Hà Nội",
                    RegionImageUrl = "https://example.com/images/ha-noi.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("b7211821-39ce-4f38-8c7c-26cee55c3f98"),
                    Code = "HCM",
                    Name = "Hồ Chí Minh",
                    RegionImageUrl = "https://example.com/images/ho-chi-minh.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("b4036a50-eb15-4ffd-832c-f32f1aa5a1d5"),
                    Code = "DN",
                    Name = "Đà Nẵng",
                    RegionImageUrl = "https://example.com/images/da-nang.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("c5cf1405-b511-4f93-8693-7bc7dd4ff5ee"),
                    Code = "HP",
                    Name = "Hải Phòng",
                    RegionImageUrl = "https://example.com/images/hai-phong.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("afce7fa8-e4fa-4780-84bd-f5dbfcd28c45"),
                    Code = "QN",
                    Name = "Quảng Ninh",
                    RegionImageUrl = "https://example.com/images/quang-ninh.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("95e8a2c6-c877-4d0b-9ecb-5d8a32106e24"),
                    Code = "DL",
                    Name = "Đà Lạt",
                    RegionImageUrl = "https://example.com/images/da-lat.jpg"
                },
                new Region()
                {
                    Id = Guid.Parse("3018c7a0-5dbb-49be-a722-f076d6987492"),
                    Code = "VT",
                    Name = "Vũng Tàu",
                    RegionImageUrl = "https://example.com/images/vung-tau.jpg"
                }
            };
            modelBuilder.Entity<Difficulty>().HasData(difficulties);
            modelBuilder.Entity<Region>().HasData(regions);
        }
    }
}
