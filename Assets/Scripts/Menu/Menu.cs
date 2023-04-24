using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Prototype.Menu
{
    public class Menu : MonoBehaviour
    {
        public void OnClickStart()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
