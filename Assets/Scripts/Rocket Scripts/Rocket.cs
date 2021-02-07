using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.SceneManagement;

public class Rocket : MonoBehaviour
{
    [SerializeField] float RespondToBoostInputPower = 2f;
    [SerializeField] float rotatePower = 2f;
    FloatingJoystick joystick;
    FireButton fireButton;
    Rigidbody myRigidBody;
    AudioSource audioSource;
    [SerializeField] AudioClip engineSound;
    [SerializeField] ParticleSystem boostParticleSystem;
    [SerializeField] ParticleSystem successParticleSystem;
    [SerializeField] float levelCompleteTime = 2f;
    [SerializeField] float boostVolume = 1f;
    enum State { Alive, Dying, Transcending };
    State state = State.Alive;
    Coroutine successCoroutine;
    bool collisionsAreDisabled = false;
    bool soundPlaying = false;

    void Start()
    {
        myRigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
        joystick = FindObjectOfType<FloatingJoystick>();
        fireButton = FindObjectOfType<FireButton>();
    }

    void Update()
    {
        ProcessInput();
    }

    private void ProcessInput()
    {
        if (state != State.Dying)
        {
            RespondToBoostInput();
            RespondToRotateInput();
        }
        //only if debug on
        if (Debug.isDebugBuild)
        {
            RespondToDebugKeys();
        }


    }

    private void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            LevelLoader.LoadNextLevel();
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionsAreDisabled = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        Collider childCollider = other.contacts[0].thisCollider;
        //if (state != State.Alive || collisionsAreDisabled) { return; }
        if (collisionsAreDisabled) { return; }
        if (childCollider.gameObject.tag == "RocketBody")
        {
            OnBodyCollision();
        }
        else if (childCollider.gameObject.tag == "RocketFoot")
        {
            OnFootCollision(other.gameObject.tag);
        }
        else
        {
            Debug.LogError("Hey what is this");
        }
    }

    public void OnFootCollision(String tag)
    {
        if (collisionsAreDisabled) { return; }
        switch (tag)
        {
            case "Friendly":
                OnFriendlyCollision();
                break;
            case "Finish":
                OnFinishCollision();
                break;
            default:
                StartExplosionSequence();
                break;
        }
    }

    public void OnFootCollisionExit(String tag)
    {
        if (collisionsAreDisabled) { return; }
        if (tag == "Finish")
        {
            state = State.Alive;
            StopCoroutine(successCoroutine);
        }
    }

    public void OnBodyCollision()
    {
        StartExplosionSequence();
    }

    void OnCollisionExit(Collision other)
    {
        if (collisionsAreDisabled) { return; }
        OnFootCollisionExit(other.gameObject.tag);
    }

    private void OnFinishCollision()
    {
        if (successCoroutine != null)
        {
            StopCoroutine(successCoroutine);
        }
        successCoroutine = StartCoroutine(CheckIfItIsStillOnTheLandingPad());
    }

    private void OnFriendlyCollision()
    {
        if (state == State.Transcending)
        {
            state = State.Alive;
            StopCoroutine(successCoroutine);
        }
    }

    IEnumerator CheckIfItIsStillOnTheLandingPad()
    {
        state = State.Transcending;
        yield return new WaitForSeconds(levelCompleteTime);
        if (state == State.Transcending)
        {
            StartSuccessSequence();
        }
    }

    private void StartExplosionSequence()
    {
        state = State.Dying;
        Destructable destructable = GetComponent<Destructable>();
        destructable.Bomb();
        boostParticleSystem.Stop();
        audioSource.Stop();
        if (FindObjectOfType<VcamMoveBack>())
        {
            FindObjectOfType<VcamMoveBack>().moveBackCamera();
        }
        //CameraEffects.ShakeOnce(2f, 10f, new Vector3(100, 100, 0), null, true);
        FindObjectOfType<CameraEffects>().ShakeOnce(1f, 3f, new Vector3(5, 5, 0), null, true);
        Invoke("ShowExplosionCanvas", 2f);
    }

    private void ShowExplosionCanvas()
    {
        FindObjectOfType<LevelUIController>().OnRocketCollision();
        FindObjectOfType<Level>().ShowExplosionCanvas();
    }

    private void StartSuccessSequence()
    {
        //if (myRigidBody.velocity == Vector3.zero)
        if (true)// todo - should check the velocity == 0
        {
            myRigidBody.constraints = RigidbodyConstraints.None;
            successParticleSystem.Play();
            // audioSource.Stop();
            // audioSource.PlayOneShot(successSound);

            FindObjectOfType<Level>().SaveDataToSystemOnSuccess();
            if (FindObjectOfType<VcamMoveBack>())
            {
                FindObjectOfType<VcamMoveBack>().moveBackCamera();
            }
            FindObjectOfType<Level>().PlaySuccessSound();
            Invoke("ShowSuccessCanvas", levelCompleteTime);
            //Invoke("LoadNextLevel", levelCompleteTime); // call after 1 second 
        }
        else
        {
            StartCoroutine(CheckIfItIsStillOnTheLandingPad());
        }
    }

    private void ShowSuccessCanvas()
    {
        FindObjectOfType<Level>().ShowSuccessCanvas();
    }

    private void ShowLevelEndMenu()
    {

    }

    private void LoadNextLevel()
    {
        LevelLoader.LoadNextLevel();
    }

    private void RespondToBoostInput()
    {
        if ((fireButton.isPowerOn) || Input.GetKey(KeyCode.Space))//Input.GetKey(KeyCode.Space)
        {

            Boost();
        }
        else
        {
            boostParticleSystem.Stop();
            if (soundPlaying)
            {
                soundPlaying = false;
                StartCoroutine(VolumeFade(0f, 0.5f));
            }
            //audioSource.Stop();
        }
    }

    IEnumerator VolumeFade(float _EndVolume, float _FadeLength)
    {
        float _StartTime = Time.time;
        while (!soundPlaying &&
             Time.time < _StartTime + _FadeLength)
        {
            float alpha = (_StartTime + _FadeLength - Time.time) / _FadeLength;
            // use the square here so that we fade faster and without popping
            alpha = alpha * alpha;
            audioSource.volume = alpha * boostVolume + _EndVolume * (1.0f - alpha);

            yield return null;

        }

        if (_EndVolume == 0) { audioSource.UnPause(); }
    }

    private void Boost()
    {
        boostParticleSystem.Play();
        myRigidBody.AddRelativeForce(Vector3.up * RespondToBoostInputPower * Time.deltaTime);
        //audioSource.PlayOneShot(engineSound);
        if (!soundPlaying)
        {
            soundPlaying = true;
            //audioSource.PlayOneShot(engineSound);
            audioSource.Play();
            audioSource.volume = boostVolume;
            audioSource.UnPause();
        }
        else
        {

        }
    }

    private void RespondToRotateInput()
    {
        myRigidBody.angularVelocity = Vector3.zero; // take manual control of rotation
        //float rotateAxis = Input.GetAxis("Horizontal");
        float rotateAxis = joystick.Horizontal + Input.GetAxis("Horizontal"); // delete Input.GetAxis("Horizontal")
        transform.Rotate(-Vector3.forward * rotatePower * Time.deltaTime * rotateAxis);
    }
}
