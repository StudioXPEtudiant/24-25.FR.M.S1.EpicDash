using System.Collections;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class BrickHeadStartFunction : MonoBehaviour
    {
        [SerializeField] private float vitesseFoncer = 0.05f;
        [SerializeField] private Vector2 direction = Vector2.up * -1;
        [SerializeField] private Collider2D hazardCollider;
        [SerializeField] private AnimatorHandler animHandler;

        private bool canMove = true;
        private bool isAtteri = false;

        private void OnTriggerStay2D(Collider2D other) 
        {
            if(other.CompareTag("Player") && canMove) 
            {
                canMove = false;
                isAtteri = false;
                hazardCollider.enabled = true;
                animHandler.SetAnimatorBoolTrue("IsMoving");
                StartCoroutine(MoveOneDirection());
            }
        }

        private IEnumerator MoveOneDirection()
        {
            while(!isAtteri)
            {
                transform.parent.Translate(direction * vitesseFoncer);
                yield return null;
            }
        }

        public void SetCanMove(bool _canMove)
        {
            canMove = _canMove;
        }

        public void SetIsAtteri(bool _isAtteri)
        {
            isAtteri = _isAtteri;
        }
    }
}
