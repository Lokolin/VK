using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Enums.SafetyEnums;
using VkNet.Exception;
using VkNet.Model;
using VkNet.Model.RequestParams;
using VkNet.Utils;

namespace VK_Analysis_ConsoleAnalysis
{
    class AccountService
    {
        VkApi vkApi = new VkApi();

        public void Authorize()
        {
            try
            {
                Console.WriteLine("Введите логин");
                string login = Console.ReadLine();
                Console.WriteLine("Введите пароль");
                string password = Console.ReadLine();
                vkApi.Authorize(new ApiAuthParams
                {
                    ApplicationId = 6612352,
                    Login = login,
                    Password = password,
                    Settings = Settings.All
                });

            }
            catch (VkApiException)
            {
                Console.WriteLine("Неправильный логин или пароль");
            }
            Console.WriteLine("Вы успешно авторизировались!");
        }

        public List<User> GetAllFriends(long userId)
        {
            try
            {
                var users = vkApi.Friends.Get(new FriendsGetParams
                {
                    UserId = userId,
                    Fields = ProfileFields.FirstName | ProfileFields.LastName | ProfileFields.City | ProfileFields.Uid,
                    Order = FriendsOrder.Name,
                }).ToList();
                return users;

            }
            catch (FormatException)
            {
                Console.WriteLine("Неправильный ID");
                return null;
            }
        }

        public List<User> GetFriendsFromCity(long userId, string city)
        {
            List<User> CityUsers = new List<User>();
            var users = GetAllFriends(userId);
                foreach (var user in users)
                {
                    if (user.City?.Title == city)
                    {
                        CityUsers.Add(user);
                    }
                }

            return CityUsers;
        }

        public void PrintUsers(List<User> Users)
        {
            foreach (var user in Users)
            {
                Console.WriteLine(user.FirstName + " " + user.LastName + " " + user.City?.Title + " ");
            }
        }

    }
}
