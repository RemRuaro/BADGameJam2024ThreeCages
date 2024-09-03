using System.Collections;
using System.Collections.Generic;
using UnityEditor.MPE;
using UnityEngine;
using UnityEngine.AI;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] DataEnemies _EnemyData;

    // Temporarily disabled
    //Rigidbody enemyRb;

    [SerializeField] private NavMeshAgent _NavigationMeshAgent;
    [SerializeField] private Transform _PlayerTarget;
    [SerializeField] private LayerMask _WhatIsPlayer;
    [SerializeField] private LayerMask _WhatIsGround;
    public Vector3 _WalkPoint;
    [SerializeField] private Vector3 _DistanceToWalkPoint;
    [SerializeField] private bool _WalkPointSet;
    [SerializeField] private Transform _AttackPoint;
    
    // Temporarily disabled
    // [SerializeField] private Vector3 _WalkPointMagnitude;
    
    public bool _PlayerInSightRange;
    public bool _PlayerInAttackRange;
   
    bool alreadyAttacked;
    float currentTime;

    private void Awake()
    {
        _PlayerTarget = GameObject.FindGameObjectWithTag("TagPlayer").transform;
        _NavigationMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        // Temporarily disabled
        //enemyRb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _PlayerInSightRange = Physics.CheckSphere(transform.position, _EnemyData._HandSightRange, _WhatIsPlayer);
        _PlayerInAttackRange = Physics.CheckSphere(transform.position, _EnemyData._HandAttackRange, _WhatIsPlayer);

        if (!_PlayerInSightRange && !_PlayerInAttackRange) HandInPatrol();
        else if (_PlayerInSightRange && !_PlayerInAttackRange) HandSeekPlayer();
        else if (_PlayerInSightRange && _PlayerInAttackRange) HandAttackPlayer();
    }

    private void HandInPatrol()
    {
        if (!_WalkPointSet) HandLookForWalkPoint();
        else if (_WalkPointSet) _NavigationMeshAgent.SetDestination(_WalkPoint);

        _DistanceToWalkPoint = transform.position - _WalkPoint;

        // Temporarily disabled
        //_WalkPointMagnitude = enemyRb.velocity;
        //_WalkPointMagnitude = Vector3.forward;

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

    private void HandAttackPlayer()
    {
        _NavigationMeshAgent.SetDestination(transform.position);
        transform.LookAt(_PlayerTarget);

        if(!alreadyAttacked)
        {
            // Projectile attack
            Rigidbody projectileRb = Instantiate(_EnemyData._ChanclaObject, _AttackPoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            projectileRb.AddForce(transform.forward * _EnemyData._ProjectileForce, ForceMode.Impulse);

            alreadyAttacked = true;
            
            Invoke(nameof(HandResetAttack), _EnemyData._HandAttackRate);
        }
    }

    private void HandResetAttack()
    {
        alreadyAttacked = false;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, _EnemyData._HandSightRange);
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, _EnemyData._HandAttackRange);
    }
}
