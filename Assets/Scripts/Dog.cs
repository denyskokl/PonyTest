using UnityEngine;

public class Dog : BaseCharakter
{
    [SerializeField]
    private SpriteRenderer _selected;

    public float SphereRadius = 4f;
    public void FixedUpdate()
    {
        Physics.OverlapSphere(transform.position, SphereRadius);
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    public void Select(bool status = false)
    {
        _selected.gameObject.SetActive(status);
    }

}
