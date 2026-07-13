/*
[Decorator Pattern]
- 기존 객체를 직접 수정하지 않고 객체를 감싸는 방식으로 기능을 추가하는 패턴
- 상속으로  FireSword, PoisonSword, FirePoisonSword... 처럼 클래스를 계속 늘리지 않아도 됨.
- 기본 객체에 필요한 기능을 하나씩 조립할 수 있음

기본검 -> 화염추가 -> 독강화 추가 -> 크리티컬 강화 추가..

- 무기강화
- 버프시스템
- 스킬 추가효과
- 장비 세트 효과..

*/

// 모든 무기가 만드시 가져야 할 기능을 정의
namespace DesignPatterns.Decorator
{
    public interface IWeapon
    {
        string GetName();
        int GetDamage();
    }
}
