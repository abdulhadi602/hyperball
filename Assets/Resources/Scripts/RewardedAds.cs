using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class RewardedAds : MonoBehaviour, IUnityAdsListener
{

        private string gameId = "3847613";


        Button myButton;
        public string myPlacementId = "rewardedVideo";

        void Start()
        {
            myButton = GetComponent<Button>();

            // Set interactivity to be dependent on the Placement’s status:
            myButton.interactable = Advertisement.IsReady(myPlacementId);

            // Map the ShowRewardedVideo function to the button’s click listener:
            if (myButton) myButton.onClick.AddListener(ShowRewardedVideo);

            // Initialize the Ads listener and service:
            Advertisement.AddListener(this);
            Advertisement.Initialize(gameId, false);
        }

        // Implement a function for showing a rewarded video ad:
        void ShowRewardedVideo()
        {
            Advertisement.Show(myPlacementId);
        }

        // Implement IUnityAdsListener interface methods:
        public void OnUnityAdsReady(string placementId)
        {
            // If the ready Placement is rewarded, activate the button: 
            if (placementId == myPlacementId)
            {
                myButton.interactable = true;
            }
        }

        public void OnUnityAdsDidFinish(string placementId, ShowResult showResult)
        {
            // Define conditional logic for each ad completion status:
            if (showResult == ShowResult.Finished)
            {
            GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameRestart(true);
            }
            else if (showResult == ShowResult.Skipped)
            {
             GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>().GameRestart(false);
            }
            else if (showResult == ShowResult.Failed)
            {
                Debug.LogWarning("The ad did not finish due to an error.");
            }
        }

        public void OnUnityAdsDidError(string message)
        {
            // Log the error.
        }

        public void OnUnityAdsDidStart(string placementId)
        {
            // Optional actions to take when the end-users triggers an ad.
        }
    
}
