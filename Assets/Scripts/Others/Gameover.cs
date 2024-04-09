using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;


public class Gameover : MonoBehaviour
{
    public void Playgame()
    {
        SceneManager.LoadSceneAsync("Level1");
    }

}
