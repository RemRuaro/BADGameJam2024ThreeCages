using UnityEngine;
using UnityEngine.UI;

public class PlayerHealthBarSlider : MonoBehaviour
{
    [SerializeField] private DataPlayer _PlayerData;
    public Slider _HealthBarSlider;

    public void SetHealth(int amount)
    {
        _HealthBarSlider.value = amount;
    }

    public void SetHealthMax(int amount)
    {
        _HealthBarSlider.maxValue = amount;
        SetHealth(amount);
    }
}
