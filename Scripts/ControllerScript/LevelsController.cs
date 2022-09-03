using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelsController : MonoBehaviour
{

    public void ChooseLevel()
    {
        SceneManager.LoadScene("LevelsMenu");
    }
}
