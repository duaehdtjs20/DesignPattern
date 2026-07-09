using DesignPatterns.FactoryPattern;
using Unity.VisualScripting;
using UnityEngine;

public class MonsterBase : MonoBehaviour, IMonsterProduct
{

    private MonsterData monsterData;
    private int currentHp;
    private int attack;
    private float moveSpeed;
    private Renderer render;
    public string MonsterName => monsterData.MonsterName;

    private void Awake()
    {
        render = GetComponent<Renderer>();
    }

    public void Initialize(MonsterData data)
    {
        if (data == null) return;
        currentHp = data.MaxHp;
        attack = data.Attack;
        moveSpeed = data.MoveSpeed;
        monsterData = data;

        if(render != null)
        {
            // 몬스터 색상을 데이터에 설정된 색상으로 바꾸자
            render.material.color = monsterData.MonsterColor;
        }
        Debug.Log(monsterData.MonsterName + "생성됨 / HP : " + currentHp + " / Attack : " + attack);
    }

    public void TakeDamage(int damage)
    {
        currentHp = damage;
        if(currentHp <= 0)
        {
            // 죽음
            Die();
        }
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
