using UnityEngine;

public class BadSpawn : MonoBehaviour
{
    [SerializeField] private GameObject sheepPrefab;
    [SerializeField] private int spawnSheepCount; 
    
    void Start()
    {
        for (int i = 0; i < spawnSheepCount; i++)
        {
            var sheepPosition = new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50));
            Instantiate(sheepPrefab, sheepPosition, Quaternion.identity);
        }
    }
 
}
