using System;
using Sirenix.OdinInspector;
using StudioXP.Scripts.Components.Handlers;
using StudioXP.Scripts.Events;
using StudioXP.Scripts.Game;
using UnityEngine;
using UnityEngine.Events;

namespace StudioXP.Scripts.Components.AI
{
    /// <summary>
    /// Fait marcher l'ennemi vers le joueur
    /// Hérite de <see cref="PassiveWalkAI"/>
    /// </summary>
    public class WalkTowardsPlayerAI : PassiveWalkAI
    {
        [LabelText("Temps de réaction")] [SerializeField]
        private float reactionTime = 0.2f;

        private GameObject _player;
        private float _reactionCounter;

        private void Start()
        {
            _player = GameObject.FindWithTag("Player");
        }

        void Update()
        {
            if (Stopped) return;
            
            _reactionCounter += Time.deltaTime;
            if (_reactionCounter < reactionTime)
                return;

            _reactionCounter = 0;

            var diffX = _player.transform.position.x - transform.position.x;

            if (diffX > 0 || ColliderHandler.IsTouching(Direction.Left, blockingLayers))
                Direction = Direction.Right;

            if (diffX < 0 || ColliderHandler.IsTouching(Direction.Right, blockingLayers))
                Direction = Direction.Left;

            Walk(Direction);
        }
    }
}
