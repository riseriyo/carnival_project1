using UnityEngine;
using UnityEngine.UI;

public class CarnivalCoinToss : MonoBehaviour {

    [Tooltip("Floating Score Prefab")]
    public ScoreHighlight ScoreHighlighterPrefab;

    [Tooltip("The Camera that the Player uses to see the world")]
    public Camera VRView;

    [Tooltip("Controls the scale of the power the coin is Tossed")]
    public CarnivalPowerSlider PowerScalar;

    [Tooltip("The prefab for the coin we are going to toss.")]
    public GameObject CoinPrefab;

    [Tooltip("The Center of the Coin Pile")]
    public Transform CoinPile;

    [Tooltip("The current coin we control")]
    public float DistanceFromFace = .5f;

    [Tooltip("The MINIMUM power toss the coin with. This is when the slider is at the bottom")]
    public float MinTossPower = 4f;

    [Tooltip("The MAXIMUM power toss the coin with. This is when the slider is at the top")]
    public float MaxTossPower = 8f;

    [Tooltip("The speed that the slider moves up and down with")]
    public float SliderSpeed = 2f;

    [Tooltip("The audio clip to play when coins are clicked")]
    public GvrAudioSource clickNotification;

    [Tooltip("The audio clip to play when the coin lands")]
    public AudioSource yay;

    [Tooltip("The audio clip to play when coin misses")]
    public AudioSource fail;

    private GameObject currCoin;

    private bool coinPickedUp = false;
    private float pickUpTime = 0f;

    void Start() {
        CarnivalCoinTossPlatform.OnCoinLanded += OnCoinLanded;
        CoinTossCoin.OnCoinMissed += OnCoinMissed;
    }

    void Update() {
        if (coinPickedUp) {
            //HeadPose.position doesn't seem to work...
            Vector3 target = VRView.transform.position + (VRView.transform.rotation * Vector3.forward) * DistanceFromFace;
            Vector3 curr = currCoin.transform.position;
            if ( (target - curr).magnitude > .01f ) {
                currCoin.transform.position = Vector3.Lerp(curr, target, Time.deltaTime * 3f); //have the coin float to your head
            }

            PowerScalar.SetPowerScale( Mathf.Abs(Mathf.Sin( (Time.time - pickUpTime) * SliderSpeed )) );
        }
    }

    public void PickUpCoin() {
        if (!coinPickedUp) {
            clickNotification.Play();
            currCoin = Instantiate(CoinPrefab);
            currCoin.GetComponent<Collider>().enabled = false;
            currCoin.transform.position = CoinPile.position;
            coinPickedUp = true;
            pickUpTime = Time.time;
        }
    }

	// Difficult task! But I was able to get scores with targetVel.normalized at (0.8, 0.6, 0.1) and power and r.velocity values at: 
	// 6.72757, (5.2, 4.2, 1.0)
	// 6.926415, (5.2, 4.2, 1.0)
	// 7.350133, (5.6, 4.6, 1.1)
	// to give you an idea that it is possible. Just make sure you set the GVRViewCamera closer to the coin toss booth. It seems to help.
    public void TossCoin() {
        if (coinPickedUp) { 
            coinPickedUp = false;
            currCoin.GetComponent<Collider>().enabled = true;
            currCoin.GetComponent<GvrAudioSource>().Play();
            Rigidbody r = currCoin.GetComponent<Rigidbody>();
            r.isKinematic = false;
			//Debug.Log("VRView.transform.position: " + VRView.transform.position + "; VRView.transform.forward: " + VRView.transform.forward); // (0.1, 1.8, -1.1)
			//VRView.transform.forward = new Vector3(-1f, 1f, 0.8f);
			//Debug.Log("VRView.transform.forward: " + VRView.transform.forward);
			Vector3 targetVel = VRView.transform.position + VRView.transform.forward; //the direction of the toss
			//Debug.Log("targetVel: " + targetVel);
            targetVel.y = 0f;
			//Debug.Log ("targetVel before normalized: " + targetVel);
            targetVel.Normalize();
			//Debug.Log ("targetVel after normalized " + targetVel);
            targetVel.y = 0.8f; //0.8f have a consistant y velocity
			//Debug.Log ("targetVel after y = 0.8f:  " + targetVel);
            float power = (MaxTossPower - MinTossPower) * PowerScalar.value + MinTossPower;
			r.velocity = targetVel.normalized * power;
			Debug.Log("Points scored w/values: (targetVel.normalized, power, r.velocity): (" + targetVel.normalized + ", " + power + ", " + r.velocity + ")");
            currCoin = null;
        }
    }

    private void OnCoinLanded() {
        CarnivalScores.Instance.IncrementCoinScore();
        ScoreHighlight sh = Instantiate(ScoreHighlighterPrefab, transform.position,
    Quaternion.LookRotation(-transform.right));
        sh.SetPoints(1000);

        yay.Play();

#if UNITY_EDITOR
        TMPro.TextMeshPro text = new GameObject().AddComponent<TMPro.TextMeshPro>();
        text.transform.rotation = transform.rotation * Quaternion.Euler(0f, 270f, 0f);
        text.transform.position = new Vector3(7.5f, 6f, -2f);
        text.text = "OssDist0.7";
#endif
    }

    private void OnCoinMissed() {
        ScoreHighlight sh = Instantiate(ScoreHighlighterPrefab, transform.position,
    Quaternion.LookRotation(-transform.right));
        sh.SetPoints(0);

        fail.Play();
    }

}
