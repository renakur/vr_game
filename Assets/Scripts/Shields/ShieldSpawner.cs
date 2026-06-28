using System.Collections.Generic;
using UnityEngine;

public class ShieldSpawner : MonoBehaviour
{
    
    public GameObject shieldPrefab;
    public GameObject badge;
    public List<Transform> spawnPoints = new List<Transform>(); 

    private int shieldsSpawnedCount = 0;
    private const int MAX_SHIELDS = 6;
    private GameObject currentShield;
    private List<Transform> availablePoints = new List<Transform>();

    void Start()
    {
        badge.SetActive(false);
        availablePoints = new List<Transform>(spawnPoints);

        if (availablePoints.Count < MAX_SHIELDS)
        {
            
            return;
        }

        SpawnNextShield();
    }

    void Update()
    {
        
        if (currentShield == null && shieldsSpawnedCount < MAX_SHIELDS)
        {
            SpawnNextShield();
        }
    }

    private void SpawnNextShield()
    {
        
        int randomIndex = Random.Range(0, availablePoints.Count);
        Transform chosenPoint = availablePoints[randomIndex];

        
        availablePoints.RemoveAt(randomIndex);

        currentShield = Instantiate(shieldPrefab, chosenPoint.position, chosenPoint.rotation);
        shieldsSpawnedCount++;

        Shield anim = currentShield.GetComponentInChildren<Shield>();
        if (anim != null)
        {
            anim.OnShieldDestroyed += HandleShieldDestroyed;
        }
    }

    private void HandleShieldDestroyed()
    {
        
        if (shieldsSpawnedCount >= MAX_SHIELDS)
        {
            AllShieldsDestroyed();
        }
    }

    private void AllShieldsDestroyed()
    {
        badge.SetActive(true);
        DoorVisuals.Instance.StartAnimation();
        
    }
}
