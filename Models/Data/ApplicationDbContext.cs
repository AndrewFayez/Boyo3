using BYO3WebAPI.Models.DataModel.OTPModel;
using BYO3WebAPI.Models.DataModels.AdsPackageModels;
using BYO3WebAPI.Models.DataModels.DillsModel;
using BYO3WebAPI.Models.DataModels.PackageModels;
using BYO3WebAPI.Models.DataModels.PostModel;
using BYO3WebAPI.Models.DataModels.Products;
using BYO3WebAPI.Models.DataModels.ServiceModel;
using BYO3WebAPI.Models.DataModels.ServicePackageModel;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BYO3WebAPI.Models.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {

        }
        public DbSet<OTPEmailModel> OTPEmail { get; set; }
        public DbSet<AdsModel> Ads { get; set; }
        public DbSet<UserAds> UserAds { get; set; }

        public DbSet<NewsModel> News { get; set; }
        public DbSet<UserNews> UserNews { get; set; }

        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }

        public DbSet<ServiceModels> Service { get; set; }
        public DbSet<UserService> UserService { get; set; }

        public DbSet<AdsPackageModel> Package { get; set; }
        public DbSet<UserAdsPackage> UserPackage { get; set; }

        public DbSet<ServicePackageModel> ServicePackage { get; set; }
        public DbSet<UserServicePackage> UserServicePackage { get; set; }
        public DbSet<AdsForPackage> AdsForPackage { get; set; }
        public DbSet<ServiceForPackage> ServiceForPackage { get; set; }
       



        public DbSet<BillModel> Bill { get; set; }
        public DbSet<UserBills> UserBills { get; set; }
        public DbSet<BillProducts> BillProducts { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>()
              .HasKey(u => new {
                  u.Id
              });

            ///////////////////////////////////////AdsModel
            builder.Entity<AdsModel>()
              .HasKey(p => new {
                  p.Id
              });

            builder.Entity<UserAds>()
              .HasKey(up => new {
                  up.UserId,
                  up.AdsId
              });

            builder.Entity<UserAds>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserAds)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<UserAds>()
              .HasOne(up => up.Ads)
              .WithMany(p => p.UserAds)
              .HasForeignKey(p => p.AdsId)
              .OnDelete(DeleteBehavior.NoAction);


            ///////////////////////////////////////ServiceModel
            builder.Entity<ServiceModels>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<UserService>()
              .HasKey(up => new {
                  up.UserId,
                  up.ServiceId
              });

            builder.Entity<UserService>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserService)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<UserService>()
              .HasOne(up => up.Service)
              .WithMany(p => p.UserService)
              .HasForeignKey(p => p.ServiceId)
              .OnDelete(DeleteBehavior.NoAction); ;

            /////////////////////////////////////////PackageModel
            builder.Entity<AdsPackageModel>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<UserAdsPackage>()
              .HasKey(up => new {
                  up.UserId,
                  up.PackageId
              });

            builder.Entity<UserAdsPackage>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserPackage)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction); 

            builder.Entity<UserAdsPackage>()
              .HasOne(up => up.Package)
              .WithMany(p => p.UserAdsPackage)
              .HasForeignKey(p => p.PackageId)
              .OnDelete(DeleteBehavior.NoAction); 

            ////////////////////////////////////////////////userProduct
            builder.Entity<ProductModel>()
            .HasKey(p => new {
                p.Id
            });

            builder.Entity<UserProduct>()
              .HasKey(up => new {
                  up.UserId,
                  up.ProductId
              });

            builder.Entity<UserProduct>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserProduct)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<UserProduct>()
              .HasOne(up => up.Product)
              .WithMany(p => p.UserProduct)
              .HasForeignKey(p => p.ProductId)
              .OnDelete(DeleteBehavior.NoAction); ;


            ////////////////////////////////////////////servicePackage
            ///

            builder.Entity<ServicePackageModel>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<UserServicePackage>()
              .HasKey(up => new {
                  up.UserId,
                  up.PackageId
              });

            builder.Entity<UserServicePackage>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserservicePackage)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.Entity<UserServicePackage>()
              .HasOne(up => up.Package)
              .WithMany(p => p.UserservicePackage)
              .HasForeignKey(p => p.PackageId)
              .OnDelete(DeleteBehavior.NoAction);


            ///////////////////////////////////////NewsModel
            builder.Entity<NewsModel>()
              .HasKey(p => new {
                  p.Id
              });

            builder.Entity<UserNews>()
              .HasKey(up => new {
                  up.UserId,
                  up.NewsId
              });

            builder.Entity<UserNews>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserNews)
              .HasForeignKey(u => u.UserId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<UserNews>()
              .HasOne(up => up.news)
              .WithMany(p => p.UserNews)
              .HasForeignKey(p => p.NewsId)
              .OnDelete(DeleteBehavior.NoAction);


            ///////////////////////////////////////////Billing
            builder.Entity<BillModel>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<UserBills>()
              .HasKey(up => new {
                  up.UserId,
                  up.BillId
              });

            builder.Entity<UserBills>()
              .HasOne(up => up.User)
              .WithMany(u => u.UserBills)
              .HasForeignKey(u => u.UserId) 
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<UserBills>()
              .HasOne(up => up.Bill)
              .WithMany(p => p.UserBills)
              .HasForeignKey(p => p.BillId)
              .OnDelete(DeleteBehavior.NoAction);

            ///////////////////////////////////

            builder.Entity<BillModel>()
            .HasKey(p => new {
                p.Id
            });

            builder.Entity<BillProducts>()
              .HasKey(up => new {
                  up.ProductId,
                  up.BillId
              });

            builder.Entity<BillProducts>()
              .HasOne(up => up.Bill)
              .WithMany(u => u.BillProducts)
              .HasForeignKey(u => u.BillId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<BillProducts>()
              .HasOne(up => up.Product)
              .WithMany(p => p.BillProducts)
              .HasForeignKey(p => p.ProductId)
              .OnDelete(DeleteBehavior.NoAction);

            //////////////////////////////////////////////////////AdsPackage
            builder.Entity<AdsModel>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<AdsForPackage>()
              .HasKey(up => new {
                  up.PackageId,
                  up.AdsId
              });

            builder.Entity<AdsForPackage>()
              .HasOne(up => up.Package)
              .WithMany(u => u.AdsForPackages)
              .HasForeignKey(u => u.PackageId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<AdsForPackage>()
              .HasOne(up => up.Ads)
              .WithMany(p => p.AdsForPackages)
              .HasForeignKey(p => p.AdsId)
              .OnDelete(DeleteBehavior.NoAction);

            /////////////////////////////////////////////////////////////
            builder.Entity<ServiceModels>()
             .HasKey(p => new {
                 p.Id
             });

            builder.Entity<ServiceForPackage>()
              .HasKey(up => new {
                  up.ServiceId,
                  up.ServicePackageId
              });

            builder.Entity<ServiceForPackage>()
              .HasOne(up => up.ServicePackage)
              .WithMany(u => u.ServiceForPackage)
              .HasForeignKey(u => u.ServicePackageId)
               .OnDelete(DeleteBehavior.NoAction); ;

            builder.Entity<ServiceForPackage>()
              .HasOne(up => up.Service)
              .WithMany(p => p.ServiceForPackage)
              .HasForeignKey(p => p.ServiceId)
              .OnDelete(DeleteBehavior.NoAction);
        }




    }
}
