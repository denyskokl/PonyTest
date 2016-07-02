
using UnityEngine;

public class CharacterSpawnManager : MonoBehaviour {

    private GameObject _dogPrefab;
    private GameObject _cowPrefab;

    [SerializeField]
    private BoxCollider _dogCollider;
    [SerializeField]
    private BoxCollider _cowCollider;


    void Start ()
    {
        _dogPrefab = Resources.Load("Characters/Dog") as GameObject;
        _cowPrefab = Resources.Load("Characters/Cow") as GameObject;
    }

    // Update is called once per frame
    void Update () {
	    if(Input.GetKeyUp(KeyCode.Q))
        {
            SpawnCharacter(_dogPrefab, RandomDogPosition());
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            SpawnCharacter(_cowPrefab, RandomCowPosition());
        }
    }

    private void SpawnCharacter(GameObject characterPrefab , Vector3 position)
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


}
