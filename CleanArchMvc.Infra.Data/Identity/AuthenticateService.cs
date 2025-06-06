﻿using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Infra.Data.Identity
{
    public class AuthenticateService : IAuthenticate
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signManager;
        public AuthenticateService(SignInManager<ApplicationUser> signManager, UserManager<ApplicationUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }

        public async Task<bool> Authenticate(string email, string password)
        {
            var result = await _signManager.PasswordSignInAsync(email, password, false, lockoutOnFailure: false);
            return result.Succeeded;
        }

        public async Task Logout()
        {
            await _signManager.SignOutAsync();
            
        }

        public async Task<bool> RegisterUser(string email, string password)
        {
            var applicationUser = new ApplicationUser
            {
                UserName = email,
                Email = email,
            };

            var result = await _userManager.CreateAsync(applicationUser, password);
            if (result.Succeeded) 
            {
                await _signManager.SignInAsync(applicationUser, isPersistent: false);
            }
            return result.Succeeded;

        }
    }
}
