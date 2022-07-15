using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NotificationSamples;
using System;
public class NotifManager : MonoBehaviour
{
    
    private GameNotificationsManager gameNotifmanager;
    private static bool Reminder = false;

    private void Start()
    {
        // access notif manager
        gameNotifmanager = GetComponent<GameNotificationsManager>();
        // channel 
        GameNotificationChannel chan = new GameNotificationChannel("channel0","Default Channel","Generic Notifications");
        // initialising manager
        gameNotifmanager.Initialize(chan);

        // check if notif is added
        if(!Reminder)
        {
        // notification message
        ShowNotif("Arcadexium","Thanks for playing, Hope you like the game", DateTime.Now.AddMinutes(5));

            
            Reminder=true;
        }

    }

    // function to display notif
    public void ShowNotif(string title, string body, System.DateTime delivery)
    {
        IGameNotification gameNotification = gameNotifmanager.CreateNotification();

        if (gameNotification != null)
        {
            // notif title
            gameNotification.Title = title;
            gameNotification.LargeIcon = "_logo";
            // notif body text
            gameNotification.Body = body;
            // time to wait before notif
            gameNotification.DeliveryTime = delivery;
            // linking notif to manager
            gameNotifmanager.ScheduleNotification(gameNotification);
        }
    }   

}
