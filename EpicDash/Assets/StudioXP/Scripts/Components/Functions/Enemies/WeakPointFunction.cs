using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;
using UnityEngine.Events; //exercice 2

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class WeakPointFunction : MonoBehaviour
    {
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        [SerializeField] private float bounceSpeed = 7f;
        [SerializeField] private ManyWeakPointsFunction manyWeakPointsFunction;
        [SerializeField] private AnimatorHandler bossAnimatorHandler;
        [SerializeField] private ParticleSystem fireworks;
        [SerializeField] private UnityEvent weakPointDestroyed; //exercice 2

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups))
            {
                other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;
                bossAnimatorHandler.SetAnimatorTrigger("Hurt");
                fireworks.Play();
                gameObject.SetActive(false);
                weakPointDestroyed.Invoke(); //exercice 2
                manyWeakPointsFunction.LoseWeakPoint();
            }  
        }
    }
}
