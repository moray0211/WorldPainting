using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (FindObjectOfType<SingletonContainer>() != null)
        {
            Destroy(FindObjectOfType<SingletonContainer>().GetComponent<SingletonContainer>());
            Destroy(GameObject.Find("Managers"));
        }
        if (FindObjectOfType<UISingleton>() != null)
        {
            Destroy(FindObjectOfType<UISingleton>().GetComponent<SingletonContainer>());
            Destroy(GameObject.Find("UI"));
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
