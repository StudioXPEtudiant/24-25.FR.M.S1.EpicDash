using StudioXP.Scripts.Components.AI;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class GhostStopFunction : MonoBehaviour
    {
        [SerializeField] private float initialRotationY = 0;
        [SerializeField] private float flippedRotationY = 180;

        private SpriteRenderer spriteRendererAvatar;
        private GameObject avatar;

        private void Start() 
        {
            avatar = GameObject.FindWithTag("Player");
            spriteRendererAvatar = avatar.GetComponentInChildren<SpriteRenderer>();
        }

        void Update()
        {
            transform.position = avatar.transform.position;

            if(spriteRendererAvatar.flipX)
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0,flippedRotationY,0));
            }
            else
            {
                transform.localRotation = Quaternion.Euler(new Vector3(0,initialRotationY,0));
            }
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            if(other.tag == "Ghost" && other.GetComponentInParent<GhostFollowerAI>().GetStopWhenIsSeen())
            {
                other.GetComponentInParent<GhostFollowerAI>().SetIsSeen(true);
            }

        }

        private void OnTriggerExit2D(Collider2D other) 
        {
            if(other.tag == "Ghost" && other.GetComponentInParent<GhostFollowerAI>().GetStopWhenIsSeen())
            {
                other.GetComponentInParent<GhostFollowerAI>().SetIsSeen(false);
            }
        }

    }
}
