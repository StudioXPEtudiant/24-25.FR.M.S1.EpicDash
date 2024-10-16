using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// BooleanGateFunction a le même comportement que ToggleFunction. (Classe superflue, TODO: À supprimer)
    /// </summary>
    public class BooleanGateFunction : SXPMonobehaviour
    {
        [LabelText("Valeur de départ")]
        [SerializeField] private bool startValue;
        [LabelText("Exécution")]
        [SerializeField] private UnityEvent onExecute;
        [LabelText("Activation")]
        [SerializeField] private UnityEvent onActivate;
        [LabelText("Desactivation")]
        [SerializeField] private UnityEvent onDeactivate;

        private bool _activated;
        
        public void SetActive(bool activated)
        {
            if (_activated == activated) return;
            
            if(activated)
                onActivate.Invoke();
            else
                onDeactivate.Invoke();
            
            _activated = activated;
        }

        public void Execute()
        {
            if (!_activated) return;
            onExecute.Invoke();
        }

        private void Awake()
        {
            _activated = startValue;
        }
    }
}
