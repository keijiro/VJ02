using UnityEngine;
using System.Collections;

public class EmergencyButton : MonoBehaviour
{
    public GameObject originObject;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // Reset the position of the origin object.
            originObject.transform.position = Vector3.zero;
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            // Reload the scene.
            Application.LoadLevel(0);
        }
    }
}
