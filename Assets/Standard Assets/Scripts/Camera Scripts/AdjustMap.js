private var thePlayer : Transform;

function Start() {
	thePlayer = GameObject.Find("Player").transform;
	var mWidth = 0.3* 598/Screen.width;
	var mHeight = 0.25* 598/Screen.height;
	GetComponent.<Camera>().rect = Rect (0, 0, mWidth, mHeight);
}

function FixedUpdate() {
	transform.position = thePlayer.position + Vector3(0,60,0);
}