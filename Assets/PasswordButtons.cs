using UnityEngine;

public class PasswordButtons : MonoBehaviour
{
    [SerializeField] private PasswordController passwordController;
    [SerializeField] private int selectedVariable;
    private int choosenVariable;
    [SerializeField] private AudioSource sound;
    

    private void Start()
    {
        switch (selectedVariable)
        {
            case 1:
                choosenVariable = 1;
               break;
            case 2:
                choosenVariable = 2;
                break;
            case 3:
                choosenVariable = 3;
                break;
            case 4:
                choosenVariable = 4;
                break;
            case 5:
                choosenVariable = 5;
                break;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                sound.Play();
                if(choosenVariable == 1)
                {
                    addC();
                }
                else if(choosenVariable == 2)
                {
                    addI();
                }
                else if(choosenVariable == 3)
                {
                    addT();
                }
                else if(choosenVariable == 4)
                {
                    addY();
                }
                else{
                    reset();
                }
            }
        }
    }

    private void addC()
    {
        passwordController.C += 1;
        if(passwordController.C > 26)
        {
            passwordController.C = 1;
        }
    }
    private void addI()
    {
        passwordController.I += 1;
        if (passwordController.I > 26)
        {
            passwordController.I = 1;
        }
    }
    private void addT()
    {
        passwordController.T += 1;
        if (passwordController.T > 26)
        {
            passwordController.T = 1;
        }
    }
    private void addY()
    {
        passwordController.Y += 1;
        if (passwordController.Y > 26)
        {
            passwordController.Y = 1;
        }
    }

    private void reset()
    {
        passwordController.C = 1;
        passwordController.I = 1;
        passwordController.T = 1;
        passwordController.Y = 1;
    }
}
