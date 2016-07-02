using UnityEngine;
using System.Collections;

public class InputManager : MonoBehaviour
{

    private LayerMask _selectableMask;
    [SerializeField]
    private Transform _target;

    private Vector3 _targetOffset = new Vector3(0, 0.5f, 0);

    public Dog CurrentDog;

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
                    Debug.Log(hit.collider.name + " name");
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
                        //need refactor
                        _target.gameObject.SetActive(true);
                        _target.position = hit.point + _targetOffset;
                        if(CurrentDog != null)
                        {
                            CurrentDog.MoveTo(_target.position);
                        }

                    }
                }
        }
    }
}
