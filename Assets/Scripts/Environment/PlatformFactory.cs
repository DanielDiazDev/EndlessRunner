using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFactory 
{
    
    private readonly PlatformConfiguration _configuration;
    private Transform _levelTest;
    public PlatformFactory(PlatformConfiguration configuration, Transform levelTest = null)
    {
        _configuration = configuration;
        _levelTest = levelTest;
    }
    public Transform Create(int difficulty, Vector3 endPosition)
    {
        var levelsChoice = _configuration.ChoiceLevel(difficulty);
        var levelPart = levelsChoice[Random.Range(0, levelsChoice.Length)];
        if(_levelTest != null)
        {
            levelPart = _levelTest;
        }
        return Object.Instantiate(levelPart, endPosition, Quaternion.identity);
    } 
}
