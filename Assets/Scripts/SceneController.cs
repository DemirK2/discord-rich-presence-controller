using UnityEngine;
using UnityEngine.UI;

public class SceneController : MonoBehaviour
{
    public DiscordController discord;

    public GameObject profile;
    public GameObject id;
    public GameObject details;
    public GameObject state;
    public GameObject largeImage;
    public GameObject largeText;
    public GameObject smallImage;
    public GameObject smallText;

    void Start()
    {
        profile.GetComponent<InputField>().text = "0";
        id.GetComponent<InputField>().text = PlayerPrefs.GetString("0-id", "");
        details.GetComponent<InputField>().text = PlayerPrefs.GetString("0-details", "");
        state.GetComponent<InputField>().text = PlayerPrefs.GetString("0-state", "");
        largeImage.GetComponent<InputField>().text = PlayerPrefs.GetString("0-largeImage", "");
        largeText.GetComponent<InputField>().text = PlayerPrefs.GetString("0-largeText", "");
        smallImage.GetComponent<InputField>().text = PlayerPrefs.GetString("0-smallImage", "");
        smallText.GetComponent<InputField>().text = PlayerPrefs.GetString("0-smallText", "");
    }

    void Update()
    {
        if (Input.GetKeyDown("return"))
        {
            UpdateActivity();
        }
        if (Input.GetKeyDown("space"))
        {
            UpdateID();
        }
        if (Input.GetKeyDown("escape"))
        {
            Disconnect();
        }
        if (Input.GetKeyDown("f8"))
        {
            OpenURL("https://youtu.be/dQw4w9WgXcQ");
        }
    }

    public void ChangeProfile()
    {
        if (profile.GetComponent<InputField>().text.Length > 0)
        {
            id.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-id", "");
            details.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-details", "");
            state.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-state", "");
            largeImage.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-largeImage", "");
            largeText.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-largeText", "");
            smallImage.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-smallImage", "");
            smallText.GetComponent<InputField>().text = PlayerPrefs.GetString($"{profile.GetComponent<InputField>().text}-smallText", "");
        }
    }

    public void UpdateID()
    {
        if (id.GetComponent<InputField>().text.Length > 0)
        {
            discord.Connect();
        }
    }

    public void UpdateActivity()
    {
        var activity = new Discord.Activity { };
        if (details.GetComponent<InputField>().text.Length > 0) activity.Details = details.GetComponent<InputField>().text;
        if (state.GetComponent<InputField>().text.Length > 0) activity.State = state.GetComponent<InputField>().text;
        if (largeImage.GetComponent<InputField>().text.Length > 0) activity.Assets.LargeImage = largeImage.GetComponent<InputField>().text;
        if (largeText.GetComponent<InputField>().text.Length > 0) activity.Assets.LargeText = largeText.GetComponent<InputField>().text;
        if (smallImage.GetComponent<InputField>().text.Length > 0) activity.Assets.SmallImage = smallImage.GetComponent<InputField>().text;
        if (smallText.GetComponent<InputField>().text.Length > 0) activity.Assets.SmallText = smallText.GetComponent<InputField>().text;
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-id", id.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-details", details.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-state", state.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-largeImage", largeImage.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-largeText", largeText.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-smallImage", smallImage.GetComponent<InputField>().text);
        PlayerPrefs.SetString($"{profile.GetComponent<InputField>().text}-smallText", smallText.GetComponent<InputField>().text);
        discord.UpdateActivity(activity);
    }

    public void Disconnect()
    {
        discord.Disconnect();
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }
}
