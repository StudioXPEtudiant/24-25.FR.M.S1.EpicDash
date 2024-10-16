using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    ///
    /// ChangeSpriteFunction permet de changer le sprite du spriteRenderer par le sprite défini dans l'inspecteur.
    /// </summary>
    public class ChangeSpriteFunction : SXPMonobehaviour
    {
        [Required("Ajoute le SpriteRenderer dont tu veux changer le Sprite")]
        [SerializeField] private SpriteRenderer spriteRenderer;
        [Required("Ajoute le nouveau Sprite qui va remplacer l'ancien")]
        [SerializeField] private Sprite sprite;

        /// <summary>
        /// Fait le changement de sprite du spriteRenderer.
        /// </summary>
        public void Apply()
        {
            spriteRenderer.sprite = sprite;
        }
    }
}
