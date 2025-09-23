using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text infoText;

    void Start()
    { infoText.text = $"버틴 시간: {GameManager.finalTime:0.0}s"; }
}