using UnityEngine;
using UnityEngine.SceneManagement;

public class ElevatorLoadScene : MonoBehaviour
{
    [SerializeField] private float speedScale = 1f;
    [SerializeField] private Color fadeColor = Color.black;
    [SerializeField] private string sceneName;

    private AnimationCurve Curve = new AnimationCurve(new Keyframe(0, 1), 
        new Keyframe(0.5f, 0.5f, -1.5f, -1.5f), new Keyframe(1,0));
    private bool startFadedOut = false;
    
    private bool EnteredTrigger = false;


    private float alpha = 0f;
    private Texture2D texture;
    private int direction = 0;
    private float time = 0f;

    private void Start()
    {
        if (startFadedOut) alpha = 1f; else alpha = 0f;
        texture = new Texture2D(1, 1);
        texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
        texture.Apply();
    }

    private void Update()
    {
        if (direction == 0 && EnteredTrigger)
        {
            if (alpha >= 1f)
            {
                alpha = 1f;
                time = 0f;
                direction = 1;
            }
            else
            {
                alpha = 0f;
                time = 1f;
                direction = -1;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Elevator"))
        {
            EnteredTrigger = true;
            Debug.Log("Entered");
        }
    }

    private void OnGUI()
    {
        if (alpha > 0f) GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), texture);
        if(direction != 0)
        {
            time += direction * Time.deltaTime * speedScale;
            alpha = Curve.Evaluate(time);
            texture.SetPixel(0, 0, new Color(fadeColor.r, fadeColor.g, fadeColor.b, alpha));
            texture.Apply();
            if (alpha <= 0f || alpha >= 1f) {
                direction = 0;
                
                SceneManager.LoadScene(sceneName);
                
            } 
        }
    }
}
