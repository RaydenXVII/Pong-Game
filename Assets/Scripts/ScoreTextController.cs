using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class ScoreTextController : MonoBehaviour
{
    public TextMeshProUGUI text;
    
    public void SetScore(int value)
    {
        text.text = value.ToString();
    }
}
