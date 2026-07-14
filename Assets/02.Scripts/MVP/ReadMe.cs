/*
[MVC, MVP, MVVM]
- 화면, 데이터, 사용자 입력을 분리해서 관리하기 위한 UI 아키텍처 패턴
- UI코드와 실제 데이터 처리 코드를 분리해서 유지보수를 쉽게 하자.
- 누가 화면을 제어하는지, view가 Model을 직접 알고 있는지, 데이터가 화면에 어떻게 반양되는지 차이가 있음.

[Model]
- 게임이나 프로그램의 실제 데이터를 담당
ㄴ 플레이어Hp, 골드, exp, 인벤 데이터, 로그인정보...서버에서 받은데이터..데미지..

[View]
- 사용자에게 보여지는 화면
ㄴ Text, Button, HUD...

[MVC]
- model(데이터랑 비즈니스 로직), view(화면표시), controller(사용자 입력처리와 Model조작)
- 사용자의 입력을 컨트롤러가 받고 컨트롤러가 모델을 변경 -> 변경된 결과를 View가 표시한다.
- 사용자(입력) -> Controller -> (데이터 변경 요청) -> Model -> (변경결과) -> View -> (화면갱신)
---------------------------------------------------------------------------------------------------
[MVP]
- model, view, presenter
- 사용자 -> view(입력 이벤트) -> presenter -> model -> presenter -> view
- 데미지 버튼 클릭 -> view가 클릭 이벤ㅌ를 감지 -> presenter.OndamageClicked() -> model.TakeDamage(1) -> presenter 가 현재 HP 읽음 -> View.UpdateHp() -> HP UI 갱신

[MVVM]
- model, View, ViewModel

*/