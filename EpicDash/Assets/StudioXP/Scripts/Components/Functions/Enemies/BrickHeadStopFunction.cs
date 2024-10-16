using System.Collections;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class BrickHeadStopFunction : MonoBehaviour
    {
        [SerializeField] private float vitesseRemonter = 10;
        [SerializeField] private BrickHeadStartFunction brickHeadStart;
        [SerializeField] private Collider2D hazardCollider;
        [SerializeField] private LayerMask layerToDetect; 
        [SerializeField] private AnimatorHandler animHandler;

        private Vector3 initialPosition;

        void Start()
        {
            initialPosition = transform.parent.position;
            hazardCollider.enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(layerToDetect == (layerToDetect | (1 << other.gameObject.layer)))
            {
                brickHeadStart.SetIsAtteri(true);
                hazardCollider.enabled = false;
                animHandler.SetAnimatorBoolFalse("IsMoving");
                StartCoroutine(ActivateAndExplose());
            }
        }
    
        private IEnumerator ActivateAndExplose()
        {
            while(Vector3.Distance(transform.parent.position, initialPosition) > 0.001f)
            {
                transform.parent.position = Vector3.MoveTowards(transform.parent.position, initialPosition, vitesseRemonter * Time.deltaTime);
                yield return null;
            }
            brickHeadStart.SetCanMove(true);
        }
    }
}


