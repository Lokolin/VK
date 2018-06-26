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

        /// <summary>
        /// Метод авторизирующий пользователя
        /// </summary>
        /// <param name="login"> Логин (e-mail) пользователя </param>
        /// <param name="password"> Пароль пользователя </param>
        public void Authorize(string login, string password)
        {
            try
            {
                
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

        /// <summary>
        /// Метод получающий список всех друзей по заданому Id пользователя
        /// </summary>
        /// <param name="userId"> Id пользователя </param>
        ///  <returns> Возвращает список друзей </returns>
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

        /// <summary>
        /// Метод получающий список всех друзей по заданому Id пользователя в указанном городе
        /// </summary>
        /// <param name="userId"> Id пользователя </param>
        /// <param name="city"> Город </param>
        ///  <returns> Возвращает список друзей из определенного города </returns>
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
