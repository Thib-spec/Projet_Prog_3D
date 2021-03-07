using DefaultNamespace;
using UnityEngine;

public class BatteryController : MonoBehaviour
{
    private static float energy = 30;
    [SerializeField] private Stats battery;
    [SerializeField] private StatManager batterybar;




    public void BatteryCharge()
    {
        battery.Battery += energy;
        if (battery.Battery > 100)
        {
            battery.Battery = 100;
        }
        batterybar.SetBar(battery.Battery);
    }
}
