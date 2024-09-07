using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] private DataPlayer _PlayerData;

    void Start()
    {
        Destroy(this.gameObject, 1.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TagEnemy")
        {
            collision.gameObject.GetComponent<EnemyHealthSystem>().enemyHealth -= _PlayerData._ProjectileDamage;
            Destroy(this.gameObject);
        }
    }
}
