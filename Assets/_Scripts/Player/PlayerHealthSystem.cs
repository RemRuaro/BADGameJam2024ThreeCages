using UnityEngine;

public class PlayerHealthSystem : MonoBehaviour
{
    [SerializeField] private DataPlayer _PlayerData;
    [SerializeField] private PlayerHealthBarSlider _HealthBar;

    void Start()
    {
        _PlayerData._PlayerCurrentHealth = _PlayerData._PlayerMaxHealth;
        _HealthBar.SetHealthMax(_PlayerData._PlayerCurrentHealth);
    }

    public void TakeDamage(int amount)
    {
        _PlayerData._PlayerCurrentHealth -= amount;
        _HealthBar.SetHealth(_PlayerData._PlayerCurrentHealth);
    }
}
