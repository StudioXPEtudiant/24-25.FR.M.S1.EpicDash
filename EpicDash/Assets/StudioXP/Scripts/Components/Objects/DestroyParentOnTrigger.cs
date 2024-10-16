using UnityEngine;

namespace StudioXP.Scripts.Components.Objects
{
    public class DestroyParentOnTrigger : MonoBehaviour
    {
        [SerializeField] private int [] blockingLayers;

        private void OnTriggerEnter2D(Collider2D other) 
        {
            foreach (var blockingLayer in blockingLayers)
            {
                if(other.gameObject.layer == blockingLayer)
                {
                    Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
