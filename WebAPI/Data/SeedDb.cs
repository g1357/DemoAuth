using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Data
{
    public class SeedDb
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApplicationDbContext>();
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            context.Database.EnsureCreated();
            if (!context.Users.Any())
            {
                ApplicationUser user = new ApplicationUser()
                {
                    Email = "ahmad@gmail.com",
                    SecurityStamp = Guid.NewGuid().ToString(),
                    UserName = "Ahmad"
                };
                userManager.CreateAsync(user, "Ahmad@123");
            }
            var dishTypes = context.DishTypes;
            /*
            dishTypes.Add(
            new DishType
            {
                Name = "Закуска", Plurals = "Закуски",
                Description = "Блюда с которых начинают обед."
            });
            dishTypes.Add(new DishType
            {
                Name = "Слат",
                Plurals = "Салаты",
                Description = "Вид закуски с которой начинают обед."
            });
            dishTypes.Add(new DishType
            {
                Name = "Основное блюдо",
                Plurals = "Основные блюда",
                Description = "Второе (основное) блюдо за обедом."
            });
            dishTypes.Add(new DishType
            {
                Name = "Гарнир",
                Plurals = "Гарниры",
                Description = "Гарнир к основному (второму) блюду."
            });
            dishTypes.Add(new DishType
            {
                Name = "Десерт",
                Plurals = "Десерты",
                Description = "Сладкое блюдо, которое едят в конце обеда."
            });
            dishTypes.Add(new DishType
            {
                Name = "Закуска",
                Plurals = "Закуски",
                Description = "Блюда с которых начинают обед."
            });
            dishTypes.Add(new DishType
            {
                Name = "Закуска",
                Plurals = "Закуски",
                Description = "Блюда с которых начинают обед."
            });
            context.SaveChanges();
            */
            var dishes = context.Dishes;
            //var dishTypeId = dishTypes.FirstOrDefault(r => r.Name == "Закуска").Id;
            /*
            dishes.Add(new Dish
            {
                Name = "ФРИТТА МИСТА", Price = 590.00M,
                Description = "Кальмары и креветки в кляре под соусом айоли",
                Weight = "290", TypeId = dishTypeId
            });
            dishes.Add(new Dish
            {
                Name = "БАКЛАЖАН ПАРМИДЖАНО", Price = 640.00M,
                Description = "Баклажаны, томатный соус, базилик, пармезан, масло оливковое",
                Weight = "370", TypeId = dishTypeId
            });
            dishes.Add(new Dish
            {
                Name = "ТУНЕЦ С ГУАКОМОЛЕ",
                Price = 880.00M,
                Description = "Гуакомоле, филе тунца, лук-резанец, кинза, перец чили, пармезан, соус шрирача, вустерский соус, соус табаско, оливковое масло",
                Weight = "260",
                TypeId = dishTypeId
            });
            dishes.Add(new Dish
            {
                Name = "ТАР ТАР ИЗ ГОВЯЖЕЙ ВЫРЕЗКИ",
                Price = 950.00M,
                Description = "Вырезка из говядины, красный лук, каперсы, соус табаско, дижонская горчица, вустерский соус, соль, яйцо перепелиное, багет, оливковое масло",
                Weight = "145/25",
                TypeId = dishTypeId
            });
            dishes.Add(new Dish
            {
                Name = "СЫР БУРАТТА",
                Price = 780.00M,
                Description = "Сыр Буратта, руккола, бальзамик.",
                Weight = "125",
                TypeId = dishTypeId
            });
            context.SaveChanges();
            */
        }
    }
}
