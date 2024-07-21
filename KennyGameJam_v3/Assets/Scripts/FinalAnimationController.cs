using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalAnimationController : MonoBehaviour
{
    public Animator finalFemaleRun;
    public Animator finalAnimationPlayer;

    private void Start() {
        finalAnimationPlayer.SetBool("IsRuning", true);
    }

    public void StartRuning()
    {
        finalAnimationPlayer.SetBool("IsRuning", true);
    }
    public void StopRuning()
    {
        finalAnimationPlayer.SetBool("IsRuning", false);
    }
    public void FemaleStartRun()
    {
        finalFemaleRun.SetBool("FemaleIsRunning", true);
    }
}
