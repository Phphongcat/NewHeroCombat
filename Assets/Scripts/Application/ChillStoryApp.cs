using Application.Services;
using Data;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

namespace Application
{
    public partial class ChillStoryApp : MonoBehaviour
    {
        [Header("Setup")] 
        [SerializeField] private string nextScene;

        [Header("Config")]
        [SerializeField] private GameService service;

        [Header("Data")]
        [SerializeField] private CharacterData playerData;


        public static ChillStoryApp Instance
        {
            get;
            private set;
        }

        private void Awake()
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }

        private void Start()
        {
            service.GetService<LoadPlayerService>().Init(playerData);
            service.GetService<SaveLayerService>().Init(playerData);

            SceneManager.LoadScene(nextScene);
        }

        private void OnDestroy()
        {
            Instance = null;
        }

        private static bool Validate(UnityAction action)
        {
            var validate = Instance != null;
            if (validate) action?.Invoke();
            else Debug.LogError("Application is null");
            return validate;
        }
    }
}