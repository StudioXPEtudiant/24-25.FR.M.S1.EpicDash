using UnityEngine;
using Sirenix.OdinInspector;

namespace StudioXP.Scripts.Components.Movements.Simple
{
    public class MoveSinusoidal : MonoBehaviour
    {
        [LabelText("Mouvement")]
        [SerializeField] private Vector2 movement;

        [LabelText("Vitesse")]
        [SerializeField] private float speed;

        [LabelText("Amplitude de mouvement")]
        [SerializeField] private float amplitude;

        private Vector3 initialPos;

        private void Start()
        {
            initialPos = transform.position;
        }

        private void Update()
        {
            Vector3 move = movement * Mathf.Sin(Time.time * speed) * amplitude;
            transform.position = initialPos + move;
        }
    }
}
