using System.Collections;
using StudioXP.Scripts.Components.Functions;
using UnityEngine;

namespace StudioXP.Scripts.Components.AI
{
    public class GenerateAndThrowAtTargetAI : MonoBehaviour
    {
        [SerializeField]
        private float tempsEntreProjectiles = 1f;

        private bool _isThrowing = false;

        private IEnumerator WaitAndThrow()
        {
            yield return new WaitForSeconds(tempsEntreProjectiles);
            _isThrowing = false;
            GetComponent<GeneratorFunction>().GenerateAndThrowAtTarget();
        }

        private void OnTriggerStay2D(Collider2D other) 
        {
            if (_isThrowing)
                return;
        
            if (other.CompareTag("Player"))
            {
                _isThrowing = true;
                StartCoroutine("WaitAndThrow");
            }    
        }
    }
}
