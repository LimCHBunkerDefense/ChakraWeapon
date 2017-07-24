var target : Transform;
var distance = 10.0;

var xSpeed = 250.0;
var ySpeed = 120.0;

var yMinLimit = -20;
var yMaxLimit = 80;

private var x = 0.0;
private var y = 0.0;
private var lastPos = new Vector3 (0,0,0);
private var DoIT : float;
private var FirstLogin : float;

@script AddComponentMenu("Camera-Control/Mouse Orbit")

function LateUpdate () {
CameraZoom();
    if (target) {
	if (Input.mousePosition.x > Screen.width - 2 || Input.mousePosition.x < 2 || Input.mousePosition.y > Screen.height - 2 || Input.mousePosition.y < 2) DoIT = 1;
	else DoIT = 0;
	if (FirstLogin == 0) { FirstLogin = 1; DoIT = 1; }
	if (DoIT == 1) {
			if (Input.mousePosition.x > Screen.width - 2) x += 60 * xSpeed * 0.02 * Time.deltaTime;
			if (Input.mousePosition.x < 2) x -= 60 * xSpeed * 0.02 * Time.deltaTime;
			if (Input.mousePosition.y < 2) y += 30 * ySpeed * 0.02 * Time.deltaTime;
			if (Input.mousePosition.y > Screen.height - 2) y -= 30 * ySpeed * 0.02 * Time.deltaTime;
			y = ClampAngle(y, yMinLimit, yMaxLimit);
			var rotation = Quaternion.Euler(y, x, 0);
			var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
			transform.rotation = rotation;
			transform.position = position;
			lastPos = transform.position - target.position;
	}
	else transform.position = target.transform.position + lastPos;

    }
}

static function ClampAngle (angle : float, min : float, max : float) {
	if (angle < -360)
		angle += 360;
	if (angle > 360)
		angle -= 360;
	return Mathf.Clamp (angle, min, max);
}

function CameraZoom () {
    	if (Input.GetAxis("Camera Zoom") > 0) // back
        {
            Camera.main.orthographicSize = Mathf.Max(Camera.main.orthographicSize-2, 30);

        }
        if (Input.GetAxis("Camera Zoom") < 0) // forward
        {
            Camera.main.orthographicSize = Mathf.Min(Camera.main.orthographicSize+2, 46);
        }
}

function StartTheCam() {
    var angles = transform.eulerAngles;
    x = angles.y;
    y = angles.x;
	y = ClampAngle(y, yMinLimit, yMaxLimit);
	var rotation = Quaternion.Euler(y, 0, 0);
	var position = rotation * Vector3(0.0, 0.0, -distance) + target.position;
	transform.rotation = rotation;
	transform.position = position;
	lastPos = transform.position - target.position;
	transform.position = target.transform.position + lastPos;
}