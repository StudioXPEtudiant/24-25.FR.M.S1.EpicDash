using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// AddForceFunction permet d'ajouter la force strength au rigidbody de l'objet lorsque la méthode AddForce est
    /// appelé.
    ///
    /// Si le rigidbody n'est pas défini dans l'inspecteur. Le rigidbody sera recherché dans l'objet ou un de ses enfants.
    /// </summary>
    public class AddForceFunction : SXPMonobehaviour
    {
        [LabelText("Mouvement")]
        [SerializeField] private Vector2 movement;
        
        [FormerlySerializedAs("strengh")]
        [LabelText("Force")]
        [SerializeField] private float strength;

        [SerializeField, LabelText("Rigidbody 2D")] private Rigidbody2D myRigidbody;

        private void Awake()
        {
            if(!myRigidbody)
                myRigidbody = GetComponentInChildren<Rigidbody2D>();
        }

        /// <summary>
        /// Ajoute la force strength au rigidbody de l'objet. Si le rigid body n'est pas défini, lance une exception
        /// </summary>
        public void AddForce()
        {
            myRigidbody.AddForce(movement * strength);
        }
    }
}
