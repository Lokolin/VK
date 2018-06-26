using System;
using System.Collections.Generic;
using System.Text;
using VkNet;
using VkNet.Enums.Filters;
using VkNet.Model.RequestParams;

namespace VK_Analysis_ConsoleAnalysisAnalysis
{
    class GroupService
    {
        private readonly VkApi vkApi;
        public GroupService(VkApi _vkApi)
        {
            vkApi = _vkApi;
        }

        public void GetGroupMembersInfo(string groupId)
        {
            var members = vkApi.Groups.GetMembers(new GroupsGetMembersParams
            {
                GroupId = groupId,
                Fields = UsersFields.City
            });
            foreach (var member in members)
            {
                Console.WriteLine(member.FirstName + " " + member.LastName + " " + member.City?.Title);
            }

            Console.WriteLine("Число подписчкиов в группе" + members.Count);

        }
    }
}
