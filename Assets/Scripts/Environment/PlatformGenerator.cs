using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform _platformStart;
    [SerializeField] private List<Transform> _levelsEasy;
    [SerializeField] private Player _player;
    [SerializeField] private float PLAYER_DISTANCE_SPAWN_LEVEL = 30f;
    private Transform _endPosition;
    // Start is called before the first frame update
    void Awake()
    {
        _endPosition = _platformStart.Find("EndPosition");
        var startingSpawnPlatformStart = 3;
        for (int i = 0; i < startingSpawnPlatformStart; i++)
        {
            SpawnLevelPart();
        }
    }
    // Update is called once per frame
    void Update()
    {
        float distance = GetDistance();
        if (distance < PLAYER_DISTANCE_SPAWN_LEVEL)
        {
            SpawnLevelPart();
        }
    }
    private void SpawnLevelPart()
    {
        var chosenLevelPart = _levelsEasy[UnityEngine.Random.Range(0, _levelsEasy.Count)];
        //Hacer testeos hardcord
        var level = Instantiate(chosenLevelPart, _endPosition.position, Quaternion.identity); //Agregar padre
        _endPosition = level.Find("EndPosition");
    }

    
    private float GetDistance()
    {
        var distanceSquared = (_player.transform.position - _endPosition.position).sqrMagnitude;
        return MathF.Sqrt(distanceSquared);
    }
}
