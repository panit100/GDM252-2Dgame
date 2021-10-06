using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;
using UnityEngine.Analytics;

public class Restart : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private int currentLevel;
    [SerializeField] string _androidAdUnitId = "Interstitial_Android";
    [SerializeField] string _iOsAdUnitId = "Interstitial_iOS";
    string _adUnitId;
    private Scene scene;

    void Awake()
    {
        scene = SceneManager.GetActiveScene();
        AnalyticsEvent.GameOver();
        AnalyticsEvent.TutorialStart();
        // Get the Ad Unit ID for the current platform:
        _adUnitId = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iOsAdUnitId
            : _androidAdUnitId;
    }
    // Start is called before the first frame update
    void Start()
    {
        currentLevel = SceneManager.GetActiveScene().buildIndex;
        LoadAd();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            LogLevelFail(1,100);
            AnalyticsResult analyticsResult = Analytics.CustomEvent("LevelRestart " + 1);
            Debug.Log("analyticsResult = " + analyticsResult);
            
            AnalyticsResult aRDictionaty = Analytics.CustomEvent("LevelRestart Dic " + 
                new Dictionary<string,object>{
                    {"Level",1},{"Point",100}
                }
            );
            Debug.Log("aRDictionaty = " + analyticsResult);

            ShowAd();
            SceneManager.LoadScene(currentLevel);
        }
    }

    void LogLevelFail(int level, int point){
        Dictionary<string,object> customParams = new Dictionary<string, object>();
        customParams.Add("Level", level);
        customParams.Add("Point",point);
        AnalyticsEvent.LevelFail(scene.name,scene.buildIndex,customParams);

        // AnalyticsEvent.LevelStart(scene.name, scene.buildIndex);
    }

    // Load content to the Ad Unit:
    public void LoadAd()
    {
        // IMPORTANT! Only load content AFTER initialization (in this example, initialization is handled in a different script).
        Debug.Log("Loading Ad: " + _adUnitId);
        Advertisement.Load(_adUnitId, this);
    }

    // Show the loaded content in the Ad Unit: 
    public void ShowAd()
    {
        // Note that if the ad content wasn't previously loaded, this method will fail
        Debug.Log("Showing Ad: " + _adUnitId);
        Advertisement.Show(_adUnitId, this);
    }

    // Implement Load Listener and Show Listener interface methods:  
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        // Optionally execite code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execite code if the Ad Unit fails to show, such as loading another ad.
    }

    public void OnUnityAdsShowStart(string adUnitId) { }
    public void OnUnityAdsShowClick(string adUnitId) { 
        Debug.Log("Ads Click");
    }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState) { 
        Debug.Log("Ads Completed");
    }
}
