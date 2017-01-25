using UnityEngine;

public class LaserGunBehaviour : Weapon
{

    public AudioClip selectSound;
    public AudioClip hitSound;
    public GameObject ammunition;

    private float hitsPerSecond = 1.0f;
    private float timeSinceLastDamage = 0.0f;
    private LineRenderer laserLine = null;
    private GameObject sourceLight = null;
    private GameObject hitLight = null;

    void Start()
    {
        weaponType = AvailableWeapons.LaserGun;
        continuesFiring = true;
    }

    void Awake()
    {
    }

    void OnDestroy()
    {
        stop();
    }

    public override void fire()
    {
        RaycastHit rayCastHit;
        if (Physics.Raycast(transform.position, transform.forward, out rayCastHit))
        {
            drawLaserLine(transform.position, rayCastHit.point);
            lightUp(transform.position, rayCastHit.point);
            //Quaternion.FromToRotation(Vector3.up, rayCast.normal);
            PlayerHealth player = rayCastHit.collider.GetComponent<PlayerHealth>();
            if (player != null)
            {
                if (Time.realtimeSinceStartup - timeSinceLastDamage >= 1.0f / hitsPerSecond)
                {
                    timeSinceLastDamage = Time.realtimeSinceStartup;
                    player.TakeDamage();
                    // Remark: this is a really bad position for the sound if we want to have a 
                    // hit sound depending on the TARGET material. For now the hit sound is depending on the weapon.
                    //AudioSource.PlayClipAtPoint(hitSound, transform.position, 10.0f);
                }
            }
        }
    }

    private void drawLaserLine(Vector3 startPosition, Vector3 endPosition)
    {
        if (this.laserLine == null)
        {
            GameObject line = Instantiate(ammunition) as GameObject;
            this.laserLine = line.GetComponent<LineRenderer>();
        }
        this.laserLine.enabled = true;

        Vector3[] points = new Vector3[2]{ startPosition, endPosition };
        laserLine.SetPositions(points);
    }

    private void lightUp(Vector3 startPosition, Vector3 endPosition)
    {
        if (findLights())
        {
            sourceLight.transform.position = startPosition;
            sourceLight.GetComponent<Light>().enabled = true;
            hitLight.transform.position = endPosition;
            hitLight.GetComponent<Light>().enabled = true;
        }
    }

    private void lightOff()
    {
        if (findLights())
        {
            sourceLight.GetComponent<Light>().enabled = false;
            hitLight.GetComponent<Light>().enabled = false;
        }
    }

    private bool findLights()
    {
        if (sourceLight == null || hitLight == null)
        {
            if (this.laserLine)
            {
                foreach (Transform attachedObject in this.laserLine.gameObject.transform)
                {
                    if (attachedObject.gameObject.name == "sourceLight") // TODO: is there a better way?
                    {
                        sourceLight = attachedObject.gameObject;
                    }
                    else if (attachedObject.gameObject.name == "hitLight")
                    {
                        hitLight = attachedObject.gameObject;
                    }
                }
            }
        }
        return sourceLight != null && hitLight != null;
    }

    public override void stop()
    {
        if (this.laserLine)
        {
            this.laserLine.enabled = false;
        }
        lightOff();
    }

    public override void select()
    {

    }
}
