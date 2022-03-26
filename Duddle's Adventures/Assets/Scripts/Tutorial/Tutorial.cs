using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{

    public static bool IsShowingTutorial = false;
    public GameObject TutorialMsg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void ShowTutorial()
    {
        TutorialMsg.SetActive(true);
    }
}
