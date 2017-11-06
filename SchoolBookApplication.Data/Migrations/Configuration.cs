namespace SchoolBookApplication.Data.Migrations
{
    using Domain;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.IO;
    using System.Linq;

    public sealed class Configuration : DbMigrationsConfiguration<SchoolBookDbContext>
    {
        private UserManager<User> userManager;

        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            
        }

        protected override void Seed(SchoolBookDbContext context)
        {
            this.userManager = new UserManager<User>(new UserStore<User>(context));
            this.SeedUserWithBooks(context);        
            //base.Seed(context);    
        }
        private void SeedUserWithBooks(SchoolBookDbContext context)
        {
            var testUser = new User
            {
                FirstName = "Mihail",
                LastName = "Tanev",
                Email = "test_user@gmail.com",
                UserName = "testUser",
                PhoneNumber = "50 645 177",
                City ="Copenhagen"
            };

            var existingTestUser = context.Users.Where(u => string.Compare(u.Email, testUser.Email, true) == 0).FirstOrDefault();
            if (existingTestUser == null)
            {
                this.userManager.Create(testUser, "123456");

                //book1
                var book1 = new Book()
                {
                    OriginalPrice = 100,
                    SalePrice = 50,
                    ListingDate = new DateTime(2017, 1,10 ),
                    AdditionalInformation = "good condition"
                };
                book1.Seller = testUser;
                var img = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../SchoolBookApplication.Data/Migrations/img/android.jpg")),
                    FileExtension = "jpg"
                };
                book1.Image = img;
                var category = new BookCategory()
                {
                    Name = "Programming",
                };
                var bookType = new BookType()
                {
                    Name = "Beginning Android 4",
                    Year = 2014,
                    BookCategory = category
                };
                var ExistingModel = context.BookTypes.Where(m => string.Compare(m.Name, bookType.Name, true) == 0).FirstOrDefault();
                if (ExistingModel == null)
                {
                    book1.Type = bookType;
                }
                else
                {
                    book1.Type = ExistingModel;
                }

                //book2
                var book2 = new Book()
                {
                    OriginalPrice = 150,
                    SalePrice = 100,
                    ListingDate = new DateTime(2017, 2, 8),
                    AdditionalInformation = "very good condition"
                };
                book2.Seller = testUser;
                var img2 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../SchoolBookApplication.Data/Migrations/img/aspnet.jpg")),
                    FileExtension = "jpg"
                };
                book2.Image = img2;
                var category2 = new BookCategory()
                {
                    Name = "Programming",
                };
                var bookType2 = new BookType()
                {
                    Name = "ASP.NET",
                    Year = 2014,
                    BookCategory = category2
                };
                var ExistingModel2 = context.BookTypes.Where(m => string.Compare(m.Name, bookType2.Name, true) == 0).FirstOrDefault();
                if (ExistingModel2 == null)
                {
                    book2.Type = bookType2;
                }
                else
                {
                    book2.Type = ExistingModel2;
                }

                //book3
                var book3 = new Book()
                {
                    OriginalPrice = 200,
                    SalePrice = 100,
                    ListingDate = new DateTime(2017,3,30),
                    AdditionalInformation = "very good condition"
                };
                book3.Seller = testUser;
                var img3 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../SchoolBookApplication.Data/Migrations/img/java.jpg")),
                    FileExtension = "jpg"
                };
                book3.Image = img3;
                var category3 = new BookCategory()
                {
                    Name = "Programming",
                };
                var bookType3 = new BookType()
                {
                    Name = "Head First Java",
                    Year = 2015,
                    BookCategory = category3
                };
                var ExistingModel3 = context.BookTypes.Where(m => string.Compare(m.Name, bookType3.Name, true) == 0).FirstOrDefault();
                if (ExistingModel3 == null)
                {
                    book3.Type = bookType3;
                }
                else
                {
                    book3.Type = ExistingModel3;
                }

                //book4
                var book4 = new Book()
                {
                    OriginalPrice = 300,
                    SalePrice = 200,
                    ListingDate = new DateTime(2017, 3, 16),
                    AdditionalInformation = "excellent condition"
                };
                book4.Seller = testUser;
                var img4 = new Image()
                {
                    Content = File.ReadAllBytes(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    "../SchoolBookApplication.Data/Migrations/img/software.jpg")),
                    FileExtension = "jpg"
                };
                book4.Image = img4;
                var category4 = new BookCategory()
                {
                    Name = "Programming",
                };
                var bookType4 = new BookType()
                {
                    Name = "Software Engineering",
                    Year = 2016,
                    BookCategory = category4
                };
                var ExistingModel4 = context.BookTypes.Where(m => string.Compare(m.Name, bookType4.Name, true) == 0).FirstOrDefault();
                if (ExistingModel4 == null)
                {
                    book4.Type = bookType4;
                }
                else
                {
                    book4.Type = ExistingModel4;
                }

                context.Books.Add(book1);
                context.Books.Add(book2);
                context.Books.Add(book3);
                context.Books.Add(book4);
                context.SaveChanges();
            }
        }

        }
    }

