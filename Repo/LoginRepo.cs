﻿using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Palmart.Data;
using Palmart.IRepo;
using Palmart.Models;

namespace Palmart.Repo
{
	public class LoginRepo : ILoginRepo
	{
		private readonly AppDbContext _db;
        public LoginRepo(AppDbContext db)
        {
            _db = db;
        }
		public User GetByEmail(string email) {
			var user = _db.Users.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
			return user ; 
		}
        //public string[] GetLoginInfo()
        //{
        //    return ;
        //}
    }
}
