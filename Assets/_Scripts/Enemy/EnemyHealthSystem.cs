using UnityEngine;

public class EnemyHealthSystem : MonoBehaviour
{
    [SerializeField] private DataEnemies _EnemyData;
    public int enemyHealth;

    void Start()
    {
        enemyHealth = _EnemyData._EnemyHealth;
    }
}
