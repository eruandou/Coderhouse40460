using UnityEngine;
using UnityEngine.SceneManagement;

namespace ClasesRegulares.Clase13
{
    public class LevelSceneManager : MonoBehaviour
    {
        public void LoadLevel(string p_levelToLoad)
        {
            SceneManager.LoadScene(p_levelToLoad);
        }
    }
}