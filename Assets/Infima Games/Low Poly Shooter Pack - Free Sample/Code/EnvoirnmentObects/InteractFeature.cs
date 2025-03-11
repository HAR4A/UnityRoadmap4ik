using UnityEngine;

public class InteractFeature : MonoBehaviour
{
    [SerializeField] private float _overlapSphereRadius = 3.5f;
    [SerializeField] private bool _showGizmos = true;
    
    private void Update()
    {
        CheckoutKeyDown();
    }
    
    private void CheckCollisions()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, _overlapSphereRadius);
        
        IInteractable closestInteractable = null;
        float closestDistance = Mathf.Infinity;
        
        foreach (Collider collider in colliders)
        {
            if (collider.TryGetComponent<IInteractable>(out var interactable))
            {
                float distance = Vector3.Distance(transform.position, collider.transform.position);
                
                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestInteractable = interactable;
                }
            }
        }

        if (closestInteractable != null)
        {
            closestInteractable.Interact();
        }
    }

    private void CheckoutKeyDown()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CheckCollisions();
        }
    }
    private void OnDrawGizmos()
    {
        if (!_showGizmos) return;
        
        Gizmos.color = Color.green; 
        Gizmos.DrawWireSphere(transform.position, _overlapSphereRadius);
    }

}
