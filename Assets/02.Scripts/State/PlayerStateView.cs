using DesignPatterns.StatePattern;
using TMPro;
using UnityEngine;

namespace DesignPatterns.StatePattern
{
    [RequireComponent(typeof(PlayerController))]
    public class PlayerStateView : MonoBehaviour
    {
        [SerializeField] private TMP_Text labelText;
        private PlayerController player;
        private SimplePlayerStateMachine playerStateMachine;
        private MeshRenderer meshRenderer;

        private void Awake()
        {
            player = GetComponent<PlayerController>();
            meshRenderer = GetComponent<MeshRenderer>();
        }
        void Start()
        {
            playerStateMachine = player.PlayerStateMachine;
            playerStateMachine.stateChanged += OnStateChanged;
        }
        private void OnDestroy()
        {
            if(playerStateMachine != null)
            {
                playerStateMachine.stateChanged -= OnStateChanged;
            }
        }
        private void OnStateChanged(IState state)
        {
            if(labelText != null)
            {
                labelText.text = state.GetType().Name;
                labelText.color = state.MeshColor;
            }
            ChangeMeshColor(state);
        }
        private void ChangeMeshColor(IState state)
        {
            if (meshRenderer == null) return;

            meshRenderer.material.SetColor("_BaseColor", state.MeshColor);
        }
    }

}
