using UnityEngine;
using UnityEngine.UI;

public class AngerBarController : MonoBehaviour
{
    [SerializeField] Image angerBar;

    public void UpdateBar(float fillAmount) {
        angerBar.fillAmount = fillAmount;
    }
}
