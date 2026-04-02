using UnityEngine;

public class EnemyStateMachine : MonoBehaviour
{
    public State currentState;

    [SerializeField] private float patrolRadius = 10f;
    [SerializeField] private float moveSpeed = 3f;

    [HideInInspector] public Vector3 startPosition;

    public Transform currentTarget;
    public Vector3 lastSeenPosition;

    private Renderer rend;

    public Gun gun;

    void Start()
    {
        startPosition = transform.position;
        rend = GetComponent<Renderer>();
        SwitchState(new PatrolState(this));

    }

    void Update()
    {
        currentState?.Update();
    }

    public void SwitchState(State newState)
    {
        currentState?.Exit();
        currentState = newState;
        currentState.Enter();
    }

    // ================= BASE STATE =================
    public abstract class State
    {
        protected EnemyStateMachine stateMachine;

        public State(EnemyStateMachine stateMachine)
        {
            this.stateMachine = stateMachine;
        }

        public virtual void Enter() { }
        public virtual void Update() { }
        public virtual void Exit() { }
    }

    // ================= Patrol =================
    public class PatrolState : State
    {
        private Vector3 targetPoint;
        [SerializeField] private float rotationSpeed = 5f;
        public PatrolState(EnemyStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            stateMachine.SetColor(Color.green);
            SetNewPoint();
            Debug.Log("Enter Patrol");
        }

        public override void Update()
        {
            Vector3 target = new Vector3(
            targetPoint.x,
            stateMachine.transform.position.y,
            targetPoint.z);

            // движение к точке
            Vector3 direction = target - stateMachine.transform.position;
            direction.y = 0f; // убираем наклон вверх/вниз

            Quaternion targetRotation = Quaternion.LookRotation(direction);

            stateMachine.transform.rotation = Quaternion.Lerp(
            stateMachine.transform.rotation,
            targetRotation,
            rotationSpeed * Time.deltaTime);

            stateMachine.transform.position = Vector3.MoveTowards(
                stateMachine.transform.position,
                target,
                stateMachine.moveSpeed * Time.deltaTime
            );

            float distance = Vector3.Distance(
                stateMachine.transform.position,
                targetPoint
            );

            if (distance < 0.5f)
            {
                SetNewPoint();
            }
        }
        private void SetNewPoint()
        {
            Vector2 randomCircle = Random.insideUnitCircle * stateMachine.patrolRadius;

            targetPoint = new Vector3(
                stateMachine.startPosition.x + randomCircle.x,
                stateMachine.startPosition.y,
                stateMachine.startPosition.z + randomCircle.y
            );
        }
        public override void Exit()
        {
            Debug.Log("Exit Idle");
        }

    }

    // ================= Search =================
    public class SearchState : State
    {
        public SearchState(EnemyStateMachine stateMachine) : base(stateMachine) { }
        private float rotationSpeed = 5f;
        public override void Enter()
        {
            stateMachine.SetColor(Color.yellow);
            Debug.Log("Enter Chase");
        }

        public override void Update()
        {
            Vector3 target = stateMachine.lastSeenPosition;

            // фикс Y
            target.y = stateMachine.transform.position.y;

            // направление движения
            stateMachine.Look(stateMachine);

            // движение
            stateMachine.transform.position = Vector3.MoveTowards(
                stateMachine.transform.position,
                target,
                stateMachine.moveSpeed * Time.deltaTime
            );

            float distance = Vector3.Distance(
                stateMachine.transform.position,
                target
            );

            if (distance < 0.5f)
            {
                stateMachine.currentTarget = null; 
            }
        }

        public override void Exit()
        {
            Debug.Log("Exit Chase");
        }
    }

    // ================= DISTANT ATTACK =================

    public class DistantAttackState : State
    {
        float shootCooldown = 1f;
        float timer;

        public DistantAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            timer = 0;
            stateMachine.SetColor(Color.red);
            Debug.Log("DistantAttackState");
        }

        public override void Update()
        {
            if (stateMachine.currentTarget == null) return;

            timer += Time.deltaTime;

            stateMachine.Look(stateMachine);

            // Стрельба
            if (timer >= shootCooldown)
            {
                timer = 0;

                stateMachine.gun.Shoot(stateMachine.currentTarget.position);
            }
        }
    }

    // ================= MELE ATTACK =================
    public class MeleAttackState : State
    {
        private float timer;

        private float attackCooldown = 1.2f;
        private float damage = 100f;

        public MeleAttackState(EnemyStateMachine stateMachine) : base(stateMachine) { }

        public override void Enter()
        {
            timer = 0;
            stateMachine.SetColor(Color.cyan);
            Debug.Log("Melee Attack");
        }

        public override void Update()
        {
            if (stateMachine.currentTarget == null) return;

            stateMachine.Look(stateMachine);

            timer += Time.deltaTime;

            if (timer >= attackCooldown)
            {
                timer = 0;

                Attack();
            }
        }

        void Attack()
        {
            PlayerHP player = stateMachine.currentTarget.GetComponent<PlayerHP>();

            if (player != null)
            {
                player.TakeDamage(damage);
                Debug.Log("Enemy hit player!");
            }
        }

        public override void Exit() { }
    }

    public void Look(EnemyStateMachine stateMachine)
    {
            Vector3 direction = stateMachine.currentTarget.position - stateMachine.transform.position;
            direction.y = 0;

            if (direction != Vector3.zero)
            {
                Quaternion rot = Quaternion.LookRotation(direction);
                stateMachine.transform.rotation = Quaternion.Lerp(
                    stateMachine.transform.rotation,
                    rot,
                    5f * Time.deltaTime
                );
            }
    }
    public void SetColor(Color color)
    {
        if (rend != null)
        {
            rend.material.color = color;
        }
    }
}
