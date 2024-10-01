using System.Collections.Generic;
using Application.Services;
using Data;

namespace Application
{
    public partial class ChillStoryApp
    {
        public static Dictionary<string, object> GetPlayerData()
        {
            var dictionary = new Dictionary<string, object>();
            var _ = Validate(() =>
            {
                Instance.service.GetService<LoadPlayerService>().Execute();
                Instance.playerData.FieldDictionary(out dictionary);
            });

            return dictionary;
        }

        public static void ChangePlayerData(string id, object stat)
        {
            Validate(() =>
            {
                Instance.playerData.Renew(id, stat);
                Instance.service.GetService<SaveLayerService>().Execute();
            });
        }
    }
}