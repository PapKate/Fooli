using Microsoft.EntityFrameworkCore;

namespace Fooli
{
    /// <summary>
    /// Represents the database structure
    /// </summary>
    public class FooliDBContext : DbContext
    {
        #region Public Properties

        /// <summary>
        /// The users
        /// </summary>
        public DbSet<UserEntity> Users { get; set; }

        /// <summary>
        /// The companies
        /// </summary>
        public DbSet<CompanyEntity> Companies { get; set; }

        /// <summary>
        /// The branches
        /// </summary>
        public DbSet<BranchEntity> Branches { get; set; }

        /// <summary>
        /// The company's products
        /// </summary>
        public DbSet<CompanyProductEntity> CompanyProducts { get; set; }

        /// <summary>
        /// The price per measurement unit pairs
        /// </summary>
        public DbSet<PricePerMeasurementUnitEntity> PricePerMeasurementUnits { get; set; }

        /// <summary>
        /// The products
        /// </summary>
        public DbSet<ProductEntity> Products { get; set; }

        /// <summary>
        /// The categories
        /// </summary>
        public DbSet<CategoryEntity> Categories { get; set; }

        /// <summary>
        /// The products categories pairs
        /// </summary>
        public DbSet<ProductCategoryEntity> ProductCategories { get; set; }

        /// <summary>
        /// The product label pairs
        /// </summary>
        public DbSet<ProductLabelEntity> ProductLabels { get; set; }

        /// <summary>
        /// The leaflets
        /// </summary>
        public DbSet<LeafletEntity> Leaflets { get; set; }

        /// <summary>
        /// The images
        /// </summary>
        public DbSet<ImageEntity> Images { get; set; }

        /// <summary>
        /// The labels
        /// </summary>
        public DbSet<LabelEntity> Labels { get; set; }

        /// <summary>
        /// The note lists
        /// </summary>
        public DbSet<NoteEntity> Notes { get; set; }

        /// <summary>
        /// The list items
        /// </summary>
        public DbSet<CheckListItemEntity> CheckListItems { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="options">The options</param>
        public FooliDBContext(DbContextOptions<FooliDBContext> options) : base(options)
        {
        }

        #endregion

        #region Protected Methods

        /// <summary>
        /// Override this method to further configure the model that was discovered by convention
        /// from the entity types exposed in <see cref="DbSet{TEntity}"/> properties
        /// on your derived context. The resulting model may be cached and re-used for subsequent
        /// instances of your derived context.
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Notes

            modelBuilder.Entity<NoteEntity>()
                .HasMany(x => x.CheckListItems)
                .WithOne(x => x.Note)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.NoteId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Companies

            // For the leaflets of a company...
            modelBuilder.Entity<CompanyEntity>()
                // One company has many leaflets
                .HasMany(x => x.Leaflets)
                // Each leaflet has one company
                .WithOne(x => x.Company)
                // The principal key of the join is the Company.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the Leaflet.CompanyId
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            // For the images of a company...
            modelBuilder.Entity<CompanyEntity>()
                // A company has many images
                .HasMany(x => x.Images)
                // An image has one company
                .WithOne(x => x.Company)
                // The principal key of the join is the Company.Id
                .HasPrincipalKey(x => x.Id)
                // The foreign key of the join is the Image.CompanyId
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyEntity>()
                .HasMany(x => x.Branches)
                .WithOne(x => x.Company)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Products

            modelBuilder.Entity<ProductEntity>()
                .HasMany(x => x.Images)
                .WithOne(x => x.Product)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region CompanyProductPairs

            modelBuilder.Entity<CompanyProductEntity>()
                .HasOne(x => x.Company)
                .WithMany(x => x.CompayProducts)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyProductEntity>()
               .HasOne(x => x.Product)
               .WithMany(x => x.CompanyProducts)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.ProductrId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<CompanyProductEntity>()
                .HasMany(x => x.PricesPerMeasurementUnits)
                .WithOne(x => x.CompanyProduct)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.CompanyProductId)
                .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region Categories

            modelBuilder.Entity<CategoryEntity>()
                .HasMany(x => x.ChildrenCategories)
                .WithOne(x => x.ParentCategory)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ParentCategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion

            #region ProductCategoryPairs

            modelBuilder.Entity<ProductCategoryEntity>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductCategories)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductCategoryEntity>()
               .HasOne(x => x.Category)
               .WithMany(x => x.ProductCategories)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.CategoryId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region ProductLabelPairs

            modelBuilder.Entity<ProductLabelEntity>()
                .HasOne(x => x.Product)
                .WithMany(x => x.ProductLabels)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductLabelEntity>()
             .HasOne(x => x.Label)
             .WithMany(x => x.ProductLabels)
             .HasPrincipalKey(x => x.Id)
             .HasForeignKey(x => x.LabelId)
             .OnDelete(DeleteBehavior.Cascade);

            #endregion

            #region ProductMeasurementPairs

            modelBuilder.Entity<ProductMeasurementUnitEntity>()
                .HasOne(x => x.MeasurementUnit)
                .WithMany(x => x.ProductMeasurementUnits)
                .HasPrincipalKey(x => x.Id)
                .HasForeignKey(x => x.MeasurementUnitId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProductMeasurementUnitEntity>()
               .HasOne(x => x.Product)
               .WithMany(x => x.ProductMeasurementUnits)
               .HasPrincipalKey(x => x.Id)
               .HasForeignKey(x => x.ProductId)
               .OnDelete(DeleteBehavior.Cascade);

            #endregion
        }

        #endregion
    }
}
