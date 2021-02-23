using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SteamManager : MonoBehaviour
{
    private void Awake() {

        try {
            Steamworks.SteamClient.Init(1541410);
        }

        catch (System.Exception e){
            Debug.Log("Não deu pra iniciar o steam client");
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
