using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class Target : MonoBehaviour
{
    [SerializeField] private Transform CameraTrnsform;
    [SerializeField] private InputAction primaryAction;

    [SerializeField] private float explosionRadius;
    [SerializeField] private float explosionForse;

    private void OnEnable()
    {
        primaryAction.Enable();
        primaryAction.performed += OnPrimaryClisk;
    }
    private void OnDisable()
    {
        primaryAction.performed -= OnPrimaryClisk;
        primaryAction.Disable();
    }
    void OnPrimaryClisk(CallbackContext context)
    {
        Ray ray = new Ray();
        ray.origin = CameraTrnsform.position;
        ray.direction = CameraTrnsform.forward;

        bool hit = Physics.Raycast(ray,out RaycastHit hitInfo);

        Collider[] colliders = Physics.OverlapSphere(hitInfo.point,explosionRadius);
        for (int i =0;i<colliders.Length;i++)
        {
            Collider collider = colliders[i];
            if (collider.attachedRigidbody == null) continue;

            Vector3 vector = (collider.attachedRigidbody.position-hitInfo.point);
            Vector3 direction = vector.normalized;
            float distanse = vector.magnitude;
            collider.attachedRigidbody.AddForce(direction*explosionForse);
        }
    }
}
