using UnityEngine;
using UnityEngine.SceneManagement;

namespace TowerDefence.Runtime
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager
                    .LoadScene("ProjectAssets/Scenes/Game");
        }

        public void QuitGame()
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }
}


