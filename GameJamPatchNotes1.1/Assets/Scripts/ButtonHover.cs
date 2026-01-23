using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonHover : MonoBehaviour
{
    public void TextColorOn()
    {
        var text = GetComponentInChildren<TMP_Text>();
        text.color = new Color32(24,130,217,255);
    }

    public void TextColorOff()
    {
        var text = GetComponentInChildren<TMP_Text>();
        text.color = new Color32(0, 0, 0, 255);
    }
}
