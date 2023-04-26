using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerName : MonoBehaviour
{
    public static string playernamestr;
    public TextMeshProUGUI playerName;

    void Start()
    {
        playerName.text = playernamestr;
    }
}
