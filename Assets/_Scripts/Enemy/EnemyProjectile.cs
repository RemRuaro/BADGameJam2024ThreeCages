using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] private DataEnemies _EnemyData;
    public ListOfProjectiles _ProjectileType;

    public enum ListOfProjectiles
    {
        Chacnla,
        Raygon
    }

    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (_ProjectileType)
        {
            case ListOfProjectiles.Chacnla:
                if (collision.gameObject.tag == "TagPlayer")
                {
                    collision.gameObject.GetComponent<PlayerHealthSystem>().TakeDamage(_EnemyData._AttackDamageChancla);
            Destroy(this.gameObject);
                }
                break;
            case ListOfProjectiles.Raygon:
                if (collision.gameObject.tag == "TagPlayer")
                {
                    collision.gameObject.GetComponent<PlayerHealthSystem>().TakeDamage(_EnemyData._AttackDamageRaygon);
            Destroy(this.gameObject);
                }
                break;
        }
        if (collision.gameObject.tag == "TagGround")
        {
            Destroy(this.gameObject);
        }
    }
}
