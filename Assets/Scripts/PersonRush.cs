using UnityEngine;
using TMPro;  // Add this namespace to use TextMeshPro

public class PersonRush : MonoBehaviour
{
    public TextMeshProUGUI happyText;
    public TextMeshProUGUI angryText;
    public TextMeshProUGUI satisfactionText;
    public TextMeshProUGUI disgustText;

    private string currentEmotion = "None";
    private string targetEmotion = "None";

    public void SetEmotion(string emotion)
    {
        currentEmotion = emotion;
        switch (emotion)
        {
            case "Satisfaction":
                satisfactionText.gameObject.SetActive(true);
                Invoke(nameof(DestroySatisfactionText), 2f);  // Destroy satisfaction text after 2 seconds
                break;
            case "Disgust":
                disgustText.gameObject.SetActive(true);
                Invoke(nameof(DestroyDisgustText), 2f);  // Destroy disgust text after 2 seconds
                break;
        }
    }

    public void SetTargetEmotion(string emotion)
    {
        targetEmotion = emotion;
    }

    public string GetTargetEmotion()
    {
        return targetEmotion;
    }

    public void ResetEmotion()
    {
        currentEmotion = "None";
    }

    private void DestroySatisfactionText()
    {
        Destroy(satisfactionText.gameObject);
    }

    private void DestroyDisgustText()
    {
        Destroy(disgustText.gameObject);
    }
}
