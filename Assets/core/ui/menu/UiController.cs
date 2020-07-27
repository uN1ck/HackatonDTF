using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DefaultNamespace
{
    public class UiController : MonoBehaviour, MainMenuUiController
    {
        private const String NEW_GAME_SCENE = "GameScene";

        public void HandleNewGame()
        {
            SceneManager.LoadScene(NEW_GAME_SCENE, LoadSceneMode.Additive);
        }

        public void HandleOptions()
        {
            //TODO: Implement!
        }

        public void HandleExit()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }
    }
}