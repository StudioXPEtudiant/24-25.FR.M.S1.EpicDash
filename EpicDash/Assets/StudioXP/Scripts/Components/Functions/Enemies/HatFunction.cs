using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.AI;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Objects;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class HatFunction : MonoBehaviour
    {
        [SerializeField] private Collider2D hazardCollider;
        [SerializeField] private GameObject objectHat;
        [SerializeField] private Animator animator;
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        [SerializeField] private float avatarBounceSpeed = 7f;
        [SerializeField] private float hatBounceSpeed = 3f;

        private bool _hatIsOnHead = true;
        private bool _hatIsAlive = true;

        void Start()
        {
            objectHat.GetComponent<PickableObject>().SetPickableIsEnabled(false);
            objectHat.GetComponent<Collider2D>().enabled = false;
            objectHat.GetComponent<PassiveWalkAI>().enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups))
            {
                if(_hatIsOnHead)
                {
                    other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * avatarBounceSpeed;
                    animator.enabled = true;
                    objectHat.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                    objectHat.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * hatBounceSpeed;
                    objectHat.GetComponent<Collider2D>().enabled = true;
                    objectHat.GetComponent<PassiveWalkAI>().enabled = true;
                    objectHat.transform.parent = null;
                    _hatIsOnHead = false;
                }
                else if(_hatIsAlive)
                {
                    other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * avatarBounceSpeed;
                    animator.enabled = false;
                    objectHat.GetComponent<PassiveWalkAI>().enabled = false;
                    objectHat.GetComponent<PickableObject>().SetPickableIsEnabled(true);
                    hazardCollider.enabled = false;
                    _hatIsAlive = false;
                }
            }
        }
    }
}
