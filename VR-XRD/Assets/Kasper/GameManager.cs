using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public Transform bowSpawnPoint;
    public GameObject bowPrefab;
    
    public void SpawnBow(Component sender, object data)
    {
       Instantiate(bowPrefab, bowSpawnPoint.position, bowSpawnPoint.rotation);
    }
    public void GoToMainMenu(Component sender, object data)
    {
      
    }
    
    public void RestartLevel(Component sender, object data)
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

}
