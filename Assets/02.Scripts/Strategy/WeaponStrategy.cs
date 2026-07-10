using UnityEngine;

/*
[전략패턴]
- 상황에 따라 알고리즘을 자유롭게 교체하기 위한 패턴

if(weaponType == pistol) 권총발사
else if(weaponType == ShotGun) 샷건발사
else if(weaponType == Rocket) 로켓발사...

근데 문제는...무기가 10개라면....계속 if이 늘어나게됨
새로운 무기가 추가될때마다 기존코드를 계속 건드리게 됨.

전략패턴을 적용 후
playerweaponcontroller

currentWeapon.Fire();

[구성]
Strategy : 전략 인터페이스 또는 추상클래스(공통기능을 정의)
Context : 현재 사용할 전략을 보관하고 실행
Concrete strategy : 실제 알고리즘을 구현함.

상태패턴과 헷갈리지 말것.
상태 패턴은 현재 상태를 관리 하는 패턴
전략 패턴은 행동 방식을 교체 하는 패턴

상태와 전략을 혼용해서 쓰는 경우가 많다.

*/
public class WeaponStrategy : ScriptableObject
{
    [Header("무기 이름")]
    [SerializeField] protected string weaponName;

    public string WeaponName => weaponName;
    
    public virtual void Fire(GameObject owner, Transform firePoint)
    {
        Debug.Log(weaponName + "발사");
    }
}
