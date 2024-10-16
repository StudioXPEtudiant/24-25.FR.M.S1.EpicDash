using System.Collections;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;

namespace StudioXP.Scripts.Components.AI
{
    public class SkeletonAI : MonoBehaviour
    {
        [SerializeField] private GameObject objectEnemy;
        [SerializeField] private Collider2D hazardCollider;
        [SerializeField] private float tempsAvantReactivation = 5;
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        [SerializeField] private float bounceSpeed = 7f;
    
        private bool skeletonIsBroken = false;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups )&& !skeletonIsBroken)
            {
                other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;

                objectEnemy.GetComponent<AnimatorHandler>().SetAnimatorBoolTrue("IsBroken");
                objectEnemy.GetComponent<PassiveWalkAI>().enabled = false; 
                hazardCollider.enabled = false;
                skeletonIsBroken = true;
                StartCoroutine(WaitAndReactivateEnemy());
            }         
        }

        private IEnumerator WaitAndReactivateEnemy()
        {
            yield return new WaitForSeconds(tempsAvantReactivation);
        
            objectEnemy.GetComponent<AnimatorHandler>().SetAnimatorBoolFalse("IsBroken");
            objectEnemy.GetComponent<PassiveWalkAI>().enabled = true; 
            hazardCollider.enabled = true;
            skeletonIsBroken = false;
        }
    }
}


