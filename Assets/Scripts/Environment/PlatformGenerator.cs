using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    [SerializeField] private Transform _platformStart;
    [SerializeField] private Player _player;
    [SerializeField] private float PLAYER_DISTANCE_SPAWN_LEVEL = 30f;
    [SerializeField] private Transform _levelTest;
    [SerializeField] private Transform _endPosition;
    [SerializeField] private PlatformConfiguration _platformConfiguration;
    private PlatformFactory _platformFactory;
    private int _levelPartsSpawned;

    // Start is called before the first frame update
    private enum Difficulty
    {
        Easy,
        Medium,
        Hard
    }
    void Awake()
    {
        _platformFactory = new PlatformFactory(_platformConfiguration, _levelTest);
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
        var level = _platformFactory.Create(GetDifficulty(), _endPosition.position);
        //Agregar padre
        _endPosition = level.Find("EndPosition");
        _levelPartsSpawned++;
    }

    private float GetDistance()
    {
        var distanceSquared = (_player.transform.position - _endPosition.position).sqrMagnitude;
        return MathF.Sqrt(distanceSquared);
    }
    private int GetDifficulty()
    {
        if (_levelPartsSpawned >= 14) return (int)Difficulty.Hard;
        if (_levelPartsSpawned >= 7) return (int)Difficulty.Medium;
        return (int)Difficulty.Easy;

    }
}
