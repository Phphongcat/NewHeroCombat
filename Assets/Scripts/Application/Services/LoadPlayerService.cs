using Data;
using UnityEngine;

namespace Application.Services
{
    [System.Serializable]
    public class LoadPlayerService : IService
    {
        private const string CharacterDataJson = "ChillStoryCharacterData";
        private CharacterData _data;


        public string MessageID()
        {
            return Application.MessageID.PlayerData;
        }

        public void Init(object data)
        {
            if (data is CharacterData d) _data = d;
            else Debug.LogError("LoadPlayerService data must be CharacterData and not null");
        }

        public void Execute()
        {
            var json = PlayerPrefs.GetString(CharacterDataJson);
            if (string.IsNullOrEmpty(json)) PlayerPrefs.SetString(CharacterDataJson, JsonUtility.ToJson(_data));
            else _data.Renew(JsonUtility.FromJson<CharacterData>(json));
        }
    }
}