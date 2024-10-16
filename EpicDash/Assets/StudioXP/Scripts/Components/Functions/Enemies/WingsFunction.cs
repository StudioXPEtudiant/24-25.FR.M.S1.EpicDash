using StudioXP.Scripts.Components.AI;
using StudioXP.Scripts.Components.Handlers;
using StudioXP.Scripts.Components.Movements.Platforms;
using UnityEngine;
//rigidHandler
//moveAutoLimit

//walkAI

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class WingsFunction : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectEnemy;
        private bool _firstTime = true;

        public void WingsFall()
        {
            GetComponent<RigidbodyHandler>().FreezePositionY(false);
            GetComponent<RigidbodyHandler>().FreezePositionX(false);
            GetComponent<MoveLimitAuto>().enabled = false;
            GetComponent<Rigidbody2D>().velocity = Vector2.up * 7;
        }

        public void ActivateWalkAI()
        {
            gameObjectEnemy.transform.parent = null;
            gameObjectEnemy.GetComponent<RigidbodyHandler>().FreezePositionY(false);
            gameObjectEnemy.GetComponent<RigidbodyHandler>().FreezePositionX(false);
            gameObjectEnemy.GetComponent<PassiveWalkAI>().enabled = true;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.CompareTag("Player") && _firstTime) 
            {
                other.GetComponent<Rigidbody2D>().velocity = Vector2.up * 10;
                WingsFall();
                ActivateWalkAI();
                _firstTime = false;
            }    
        }
    }
}
