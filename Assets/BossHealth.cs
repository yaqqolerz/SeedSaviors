using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    [SerializeField] private Image img;
    [SerializeField] private Character boss;

    private void Update()
    {
        img.fillAmount = boss.life/20f;
    }
}
