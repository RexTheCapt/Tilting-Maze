using System;
using Assets.scripts.VS_Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movePlayer : MonoBehaviour
{
    private Rigidbody rb;
    private float speed = 10f;
    private Vector3 offset = new Vector3(0, 0, 1f);
    [HideInInspector]
    public FadeController fc;
    private bool death;
    private bool win = false;
    private Prefs prefs = new Prefs();
    private bool DeathAudio = false;
    private DataHold dataHold;

    public AudioClip DeathAudioClip;
    public AudioClip VictoryAudioClip;
    public AudioClip StartAudioClip;
    public GameObject CameraGameObject;
    public GameObject DataHoldGameObject;
    public Vector3 acc;
    public float deathAlpha = 2f;
    public float moveModifier = 1f;
    public float deadZone = 0.0f;
    public bool readyToMove;

    void Start()
    {
        fc = CameraGameObject.GetComponent<FadeController>();
        rb = GetComponent<Rigidbody>();
        dataHold = DataHoldGameObject.GetComponent<DataHold>();
    }

    void FixedUpdate()
    {
        acc = GetInput();
        acc += offset;

        // If the level is not in fading and readyToMove then move the player
        if (!fc.inFade && readyToMove)
        {
            // Move the player
            rb.AddForce(new Vector3(acc.x * moveModifier, 0, acc.y * moveModifier) * speed);
        }

        // If the player fell down into nothingness then fade to black
        if (transform.position.y <= -5 && !death)
        {
            if (!DeathAudio)
            {
                PlayAudio(DeathAudioClip);
                DeathAudio = true;
            }
            // Fade out the level
            fc.BeginFade(1, true);
            death = true;
        }

        // When the screen is black reload the level
        if (fc.alpha >= deathAlpha && !win)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
        else if (fc.alpha >= 1 && win)
        {
            if (SceneManager.sceneCountInBuildSettings == SceneManager.GetActiveScene().buildIndex + 1)
                SceneManager.LoadScene(0);
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

            if (DataHoldGameObject.GetComponent<DataHold>().Level > prefs.level)
                prefs.level++;
            Destroy(gameObject);
        }

        if (acc.x < 0.1f && acc.x > 0f - 0.1f && !fc.inFade && !win && !readyToMove)
            if (acc.y < 0.1f && acc.y > 0f - 0.1f)
            {
                PlayAudio(StartAudioClip);
                readyToMove = true;
                GetComponent<GuiTimer>().run = true;
            }
    }

    private Vector3 GetInput()
    {
        Vector3 v = new Vector3(dz(Input.acceleration.x), dz(Input.acceleration.y), dz(Input.acceleration.z));

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.S))
            v.y = 0f;
        else if (Input.GetKey(KeyCode.W))
            v.y = 1f;
        else if (Input.GetKey(KeyCode.S))
            v.y = -1f;

        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.D))
            v.x = 0f;
        else if (Input.GetKey(KeyCode.A))
            v.x = -1f;
        else if (Input.GetKey(KeyCode.D))
            v.x = 1f;

        if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.D))
        {
            v.y = 0.70f;
            v.x = 0.70f;
        }
        if (Input.GetKey(KeyCode.D) && Input.GetKey(KeyCode.S))
        {
            v.y = -0.70f;
            v.x = 0.70f;
        }
        if (Input.GetKey(KeyCode.S) && Input.GetKey(KeyCode.A))
        {
            v.y = -0.7f;
            v.x = -0.7f;
        }
        if (Input.GetKey(KeyCode.A) && Input.GetKey(KeyCode.W))
        {
            v.x = -0.7f;
            v.y = 0.7f;
        }

        //Debug.Log(v.ToString());

        return v;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Goal")
        {
            PlayAudio(VictoryAudioClip);
            GetComponent<GuiTimer>().run = false;
            float dt = GetComponent<GuiTimer>().deltaTime;
            if(dt < dataHold.record || dataHold.record == 0f)
                dataHold.record = dt;
            win = true;
            gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;

            fc.BeginFade(1);
        }
    }

    private float dz(float f)
    {
        if (f > deadZone)
            return f;
        else if (f < 0 - deadZone)
            return f;
        else
            return 0f;
    }

    private void PlayAudio (AudioClip audioClip)
    {
        gameObject.GetComponent<AudioSource>().clip = audioClip;
        gameObject.GetComponent<AudioSource>().Play();
    }
}
