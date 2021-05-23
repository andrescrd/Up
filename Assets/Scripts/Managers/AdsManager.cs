using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour
{ 
     string gameId = "4139733";
     
     bool testMode = false;
     void Start () {
         // Initialize the Ads service:
         Advertisement.Initialize(gameId, testMode);
     }

     public void ShowInterstitialAd() {
         // Check if UnityAds ready before calling Show method:
         if (Advertisement.IsReady()) {
             Advertisement.Show(gameId);
             // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
         } 
         else {
             Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
         }
     }
}
