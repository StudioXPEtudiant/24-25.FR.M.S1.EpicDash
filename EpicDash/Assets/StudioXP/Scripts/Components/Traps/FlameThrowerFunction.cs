using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace StudioXP.Scripts.Components.Traps
{
    public class FlameThrowerFunction : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        [LabelText("Zone de dégâts")]
        [SerializeField] private BoxCollider2D hazardZone;

        public void ToggleActivation()
        {
            hazardZone.enabled = !hazardZone.enabled;
            animator.SetBool("Activated", !animator.GetBool("Activated"));
        }
    }
}
