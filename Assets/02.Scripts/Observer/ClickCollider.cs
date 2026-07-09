using UnityEngine;

namespace DesignPatterns.Observer
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(ButtonSubject))]
    public class ClickCollider : MonoBehaviour
    {
        private ButtonSubject buttonSubject;
        private Collider buttonCollider;
        private Camera mainCamera;

        private void Awake()
        {
            buttonSubject = GetComponent<ButtonSubject>();
            buttonCollider = GetComponent<Collider>();
            mainCamera = Camera.main;
        }
        private void Update()
        {
            CheckClick();
        }
        private void CheckClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (mainCamera == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            bool isHit = Physics.Raycast(ray,out hitInfo, 100.0f);
            if (!isHit) return;

            if(hitInfo.collider == buttonCollider)
            {
                buttonSubject.ClickButton();
            }
        }
    }
}
