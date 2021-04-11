using UnityEngine;

public class DontDestroyObjectScript : MonoBehaviour
{
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
}
