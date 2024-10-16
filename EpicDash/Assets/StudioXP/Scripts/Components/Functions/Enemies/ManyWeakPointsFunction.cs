using StudioXP.Scripts.Components.AI;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;
using UnityEngine.Events; //exercice 2

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class ManyWeakPointsFunction : MonoBehaviour
    {
        [SerializeField] private PassiveWalkAI passiveWalkAI;
        [SerializeField] private AnimatorHandler bossAnimatorHandler;
        [SerializeField] private GameObject [] weakPointHitboxes;
        [SerializeField] private GameObject [] hazards;
        [SerializeField] private UnityEvent bossIsDead;//exercice 2

        public void LoseWeakPoint()
        {
            foreach(var weakPoint in weakPointHitboxes)
            {
                if(weakPoint.activeInHierarchy)
                    return;
            }
            foreach(var hazard in hazards)
            {
                hazard.SetActive(false);
            }
            passiveWalkAI.enabled = false;
            bossAnimatorHandler.SetAnimatorTrigger("Die");
            bossIsDead.Invoke(); //exercice2
        }
    }
}
