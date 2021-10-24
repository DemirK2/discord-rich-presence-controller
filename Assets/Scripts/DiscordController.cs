using Discord;
using UnityEngine;
using UnityEngine.UI;

public class DiscordController : MonoBehaviour
{
    public SceneController scene;
    public Discord.Discord discord;
    public bool connected;

    void Update()
    {
        if (connected)
        {
            discord.RunCallbacks();
        }
    }

    public void Connect()
    {
        discord = new Discord.Discord(long.Parse(scene.id.GetComponent<InputField>().text), (System.UInt64)CreateFlags.NoRequireDiscord);
        connected = true;
        Debug.Log("[Discord] Connected.");
    }

    public void UpdateActivity(Activity activity)
    {
        if (connected)
        {
            var activityManager = discord.GetActivityManager();
            activityManager.UpdateActivity(activity, (res) =>
            {
                if (res == Result.Ok)
                {
                    Debug.Log("[Discord] Updated.");
                }
                else
                {
                    Debug.LogWarning("[Discord] Couldn't update!");
                }
            });
        }
    }

    public void Disconnect()
    {
        if (connected)
        {
            discord.Dispose();
            connected = false;
        }
    }

    void OnApplicationQuit()
    {
        if (connected)
        {
            discord.Dispose();
            connected = false;
        }
    }
}
