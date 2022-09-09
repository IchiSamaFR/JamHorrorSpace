using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EndAction : WorldAction
{
    [SerializeField] GameObject vaisseau;
    [SerializeField] GameObject quest;
    [SerializeField] GameObject uiEnd;
    [SerializeField] GameObject effect;
    [SerializeField] AudioClip SFX;
    bool done = false;
    private Player p;
    public override void Interact(Player player)
    {
        if (SceneGameManager.Instance.IsEmergency)
        {
            p = player;
            player.PlayerController.StopMovement();
            player.PlayerController.HidePlayer();
            player.GetComponent<Rigidbody>().isKinematic = true;
            done = true;
            StartCoroutine("Escape");
            quest.SetActive(false);
        }
    }

    IEnumerator Escape() {
        effect.SetActive(true);
        SoundManager.Instance.InstantiateSound(SFX, transform.position).Play();
        yield return new WaitForSeconds(5);
        Cursor.visible = true;
        uiEnd.SetActive(true);
    }

    private void Update() {
        if (done) {
            vaisseau.transform.Translate(Vector3.forward * Time.deltaTime);
            p.transform.position = vaisseau.transform.position;
        }
        
    }

    public void BackToMenu() {
        SceneManager.LoadScene("MainMenu");
    }
   
}
