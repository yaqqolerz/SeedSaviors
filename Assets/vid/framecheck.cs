using UnityEngine;
using UnityEngine.Video;

public class framecheck : MonoBehaviour
{
    [SerializeField] private VideoPlayer orang;
    [SerializeField] private GameObject orang2;
    /*[SerializeField] private VideoClip orang3;
    [SerializeField] private VideoClip orang4;*/
    private bool hasStarted = false;

    private void Awake()
    {
        if (orang.isPrepared)
        {
            orang.Play();
            hasStarted = true;
        }
        else
        {
            orang.prepareCompleted += VideoPrepareCompleted;
            orang.Prepare();
        }
    }

    private void VideoPrepareCompleted(VideoPlayer source)
    {
        orang.Play();
        hasStarted = true;
        orang.prepareCompleted -= VideoPrepareCompleted;
    }

    private void Update()
    {
        if (hasStarted && !orang.isPlaying)
        {
            // Video has finished playing
            orang2.SetActive(true);
        }
    }
}
