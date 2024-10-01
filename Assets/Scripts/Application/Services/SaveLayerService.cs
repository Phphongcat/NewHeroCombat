using Data;
using UnityEngine;

namespace Application.Services
{
    [System.Serializable]
    public class SaveLayerService : IService
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
            else Debug.LogError("SaveLayerService data must be CharacterData and not null");
        }

        public void Execute()
        {
            if (_data is null) Debug.LogError("SaveLayerService: data is null");
            else PlayerPrefs.SetString(CharacterDataJson, JsonUtility.ToJson(_data));
        }
    }
}