using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace StudioXP.Scripts.Game
{
    public class CameraBounds : RestrictionBounds
    {
        [LabelText("Bornes")]
        [SerializeField] private Rect bounds;

        [FormerlySerializedAs("gizmoBoundColor")]
        [LabelText("Couleur du gizmo")] [SerializeField]
        private Color gizmoColor = new(45, 245, 176);

        private Camera _camera;
        private float _verticalExtent;
        private float _horizontalExtent;
        
        void Awake()
        {
            _camera = GetComponent<Camera>();
            _verticalExtent = _camera.orthographicSize;  
            _horizontalExtent = _verticalExtent * Screen.width / Screen.height;
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = gizmoColor;
            Gizmos.DrawWireCube(bounds.center, bounds.size);
        }

        public override Vector3 GetBoundedPosition(Vector3 position)
        {
            if (position.x - _horizontalExtent <= bounds.xMin)
                position.x = bounds.xMin + _horizontalExtent;
            else if (position.x + _horizontalExtent >= bounds.xMax)
                position.x = bounds.xMax - _horizontalExtent;
            
            if (position.y - _verticalExtent <= bounds.yMin)
                position.y = bounds.yMin + _verticalExtent;
            else if (position.y + _verticalExtent >= bounds.yMax)
                position.y = bounds.yMax - _verticalExtent;

            return position;
        }
    }
}
