using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fooli
{
    /// <summary>
    /// The entry point
    /// </summary>
    public class EntryPoint
    {
        #region Constructors

        /// <summary>
        /// Default constructor
        /// </summary>
        public EntryPoint()
        {

        }

        #endregion

        #region Public Methods

        /// <summary>
        /// 
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public static async Task SetUpAsync(FooliDBContext context)
        {
            var result = await context.Database.EnsureCreatedAsync();

            // If the database exists...
            if (result == false)
                return;

            #region Users

            context.Users.AddRange(new List<UserEntity>()
            {
                new UserEntity()
                {
                    FirstName = "Katherine",
                    LastName = "Papa",
                    Username = "PapKate",
                    Email = "papkate@gmail.com",
                    Password = "1234t",
                    PictureUrl = "https://i.natgeofe.com/n/9135ca87-0115-4a22-8caf-d1bdef97a814/75552.jpg?w=636&h=424",
                    Type = UserType.Admin,
                    Gender = Gender.Female,
                    Country = "Greece",
                    City = "Patras",
                    Address1 = "Zakunthou 35",
                    PostalCode = "26441"
                },
                new UserEntity()
                {
                    FirstName = "Jim",
                    LastName = "MoneyRoots",
                    Username = "Jim",
                    Email = "jim@saves.com",
                    Password = "1234t",
                    PictureUrl = "https://www.alleycat.org/wp-content/uploads/2021/02/344x361_FoundACat.jpg",
                    Type = UserType.Customer,
                    Gender = Gender.Male,
                    Country = "Greece",
                    City = "Patras",
                    Address1 = "Pantanasi 5",
                },
                new UserEntity()
                {
                    FirstName = "Labros",
                    LastName = "Papadopoulos",
                    Username = "PapLabros",
                    Email = "paplabros@gmail.com",
                    Password = "1234t",
                    PictureUrl = "http://i.imgur.com/Bhx5sV5.jpg",
                    Type = UserType.Owner,
                    Gender = Gender.Male,
                    Country = "Greece",
                    City = "Patras",
                    Address1 = "Zakunthou 35",
                    PostalCode = "26441"
                },
            });

            await context.SaveChangesAsync();

            #endregion

            #region Notes

            context.Notes.AddRange(new List<NoteEntity>()
            { 
                new NoteEntity()
                {
                    Title  = "Ψώνια Δευτέρας",
                    Text  = "Drosera",
                    Color  = "223344",
                    UserId  = 1,
                },
                new NoteEntity()
                {
                    Title  = "Ψώνια Δευτέρας",
                    Text  = "Drosera",
                    Color  = "223344",
                    UserId  = 3,
                },
                new NoteEntity()
                {
                    Title  = "Ψώνια Δευτέρας",
                    Text  = "Drosera",
                    Color  = "223344",
                    UserId  = 2,
                },
                new NoteEntity()
                {
                    Title  = "Ψώνια Δευτέρας",
                    Text  = "Drosera",
                    Color  = "223344",
                    UserId  = 1,
                },
                new NoteEntity()
                {
                    Title  = "Ψώνια Δευτέρας",
                    Text  = "Drosera",
                    Color  = "223344",
                    UserId  = 3,
                }
            });

            await context.SaveChangesAsync();

            #region Check List Items

            context.CheckListItems.AddRange(new List<CheckListItemEntity>()
            { 
                new CheckListItemEntity()
                {
                    Text = "Πατάτες",
                    NoteId = 1
                },
                new CheckListItemEntity()
                {
                    Text = "Ντομάτες",
                    NoteId = 1
                },
                new CheckListItemEntity()
                {
                    Text = "Καρότα",
                    NoteId = 1
                },
                new CheckListItemEntity()
                {
                    Text = "Κρεμμύδια κόκκινα",
                    NoteId = 2
                },
                new CheckListItemEntity()
                {
                    Text = "Σοκολάτα",
                    NoteId = 2
                },
                new CheckListItemEntity()
                {
                    Text = "Αβοκάντο",
                    NoteId = 3
                },
                new CheckListItemEntity()
                {
                    Text = "Λεμόνια",
                    NoteId = 4
                },
                new CheckListItemEntity()
                {
                    Text = "Πορτοκάλια",
                    NoteId = 5
                },
                new CheckListItemEntity()
                {
                    Text = "Αμύγδαλα",
                    NoteId = 5
                },
                new CheckListItemEntity()
                {
                    Text = "Καλαμπόκι",
                    NoteId = 5
                },
                new CheckListItemEntity()
                {
                    Text = "Φράουλες",
                    NoteId = 3
                }
            });

            await context.SaveChangesAsync();

            #endregion

            #endregion

            #region Companies

            // Creates a new range of company entities
            context.Companies.AddRange(new List<CompanyEntity>() 
            {
                new CompanyEntity()
                {
                    Name = "L.I.D.L."
                },
                new CompanyEntity()
                {
                    Name = "Σκλαβενίτης",
                },
                new CompanyEntity()
                {
                    Name = "MyMarket",
                }
            });

            await context.SaveChangesAsync();

            #region Branches

            context.Branches.AddRange(new List<BranchEntity>() 
            {
                new BranchEntity()
                {
                    Country = "Ελλάδα",
                    City = "Αλεξάνδεια",
                    Address = "Εθνική Οδός Αλεξάνδρειας - Κοζάνης 1km",
                    PhoneNumber = "8001113333",
                    CompanyId = 1
                },
                new BranchEntity()
                {
                    Country = "Ελλάδα",
                    City = "Πάτρα",
                    Address = "Νοτάρα 9",
                    PhoneNumber = "8001113333",
                    PostalCode = "26440",
                    CompanyId = 1
                },
                new BranchEntity()
                {
                    Country = "Ελλάδα",
                    City = "Πάτρα",
                    Address = "Έλληνος Στρατιώτου 51",
                    PhoneNumber = "",
                    CompanyId = 2
                },
                new BranchEntity()
                {
                    Country = "Ελλάδα",
                    City = "Πάτρα",
                    Address = "Λεωφόρος Αγ. Σοφίας 1",
                    PhoneNumber = "",
                    PostalCode = "26441",
                    CompanyId = 3
                }
            });

            await context.SaveChangesAsync();

            #endregion

            #region Company Images

            // Adds company images
            context.Images.AddRange(new List<ImageEntity>()
            {
                new ImageEntity()
                {
                    Name = "L.I.D.L. logo square",
                    Source = "https://zahramediagroup.com/wp-content/uploads/2020/06/lidl-test-logo.png",
                    Alt = "lidl logo",
                    CompanyId = 1
                },
                new ImageEntity()
                {
                    Name = "L.I.D.L. logo rectangle",
                    Source = "https://www.kindpng.com/picc/m/784-7842934_lidl-logo-logo-lidl-hd-png-download.png",
                    Alt = "lidl logo",
                    CompanyId = 1
                },
                new ImageEntity()
                {
                    Name = "L.I.D.L. logo square",
                    Source = "https://zahramediagroup.com/wp-content/uploads/2020/06/lidl-test-logo.png",
                    Alt = "lidl logo",
                    CompanyId = 2
                },
                new ImageEntity()
                {
                    Name = "L.I.D.L. logo rectangle",
                    Source = "https://www.kindpng.com/picc/m/784-7842934_lidl-logo-logo-lidl-hd-png-download.png",
                    Alt = "lidl logo",
                    CompanyId = 2
                },
                new ImageEntity()
                {
                    Name = "Sklavenitis logo square",
                    Source = "https://i.pinimg.com/736x/a1/40/2c/a1402c47e834153e9df831db2e84001b.jpg",
                    Alt = "Sklavenitis logo",
                    CompanyId = 3
                },
                new ImageEntity()
                {
                    Name = "Sklavenitis logo rectangle",
                    Source = "https://m.naftemporiki.gr/thumb/1337655/1200/1200/0x00000000013b62ea/1/sklabenitis-logotupo.jpg",
                    Alt = "Sklavenitis logo",
                    CompanyId = 3
                },
                new ImageEntity()
                {
                    Name = "My Market logo square",
                    Source = "https://www.artopoulospites.gr/wp-content/uploads/2020/12/mymarket-logo.jpg",
                    Alt = "My Market logo",
                    CompanyId = 4
                },
                new ImageEntity()
                {
                    Name = "My Market logo rectangle",
                    Source = "https://i.pinimg.com/originals/af/60/f7/af60f77a88254ca86e74b131c52b6da8.jpg",
                    Alt = "My Market logo",
                    CompanyId = 4
                }
            });

            // Save the changes
            await context.SaveChangesAsync();

            #endregion

            #region Company Leaflets

            context.Leaflets.AddRange(new List<LeafletEntity>() 
            {
                new LeafletEntity()
                {
                    Name = "Φυλλάδιο Lidl - Non Food",
                    Url = "https://www.lidl-hellas.gr/el/fyladia/apo-deutera-12-04-phulladio-lidl-food/view/jumpmarks/page/1",
                    DateStart = DateTime.Parse("11/28/2021"),
                    DateEnd = DateTime.Parse("12/04/2021"),
                    CompanyId = 1
                },
                new LeafletEntity()
                {
                    Name = "Φυλλάδιο Lidl - Food",
                    Url = "https://www.lidl-hellas.gr/el/fyladia/apo-deutera-12-04-phulladio-lidl-non-food/view/jumpmarks/page/1",
                    DateStart = DateTime.Parse("11/28/2021"),
                    DateEnd = DateTime.Parse("12/04/2021"),
                    CompanyId = 1
                },
                new LeafletEntity()
                {
                    Name = "MyMarket Φυλλάδιο",
                    Url = "https://eshop.mymarket.gr/fylladio-prosforon-my-market",
                    DateStart = DateTime.Parse("11/28/2021"),
                    DateEnd = DateTime.Parse("12/04/2021"),
                    CompanyId = 4
                }
            });

            // Save the changes
            await context.SaveChangesAsync();

            #endregion

            #endregion

            #region Company Products

            context.CompanyProducts.AddRange(new List<CompanyProductEntity>() 
            {
                new CompanyProductEntity()
                {
                    Name = "Καρότα Ελληνικά Χύμα",
                    IsOnSale = false,
                    DateOnSaleFrom = DateTime.Parse("11/18/2021"),
                    DateOnSaleTo = DateTime.Parse("11/28/2021"),
                    StockQuantity = 876,
                    IsPurchasable = true,
                    IsVerified = true,
                    CompanyId = 1
                },
                new CompanyProductEntity()
                {
                    Name = "Καρότα Ελληνικά Χύμα",
                    IsOnSale = false,
                    DateOnSaleFrom = DateTime.Parse("11/18/2021"),
                    DateOnSaleTo = DateTime.Parse("11/28/2021"),
                    StockQuantity = 657,
                    IsPurchasable = true,
                    IsVerified = true,
                    CompanyId = 2
                },
                new CompanyProductEntity()
                {
                    Name = "Καρότα Ελληνικά Χύμα",
                    IsOnSale = false,
                    DateOnSaleFrom = DateTime.Parse("11/18/2021"),
                    DateOnSaleTo = DateTime.Parse("11/28/2021"),
                    StockQuantity = 23,
                    IsPurchasable = true,
                    IsVerified = true,
                    CompanyId = 3
                },
                new CompanyProductEntity()
                {
                    Name = "Αχλάδια Κρυστάλλια Ελληνικά Ποιότητα Α΄ Χύμα",
                    IsOnSale = true,
                    DateOnSaleFrom = DateTime.Parse("11/18/2021"),
                    DateOnSaleTo = DateTime.Parse("11/28/2021"),
                    StockQuantity = 213,
                    IsPurchasable = false,
                    IsVerified = false,
                    CompanyId = 1
                },
                new CompanyProductEntity()
                {
                    Name = "Αγγουράκια Ελληνικά Χύμα",
                    StockQuantity = 345,
                    IsOnSale = true,
                    DateOnSaleFrom = DateTime.Parse("11/18/2021"),
                    DateOnSaleTo = DateTime.Parse("11/28/2021"),
                    IsPurchasable = true,
                    IsVerified = false,
                    CompanyId = 1
                }
            });

            await context.SaveChangesAsync();

            #region Price Per Measurement Unit

            context.PricePerMeasurementUnits.AddRange(new List<PricePerMeasurementUnitEntity>()
            { 
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Kilogram",
                    Quantity = 1,
                    Αbbreviation = "Kg",
                    RegularPrice = 7.88,
                    SalePrice = 4.55,
                    CompanyProductId = 1
                },
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Kilogram",
                    Quantity = 1,
                    Αbbreviation = "Kg",
                    RegularPrice = 8.77,
                    SalePrice = 6.55,
                    CompanyProductId = 2
                },
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Kilogram",
                    Quantity = 1,
                    Αbbreviation = "Kg",
                    RegularPrice = 5.44,
                    SalePrice = 1.22,
                    CompanyProductId = 3
                },
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Kilogram",
                    Quantity = 1,
                    Αbbreviation = "Kg",
                    RegularPrice = 546,
                    SalePrice = 234,
                    CompanyProductId = 4
                },
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Kilogram",
                    Quantity = 1,
                    Αbbreviation = "Kg",
                    RegularPrice = 0.5,
                    SalePrice = 0.3,
                    CompanyProductId = 5
                },
                new PricePerMeasurementUnitEntity()
                {
                    Name = "Grams",
                    Quantity = 320,
                    Αbbreviation = "g",
                    RegularPrice = 0.5,
                    SalePrice = 0.3,
                    CompanyProductId = 5
                }
            });

            await context.SaveChangesAsync();

            #endregion

            var companyProducts = await context.CompanyProducts.Include(x => x.PricesPerMeasurementUnits).ToListAsync();

            #endregion

            #region Products

            var products = await context.Products.ToListAsync();

            foreach(var companyProduct in companyProducts)
            {
                var product = products.FirstOrDefault(x => x.Name == companyProduct.Name);

                if (product != null)
                {
                    var updatedCompanyProducts = product.CompanyProducts.ToList();
                    updatedCompanyProducts.Add(companyProduct);
                    product.CompanyProducts = updatedCompanyProducts;
                }
                else
                {
                    var newProduct = new ProductEntity()
                    {
                        Name = companyProduct.Name,
                        CompanyProducts = new List<CompanyProductEntity>() { companyProduct }
                    };

                    context.Products.Add(newProduct);
                }
            }

            await context.SaveChangesAsync();

            #endregion

            #region Categories

            context.Categories.AddRange(new List<CategoryEntity>() 
            {
                new CategoryEntity()
                {
                    Name = "Vegetables & Fruits",
                    Path = "",
                    Color = "342564",
                    Description = "Contains the vegetables and fruits of every company"
                }
            });

            await context.SaveChangesAsync();

            context.Categories.AddRange(new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Name = "Vegetables",
                    Path = "",
                    Color = "342564",
                    Description = "Contains the vegetables of every company",
                    ParentCategoryId = 1
                },
                new CategoryEntity()
                {
                    Name = "Fruits",
                    Path = "",
                    Color = "342564",
                    Description = "Contains the fruits of every company",
                    ParentCategoryId = 1
                }
            });

            await context.SaveChangesAsync();

            #endregion

            #region Products And Categories

            

            #endregion
        }

        #endregion
    }
}
