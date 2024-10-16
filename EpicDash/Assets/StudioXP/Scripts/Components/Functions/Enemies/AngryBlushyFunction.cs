using System.Collections;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Movements.Characters;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class AngryBlushyFunction : MonoBehaviour
    {
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        [SerializeField] private float tempsAvantRetourCalme = 4;
        [SerializeField] private MoveFunction moveFunction;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private BoxCollider2D hazardCollider;
        [SerializeField] private float bounceSpeed = 7f;
        [SerializeField] private float speedFast = 10;

        private float speedNormal;
        private bool isAngry = false;

        void Start()
        {
            speedNormal = moveFunction.GetSpeed();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if (otherGroupList == null || !otherGroupList.GroupFilter.Match(groups) || isAngry) return;
            
            other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;
            transform.parent.localScale = new Vector3 (2,2,2);
            moveFunction.SetSpeed(speedFast);
            spriteRenderer.color = Color.red;
            isAngry = true;

            StartCoroutine("WaitAndMakeBlushyFriendly");
        }

        private IEnumerator WaitAndMakeBlushyFriendly()
        {
            yield return new WaitForSeconds(0.2f);
            hazardCollider.enabled = true;
            yield return new WaitForSeconds(tempsAvantRetourCalme);
            transform.parent.localScale = new Vector3 (1,1,1);
            hazardCollider.enabled = false;
            moveFunction.SetSpeed(speedNormal);
            spriteRenderer.color = Color.white;
            isAngry = false;
        }
    }
}
