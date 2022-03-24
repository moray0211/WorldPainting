using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSetting : MonoBehaviour
{
    void Start()
    {
        if (FindObjectOfType<SingletonContainer>() != null)
        {
            Destroy(FindObjectOfType<SingletonContainer>().GetComponent<SingletonContainer>());
            Destroy(GameObject.Find("Managers"));
        }
        Debug.Log("매니저 삭제");

        if (FindObjectOfType<UISingleton>() != null)
        {
            Destroy(FindObjectOfType<UISingleton>().GetComponent<SingletonContainer>());
            Destroy(GameObject.Find("UI"));
        }
        Debug.Log("UI 삭제");
        new WaitForSeconds(1);
        SceneManager.LoadScene("KitchenScene");
    }

    void Update()
    {
        
    }
}
