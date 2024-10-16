using System.Collections;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Movements.Characters;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions.Enemies
{
    public class ExplosiveEnemyFunction : MonoBehaviour
    {
        [SerializeField] private float tempsAvantExplosion = 3f;
        [SerializeField] private float speedFast = 10f;
        [SerializeField] private SpriteRenderer spriteEnemy;
        [SerializeField] private MoveFunction moveFunction;
        [SerializeField] private GameObject objetExplosion;
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;
        [SerializeField] private float bounceSpeed = 7f;

        private bool firstTime = true; 

        private IEnumerator ActivateAndExplose()
        {
            spriteEnemy.color = Color.red;
            moveFunction.SetSpeed(speedFast);
            yield return new WaitForSeconds(tempsAvantExplosion);
        
            spriteEnemy.enabled = false;
            moveFunction.Stop();
            objetExplosion.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D other) 
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups) && firstTime)
            {
                other.GetComponentInParent<Rigidbody2D>().velocity = Vector2.up * bounceSpeed;
                StartCoroutine(ActivateAndExplose());
                firstTime = false;
            }    
        }
    }
}



