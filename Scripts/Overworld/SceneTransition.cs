using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
    public string sceneToLoad;
    public Vector2 playerPosition;
    public Vector2Value playerPosStorage;
    public Vector2 playerRotation;
    public Vector2Value playerRotStorage;

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !other.isTrigger)
        {
            playerPosStorage.initialValue = playerPosition;
            playerRotStorage.initialValue = playerRotation;
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}
