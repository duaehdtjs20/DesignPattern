using UnityEngine;

namespace DesignPatterns.MVP
{
    public class ClickDamageController : MonoBehaviour
    {
        [SerializeField] private int damage = 10;
        [SerializeField] private LayerMask targetLayer;

        private Camera mainCamera;
        private void Awake()
        {
            mainCamera = Camera.main;
        }

        void Update()
        {
            if(Input.GetMouseButtonDown(0))
            {
                TryDamage();
            }
        }
        private void TryDamage()
        {
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            if(Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, targetLayer))
            {
                MonsterHealthPresenter presenter = hit.collider.GetComponent<MonsterHealthPresenter>();
                if(presenter != null)
                {
                    presenter.Damage(damage);
                }
            }
        }
    }
}
