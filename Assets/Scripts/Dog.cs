using System;
using UnityEngine;

public class Dog : BaseCharakter
{
    [SerializeField]
    private SpriteRenderer _selected;
    public Action<Dog> OnCorral;
    public Action<Dog, Action> OnMoveToDog;

    public float SphereRadius = 4f;

    private LayerMask _groupCharacterMask;
    void Start()
    {
        _groupCharacterMask = 1 << LayerMask.NameToLayer("GroupCharacter");
    }
    public void FixedUpdate()
    {
        Collider[] cows = Physics.OverlapSphere(transform.position, SphereRadius, _groupCharacterMask);
        foreach (var cow in cows)
        {
            if (!cow.CompareTag("Attached"))
            {
                cow.GetComponent<Cow>().Subscribe(this);
                cow.tag = "Attached";
            }
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, SphereRadius);
    }

    public void Select(bool status = false)
    {
        _selected.gameObject.SetActive(status);
    }

    public override void MoveTo(Vector3 targetPosition, Action OnComplete = null)
    {
        base.MoveTo(targetPosition, OnComplete);
        if (OnMoveToDog != null)
        {
            OnMoveToDog(this, null);
        }
    }

    public void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("CoralEnter"))
        {
            if (OnCorral != null)
            {
                OnCorral(this);
            }
        }
    }
}
