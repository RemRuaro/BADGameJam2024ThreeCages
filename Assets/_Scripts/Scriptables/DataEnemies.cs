using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName = "BGJTC/Create Scriptable Object/Create Enemy Data")]
public class DataEnemies : ScriptableObject
{
    [Header("Enemy Behavior")]
    public float _HandWalkPointRange;
    public float _HandSightRange;
    public float _HandAttackRange;
    public float _HandAttackRate;
    public GameObject _ChanclaObject;
    public float _ProjectileForce;
    public float _PatrolTimeInterval;
    public float _Speed;
}
