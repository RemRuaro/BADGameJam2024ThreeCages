using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [Header("Refernces")]
    [SerializeField] private DataEnemies _EnemyData;
    [SerializeField] private EnemyHealthSystem _HealthSystem;
    public WeaponList _WeaponUsed;
    [SerializeField] private Transform _AttackPoint;

    [Header("NavMesh Settings")]
    [SerializeField] private NavMeshAgent _NavigationMeshAgent;
    [SerializeField] private Transform _PlayerTarget;
    [SerializeField] private LayerMask _WhatIsPlayer;
    [SerializeField] private LayerMask _WhatIsGround;
    public Vector3 _WalkPoint;
    [SerializeField] private Vector3 _DistanceToWalkPoint;
    [SerializeField] private bool _WalkPointSet;
    public bool _PlayerInSightRange;
    public bool _PlayerInAttackRange;
    bool alreadyAttacked;
    float currentTime;
    Rigidbody projectileRb;
    Vector3 attackDirection;

    public enum WeaponList
    {
        Chancla,
        Raygon
    }

    private void Awake()
    {
        _PlayerTarget = GameObject.FindGameObjectWithTag("TagPlayer").transform;
        _NavigationMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {

    }

    void Update()
    {
        _PlayerInSightRange = Physics.CheckSphere(transform.position, _EnemyData._HandSightRange, _WhatIsPlayer);
        _PlayerInAttackRange = Physics.CheckSphere(transform.position, _EnemyData._HandAttackRange, _WhatIsPlayer);

        if (!_PlayerInSightRange && !_PlayerInAttackRange) HandInPatrol();
        else if (_PlayerInSightRange && !_PlayerInAttackRange) HandSeekPlayer();
        else if (_PlayerInSightRange && _PlayerInAttackRange) HandAttackPlayer();

        if (_HealthSystem.enemyHealth <= 0) Destroy(this.gameObject);
    }

    private void HandInPatrol()
    {
        if (!_WalkPointSet) HandLookForWalkPoint();
        else if (_WalkPointSet) _NavigationMeshAgent.SetDestination(_WalkPoint);

        _DistanceToWalkPoint = transform.position - _WalkPoint;

        if (currentTime < _EnemyData._PatrolTimeInterval) currentTime += Time.deltaTime;
        else
        {
            currentTime = 0.0f;
            _WalkPointSet = false;
        }
    }

    private void HandLookForWalkPoint()
    {
        float randomX = Random.Range(-_EnemyData._HandWalkPointRange, _EnemyData._HandWalkPointRange);
        float randomZ = Random.Range(-_EnemyData._HandWalkPointRange, _EnemyData._HandWalkPointRange);
        
        _WalkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(_WalkPoint, -transform.up, 2f, _WhatIsGround)) _WalkPointSet = true;
    }

    private void HandSeekPlayer()
    {
        _NavigationMeshAgent.SetDestination(_PlayerTarget.position);
    }

    Vector3 directedForwards = Vector3.zero;

    int projectilesFired;

    private void HandAttackPlayer()
    {
        _NavigationMeshAgent.SetDestination(transform.position);
        transform.LookAt(_PlayerTarget);

        if(!alreadyAttacked)
        {
            // Projectile attack
            switch (_WeaponUsed)
            {
                case WeaponList.Chancla:
                    attackDirection = _PlayerTarget.position - _AttackPoint.position;
                    
                    projectileRb = Instantiate(_EnemyData._ChanclaObject, _AttackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
                    directedForwards = transform.forward + attackDirection.normalized;
                    projectileRb.AddForce((transform.forward + attackDirection.normalized) * _EnemyData._ProjectileForce, ForceMode.Impulse);
                    
                    break;
                case WeaponList.Raygon:
                    projectilesFired = 0;
                    RaygonAttack();
                    break;
            }

            alreadyAttacked = true;
            switch (_WeaponUsed)
            {
                case WeaponList.Chancla:
                    Invoke(nameof(HandResetAttack), _EnemyData._AttackRateChancla);
                    break;
                case WeaponList.Raygon:
                    Invoke(nameof(HandResetAttack), _EnemyData._AttackRateRaygon);
                    break;
            }
        }
    }

    private void HandResetAttack()
    {
        alreadyAttacked = false;
    }

    private void RaygonAttack()
    {
        float x = Random.Range(-_EnemyData._ProjectileSpread, _EnemyData._ProjectileSpread);
        float y = Random.Range(-_EnemyData._ProjectileSpread, _EnemyData._ProjectileSpread);
        float z = Random.Range(-_EnemyData._ProjectileSpread, _EnemyData._ProjectileSpread);

        attackDirection = _PlayerTarget.position - _AttackPoint.position;
        Vector3 sprayDirection = attackDirection + new Vector3(x, y, z);

        projectileRb = Instantiate(_EnemyData._ParticulateObject, _AttackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
        directedForwards = transform.forward + sprayDirection.normalized;
        projectileRb.AddForce((transform.forward + sprayDirection.normalized) * _EnemyData._ProjectileForce, ForceMode.Impulse);

        projectilesFired++;

        if (projectilesFired < _EnemyData._ProjectileAmount)
        {
            Invoke(nameof(RaygonAttack), _EnemyData._TimeBetweenAttacks);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _EnemyData._HandSightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _EnemyData._HandAttackRange);
    }
}
