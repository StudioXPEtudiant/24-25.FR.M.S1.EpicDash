using StudioXP.Scripts.Game;
using UnityEngine.SceneManagement;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// ChangeLevelFunction permet de charger le niveau suivant ou un niveau spécifique.
    /// </summary>
    public class ChangeLevelFunction : SXPMonobehaviour
    {
        /// <summary>
        /// Charge le niveau suivant s'il existe.
        /// </summary>
        public void LoadNextLevel()
        {
            if(GameData.Instance)
                GameData.Instance.SetCheckpoint(null);
                
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        /// <summary>
        /// Charge le niveau dont le id a été défini en  paramètre.
        /// </summary>
        /// <param name="level"></param>
        public void LoadLevel(int level)
        {
            if(GameData.Instance && level != SceneManager.GetActiveScene().buildIndex)
                GameData.Instance.SetCheckpoint(null);
            
            SceneManager.LoadScene(level);
        }
    }
}
