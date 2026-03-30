using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static EnemyStateMachine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float attackRange = 3f;

    public bool isAlive = true;

    private EnemyStateMachine fsm;

    Collider[] hits;
    public void Start()
    {
        fsm = GetComponent<EnemyStateMachine>();
    }
    private void Update()
    {
        if (!isAlive)
        {
            Destroy(gameObject);
            return;
        }
        else
        {
            Transform player = GetPlayerInVision();

            if (player != null)
            {
                fsm.currentTarget = player;
                fsm.lastSeenPosition = player.position;

                float distance = Vector3.Distance(transform.position, player.position);

                if (distance <= attackRange)
                {
                    if (!(fsm.currentState is MeleAttackState))
                        fsm.SwitchState(new MeleAttackState(fsm));
                }
                else
                {
                    if (!(fsm.currentState is DistantAttackState))
                        fsm.SwitchState(new DistantAttackState(fsm));
                }
            }
            else
            {
                if (fsm.currentTarget != null)
                {
                    if (!(fsm.currentState is SearchState))
                        fsm.SwitchState(new SearchState(fsm));
                }
                else
                {
                    if (!(fsm.currentState is PatrolState))
                        fsm.SwitchState(new PatrolState(fsm));
                }
            }
        }
    }
    public Transform GetPlayerInVision()
    {
        hits = Physics.OverlapSphere(transform.position, visionRange, playerLayer);

        if (hits.Length > 0)
        {
            return hits[0].transform;
        }

        return null;
    }

}
