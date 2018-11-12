using PetShopApp.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetShop.ConsoleApp.Infrastructure.Data
{
    public class DBinitializer
    {
        public static void SeedDB(PetShopContext ctx)
        {
           //ctx.Database.EnsureDeleted();
           //ctx.Database.EnsureCreated();

            var owner1 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Lotte",
                LastName = "Tubæk",
                Address = "Rosenparken 53",
                Email = "Ctubaek@hotmail.com",
                PhoneNumber = "23313226"
            }
           ).Entity;

            var owner2 = ctx.Owners.Add(new Owner()
            {
                FirstName = "Mikael",
                LastName = "Fabrisous",
                Address = "Gammelmandvej 53",
                Email = "IluvGoats@hotmail.com",
                PhoneNumber = "2334334226"
            }
                ).Entity;


            var pet1 = ctx.Pets.Add(new Pet()
            {
                name = "Daniel",
                type = "Goat",
                color = "Ugly",
                price = 2400,
                previousOwner = owner1
                
                
            });

            var pet2 = ctx.Pets.Add(new Pet()
            {
                name = "Misser",
                type = "Hund",
                color = "Brun",
                price = 7699,
                previousOwner = owner2
            });

            string password = "1234";
            byte[] passwordHashJoe, passwordSaltJoe, passwordHashAnn, passwordSaltAnn;
            CreatePasswordHash(password, out passwordHashJoe, out passwordSaltJoe);
            CreatePasswordHash(password, out passwordHashAnn, out passwordSaltAnn);

            List<User> users = new List<User>
            {
                new User {
                    Username = "UserJoe",
                    PasswordHash = passwordHashJoe,
                    PasswordSalt = passwordSaltJoe,
                    IsAdmin = false
                },
                new User {
                    Username = "AdminAnn",
                    PasswordHash = passwordHashAnn,
                    PasswordSalt = passwordSaltAnn,
                    IsAdmin = true
                }
            };

            ctx.Users.AddRange(users);
            ctx.SaveChanges();


        }

        private static void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}

