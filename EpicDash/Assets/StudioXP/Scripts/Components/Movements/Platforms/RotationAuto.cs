using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Components.Movements.Platforms
{
    public class RotationAuto : MonoBehaviour
    {
        [LabelText("Vitesse")]
        [SerializeField] private float velocity;
        
        private void Update()
        {
            transform.Rotate(0, 0, velocity * Time.deltaTime);
        }
    }
}
