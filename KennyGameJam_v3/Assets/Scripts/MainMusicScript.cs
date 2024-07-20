using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMusicScript : MonoBehaviour
{
    private void Awake() {
        DontDestroyOnLoad(this.gameObject);
    }
}
