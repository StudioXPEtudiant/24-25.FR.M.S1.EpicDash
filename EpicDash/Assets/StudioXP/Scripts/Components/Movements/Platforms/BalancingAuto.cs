using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Components.Movements.Platforms
{
    public class BalancingAuto : MonoBehaviour
    {
        [MaxValue(0)]
        [LabelText("Rotation minimum")]
        [SerializeField] private float minimumRotation = -30;

        [MinValue(0)]
        [LabelText("Rotation maximum")]
        [SerializeField] private float maximumRotation = 30;

        [LabelText("Force de balancement")]
        [SerializeField] private float balanceForce = 0.1f;
        
        private void Awake()
        {
        }

        void Update()
        {
            var currentRotation = transform.localRotation.eulerAngles.z;
            if (currentRotation > 180)
                currentRotation -= 360;

            if (currentRotation > maximumRotation)
            {
                transform.localRotation = Quaternion.Euler(0, 0, maximumRotation);
            }
            else if (currentRotation < minimumRotation)
            {
                transform.localRotation = Quaternion.Euler(0, 0, 360 + minimumRotation);
            }
            else
            {
                if(currentRotation > 0)
                    transform.Rotate(0, 0, -balanceForce);
                else if(currentRotation < 0)
                    transform.Rotate(0, 0, balanceForce);
            }
        }
    }
}
