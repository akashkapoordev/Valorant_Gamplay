using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

[CreateAssetMenu(fileName = "Gun", menuName = "GunMechanics/Gun", order = 0)]
public class GunScriptableObject : ScriptableObject
{
    public GunType type;
    public string gunName;
    public GameObject modelPrefab;
    public Vector3 spwanPoint;
    public Vector3 spwanRotaion;


    public ShootConfigurationSo shootConfiguration;
    public TrailConfigurationSO trailConfiguration;

    private MonoBehaviour activeMonoBehaviour;
    private GameObject model;
    private float lastShotTime;
    private ParticleSystem shootSystem;
    private ObjectPool<TrailRenderer> trailPool;


    public void Spwan(Transform parent, MonoBehaviour activeMonoBehaviour)
    {
        this.activeMonoBehaviour = activeMonoBehaviour;
        lastShotTime = 0f;
        trailPool = new ObjectPool<TrailRenderer>(createTrail);
        model = Instantiate(modelPrefab);
        model.transform.SetParent(parent,false);
        model.transform.localPosition = spwanPoint;
        model.transform.localRotation = Quaternion.Euler(spwanRotaion);

        shootSystem = model.GetComponentInChildren<ParticleSystem>();
    }

    public void Shoot()
    {
        if(Time.time > shootConfiguration.fireRate + lastShotTime)
        {
            lastShotTime = Time.time;
            shootSystem.Play();
            Vector3 shootDirection = shootSystem.transform.forward 
                + new Vector3(
                    Random.Range(-shootConfiguration.spread.x, shootConfiguration.spread.x),
                    Random.Range(-shootConfiguration.spread.y, shootConfiguration.spread.y),
                    Random.Range(-shootConfiguration.spread.z, shootConfiguration.spread.z)
                );

            shootDirection.Normalize();

            //Debug.DrawRay(shootSystem.transform.position, shootDirection * 100f, Color.red, 2f);
            if (Physics.Raycast(
                shootSystem.transform.position,
                shootDirection,
                out RaycastHit hit,
                float.MaxValue,
                shootConfiguration.hitMask
                ))
            {
                activeMonoBehaviour.StartCoroutine(
                    PlayTrail(
                        shootSystem.transform.position,
                        hit.point,
                        hit
                        )
                );
            }
            else
            {
                activeMonoBehaviour.StartCoroutine(
                    PlayTrail(
                   shootSystem.transform.position,
                   shootSystem.transform.position + (shootDirection * trailConfiguration.missDistance),
                   new RaycastHit()
                    )
                );
            }
        }
    }

    private IEnumerator PlayTrail(Vector3 startPoint,Vector3 endPoint,RaycastHit hit)
    {
        TrailRenderer instance = trailPool.Get();
        instance.gameObject.SetActive(true);
        instance.transform.position = startPoint;
        yield return null; // Wait for the next frame to ensure the position is set before emitting

        instance.emitting = true;
        float distance = Vector3.Distance(startPoint, endPoint);
        float remainingDistance = distance;
        while(remainingDistance>0)
        {
            instance.transform.position = Vector3.Lerp(startPoint, endPoint, 1 - (remainingDistance / distance));
            remainingDistance -= trailConfiguration.simulationSpeed * Time.deltaTime;
            yield return null;
        }

        instance.transform.position = endPoint;

        //if(hit.collider != null)
        //{
        //    //Later we can add logic to handle hit effects, like spawning decals or playing sounds
        //}


        yield return new WaitForSeconds(trailConfiguration.duration);
        yield return null;
        instance.emitting = false;
        instance.gameObject.SetActive(false);
        trailPool.Release(instance);


    }

    private TrailRenderer createTrail()
    {
        GameObject instance = new GameObject("BulletTrail");
        TrailRenderer trail = instance.AddComponent<TrailRenderer>();
        trail.colorGradient = trailConfiguration.colorGradient;
        trail.material = trailConfiguration.material;
        trail.widthCurve = trailConfiguration.widthCurve;
        trail.time = trailConfiguration.duration;
        trail.minVertexDistance = trailConfiguration.minVertexDistance;

        trail.emitting = false;
        trail.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.Off;
        return trail;
    }
}
