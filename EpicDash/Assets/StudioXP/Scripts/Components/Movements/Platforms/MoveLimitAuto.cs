using Sirenix.OdinInspector;
using StudioXP.Scripts.Events;
using StudioXP.Scripts.Game;
using UnityEditor;
using UnityEngine;

namespace StudioXP.Scripts.Components.Movements.Platforms
{
    public class MoveLimitAuto : MonoBehaviour
    {
        [LabelText("Direction de départ")]
        [SerializeField] private Direction startingDirection;
        
        [LabelText("Position Gauche")]
        [MaxValue(0)]
        [SerializeField] private float leftPosition;
        
        [LabelText("Position Droite")]
        [MinValue(0)]
        [SerializeField] private float rightPosition;
        
        [LabelText("Vitesse")]
        [SerializeField] private float velocity;
        
        [FoldoutGroup("Évènements",false)]
        [LabelText("Vitesse changée")]
        [SerializeField] private Vector2Event velocityChanged;

        [LabelText("Couleur du gizmo")] [SerializeField]
        private Color gizmoColor = new(63, 86, 173);
        
        [HideInInspector] [SerializeField] private Rect bounds;
        
        private Vector2 _initialPosition;
        private float _currentMovement;
        private float _currentVelocity;

        public void SetBounds(Rect rect)
        {
            bounds = rect;
        }
        
        private void Awake()
        {
            _initialPosition = transform.position;
            if (startingDirection == Direction.Down || startingDirection == Direction.Left)
                _currentVelocity = -velocity;
            else
                _currentVelocity = velocity;
        }

        private void FixedUpdate()
        {
            var direction = GetDirection();
            
            _currentMovement += _currentVelocity * Time.deltaTime;
            if (_currentVelocity < 0 && _currentMovement < leftPosition)
            {
                _currentMovement = leftPosition;
                _currentVelocity = velocity;
                velocityChanged.Invoke(_currentVelocity * direction);
            }
            else if (_currentVelocity > 0 && _currentMovement > rightPosition)
            {
                _currentMovement = rightPosition;
                _currentVelocity = -velocity;
                velocityChanged.Invoke(_currentVelocity * direction);
            }
            
            transform.position = _initialPosition + direction * _currentMovement;
        }

        private Vector2 GetDirection()
        {
            return startingDirection switch
            {
                Direction.Down => Vector2.up,
                Direction.Left => Vector2.right,
                Direction.Right => Vector2.right,
                Direction.Up => Vector2.up,
                _ => Vector2.zero
            };
        }
        
#if UNITY_EDITOR
        private void OnDrawGizmosSelected()
        {
            var direction = GetDirection();
            float extent = 0;
            if (direction == Vector2.left)
            {
                direction = Vector2.right;
            }
            else if (direction == Vector2.down)
            {
                direction = Vector2.up;
            }

            if (direction == Vector2.right)
                extent = bounds.size.x / 2;
            else
                extent = bounds.size.y / 2;

            Vector2 position;
            if (Application.isPlaying)
                position = _initialPosition;
            else
                position = transform.position;

            Vector3 start = position + (leftPosition - extent) * direction;
            Vector3 end = position + (rightPosition + extent) * direction;
            Vector3 perpendicular = Vector2.Perpendicular(direction);

            var color = gizmoColor;
            DrawThickLine(start, end, color);
            DrawThickLine(start + perpendicular * 0.5f, start + perpendicular * (-0.5f), color);
            DrawThickLine(end + perpendicular * 0.5f, end + perpendicular * (-0.5f), color);
        }

        private void DrawThickLine(Vector3 start, Vector3 end, Color color)
        {
            Handles.DrawBezier(start, end, start, end, color, null, 4);
        }
#endif
    }
}
