using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour
{
    public Transform CoralEnter;
    public static CharacterSpawnManager Instance;
    private GameObject _dogPrefab;
    private GameObject _cowPrefab;
    private float _cowOffset = 2f;
    
    [SerializeField]
    private BoxCollider _dogCollider;
    [SerializeField]
    private BoxCollider _cowCollider;
    [SerializeField]
    private BoxCollider _corelCollider;
    
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

    public void SpawnCow()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnCharacter(_cowPrefab, RandomCowPosition());
        }
    }

    public void SpawnDog()
    {
        SpawnCharacter(_dogPrefab, RandomDogPosition());
    }


    private void SpawnCharacter(GameObject characterPrefab, Vector3 position)
    {
        GameObject go = Instantiate(characterPrefab);
        go.transform.position = position;
    }

    private Vector3 RandomCowPosition()
    {
        return new Vector3(GenerateRandomPositionX(_cowCollider), 0, GenerateRandomPositionZ(_cowCollider));
    }


    private Vector3 RandomDogPosition()
    {
        return new Vector3(GenerateRandomPositionX(_dogCollider), 0, GenerateRandomPositionZ(_dogCollider));
    }

    public Vector3 RandomCorelPosition()
    {
        return new Vector3(GenerateRandomPositionX(_corelCollider), 0, GenerateRandomPositionZ(_corelCollider));
    }

    private float GenerateRandomPositionX(BoxCollider collider)
    {
        return Random.Range(
            collider.transform.position.x + collider.transform.localScale.x / 2,
            collider.transform.position.x - collider.transform.localScale.x / 2);
    }

    private float GenerateRandomPositionZ(BoxCollider collider)
    {
        return Random.Range(
            collider.transform.position.z + collider.transform.localScale.z / 2,
            collider.transform.position.z - collider.transform.localScale.z / 2);
    }

    public Vector3 RandomPositionAroundDog(Dog dog)
    {
        return new Vector3(
            Random.Range(
            dog.transform.position.x + _cowOffset,
             dog.transform.position.x - _cowOffset),
            0,
            Random.Range(
            dog.transform.position.z + _cowOffset,
            dog.transform.position.z - _cowOffset
            ));
    }
}
