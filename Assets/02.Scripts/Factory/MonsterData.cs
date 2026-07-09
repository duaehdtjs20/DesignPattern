using UnityEngine;

[CreateAssetMenu(fileName = "MonsterData", menuName = "Factory/Monster Data")]
public class MonsterData : ScriptableObject 
{
    [SerializeField] private string monsterName;
    [SerializeField] private int maxHp;
    [SerializeField] private int attack;
    [SerializeField] private float moveSpeed;
    [SerializeField] private Color monsterColor = Color.white;

    public string MonsterName => monsterName;
    public int MaxHp => maxHp;
    public int Attack => attack;
    public float MoveSpeed => moveSpeed;
    public Color MonsterColor => monsterColor;
}
