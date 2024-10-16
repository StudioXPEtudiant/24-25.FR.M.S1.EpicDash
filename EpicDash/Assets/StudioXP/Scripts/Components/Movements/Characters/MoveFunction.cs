using System;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Handlers;
using StudioXP.Scripts.Game;
using UnityEngine;

namespace StudioXP.Scripts.Components.Movements.Characters
{
    [RequireComponent(typeof(SpriteRendererHandler))]
    [RequireComponent(typeof(AnimatorHandler))]
    [RequireComponent(typeof(Rigidbody2D))]
    public class MoveFunction : MonoBehaviour
    {
        [LabelText("Vitesse")]
        [SerializeField] private float speed = 5;
        
        private SpriteRendererHandler _spriteRendererHandler;
        private AnimatorHandler _animatorHandler;
        private Rigidbody2D _rigidbody;
        
        private int _animatorHorizontalVelocity;
        
        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _spriteRendererHandler = GetComponent<SpriteRendererHandler>();
            _animatorHandler = GetComponent<AnimatorHandler>();
            _animatorHorizontalVelocity = AnimatorHandler.GetAnimatorHash("HorizontalVelocity");
        }

        public void MoveHorizontal(float horizontal)
        {
            if (horizontal == 0)
            {
                Stop();
                return;
            }
            
            Move(horizontal < 0 ? Direction.Left : Direction.Right);
        }

        public void MoveVertical(float vertical)
        {
            if (vertical == 0)
            {
                Stop();
                return;
            }
                
            Move(vertical < 0 ? Direction.Down : Direction.Up);
        }

        public void Move(Direction direction)
        {
            switch (direction)
            {
                case Direction.Left:
                    _rigidbody.velocity = Vector2.left * speed + _rigidbody.velocity * Vector2.up;
                    _spriteRendererHandler.HorizontalFacing = DirectionHorizontal.Left;
                    break;
                case Direction.Right:
                    _rigidbody.velocity = Vector2.right * speed + _rigidbody.velocity * Vector2.up;
                    _spriteRendererHandler.HorizontalFacing = DirectionHorizontal.Right;
                    break;
                case Direction.Up:
                    _rigidbody.velocity = Vector2.up * speed + _rigidbody.velocity * Vector2.right;
                    _spriteRendererHandler.VerticalFacing = DirectionVertical.Up;
                    break;
                case Direction.Down:
                    _rigidbody.velocity = Vector2.down * speed + _rigidbody.velocity * Vector2.right;
                    _spriteRendererHandler.VerticalFacing = DirectionVertical.Down;
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, null);
            }
            
            _animatorHandler.SetAnimatorFloat(_animatorHorizontalVelocity, Mathf.Abs(_rigidbody.velocity.x));
        }

        public void Stop()
        {
            _rigidbody.velocity = Vector2.zero;
        }

        public float GetSpeed()
        {
            return speed;
        }

        public void SetSpeed(float _newSpeed)
        {
            speed = _newSpeed;
        }

    }
}
