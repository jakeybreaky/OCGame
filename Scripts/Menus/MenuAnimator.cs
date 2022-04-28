using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuAnimator : MonoBehaviour
{
    //Right now this script mostly just animates a 3D sphere which serves as the background for the main menu.

    public Camera camera;
    public GameObject sphere;
    public float sphereRotationSpeed;

    void Update()
    {
        sphere.transform.Rotate(Vector3.up * (sphereRotationSpeed * Time.deltaTime));
    }

    void OnEnable()
    {
        transform.position = new Vector3 (camera.transform.position.x, camera.transform.position.y - 1, camera.transform.position.z - 1);
    }
}
