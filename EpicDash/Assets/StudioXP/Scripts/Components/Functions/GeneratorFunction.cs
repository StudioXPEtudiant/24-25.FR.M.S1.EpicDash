using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Components.Functions
{
    /// <summary>
    /// Une fonction permet d'exécuter une action spécifique à partir d'un évenement Unity.
    /// 
    /// Fait apparaitre un prefab spécifique dans le monde.
    /// </summary>
    public class GeneratorFunction : MonoBehaviour
    {
        [AssetsOnly]
        [SerializeField] 
        private GameObject prefabToGenerate;
        [AssetsOnly]
        [SerializeField]
        private GameObject [] randomPrefabToGenerate;
        
        [BoxGroup("Options pour : Generate and throw at target")]
        [SerializeField]
        private GameObject targetGameObject;
        [BoxGroup("Options pour : Generate and throw at target")]
        [SerializeField]
        private float projectileSpeed = 4;
        
        private void Start()
        {
            if(targetGameObject == null)
            {
                targetGameObject = GameObject.FindGameObjectWithTag("Player");
            }
        }

        /// <summary>
        /// Fait apparaitre un prefab dans le monde.
        /// </summary>
        public void Generate()
        {
            var prefabGenerated = Instantiate(prefabToGenerate, transform);
            prefabGenerated.transform.localPosition = new Vector3(0,0,0);
        }
        
        /// <summary>
        /// Fait apparaitre plusieurs prefab dans le monde
        /// </summary>
        /// <param name="quantity"></param>
        public void Generate(int quantity)
        {
            for(var i = 0 ; i < quantity ; i++)
            {
                var prefabGenerated = Instantiate(prefabToGenerate, transform);
                prefabGenerated.transform.localPosition = new Vector3(0,0,0);
            }
        }

        /// <summary>
        /// Fait apparaitre un prefab au hasard à partir de la liste aléatoire.
        /// </summary>
        public void GenerateRandom()
        {
            var prefabGenerated = Instantiate(randomPrefabToGenerate[Random.Range(0,randomPrefabToGenerate.Length)], transform);
            prefabGenerated.transform.localPosition = new Vector3(0,0,0);      
        }
        
        /// <summary>
        /// Fait apparaitre un prefab et le lance vers le joueur en lui mettant une velocité. Le prefab doit avoir un Rigidbody2D.
        /// </summary>
        public void GenerateAndThrowAtTarget()
        {
            var prefabGenerated = Instantiate(prefabToGenerate, transform);
            prefabGenerated.transform.localPosition = new Vector3(0,0,0);

            prefabGenerated.transform.up = transform.position - targetGameObject.transform.position; 
            prefabGenerated.GetComponent<Rigidbody2D>().velocity = prefabGenerated.transform.up * - projectileSpeed;
            prefabGenerated.transform.parent = null;
        }
    }
}
