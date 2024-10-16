using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// Exécute un évènement en boucle à chaque Frame Update.
    /// </summary>
    public class LoopFunction : SXPMonobehaviour
    {
        [LabelText("Activé")]
        [SerializeField] private bool active;
        [LabelText("En boucle")]
        [SerializeField] private UnityEvent onLoop;

        /// <summary>
        /// Active ou désactive la boucle.
        /// </summary>
        /// <param name="activeParam"></param>
        public void SetActive(bool activeParam)
        {
            active = activeParam;
        }

        private void Update()
        {
            onLoop.Invoke();
        }
    }
}
