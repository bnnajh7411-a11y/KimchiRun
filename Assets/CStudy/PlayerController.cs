using UnityEngine;

public class PlayerController : MonoBehaviour
{
    void Start()
    {
        /*
        string[] enermies = new string[3];
        enermies[0] = "슬라임";
        enermies[1] = "고블린";
        enermies[2] = "오크";
        */

        string[] enermies = {"슬라임", "고블린", "오크", "적"};

        for (int i = 0; i < enermies.Length; i++)
        {
            Debug.Log(enermies[i]);
        }
    }

    void Update()
    {
        
    }
}
