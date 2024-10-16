using System.Collections;
using UnityEngine;
using Sirenix.OdinInspector;

namespace StudioXP.Scripts.Components.Traps
{
    public class HiddenSpikesFunction : MonoBehaviour
    {
        [LabelText("Temps avant l'activation")]
        [MinValue(0)]
        [SerializeField] private float timeBeforeActivation = 0.5f;

        [LabelText("Temps avant la désactivation")]
        [MinValue(0)]
        [SerializeField] private float timeBeforeDeactivation = 2.5f;

        [SerializeField] private Animator animator;

        [LabelText("Zone de dégâts")]
        [SerializeField] private BoxCollider2D hazardZone;

        public void Activate() 
        {
            StartCoroutine(ActivateSpikes());
        }

        private IEnumerator ActivateSpikes()
        {
            yield return new WaitForSeconds(timeBeforeActivation);
            animator.SetBool("isTrigger", true);
            hazardZone.enabled = true;
            yield return new WaitForSeconds(timeBeforeDeactivation);
            animator.SetBool("isTrigger", false);
            hazardZone.enabled = false;
        }
    }
}
