using Windows.UI.Notifications;

namespace mattresses_management_dektop_app.Services
{
    internal interface IToastNotificationsService
    {
        void ShowToastNotification(ToastNotification toastNotification);

        void ShowToastNotificationSample();
    }
}
