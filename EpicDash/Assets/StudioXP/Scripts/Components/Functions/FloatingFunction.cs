using Sirenix.OdinInspector;
using UnityEngine;
#pragma warning disable 108,114

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// Permet de modifier la gravité d'un objet en la multipliant par gravityScale lorsque StartFloating est appelé.
    /// </summary>
    public class FloatingFunction : SXPMonobehaviour
    {   
        [Required("Ajoute le RigidBody2D de l'objet qui va flotter")]
        [SerializeField] private Rigidbody2D rigidbody2D;
        [LabelText("Echelle de gravité")]
        [SerializeField] private float gravityScale = 0.5f;
        
        private float _previousGravityScale;
        private bool _isFloating;

        /// <summary>
        /// Multiplie la gravité de l'objet par gravityScale.
        /// </summary>
        public void StartFloating()
        {
            if (_isFloating) return;
            _isFloating = true;
            _previousGravityScale = rigidbody2D.gravityScale;
            rigidbody2D.gravityScale = gravityScale;
        }

        /// <summary>
        /// Réinitialise la gravité de l'objet à celle par défaut.
        /// </summary>
        public void StopFloating()
        {
            if (!_isFloating) return;
            _isFloating = false;
            rigidbody2D.gravityScale = _previousGravityScale;
        }
    }
}