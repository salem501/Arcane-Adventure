using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Teleporter : MonoBehaviour
{
    public string sceneName;

    public void OnTriggerEnter(Collider coll) {
        if (coll.GetComponent<PlayerController>() != null) {
            SceneManager.LoadScene(sceneName);
        }
    }
}
