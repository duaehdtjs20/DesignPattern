using UnityEngine;

namespace DesignPatterns.Facade
{
    public class AudioManager : MonoBehaviour
    {
        public void PlayBGM(string bgm)
        {
            // 실제 오디오를 재생하는 로직
        }
        public void StopBGM()
        {
            // 정지하는 로직
        }
        public void PlaySFX(string sfxName)
        {
            // 효과음 재생하는 로직
        }
    }
}
