using UnityEngine;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;
using StudioXP.Scripts.Components.Functions;

namespace StudioXP.Scripts.Components.Objects
{
    public class DamageEntity : MonoBehaviour
    {
        [SerializeField] private bool destroyParentAfterDamage = false;

        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;

        [LabelText("Nombre de dégâts")]
        [MinValue(0)]
        [SerializeField] private int damages = 1;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups))
            {
                var otherCounterFunc = other.GetComponentInParent<CounterFunction>();

                if(otherCounterFunc)
                {
                    otherCounterFunc.Decrement(damages);
                    if(destroyParentAfterDamage)
                        Destroy(transform.parent.gameObject);
                }
            }
        }
    }
}
