using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColumnPool : MonoBehaviour {
    public int obstaclePoolSize = 5;
    public GameObject obstaclePrefab;
    private GameObject[] obstacles;
	// Use this for initialization
	void Start () {
        obstacles = new GameObject[obstaclePoolSize];
        for(int i=0;i < obstaclePoolSize; i++)
        {

        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
