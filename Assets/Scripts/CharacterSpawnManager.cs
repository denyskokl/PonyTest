using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour
{
    public static CharacterSpawnManager Instance;
    private GameObject _dogPrefab;
    private GameObject _cowPrefab;

    public Transform CoralEnter;

    [SerializeField]
    private BoxCollider _dogCollider;
    [SerializeField]
    private BoxCollider _cowCollider;
    [SerializeField]
    private BoxCollider _corelCollider;

    private float _cowOffset = 2f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }


    void Start()
    {
        _dogPrefab = Resources.Load("Characters/Dog") as GameObject;
        _cowPrefab = Resources.Load("Characters/Cow") as GameObject;
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Q))
        {
            SpawnCharacter(_dogPrefab, RandomDogPosition());
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            SpawnCharacter(_cowPrefab, RandomCowPosition());
        }
    }

    private void SpawnCharacter(GameObject characterPrefab, Vector3 position)
    {
        GameObject go = Instantiate(characterPrefab);
        go.transform.position = position;
    }

    private Vector3 RandomCowPosition()
    {
        return new Vector3(Random.Range(
            _cowCollider.transform.position.x + _cowCollider.transform.localScale.x / 2,
            _cowCollider.transform.position.x - _cowCollider.transform.localScale.x / 2), 0,
            Random.Range(
            _cowCollider.transform.position.z + _cowCollider.transform.localScale.z / 2,
            _cowCollider.transform.position.z - _cowCollider.transform.localScale.z / 2
            ));
    }


    private Vector3 RandomDogPosition()
    {
        return new Vector3(Random.Range(
             _dogCollider.transform.position.x + _dogCollider.transform.localScale.x / 2,
             _dogCollider.transform.position.x - _dogCollider.transform.localScale.x / 2), 0,
             Random.Range(
             _dogCollider.transform.position.z + _dogCollider.transform.localScale.z / 2,
             _dogCollider.transform.position.z - _dogCollider.transform.localScale.z / 2
             ));

    }

    public Vector3 RandomCorelPosition()
    {
        return new Vector3(Random.Range(
            _corelCollider.transform.position.x + _corelCollider.transform.localScale.x / 2,
            _corelCollider.transform.position.x - _corelCollider.transform.localScale.x / 2), 0,
            Random.Range(
            _corelCollider.transform.position.z + _corelCollider.transform.localScale.z / 2,
            _corelCollider.transform.position.z - _corelCollider.transform.localScale.z / 2
            ));
    }

    public Vector3 RandomPositionAroundDog(Dog dog)
    {
        return new Vector3(Random.Range(
            dog.transform.position.x + _cowOffset,
             dog.transform.position.x  - _cowOffset), 0,
            Random.Range(
            dog.transform.position.z + _cowOffset,
            dog.transform.position.z - _cowOffset
            ));
    }



}
