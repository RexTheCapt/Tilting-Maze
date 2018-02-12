using UnityEngine;

public class NoMoveNotification : MonoBehaviour
{
    private movePlayer movePlayer;

    public float DelayBetween = 1f;
    public float tmr;
    public GameObject PlayerGameObject;
    public AudioClip NotifAudioClip;

    void Start()
    {
        movePlayer = PlayerGameObject.GetComponent<movePlayer>();
    }

    void FixedUpdate()
    {
        if (!movePlayer.readyToMove && !movePlayer.fc.inFade)
            tmr += Time.deltaTime;
        if (!movePlayer.fc.inFade && DelayBetween < tmr && !movePlayer.readyToMove)
        {
            PlayerGameObject.GetComponent<AudioSource>().clip = NotifAudioClip;
            GetComponent<GyroDisk>().Flash();
            PlayerGameObject.GetComponent<AudioSource>().Play();
            tmr = 0;
        }
    }
}
