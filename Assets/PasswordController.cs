using UnityEngine;

public class PasswordController : MonoBehaviour
{
    [SerializeField] public int C=1;
    [SerializeField] public int I=1;
    [SerializeField] public int T=1;
    [SerializeField] public int Y=1;
    [SerializeField] private GameObject box;
    [SerializeField] private GameObject buttonC;
    [SerializeField] private GameObject buttonI;
    [SerializeField] private GameObject buttonT;
    [SerializeField] private GameObject buttonY;
    [SerializeField] private Sprite spriteWrong;
    [SerializeField] private Sprite spriteRight;

    private void Start()
    {
        C = 1;
        I = 1;
        T = 1;
        Y = 1;
    }

    private void Update()
    {
        if(C==3 && I==9 && T==20 && Y == 25)
        {
            box.SetActive(true);
        }
        CspriteChanger();
        IspriteChanger();
        TspriteChanger();
        YspriteChanger();
        
    }

    private void CspriteChanger()
    {
        if (C == 3)
        {
            buttonC.GetComponent<SpriteRenderer>().sprite = spriteRight;
        }
        else
        {
            buttonC.GetComponent<SpriteRenderer>().sprite = spriteWrong;
        }
    }

    private void IspriteChanger()
    {
        if (I == 9)
        {
            buttonI.GetComponent<SpriteRenderer>().sprite = spriteRight;
        }
        else
        {
            buttonI.GetComponent<SpriteRenderer>().sprite = spriteWrong;
        }
    }

    private void TspriteChanger()
    {
        if (T == 20)
        {
            buttonT.GetComponent<SpriteRenderer>().sprite = spriteRight;
        }
        else
        {
            buttonT.GetComponent<SpriteRenderer>().sprite = spriteWrong;
        }
    }

    private void YspriteChanger()
    {
        if (Y == 25)
        {
            buttonY.GetComponent<SpriteRenderer>().sprite = spriteRight;
        }
        else
        {
            buttonY.GetComponent<SpriteRenderer>().sprite = spriteWrong;
        }
    }
}
