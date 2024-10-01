using Application;
using Data;
using UnityEngine;

namespace Test
{
    public class TestPlayerService : MonoBehaviour
    {
        private void Awake()
        {
            var player = new CharacterData();

            player.Renew(ChillStoryApp.GetPlayerData());
            Debug.Log($"Before playerData changed: {player.atk}, {player.hp}");

            ChillStoryApp.ChangePlayerData("atk", 50);
            ChillStoryApp.ChangePlayerData("hp", 1000);

            player.Renew(ChillStoryApp.GetPlayerData());
            Debug.Log($"After playerData changed: {player.atk}, {player.hp}");
        }
    }
}