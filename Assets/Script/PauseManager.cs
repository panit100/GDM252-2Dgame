using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PauseManager : MonoBehaviour
{
    public AudioMixerSnapshot inGame;
    public AudioMixerSnapshot pause;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas  = GetComponent<Canvas>();      
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            canvas.enabled = !canvas.enabled;
            Pause();
        }
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
