using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField] float spawnDelay;

    WaitForSeconds wait;

    [SerializeField] List<Rect> spawnArea;
    [SerializeField] Color color = new Color(1, 0, 0, 0.5f);

    List<GameObject> asteroidList=new List<GameObject>();
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        wait=new WaitForSeconds(spawnDelay);
        StartCoroutine(SumAstroid());
    }
    IEnumerator SumAstroid()
    {
        while(true)
        {
            yield return wait;
            SpawnAstroid();
        }
    }
    private void SpawnAstroid()
    {

        Rect spawnRect=spawnArea[Random.Range(0,spawnArea.Count)];

        Vector2 randPos = new Vector2(Random.Range(spawnRect.xMin, spawnRect.xMax), Random.Range(spawnRect.yMin, spawnRect.yMax));

        GameObject asteroid=ObjectPoolManager.instance.GetObject("Asteroid");
        asteroid.transform.position = randPos;

        asteroidList.Add(asteroid);

    }
    public void RemoveAsteroid(GameObject asteroid)
    {
        asteroidList.Remove(asteroid);
    }
    private void OnDrawGizmosSelected()
    {
        if(spawnArea == null)
        {
            return;
        }
        Gizmos.color = color;

        foreach(var area in spawnArea)
        {
            Vector3 center = new Vector3(area.x + area.width / 2, area.y + area.height / 2);
            Vector3 size = new Vector3(area.width, area.height);

            Gizmos.DrawCube(center,size);
            
        }
    }



}
