﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Palmart.Data;
using Palmart.IRepo;

namespace Palmart.Repo
{
	public class BasicRepo<T> : IBasicRepo<T> where T : class
	{
		private readonly AppDbContext _db;

        public BasicRepo(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<T>> GetAll()
		{
			//modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())
			return await _db.Set<T>().ToListAsync();
		}

		public async Task<T> GetByID(int id)
		{
			return await _db.Set<T>().FindAsync(id);
		}
		
		public async void Insert(T entity)
		{
			await _db.Set<T>().AddAsync(entity);
			_db.SaveChanges();
		}
		public async void Update(T entity)
		{
			_db.Set<T>().Update(entity);
			_db.SaveChanges();
		}
		public async void Delete(T entity)
		{
			_db.Set<T>().Remove(entity);
			_db.SaveChanges();
		}
	}
}
