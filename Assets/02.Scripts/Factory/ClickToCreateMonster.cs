using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.FactoryPattern
{
    public class ClickToCreateMonster : MonoBehaviour
    {
        [SerializeField] private LayerMask layerToClick;
        [SerializeField] private Vector3 offset;
        [SerializeField] private MonsterFactory monsterFactory;

        private List<GameObject> createdMonsters = new List<GameObject>();

        private Camera mainCamera;

        private void Awake()
        {
            mainCamera = Camera.main;
        }
        private void Update()
        {
            CreateMonsterAtClick();
        }
        private void CreateMonsterAtClick()
        {
            if (!Input.GetMouseButtonDown(0)) return;
            if (mainCamera == null) return;

            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            bool isHit = Physics.Raycast(ray, out hitInfo, Mathf.Infinity, layerToClick);

            if (!isHit) return;

            Vector3 createPosition = hitInfo.point + offset;

            // 팩토리에게 랜덤 몬스터 생성을 요청하자.
            IMonsterProduct monster = monsterFactory.CreateRandomMonster(createPosition);

            if(monster is Component component)
            {
                createdMonsters.Add(component.gameObject);
            }
        }
        private void OnDestroy()
        {
            foreach (GameObject monster in createdMonsters)
            {
                if(monster != null)
                {
                    Destroy(monster);
                }
            }
            createdMonsters.Clear();
        }
    }
}
