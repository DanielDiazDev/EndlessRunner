
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlatformConfiguration", menuName = "Factory/Create PlatformConfiguration")]
public class PlatformConfiguration : ScriptableObject
{
    [SerializeField] private Transform[] _levelEasy;
    [SerializeField] private Transform[] _levelMedium;
    [SerializeField] private Transform[] _levelHard;

    public Transform[] ChoiceLevel(int difficulty)
    {
        Transform[] list = null;
        switch (difficulty)
        {
            case 0:
                list = _levelEasy;
                break;
            case 1:
                list = _levelMedium;
                break;
            case 2:
                list = _levelHard;
                break;
            default:
                break;
        }
        return list;

    }
}
