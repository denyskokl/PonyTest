using UnityEngine;

public class InputManager : MonoBehaviour
{
    public Dog CurrentDog;
    [SerializeField]
    private Transform _target;
    private LayerMask _selectableMask;
    private Vector3 _targetOffset = new Vector3(0, 0.5f, 0);

    void Start()
    {
        _selectableMask = ~(1 << LayerMask.NameToLayer("GroupCharacter"));
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null)
                {
                    if (hit.collider.tag == "Сorral") return;
                    var newDog = hit.collider.GetComponent<Dog>();
                    if (newDog != null)
                    {
                        if (CurrentDog != null)
                        {
                            CurrentDog.Select(false);
                        }
                        CurrentDog = newDog;
                        CurrentDog.Select(true);

                        _target.gameObject.SetActive(false);
                    }
                    else
                    {
                        _target.gameObject.SetActive(true);
                        _target.position = hit.point + _targetOffset;
                        if (CurrentDog != null)
                        {
                            CurrentDog.MoveTo(_target.position);
                        }
                    }
                }
        }
    }
}
