using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static EnemyStateMachine;
using State = EnemyStateMachine.State;

public class EnemyBehaviour : MonoBehaviour
{
    public delegate bool BehaviorCondition();
    public abstract class BehaviorNode 
    {
        protected EnemyStateMachine fsm;

        public BehaviorNode(EnemyStateMachine fsm) 
        {
            this.fsm = fsm;
        }
        public abstract void Execute();
        
    }
    public class BehaviorLeaf<T> : BehaviorNode where T : State
    {
        public BehaviorLeaf(EnemyStateMachine fsm) : base(fsm)
        {

        }
        public override void Execute()
        {
            fsm.SwitchState<T>();
        }
    }

    public class BehaviorBranch : BehaviorNode
    {
        private BehaviorNode trueNode;
        private BehaviorNode falseNode;
        private BehaviorCondition condition;
        public BehaviorBranch(EnemyStateMachine fsm, BehaviorNode trueNode,
            BehaviorNode falseNode,BehaviorCondition condition) : base(fsm)
        {
            this.trueNode = trueNode;
            this.falseNode = falseNode;
            this.condition = condition;
        }
        public override void Execute()
        {
            if (condition())
            {
                trueNode.Execute();
            }
            else
            {
                falseNode.Execute();
            }
        }
    }



    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float visionRange = 10f;
    [SerializeField] private float attackRange = 3f;

    public bool isAlive = true;

    private EnemyStateMachine fsm;
    private BehaviorNode tree;

    Collider[] hits;

    Transform player;
    public void Start()
    {
        fsm = GetComponent<EnemyStateMachine>();
        BehaviorLeaf<MeleAttackState> meleeLeaf = new(fsm);
        BehaviorLeaf<DistantAttackState> reangeLeaf = new(fsm);
        BehaviorLeaf<SearchState> searchLeaf = new(fsm);
        BehaviorLeaf<PatrolState> patrolLeaf = new(fsm);

        BehaviorBranch atackType = new(fsm, meleeLeaf, reangeLeaf, IsInmeleeRange);
        BehaviorBranch searchBranch = new(fsm, searchLeaf, patrolLeaf, HasTarget);
        tree = new BehaviorBranch(fsm, atackType, searchBranch, IsPlayerInVision);
    }
    private bool IsPlayerInVision()
    {
        return player != null;
    }
    private bool IsInmeleeRange()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        return distance <= attackRange;
    }

    private bool HasTarget()
    {
        return fsm.currentTarget != null;
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
            player = GetPlayerInVision();
            if (player != null)
            {
                fsm.currentTarget = player;
                fsm.lastSeenPosition = player.position;
            }
            tree.Execute();
            
            
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
