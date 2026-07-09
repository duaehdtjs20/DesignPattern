using System;
using UnityEngine;

/*
public class Button
{
    public AudioObserver audio;
    public 파티클옵저버 파티클;
    public 조명옵저버 조명;
    public 문옵저버 문

    public void Click()
    {
        audio.play();
        파티클.play();
        조명.on();
        문.open();
    }
}
ButtonSubject
{
    public event Action Clicked;
    public void ClickButton()
    {
        Clicked?.Invoke();
    }
}
*/
// 옵저버 패턴 객체간의 1:N의 관계를 만드는 디자인 패턴이다.
// 한 객체(Subject)의 상태가 변경되거나 이벤트가 발생하면 그 객체를 구독하고 있는 여러객체(Obsever)에게
// 자동으로 알림을 보내준다.
// 쉽게 말하면 야~나한테 무슨일 생기면 알려주께!
// Subject : 이벤트를 발생시키는 객체(내 상태가 바뀌었는걸?)
// Observer : Subject가 알려주는 이벤트를 듣고 있다가 반응하는 객체

// 1. 결합도를 낮출 수 있다.
// -subject는 observer를 몰라도 됨. observer도 subject의 내부 구현을 몰라도 됨.
// 2. 기능 추가가 쉽다.
// 새로운 observer를 추가해도 subject는 수정x
// 유지보수가 쉽다.
// - 기능이 분리되어 있어서 코드를 찾고 수정하기 쉽다.

namespace DesignPatterns.Observer
{
    public class ButtonSubject : MonoBehaviour
    {
        public event Action Clicked;
        public void ClickButton()
        {
            Debug.Log("버튼 클릭 이벤트 발생");
            Clicked?.Invoke();
        }
    }
}
