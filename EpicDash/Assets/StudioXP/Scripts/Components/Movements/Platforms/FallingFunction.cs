using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Components.Movements.Platforms
{
    public class FallingFunction : MonoBehaviour
    {
        [LabelText("Délai")]
        [MinValue(0)]
        [SerializeField] private float delay;
        
        [LabelText("Vitesse")]
        [SerializeField] private float velocity;

        private bool _isTriggered;
        private bool _isFalling;
        
        public void Fall()
        {
            if (_isTriggered) return;
            
            _isTriggered = true;
            StartCoroutine(FallWithDelay());
        }

        private IEnumerator FallWithDelay()
        {
            yield return new WaitForSeconds(delay);
            _isFalling = true;
        }

        private void FixedUpdate()
        {
            if(_isFalling)
                transform.position += Vector3.down * (velocity * Time.deltaTime);
        }
    }
}
