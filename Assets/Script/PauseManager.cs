using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot inGame;
    public AudioMixerSnapshot pause;

    bool pausePressed;
    bool pauseReleased;

    Canvas canvas;
    PlayerControl playerControl;
    private void Awake() {
        playerControl = new PlayerControl();
        playerControl.PlayerControls.Pause.performed += context => pausePressed = true;
        playerControl.PlayerControls.Pause.canceled += context => pauseReleased = true;
    }

    // Start is called before the first frame update
    void Start()
    {
        canvas  = GetComponent<Canvas>();      
    }
    private void OnEnable() {
        playerControl.Enable();
    }
    private void OnDisable() {
        playerControl.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        if(pausePressed){
        // if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.enabled = !canvas.enabled;
            Pause();
        }
        pausePressed = false;
        pauseReleased = false;
        
    }

    void Pause(){
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;

        /*
        if(Time.timeScale == 0){
            Time.timeScale = 1;
        }else{
            Time.timeScale = 0;
        }
        */

        MixerTransition();
    }

    void MixerTransition(){
        if(Time.timeScale == 0){
            pause.TransitionTo(.05f);
        }else{
            inGame.TransitionTo(.05f);
        }
    }
}
