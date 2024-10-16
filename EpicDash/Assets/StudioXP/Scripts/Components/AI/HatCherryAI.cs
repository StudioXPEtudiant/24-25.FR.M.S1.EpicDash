using System.Collections;
using StudioXP.Scripts.Components.Handlers;
using StudioXP.Scripts.Components.Movements.Characters;
using UnityEngine;

namespace StudioXP.Scripts.Components.AI
{
    public class HatCherryAI : MonoBehaviour
    {
        [SerializeField] private MoveFunction moveFunction;
        [SerializeField] private AnimatorHandler animHandler;
        [SerializeField] private float tempsAvantReactivation = 5;
        [SerializeField] private float speedFast = 10;
        [SerializeField] private float bounceSpeed = 7f;
    
        private float speedNormal;

        private bool hatIsCrushed = false;

        private void Start()
        {
            speedNormal = moveFunction.GetSpeed();
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player")) 
            {
                if(hatIsCrushed)
                {
                    StopCoroutine("WaitAndReactivateEnemy");
                    other.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;
                    moveFunction.SetSpeed(speedNormal);
                    animHandler.SetAnimatorBoolFalse("IsSquished");
                    hatIsCrushed = false;
                }
                else
                {
                    other.GetComponent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;
                    moveFunction.SetSpeed(speedFast);
                    animHandler.SetAnimatorBoolTrue("IsSquished");
                    hatIsCrushed = true;
                    StartCoroutine("WaitAndReactivateEnemy");
                }
            }
        }

        private IEnumerator WaitAndReactivateEnemy()
        {
            yield return new WaitForSeconds(tempsAvantReactivation);
            moveFunction.SetSpeed(speedNormal);
            animHandler.SetAnimatorBoolFalse("IsSquished");
            hatIsCrushed = false;
        }
    }
}
