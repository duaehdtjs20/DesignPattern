using UnityEngine;

/*
[Facade Pattern]
- 복잡한 여러 클래스나 시스템을 단순한 창구의 역할을 하는 클래스로 감싸서 사용하는 패턴
- 내부에서는 여러 복잡한 시스템이 있어도 외부에서는 Facade 클래스 하나만 보고 쉽게 사용한다.

- AudioManager
- UIManager
- SaveManager
- PlayerManager
- InventoryManager
...
여러 매니저를 직접 각각 호출하는 대신에
GameFacade.StartGame();
GameFacade.GameOver();

-------------------------------------
AudioManager.Instance.PlayBGM();
UIManager.Instance.OpenMainUI();
SaveManager.Instance.Load();
--------------------------------------

- 호출하는 쪽이 내부 구조를 몰라도 된다.
버튼, NPC, 스킬, 퀘스트 같은 클래스가 AudioManager, UIManager, SaveManager...등등을 전부 알필요가 없다.

그냥 Facade에게 요청하면 됨.

GameFacade.Instance.OpenShop();
내부에서는
- 상점 UI열기
- 효과음 재생하고
- 기타등등...
와 같은 작업을 Facade가 대신 처리함.
1. 게임시작 처리
- 세이브 데이터를 로드
- 플레이어를 생성
- UI초기화
- BGM 재생
- 게임 상태 변경..

GameFacade.Instance.StartGame();

GameFacade.Instance.ChangeScene("씬이름");

*/

namespace DesignPatterns.Facade
{
    public class GameFacade : MonoBehaviour
    {
        [SerializeField] private UIManager uIManager;
        [SerializeField] private AudioManager audioManager;
        [SerializeField] private SaveManager saveManager;
        [SerializeField] private PlayerManager playerManager;
        void Start()
        {
            ShowMainMenu();
        }

        private void ShowMainMenu()
        {
            uIManager.ShowMainUI();
            audioManager.PlayBGM("아무거나");
            playerManager.RemovePlayer();
        }
        public void StartGame()
        {
            saveManager.SaveGame();
            playerManager.SpawnPlayer();
            uIManager.ShowGameUI();
            audioManager.PlayBGM("Game");
            audioManager.PlaySFX("Start");
        }
    }
}
