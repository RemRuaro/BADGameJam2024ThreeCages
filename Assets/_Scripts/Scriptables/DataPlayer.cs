using UnityEngine;

[CreateAssetMenu(fileName = "PlayerData", menuName = "BGJTC/Create Scriptable Object/Create Player Data")]
public class DataPlayer : ScriptableObject
{
    [Header("Player Controls")]
    public int _PlayerMaxHealth;
    public int _PlayerCurrentHealth;
    public float _PlayerSpeed;
    public float _PlayerGroundDrag;
    public float _PlayerHeight;
    public float _MouseSensitivityX;
    public float _MouseSensitivityY;
}
