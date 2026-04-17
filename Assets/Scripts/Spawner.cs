using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("스폰 시간 설정")]
    public float minSpawnTime = 2f;
    public float maxSpawnTime = 4f;

    [Header("생성할 건물")]
    public GameObject[] buildingPrefabs;

    private void OnEnable()
    {
        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("Spawn", randomTime);
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    void Start()
    {
        //MakeInstance();
    }

    void Spawn()
    {
        MakeInstance();

        float randomTime = Random.Range(minSpawnTime, maxSpawnTime);
        Invoke("Spawn", randomTime);
    }

    void MakeInstance()
    {
        GameObject randomBuilding = buildingPrefabs[Random.Range(0, buildingPrefabs.Length)];
        Instantiate(randomBuilding, transform.position, Quaternion.identity);
    }

}
