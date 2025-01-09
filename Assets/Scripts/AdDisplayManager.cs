using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class AdDisplayManager : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    public static AdDisplayManager instance;
    public string UnityAdsId;
    public int androidID, appleID;
    public bool testMode = true;
    public string adType;

    public void OnInitializationComplete()
    {
        
    }

    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Advertisement.Show(adType, this); 
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("add fail" + message);
    }

    public void OnUnityAdsShowClick(string placementId)
    {
       
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        SceneManager.LoadScene("Juego"); 
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (!instance)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }


    private void Start()
    {
        if (!Advertisement.isInitialized)
        {
#if UNITY_ANDROID || UNITY_STANDALONE_WIN || UNITY_EDITOR
            Advertisement.Initialize(androidID.ToString(), testMode, this); // el testmode para que no te denuncie unity, lo inicializamos con el id de android o apple 
#elif UNITY_IOS
            Advertisement.Initialize(appleID.ToString(), testMode, this); 
#endif
        }
    }
    public void ShowAd()
    {
        if (Advertisement.isInitialized)
        {
            Advertisement.Load(adType, this);

        }
    }

}
