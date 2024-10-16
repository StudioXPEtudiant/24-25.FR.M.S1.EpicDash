using UnityEngine;
using UnityEngine.Events;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Common;

namespace StudioXP.Scripts.Components.Objects
{
    public class TriggerEvent : MonoBehaviour
    {
        [LabelText("Groupes")]
        [SerializeField] private GroupFilter groups;

        [FoldoutGroup("Évènements")]
        [LabelText("Lors de la détection")]
        [SerializeField] private UnityEvent triggerEvent;

        private void OnTriggerEnter2D(Collider2D other)
        {
            var otherGroupList = other.GetComponent<GroupList>();

            if(otherGroupList != null && otherGroupList.GroupFilter.Match(groups))
            {
                triggerEvent.Invoke();
            }
        }
    }
}
