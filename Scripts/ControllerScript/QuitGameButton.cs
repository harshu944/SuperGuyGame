﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGameButton : MonoBehaviour
{
    public void Quit()
    {
        SceneManager.LoadScene("HomeScreen");
    }
}
