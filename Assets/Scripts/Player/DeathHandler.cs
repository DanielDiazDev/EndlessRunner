using UnityEngine;

public class DeathHandler : MonoBehaviour
{
    public void HandleDeath()
    {
        //Mostrar animacion de muerte
        Time.timeScale = 0;
        Debug.Log("Mori");
    }
    public void ShowEnding()
    {
        //Canvas
    }
}