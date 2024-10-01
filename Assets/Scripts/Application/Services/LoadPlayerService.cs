using Data;
using UnityEngine;

namespace Application.Services
{
    [System.Serializable]
    public class PlayerService : AService
    {
        private const string CharacterDataJson = "ChillStoryCharacterData";
        private CharacterData _data = new();


        public void SendRequest()
        {
            var json = PlayerPrefs.GetString(CharacterDataJson);
            if (string.IsNullOrEmpty(json)) PlayerPrefs.SetString(CharacterDataJson, JsonUtility.ToJson(_data));
            else _data = JsonUtility.FromJson<CharacterData>(json);

            Debug.Log("Done Player Service");

            _handleResponse?.Invoke(MessageID(), _data);
        }

        public override string MessageID()
        {
            return Application.MessageID.PlayerData;
        }
    }
}