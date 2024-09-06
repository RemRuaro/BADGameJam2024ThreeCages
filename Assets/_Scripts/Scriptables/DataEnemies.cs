using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData", menuName = "BGJTC/Create Scriptable Object/Create Enemy Data")]
public class DataEnemies : ScriptableObject
{
    [Header("NavMesh Settings")]
    public float _HandWalkPointRange;
    public float _HandSightRange;
    public float _HandAttackRange;
    public float _PatrolTimeInterval;

    [Header("General Enemy Settings")]
    public int _EnemyHealth;
    public float _ProjectileForce;

    [Header("Chancla Settings")]
    public GameObject _ChanclaObject;
    public float _AttackRateChancla;
    public int _AttackDamageChancla;

    [Header("Raygon Settings")]
    public GameObject _ParticulateObject;
    public float _AttackRateRaygon;
    public int _AttackDamageRaygon;
    public int _ProjectileAmount;
    public float _ProjectileSpread;
    public float _TimeBetweenAttacks;
    //public float _RaygonAttackDelay;
}
