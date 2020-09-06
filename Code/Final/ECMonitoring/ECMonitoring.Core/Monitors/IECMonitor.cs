

namespace ECMonitoring.Core
{
    public delegate void DeviceStatusChangedHandler(object sender, object eventArgs);
    public interface IECMonitor
    {
        event DeviceStatusChangedHandler DeviceStatusChangedOn;
        void Start();
        void Stop();
    }
}
