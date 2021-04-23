using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;

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
        /// Creates and adds data to the data base
        /// </summary>
        /// <param name="context">The data base's context</param>
        /// <returns></returns>
        public static void SetUp(FooliDBContext context)
        {
            var result = context.Database.EnsureCreated();

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

            context.SaveChanges();

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

            context.SaveChanges();

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

            context.SaveChanges();

            #endregion

            #endregion

            #region Products

            context.Products.AddRange(new List<ProductEntity>() 
            {
                new ProductEntity()
                {
                    Name = "Καρότα Ελληνικά Χύμα"
                },
                new ProductEntity()
                {
                    Name = "Αχλάδια Κρυστάλλια Ελληνικά Ποιότητα Α΄ Χύμα"
                },
                new ProductEntity()
                {
                    Name = "Αγγουράκια Ελληνικά Χύμα"
                },
                new ProductEntity()
                {
                    Name = "Ντομάτες Ελληνικές Χύμα"
                }
            });

            context.SaveChanges();

            var products = context.Products.Include(x => x.CompaniesProducts)
                                           .Include(x => x.Images)
                                           .Include(x => x.ProductLabels)
                                           .Include(x => x.ProductLabels)
                                           .ToList();

            #endregion

            #region Companies

            // Creates a new range of company entities
            context.Companies.AddRange(new List<CompanyEntity>() 
            {
                new CompanyEntity()
                {
                    Name = "L.I.D.L.", 
                    Color = "011627",
                    LogoImageName = "L.I.D.L. logo square",
                    LogoImageSource = "https://zahramediagroup.com/wp-content/uploads/2020/06/lidl-test-logo.png",
                    LogoImageAlt = "lidl logo",
                    TextImageName = "L.I.D.L. logo rectangle",
                    TextImageSource = "https://www.kindpng.com/picc/m/784-7842934_lidl-logo-logo-lidl-hd-png-download.png",
                    TextImageAlt = "lidl logo",
                },
                new CompanyEntity()
                {
                    Name = "Σκλαβενίτης",
                    Color = "FF9F1C",
                    LogoImageName = "Sklavenitis logo square",
                    LogoImageSource = "https://i.pinimg.com/736x/a1/40/2c/a1402c47e834153e9df831db2e84001b.jpg",
                    LogoImageAlt = "Sklavenitis logo",
                    TextImageName = "Sklavenitis logo rectangle",
                    TextImageSource = "https://m.naftemporiki.gr/thumb/1337655/1200/1200/0x00000000013b62ea/1/sklabenitis-logotupo.jpg",
                    TextImageAlt = "Sklavenitis logo",
                },
                new CompanyEntity()
                {
                    Name = "MyMarket",
                    Color = "E71D36",
                    LogoImageName = "My Market logo square",
                    LogoImageSource = "https://www.artopoulospites.gr/wp-content/uploads/2020/12/mymarket-logo.jpg",
                    LogoImageAlt = "My Market logo",
                    TextImageName = "My Market logo rectangle",
                    TextImageSource = "https://i.pinimg.com/originals/af/60/f7/af60f77a88254ca86e74b131c52b6da8.jpg",
                    TextImageAlt = "My Market logo",
                }
            });

            context.SaveChanges();

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
                    Address = "N.E.O. Patron - Athinon 14",
                    PostalCode = "26441",
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

            context.SaveChanges();

            #endregion

            #region Branch Images

            // Adds company images
            context.Images.AddRange(new List<ImageEntity>()
            {
                new ImageEntity()
                {
                    Name = "L.I.D.L. Αλεξάνδρειας",
                    Source = "https://i2-prod.dailyrecord.co.uk/incoming/article10393290.ece/ALTERNATES/s1200b/JS111288406-1.jpg",
                    Alt = "Alexandreia branch of L.I.D.L",
                    BranchId = 1
                },
                new ImageEntity()
                {
                    Name = "L.I.D.L. Πάτρας 1",
                    Source = "https://www.helppost.gr/wp-content/uploads/2013/12/lidl-hellas-fylladio-prosfores-super-market.jpg",
                    Alt = "Patra branch 1 of L.I.D.L",
                    BranchId = 2
                },
                new ImageEntity()
                {
                    Name = "Sklavenitis Πάτρας 1",
                    Source = "https://www.newmoney.gr/wp-content/uploads/2019/07/sklavenitis-1big.jpg",
                    Alt = "Patra branch 1 of Sklavenitis",
                    BranchId = 3
                },
                new ImageEntity()
                {
                    Name = "Sklavenitis Πάτρας 2",
                    Source = "https://tsipasblog.gr/wp-content/uploads/2020/05/Sklavenitis.jpg",
                    Alt = "Patra branch 2 of Sklavenitis",
                    BranchId = 4
                },
                new ImageEntity()
                {
                    Name = "MyMarket Πάτρας 1",
                    Source = "https://www.dikaiologitika.gr/media/k2/items/cache/fdb2100eca20c920ac6ab033eabc5d22_XL.jpg",
                    Alt = "Patra branch 1 of Sklavenitis",
                    BranchId = 4
                },
            });

            // Save the changes
            context.SaveChanges();

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
                    CompanyId = 3
                }
            });

            // Save the changes
            context.SaveChanges();

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
                    CompanyId = 1,
                    ProductrId = 1
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
                    CompanyId = 1,
                    ProductrId = 1
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
                    CompanyId = 2,
                    ProductrId = 1
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
                    CompanyId = 1,
                    ProductrId = 2
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
                    CompanyId = 1,
                    ProductrId = 3
                }
            });

            context.SaveChanges();

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

            context.SaveChanges();

            #endregion

            var companyProducts = context.CompanyProducts.Include(x => x.PricesPerMeasurementUnits).ToList();

            #endregion

            #region Categories

            context.Categories.AddRange(new List<CategoryEntity>() 
            {
                new CategoryEntity()
                {
                    Name = "Vegetables & Fruits",
                    Path = "",
                    Color = "E71D36",
                    Description = "Contains the vegetables and fruits of every company"
                }
            });

            context.SaveChanges();

            context.Categories.AddRange(new List<CategoryEntity>()
            {
                new CategoryEntity()
                {
                    Name = "Vegetables",
                    Path = "",
                    Color = "FF9F1C",
                    Description = "Contains the vegetables of every company",
                    ParentCategoryId = 1
                },
                new CategoryEntity()
                {
                    Name = "Fruits",
                    Path = "",
                    Color = "2EC4B6",
                    Description = "Contains the fruits of every company",
                    ParentCategoryId = 1
                }
            });
            
            context.SaveChanges();

            #endregion

            #region Products And Categories

            foreach(var product in products)
            {
                context.ProductCategories.Add(new ProductCategoryEntity()
                {
                    ProductId = product.Id,
                    CategoryId = 1
                });
            }

            context.ProductCategories.AddRange(new List<ProductCategoryEntity>() 
            {
                new ProductCategoryEntity()
                {
                    ProductId = 1,
                    CategoryId = 2
                },
                new ProductCategoryEntity()
                {
                    ProductId = 1,
                    CategoryId = 2
                },
                new ProductCategoryEntity()
                {
                    ProductId = 1,
                    CategoryId = 3
                },
                new ProductCategoryEntity()
                {
                    ProductId = 1,
                    CategoryId = 2
                }
            });

            context.SaveChanges();

            #endregion

            #region Labels

            context.Labels.AddRange(new List<LabelEntity>()
            {
                new LabelEntity()
                {
                    Name = "Vegetarian",
                    Color = "1F0812",
                    Description = "Vegetarian",
                },
                new LabelEntity()
                {
                    Name = "Origin",
                    Color = "F3B3A6",
                    Description = "The origin",
                },
                new LabelEntity()
                {
                    Name = "Ethnic",
                    Color = "37515F",
                    Description = "Ethnic",
                },
                new LabelEntity()
                {
                    Name = "Brand",
                    Color = "DC965A",
                    Description = "The brand",
                },
                new LabelEntity()
                {
                    Name = "Bio/Organic",
                    Color = "00A6FB",
                    Description = "Organic or bio",
                }
            });

            context.SaveChanges();

            #endregion

            #region Products and Labels

            foreach(var product in products)
            {
                context.ProductLabels.Add(new ProductLabelEntity()
                {
                    ProductId = product.Id,
                    LabelId = 1,
                    Value = "Yes"
                });

                context.ProductLabels.Add(new ProductLabelEntity()
                {
                    ProductId = product.Id,
                    LabelId = 2,
                    Value = "Greece"
                });

                context.ProductLabels.Add(new ProductLabelEntity()
                {
                    ProductId = product.Id,
                    LabelId = 3,
                    Value = "No"
                });

                context.ProductLabels.Add(new ProductLabelEntity()
                {
                    ProductId = product.Id,
                    LabelId = 5,
                    Value = "Yes"
                });
            }

            context.SaveChanges();

            #endregion
        }

        #endregion
    }
}
