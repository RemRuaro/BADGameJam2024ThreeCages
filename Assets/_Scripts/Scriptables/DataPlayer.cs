using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "BGJTC/Create Scriptable Object/Create Player Data")]
public class DataPlayer : ScriptableObject
{
    [Header("Player Navigation Settings")]
    public float _PlayerSpeed;
    public float _PlayerGroundDrag;
    public float _PlayerHeight;
    public float _MouseSensitivityX;
    public float _MouseSensitivityY;

    [Header("Player Health Settings")]
    public int _PlayerMaxHealth;
    public int _PlayerCurrentHealth;

    [Header("Player Attack Settings")]
    public GameObject _PlayerProjectile;
    public float _PlayerRof;
    public float _ProjectileAmount;
    public float _ProjectileSpread;
    public float _ProjectileForce;
    public float _TimeBetweenShots;
    public int _ProjectileDamage;
}
