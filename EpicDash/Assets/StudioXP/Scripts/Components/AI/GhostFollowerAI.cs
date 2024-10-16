using System.Collections;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;

namespace StudioXP.Scripts.Components.AI
{
    public class GhostFollowerAI : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private string tagToDetect;
        [SerializeField] private SpriteRenderer spriteRendererEnemy;
        [SerializeField] private bool stopWhenIsSeen = false; 
        [SerializeField] private bool spriteDirectionIsLeft = false; 

        private GameObject target;
        private bool isFollowing = false;
        private bool isSeen = false;  

        private void OnTriggerStay2D(Collider2D other) 
        {
            if (other.tag == tagToDetect && !isFollowing)
            {
                target = other.gameObject;
                GetComponent<AnimatorHandler>().SetAnimatorBoolTrue("IsMoving");
                isFollowing = true;
                StartCoroutine("FollowTarget");
            }
        }

        private IEnumerator FollowTarget() 
        {
            while(!isSeen)
            {
                transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

                if(spriteRendererEnemy)
                {
                    if(target.transform.position.x - transform.position.x < 0)
                        spriteRendererEnemy.flipX = !spriteDirectionIsLeft;
                    else
                        spriteRendererEnemy.flipX = spriteDirectionIsLeft;
                }

                yield return null;
            }
            GetComponent<AnimatorHandler>().SetAnimatorBoolFalse("IsMoving");
            isFollowing = false;
        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if (other.tag == tagToDetect)
            {
                GetComponent<AnimatorHandler>().SetAnimatorBoolFalse("IsMoving");
                StopCoroutine("FollowTarget");
                isFollowing = false;
            }
        }

        public void SetIsSeen(bool _isSeen)
        {
            isSeen = _isSeen;
        }

        public bool GetStopWhenIsSeen()
        {
            return stopWhenIsSeen;
        }
    }
}
