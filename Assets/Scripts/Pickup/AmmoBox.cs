using UnityEngine;

public class AmmoBox : MonoBehaviour
{

    [SerializeField] string PlayerTag;
    [SerializeField] int MaxRevBullet;
    [SerializeField] int MinRevBullet;
    [SerializeField] int MaxSmgBullet;
    [SerializeField] int MinSmgBullet;
    [SerializeField] PlayerBullets PlayerBullets;
    [SerializeField] AudioSource AudioClip;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(PlayerTag))
        {
            if(PlayerBullets == null)
            {
                PlayerBullets = other.GetComponent<PlayerBullets>();
            }
            AudioSource.PlayClipAtPoint(AudioClip.clip, transform.position);
           
            AddRandomNumberOfBullets(GetRandomBulletType());
            
            Destroy(gameObject);
        }
    }

    private string GetRandomBulletType()
    {
        return PlayerBullets.AmmoNames[Random.Range(0, PlayerBullets.AmmoNames.Count)];
    }
    private void AddRandomNumberOfBullets(string type)
    {
        switch (type)
        {
            case "RevAmmo":
                Debug.Log($"Added revolver bullets");
                PlayerBullets.AddBullets(type, Random.Range(MinRevBullet, MaxRevBullet + 1));
                break;
            case "SmgAmmo":
                Debug.Log($"Added smg bullets");
                PlayerBullets.AddBullets(type, Random.Range(MinSmgBullet, MaxSmgBullet + 1));
                break;
            default:
                Debug.Log(type);
                break;
        }
    }
    
}

