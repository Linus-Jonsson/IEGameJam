using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoToStatedSceneUponOnDisable : MonoBehaviour
{
    [SerializeField] private int sceneIndex;

    private void OnDisable()
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
