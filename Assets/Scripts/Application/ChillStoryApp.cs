using System.Collections.Generic;
using Data;
using UnityEngine;

namespace Application
{
    public class ChillStoryApplication : MonoBehaviour
    {
        [Header("Config")]
        [SerializeField] private GameService service;

        [Header("Data")]
        [SerializeField] private CharacterData playerData;


        public static ChillStoryApplication Instance
        {
            get;
            private set;
        }

        public static Dictionary<string, string> GetPlayerData()
        {
            var playerData = 
            if(Instance)
            Instance.playerData = service.GetService<Load>()
        }

        private void Awake()
        {
            Instance = this;
        }

        private void OnDestroy()
        {
            Instance = null;
        }
    }
}