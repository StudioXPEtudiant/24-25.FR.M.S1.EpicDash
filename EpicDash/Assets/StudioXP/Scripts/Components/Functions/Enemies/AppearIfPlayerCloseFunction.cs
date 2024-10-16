using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.AI;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Handlers;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class AppearIfPlayerCloseFunction : MonoBehaviour
    {
        [SerializeField] private GameObject gameObjectEnnemy;
        [SerializeField] private float jumpSpeed = 5;
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        private bool _firstTime = true;

        void Update()
        {
            if (gameObjectEnnemy.GetComponent<Rigidbody2D>().velocity.y >= 0) return;
            
            gameObjectEnnemy.GetComponent<BoxCollider2D>().enabled = true;
            gameObjectEnnemy.GetComponent<PassiveWalkAI>().enabled = true;
            enabled = false;
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if (otherGroupList == null || !otherGroupList.GroupFilter.Match(groups) || !_firstTime) return;
            
            gameObjectEnnemy.GetComponent<RigidbodyHandler>().FreezePositionY(false);
            gameObjectEnnemy.GetComponent<RigidbodyHandler>().FreezePositionX(false);
            gameObjectEnnemy.GetComponent<Rigidbody2D>().velocity = Vector2.up * jumpSpeed;
            _firstTime = false;
        }
    }
}
