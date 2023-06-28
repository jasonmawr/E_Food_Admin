using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

#nullable disable

namespace BussinessObject.Models
{
    public partial class E_FoodContext : DbContext
    {
        public E_FoodContext()
        {
        }

        public E_FoodContext(DbContextOptions<E_FoodContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<AccountPayment> AccountPayments { get; set; }
        public virtual DbSet<ActiveCode> ActiveCodes { get; set; }
        public virtual DbSet<Banner> Banners { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Dish> Dishes { get; set; }
        public virtual DbSet<DishCategory> DishCategories { get; set; }
        public virtual DbSet<Menu> Menus { get; set; }
        public virtual DbSet<Notify> Notifies { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethods { get; set; }
        public virtual DbSet<Premium> Premia { get; set; }
        public virtual DbSet<PremiumHi> PremiumHis { get; set; }
        public virtual DbSet<Restaurant> Restaurants { get; set; }
        public virtual DbSet<RestaurantManager> RestaurantManagers { get; set; }
        public virtual DbSet<ReviewOfDish> ReviewOfDishes { get; set; }
        public virtual DbSet<ReviewOfRe> ReviewOfRes { get; set; }
        public virtual DbSet<SendNotify> SendNotifies { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserNotify> UserNotifies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(local);Uid=sa;Pwd=123456;Database=E_Food");
            }
        }

        public string GetConnectionStrings()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
            .AddJsonFile("appsettings.json")
            .Build();
            return configuration.GetConnectionString("DbConnect");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.Email).HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ResManagerId).HasColumnName("Res_manager_id");

                entity.Property(e => e.Role).HasMaxLength(50);

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.ResManager)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.ResManagerId)
                    .HasConstraintName("FK__Account__Res_man__4AB81AF0");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Account__User_id__49C3F6B7");
            });

            modelBuilder.Entity<AccountPayment>(entity =>
            {
                entity.HasKey(e => e.UserPaymentId)
                    .HasName("PK__Account___9622D49FA6EF49DB");

                entity.ToTable("Account_payment");

                entity.Property(e => e.UserPaymentId).HasColumnName("User_payment_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_id");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.AccountPayments)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Account_p__Accou__4D94879B");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.AccountPayments)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Account_p__Payme__4E88ABD4");
            });

            modelBuilder.Entity<ActiveCode>(entity =>
            {
                entity.HasKey(e => e.ActiveId)
                    .HasName("PK__ActiveCo__DDEC275935744587");

                entity.ToTable("ActiveCode");

                entity.Property(e => e.ActiveId).HasColumnName("Active_id");

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Banner>(entity =>
            {
                entity.ToTable("Banner");

                entity.Property(e => e.BannerId).HasColumnName("Banner_id");

                entity.Property(e => e.CreatedTime).HasColumnName("Created_time");

                entity.Property(e => e.Detail).HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.ResManagerId).HasColumnName("Res_manager_id");

                entity.Property(e => e.Title).HasMaxLength(150);

                entity.HasOne(d => d.ResManager)
                    .WithMany(p => p.Banners)
                    .HasForeignKey(d => d.ResManagerId)
                    .HasConstraintName("FK__Banner__Res_mana__5165187F");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.CategoryDescription)
                    .HasMaxLength(150)
                    .HasColumnName("Category_description");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("Category_name");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");
            });

            modelBuilder.Entity<Dish>(entity =>
            {
                entity.ToTable("Dish");

                entity.Property(e => e.DishId).HasColumnName("Dish_id");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.Name).HasMaxLength(150);

                entity.Property(e => e.VoteRating).HasColumnName("Vote_rating");
            });

            modelBuilder.Entity<DishCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Dish_category");

                entity.Property(e => e.CategoryId).HasColumnName("Category_id");

                entity.Property(e => e.DishId).HasColumnName("Dish_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Category)
                    .WithMany()
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK__Dish_cate__Categ__534D60F1");

                entity.HasOne(d => d.Dish)
                    .WithMany()
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__Dish_cate__Dish___5441852A");
            });

            modelBuilder.Entity<Menu>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Menu");

                entity.Property(e => e.DishId).HasColumnName("Dish_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.ResId).HasColumnName("Res_id");

                entity.HasOne(d => d.Dish)
                    .WithMany()
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__Menu__Dish_id__571DF1D5");

                entity.HasOne(d => d.Res)
                    .WithMany()
                    .HasForeignKey(d => d.ResId)
                    .HasConstraintName("FK__Menu__Res_id__5629CD9C");
            });

            modelBuilder.Entity<Notify>(entity =>
            {
                entity.ToTable("Notify");

                entity.Property(e => e.NotifyId).HasColumnName("Notify_id");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.Detail).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.ResId).HasColumnName("Res_id");

                entity.Property(e => e.ToUserId).HasColumnName("To_user_id");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.Notifies)
                    .HasForeignKey(d => d.ResId)
                    .HasConstraintName("FK__Notify__Res_id__59FA5E80");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.ToTable("Payment_method");

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_id");

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(150);
            });

            modelBuilder.Entity<Premium>(entity =>
            {
                entity.ToTable("Premium");

                entity.Property(e => e.PremiumId).HasColumnName("Premium_id");

                entity.Property(e => e.Period).HasMaxLength(50);
            });

            modelBuilder.Entity<PremiumHi>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Premium_his");

                entity.Property(e => e.PremiumId).HasColumnName("Premium_id");

                entity.Property(e => e.TimeEnd).HasColumnName("Time_end");

                entity.Property(e => e.TimeStart).HasColumnName("Time_start");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Premium)
                    .WithMany()
                    .HasForeignKey(d => d.PremiumId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Premium_h__Premi__5BE2A6F2");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Premium_h__User___5CD6CB2B");
            });

            modelBuilder.Entity<Restaurant>(entity =>
            {
                entity.HasKey(e => e.ResId)
                    .HasName("PK__Restaura__11B830DD4B164E48");

                entity.ToTable("Restaurant");

                entity.Property(e => e.ResId).HasColumnName("Res_id");

                entity.Property(e => e.Address).HasMaxLength(150);

                entity.Property(e => e.Description).HasMaxLength(150);

                entity.Property(e => e.District).HasMaxLength(150);

                entity.Property(e => e.Image).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.Lat).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Log).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.OpenTime).HasColumnName("Open_time");

                entity.Property(e => e.VoteRating).HasColumnName("Vote_rating");
            });

            modelBuilder.Entity<RestaurantManager>(entity =>
            {
                entity.HasKey(e => e.ResManagerId)
                    .HasName("PK__Restaura__D6A097CE69A8E942");

                entity.ToTable("Restaurant_Manager");

                entity.Property(e => e.ResManagerId).HasColumnName("Res_manager_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsFixedLength(true);

                entity.Property(e => e.ResId).HasColumnName("Res_id");

                entity.Property(e => e.SendNotifyCount).HasColumnName("Send_notify_count");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.RestaurantManagers)
                    .HasForeignKey(d => d.ResId)
                    .HasConstraintName("FK__Restauran__Res_i__46E78A0C");
            });

            modelBuilder.Entity<ReviewOfDish>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__ReviewOf__F803F2C3286B6578");

                entity.ToTable("ReviewOfDish");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("Review_id");

                entity.Property(e => e.Comment).HasMaxLength(150);

                entity.Property(e => e.DishId).HasColumnName("Dish_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Dish)
                    .WithMany(p => p.ReviewOfDishes)
                    .HasForeignKey(d => d.DishId)
                    .HasConstraintName("FK__ReviewOfD__Dish___60A75C0F");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewOfDishes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReviewOfD__User___5FB337D6");
            });

            modelBuilder.Entity<ReviewOfRe>(entity =>
            {
                entity.HasKey(e => e.ReviewId)
                    .HasName("PK__ReviewOf__F803F2C3811AE711");

                entity.Property(e => e.ReviewId)
                    .ValueGeneratedNever()
                    .HasColumnName("Review_id");

                entity.Property(e => e.Comment).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.ResId).HasColumnName("Res_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Res)
                    .WithMany(p => p.ReviewOfRes)
                    .HasForeignKey(d => d.ResId)
                    .HasConstraintName("FK__ReviewOfR__Res_i__6477ECF3");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewOfRes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__ReviewOfR__User___6383C8BA");
            });

            modelBuilder.Entity<SendNotify>(entity =>
            {
                entity.ToTable("Send_notify");

                entity.Property(e => e.SendNotifyId).HasColumnName("Send_notify_id");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.ToTable("Transaction");

                entity.Property(e => e.TransactionId)
                    .ValueGeneratedNever()
                    .HasColumnName("Transaction_id");

                entity.Property(e => e.AccountId).HasColumnName("Account_id");

                entity.Property(e => e.IsSuccess).HasColumnName("Is_success");

                entity.Property(e => e.Note).HasMaxLength(150);

                entity.Property(e => e.PaymentMethodId).HasColumnName("Payment_method_id");

                entity.Property(e => e.TimeTrans).HasColumnName("Time_trans");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Transacti__Accou__68487DD7");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK__Transacti__Payme__6754599E");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.Property(e => e.Avatar).HasMaxLength(150);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.IsPremium).HasColumnName("Is_premium");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<UserNotify>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("UserNotify");

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.NotifyId).HasColumnName("Notify_id");

                entity.Property(e => e.UserId).HasColumnName("User_id");

                entity.HasOne(d => d.Notify)
                    .WithMany()
                    .HasForeignKey(d => d.NotifyId)
                    .HasConstraintName("FK__UserNotif__Notif__6B24EA82");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__UserNotif__User___6A30C649");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
