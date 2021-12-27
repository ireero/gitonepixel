using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    public static SteamManager inst = null;

    private void Awake() {

        if(inst == null) {
            inst = this;
            DontDestroyOnLoad(this.gameObject);
        } else if(inst != this) {
            Destroy(gameObject);
        }

        try {
            Steamworks.SteamClient.Init(1541410);
        }

        catch (System.Exception e){
            Debug.Log("Não deu pra iniciar o steam client" + e);
        }

        DontDestroyOnLoad(this.gameObject);
    }

    private void OnDisable() {
        Steamworks.SteamClient.Shutdown();
    }

    void Update() {
        Steamworks.SteamClient.RunCallbacks();    
    }
}
