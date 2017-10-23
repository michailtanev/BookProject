namespace SchoolBookApplication.Data
{
    using SchoolBookApplication.Domain;
    using SchoolBookApplication.Data;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    public class SchoolBookData : ISchoolBookData
    {

        private readonly DbContext context;
        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public SchoolBookData()
            : this(new SchoolBookDbContext())
        {
        }
        public SchoolBookData(DbContext context)
        {
            this.context = context;
        }

        public IRepository<Book> Books
        {
            get
            {
                return this.GetRepository<Book>();
            }
        }
        public IRepository<User> Users
        {
            get
            {
                return this.GetRepository<User>();
            }
        }

        public IRepository<BookCategory> BookCategories
        {
            get
            {
                return this.GetRepository<BookCategory>();
            }
        }

        public IRepository<BookType> BookTypes
        {
            get
            {
                return this.GetRepository<BookType>();
            }
        }
        public IRepository<Image> Images
        {
            get
            {
                return this.GetRepository<Image>();
            }
        }

        public DbContext Context
        {
            get
            {
                return this.context;
            }
        }



        private IRepository<T> GetRepository<T>() where T : class
        {
            if (!this.repositories.ContainsKey(typeof(T)))
            {
                var type = typeof(GenericRepository<T>);

                this.repositories.Add(typeof(T), Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeof(T)];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

    }

}

