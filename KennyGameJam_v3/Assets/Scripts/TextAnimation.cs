using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro; 
using UnityEngine.
SceneManagement;
public class TextAnimation : MonoBehaviour
{
    public int nextLevelIndex;
    public TextMeshProUGUI StoryText;
    private string SaveText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TypeSentence());
        
    }

    IEnumerator TypeSentence()
    {
        SaveText = StoryText.text;
        StoryText.text = "";
        Debug.Log(SaveText);
        foreach (char letter in SaveText.ToCharArray())
        {
            StoryText.text += letter;
            yield return new WaitForSeconds(0.05f);
        }
    }

    private void Update() {
        if(Input.GetButtonDown("Jump"))
        {
            SceneManager.LoadScene(nextLevelIndex, LoadSceneMode.Single);
        }
    }


}
